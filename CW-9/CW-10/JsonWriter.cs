using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CW_10
{
    class JsonWriter : Writer
    {
        public override void WriteInFile(List<ExchangeRate> rates)
        {
            using (StreamWriter file = File.CreateText(@"../../ExchangeRates.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, rates);
            }
        }
    }
}
