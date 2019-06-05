using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace CW_10
{
    class XmlWriter : Writer
    {
        public override void WriteInFile(List<ExchangeRate> rates)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<ExchangeRate>));
            TextWriter tw = new StreamWriter(@"../../ExchangeRates.xml");
            xs.Serialize(tw, rates);
            tw.Close();
        }
    }
}
