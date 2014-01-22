using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using Relay.Core;
using AHM.Core;

namespace AHMI.Relay
{
    public class AhmiRelay : IAbstractRelay
    {
        #region Properties

        public ValidationResults ValidationResults { get; set; }
        public Tier RelayTier { get; set; }

        #endregion Properties

        public AhmiRelay()
        {
            var ValidationResults = new ValidationResults();
        }

        public void GetData()
        {
            RelayTier = getTier();
        }

        private Tier getTier()
        {
            var xml = queryServer();
            var tier = parseXml(xml);

            return tier;
        }

        private string queryServer()
        {
            using (WebClient client = new WebClient())
            {
                client.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) " +
                "(compatible; MSIE 6.0; Windows NT 5.1; " +
                ".NET CLR 1.1.4322; .NET CLR 2.0.50727)";

                // Download data.
                byte[] arr = client.DownloadData("http://localhost:8080/test/");

                // Write values.
                return System.Text.Encoding.Default.GetString(arr);
            }
        }

        private Tier parseXml(string xml)
        {
            XDocument doc = XDocument.Parse(xml);
            var tier = new Tier
                {
                    TypeName = doc.Root.Name.LocalName,
                    FieldList = new List<Field>(),
                };

            var query = from c in doc.Descendants("sensor") select c;

            foreach (var e in query)
            {
                var field = new Field
                {
                    Name = e.Attribute("name").Value,
                    Value = float.Parse(e.Attribute("value").Value),
                };
                tier.FieldList.Add(field);
            }

            return tier;
        }
    }
}
