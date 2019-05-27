namespace DEV_10
{
    class Warehouse
    {
        public delegate void WarehouseStateHandler();
        /// <summary>
        /// An event that occurs when any field of this class changes
        /// </summary>
        public event WarehouseStateHandler WarehouseChanged;

        private string _id;
        private string _name;
        private Address _address;

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
                else if (_id != value && WarehouseChanged != null)
                {
                    _id = value;
                    WarehouseChanged();
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
                else if (_name != value && WarehouseChanged != null)
                {
                    _name = value;
                    WarehouseChanged();
                }
            }
        }

        public Address address
        {
            get
            {
                return _address;
            }
            set
            {
                if (_address == null && value != null)
                {
                    _address = value;
                    _address.AddressChanged += ResponseOnAddressChanged;
                }
                else
                {
                    _address = value;
                }
            }
        }

        public void ResponseOnAddressChanged()
        {
            WarehouseChanged();
        }
    }
}
