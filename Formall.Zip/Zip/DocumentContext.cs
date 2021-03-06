﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Formall.Zip
{
    public class DocumentContext : IDocumentContext
    {
        public static void Export(IDocumentContext documentStore, Stream outputStream, string password)
        {
            using (var zipArchive = new ZipArchive(outputStream, ZipArchiveMode.Create))
            {
                var documentArchive = new DocumentContext(documentStore, zipArchive, password);

                documentArchive.Export(CompressionLevel.NoCompression);
            }
        }

        public static void Export(IDocumentContext documentStore, Stream outputStream, CompressionLevel compressionLevel = CompressionLevel.Optimal)
        {
            using (var zipArchive = new ZipArchive(outputStream, ZipArchiveMode.Create))
            {
                var documentArchive = new DocumentContext(documentStore, zipArchive, null);

                documentArchive.Export(compressionLevel);
            }
        }

        public static void Import(IDocumentContext documentStore, Stream inputStream, string password = null)
        {
            using (var zipArchive = new ZipArchive(inputStream, ZipArchiveMode.Read))
            {
                var documentArchive = new DocumentContext(documentStore, zipArchive, password);

                documentArchive.Import();
            }
        }

        private readonly IDocumentContext _documentStore;
        private readonly ZipArchive _zipArchive;
        private readonly string _password;
        private DESCryptoServiceProvider _cryptoServiceProvider;

        private DocumentContext(IDocumentContext documentStore, ZipArchive zipArchive, string password)
        {
            _documentStore = documentStore;
            _zipArchive = zipArchive;
            _password = password;
        }

        private DESCryptoServiceProvider CryptoServiceProvider
        {
            get
            {
                return _cryptoServiceProvider ?? (_cryptoServiceProvider = new DESCryptoServiceProvider
                {
                    Key = Encoding.ASCII.GetBytes(_password),
                    IV = Encoding.ASCII.GetBytes(_password)
                });
            }
        }

        public IDocumentContext DocumentStore
        {
            get { return _documentStore; }
        }

        public ZipArchive ZipArchive
        {
            get { return _zipArchive; }
        }

        private void Copy(Stream inputStream, Stream outputStream, int bufferSize = 65536)
        {
            var buffer = new byte[bufferSize];
            for (int total = 0, count = bufferSize; count.Equals(bufferSize); total += count)
            {
                count = inputStream.Read(buffer, total, bufferSize);
                outputStream.Write(buffer, 0, count);
            }
        }

        private void Decrypt(Stream inputStream, Stream outputStream)
        {
            using (var cryptoStream = new CryptoStream(inputStream, CryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Read))
            {
                Copy(cryptoStream, outputStream);

                cryptoStream.Close();
            }
            outputStream.Close();
        }

        private void Encrypt(Stream inputStream, Stream outputStream)
        {
            using (var cryptoStream = new CryptoStream(outputStream, CryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write))
            {
                Copy(inputStream, cryptoStream);

                cryptoStream.Flush();
                cryptoStream.Close();
            }
            outputStream.Close();
        }

        private void Export(CompressionLevel compressionLevel = CompressionLevel.Optimal)
        {
            const int pageSize = 400;

            for (int total = 0, count = pageSize; count.Equals(pageSize); total += count)
            {
                var jsonDocuments = _documentStore.Read(total, pageSize);
                
                count = jsonDocuments.Length;

                for (var i = 0; i < count; i++)
                {
                    Export(jsonDocuments[i], compressionLevel);
                }
            }
        }

        private void Export(IDocument jsonDocument, CompressionLevel compressionLevel = CompressionLevel.Optimal)
        {
            var documentKey = jsonDocument.Metadata.Key;
            var entryName = documentKey + ".json";
            var jsonObject = jsonDocument.ToObject();
            var zipArchiveEntry = _zipArchive.CreateEntry(entryName, compressionLevel);
            var outputStream = zipArchiveEntry.Open();

            if (string.IsNullOrEmpty(_password))
            {
                Export(jsonDocument, jsonObject, outputStream);
            }
            else
            {
                using (var cryptoStream = new CryptoStream(outputStream, CryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    Export(jsonDocument, jsonObject, cryptoStream);

                    cryptoStream.Flush();
                    cryptoStream.Close();
                }
            }
        }

        private void Export(IDocument jsonDocument, IObject jsonObject, Stream outputStream)
        {
            jsonObject.WriteJsonTo(outputStream);
        }

        private void Import()
        {
            foreach (var zipArchiveEntry in _zipArchive.Entries)
            {
                Import(zipArchiveEntry);
            }
        }

        private void Import(ZipArchiveEntry zipArchiveEntry)
        {
            var inputStream = zipArchiveEntry.Open();

            if (string.IsNullOrEmpty(_password))
            {
                Import(zipArchiveEntry, inputStream);
            }
            else
            {
                using (var cryptoStream = new CryptoStream(inputStream, CryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    Import(zipArchiveEntry, cryptoStream);

                    cryptoStream.Close();
                }
            }
        }

        private void Import(ZipArchiveEntry zipArchiveEntry, Stream inputStream)
        {
            var entryName = zipArchiveEntry.FullName;
            var documentKey = entryName.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries)[0].Replace("\\", "/");

            var document = _documentStore.Load(inputStream);
            
            // TODO: Do wee need to fix the document key? No!
            //document.Metadata.Key = documentKey;

            var jsonResult = _documentStore.Import(inputStream);

            using (var streamReader = new StreamReader(inputStream))
            {
                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    var jsonObject = RavenJObject.Load(jsonReader);
                    var jsonMetadata = jsonObject.Value<RavenJObject>("@metadata");
                    
                    if (jsonMetadata != null)
                    {
                        jsonMetadata.Remove("@metadata");
                    }
                    else
                    {
                        jsonMetadata = new RavenJObject();

                        var entityName = string.Join("/", documentKey.Split('/').Reverse().Skip(1).Reverse());

                        jsonMetadata["Raven-Entity-Name"] = new RavenJValue(entityName);
                    }

                    var jsonResult = _documentStore.DatabaseCommands.Put(documentKey, null, jsonObject, jsonMetadata);

                    Debug.Assert(jsonResult.Key == documentKey);
                }
            }
        }

        public IDocument Import(IDocument document)
        {
            throw new NotImplementedException();
        }

        public IDocument[] Read(int startIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IDocument Load(System.Xml.XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public IDocument Load(TextReader reader)
        {
            throw new NotImplementedException();
        }

        public IDocument Load(StreamReader reader)
        {
            throw new NotImplementedException();
        }

        public IDocument Load(Stream stream)
        {
            throw new NotImplementedException();
        }

        public void Store(string key, IDocument document, object session = null)
        {
            throw new NotImplementedException();
        }

        public void Store(Metadata metadata, IObject content, object session = null)
        {
            throw new NotImplementedException();
        }
    }
}