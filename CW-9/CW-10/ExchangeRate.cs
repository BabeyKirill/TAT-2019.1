namespace CW_10
{
    public class ExchangeRate
    {
        public string name;
        public string value;

        public ExchangeRate() { }

        public ExchangeRate(string name, string currencyValue)
        {
            this.name = name;
            this.value = currencyValue;
        }
    }
}
