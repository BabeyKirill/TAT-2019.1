namespace CW_10
{
    class WriterFactory
    {
        public Writer GetWriter(string str)
        {
            if (str.Contains(".json"))
            {
                JsonWriterCreator creator = new JsonWriterCreator();
                return creator.Create();
            }
            else if (str.Contains(".xml"))
            {
                XmlWriterCreator creator = new XmlWriterCreator();
                return creator.Create();
            }
            else
            {
                return null;
            }
        }
    }
}
