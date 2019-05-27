namespace DEV_10
{
    class Address
    {
        public delegate void AddressStateHandler();
        /// <summary>
        /// An event that occurs when any field of this class changes
        /// </summary>
        public event AddressStateHandler AddressChanged;

        private string _id;
        private string _cityName;
        private string _streetName;
        private string _houseNumber;
        private string _countryName;

        public string id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id == null && value != null)
                {
                    _id = value;
                }
                else if (_id != value && AddressChanged != null)
                {
                    _id = value;
                    AddressChanged();
                }
            }
        }

        public string cityName
        {
            get
            {
                return _cityName;
            }
            set
            {
                if (_cityName == null && value != null)
                {
                    _cityName = value;
                }
                else if (_cityName != value && AddressChanged != null)
                {
                    _cityName = value;
                    AddressChanged();
                }
            }
        }

        public string streetName
        {
            get
            {
                return _streetName;
            }
            set
            {
                if (_streetName == null && value != null)
                {
                    _streetName = value;
                }
                else if (_streetName != value && AddressChanged != null)
                {
                    _streetName = value;
                    AddressChanged();
                }
            }
        }

        public string houseNumber
        {
            get
            {
                return _houseNumber;
            }
            set
            {
                if (_houseNumber == null && value != null)
                {
                    _houseNumber = value;
                }
                else if (_houseNumber != value && AddressChanged != null)
                {
                    _houseNumber = value;
                    AddressChanged();
                }
            }
        }

        public string countryName
        {
            get
            {
                return _countryName;
            }
            set
            {
                if (_countryName == null && value != null)
                {
                    _countryName = value;
                }
                else if (_countryName != value && AddressChanged != null)
                {
                    _countryName = value;
                    AddressChanged();
                }
            }
        }
    }
}
