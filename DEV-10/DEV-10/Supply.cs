namespace DEV_10
{   
    class Supply
    {
        public delegate void SupplyStateHandler();
        /// <summary>
        /// An event that occurs when any field of this class changes
        /// </summary>
        public event SupplyStateHandler SupplyChanged;

        private string _id;
        private string _description;
        private string _date;

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
                else if (_id != value && SupplyChanged != null)
                {
                    _id = value;
                    SupplyChanged();
                }
            }
        }

        public string description
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description == null && value != null)
                {
                    _description = value;
                }
                else if (_description != value && SupplyChanged != null)
                {
                    _description = value;
                    SupplyChanged();
                }
            }
        }

        public string date
        {
            get
            {
                return _date;
            }
            set
            {
                if (_date == null && value != null)
                {
                    _date = value;
                }
                else if (_date != value && SupplyChanged != null)
                {
                    _date = value;
                    SupplyChanged();
                }
            }
        }
    }
}
