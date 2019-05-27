namespace DEV_10
{
    class Product
    {
        public delegate void ProductStateHandler();
        /// <summary>
        /// An event that occurs when any field of this class changes
        /// </summary>
        public event ProductStateHandler ProductChanged;

        private string _name;
        private string _id;
        private string _amount;
        private string _manufacturerId;
        private string _warehouseId;
        private string _supplyId;
        private string _productionDate;

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
                else if (_name != value && ProductChanged != null)
                {
                    _name = value;
                    ProductChanged();                    
                }
            }
        }

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
                else if (_id != value && ProductChanged != null)
                {
                    _id = value;
                    ProductChanged();
                }
            }
        }

        public string amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (_amount == null && value != null)
                {
                    _amount = value;
                }
                else if (_amount != value && ProductChanged != null)
                {
                    _amount = value;
                    ProductChanged();
                }
            }
        }

        public string manufacturerId
        {
            get
            {
                return _manufacturerId;
            }
            set
            {
                if (_manufacturerId == null && value != null)
                {
                    _manufacturerId = value;
                }
                else if (_manufacturerId != value && ProductChanged != null)
                {
                    _manufacturerId = value;
                    ProductChanged();
                }
            }
        }

        public string warehouseId
        {
            get
            {
                return _warehouseId;
            }
            set
            {
                if (_warehouseId == null && value != null)
                {
                    _warehouseId = value;
                }
                else if (_warehouseId != value && ProductChanged != null)
                {
                    _warehouseId = value;
                    ProductChanged();
                }
            }
        }

        public string supplyId
        {
            get
            {
                return _supplyId;
            }
            set
            {
                if (_supplyId == null && value != null)
                {
                    _supplyId = value;
                }
                else if (_supplyId != value && ProductChanged != null)
                {
                    _supplyId = value;
                    ProductChanged();
                }
            }
        }

        public string productionDate
        {
            get
            {
                return _productionDate;
            }
            set
            {
                if (_productionDate == null && value != null)
                {
                    _productionDate = value;
                }
                else if (_productionDate != value && ProductChanged != null)
                {
                    _productionDate = value;
                    ProductChanged();
                }
            }
        }
    }
}
