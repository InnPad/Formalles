﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Dynamo
{
    using Amazon.DynamoDBv2;
    using Amazon.DynamoDBv2.DataModel;
    using Amazon.DynamoDBv2.DocumentModel;
    using Amazon.DynamoDBv2.Model;
    using AmazonDocument = Amazon.DynamoDBv2.DocumentModel.Document;

    class DocumentContext
    {
        private DynamoDBContext _context;
        private IAmazonDynamoDB _client;

        public DocumentContext(AmazonDynamoDBConfig config)
        {
            _client = new AmazonDynamoDBClient(config);
            _context = new DynamoDBContext(_client);
            var response = _client.GetItem(
                new GetItemRequest
                {
                    Key = new Dictionary<string, AttributeValue>
                    {
                        { "Id", new AttributeValue { S = Guid.Empty.ToString() } }
                    }
                });

            var metadata = response.ResponseMetadata;
            var document = Document.FromAttributeMap(response.Item);
        }
    }
}
