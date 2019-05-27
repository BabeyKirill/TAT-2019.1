namespace DEV_10
{
    class Manufacturer
    {
        public delegate void ManufacturerStateHandler();
        /// <summary>
        /// An event that occurs when any field of this class changes
        /// </summary>
        public event ManufacturerStateHandler ManufacturerChanged;

        private string _id { get; set; }
        private string _name { get; set; }
        private string _adressId { get; set; }
        private string _countryName { get; set; }

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
                else if (_id != value && ManufacturerChanged != null)
                {
                    _id = value;
                    ManufacturerChanged();
                }
            }
        }

        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name == null && value != null)
                {
                    _name = value;
                }
                else if (_name != value && ManufacturerChanged != null)
                {
                    _name = value;
                    ManufacturerChanged();
                }
            }
        }

        public string adressId
        {
            get
            {
                return _adressId;
            }
            set
            {
                if (_adressId == null && value != null)
                {
                    _adressId = value;
                }
                else if (_adressId != value && ManufacturerChanged != null)
                {
                    _adressId = value;
                    ManufacturerChanged();
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
                else if (_countryName != value && ManufacturerChanged != null)
                {
                    _countryName = value;
                    ManufacturerChanged();
                }
            }
        }
    }
}
