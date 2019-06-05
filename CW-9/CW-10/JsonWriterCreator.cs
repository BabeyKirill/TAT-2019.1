namespace CW_10
{
    class JsonWriterCreator : WriterCreator
    {
        public Writer Create()
        {
            return new JsonWriter();
        }
    }
}
