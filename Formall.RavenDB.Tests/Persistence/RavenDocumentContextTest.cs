using System;

namespace Formall.Persistence
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Formall.Navigation;
    using Dictionary = System.Collections.Generic.Dictionary<string, object>;

    [TestClass]
    public class RavenDocumentContextTest
    {
        [TestMethod]
        public void Test_RavenDocumentContext_Import_Seeds()
        {
            var schema = Schema.Current;
            var context = new RavenDocumentContext(schema, new
                {
                    //ApiKey = string.Empty,
                    /*ApiKeys = new []
                    {
                        new { }
                    },*/
                    Embeddable = true,
                    DataDirectory = "~/App_Data/Base",
                    Name = "Base",
                    /*Replication = new {
                        Id = "Raven/Replication/Destinations",
                        Destinations = new []
                        {
                            new
                            {
                                ApiKey = string.Empty,
                                ClientVisibleUrl = string.Empty,
                                Database = string.Empty,
                                Disabled = false,
                                Domain = string.Empty,
                                IgnoredClient = string.Empty,
                                Password = string.Empty,
                                TransitiveReplicationBehavior = "Replicate",
                                Url = string.Empty,
                                Username = string.Empty
                            }
                        },
                        Source = string.Empty
                    },*/
                    //Secret = string.Empty,
                    //Url = string.Empty
                });
            Schema.Current.Domain(Guid.Empty, "*", context, null);
        }
    }
}
