namespace CW_10
{
    class XmlWriterCreator : WriterCreator
    {
        public Writer Create()
        {
            return new XmlWriter();
        }
    }
}
