namespace StoreModel
{

    /// <summary>
    /// Customer Class with Private Fields,Default Constructor
    /// </summary>
    /// Instead of throwing exceptions, a suggestion is made to fix.
    /// Input Validation on UI side should fix the issues instead of a THROW
    public class Customers
    {
    
        public int CustomerID { get; set; }
        private string _CFirstName;
        public string CFirstName
        {
            get { return _CFirstName; }

            set 
            {
                // if (value != "")
                // {
                    _CFirstName = value;
                // }
                // else
                // {
                //     throw new Exception("First Name must be entered and have a value.");
                // }         
            }
        }

        private string _CLastName;
        public string CLastName
        {
            get { return _CLastName; }

            set 
            {
                // if (string.IsNullOrEmpty(value))
                // {
                    _CLastName = value;
                // }
                // else
                // {
                //     throw new Exception("Last Name must be entered and have a value.");
                // }
            }
        }
        private string _DateofBirth;
        public string CDateofBirth
        {
            get { return _DateofBirth; }

            set 
            { 
                // if (value.Length == 8)
                // {
                    _DateofBirth = value; 
            
                // }
                // else
                // {
                //     throw new Exception("Date of Birth must be 8 Numeric Characters. MMDDYYYY");
                // } 
            }
        }
        private string _CustomerAddress;
        public string CustomerAddress
        {
            get { return _CustomerAddress; }

            set 
            {
                // if (string.IsNullOrEmpty(value))
                // {
                    _CustomerAddress = value;
                // }
                // else
                // {
                //     throw new Exception("Address must be entered.");
                // }
            }
        }
        private string _CustomerCity;
        public string CustomerCity
        {
            get { return _CustomerCity; }

            set 
            {
                // if (string.IsNullOrEmpty(value))
                // {
                    _CustomerCity = value;
                // }
                // else
                // {
                //     throw new Exception("City must be entered and have a value.");
                // }
            }
        }
   
        private string _CustomerState;
        public string CustomerState
        {
            get { return _CustomerState; }

            set 
            {
                // if (string.IsNullOrEmpty(value))
                // {
                    _CustomerState = value;
                // }
                // else
                // {
                //     throw new Exception("State must have a value");
                // }
            }
        }
        private string _CustomerZipcode;
        public string CustomerZipcode
        {
            get { return _CustomerZipcode; }

            set 
            {
                // if (string.IsNullOrEmpty(value) || value.Length != 5)
                // {
                    _CustomerZipcode = value;
                // }
                // else
                // {
                //     throw new Exception("ZipCode must have a value.");
                // }
            }
        }

        private string _CustCountry;
        public string CustCountry
        {
            get { return _CustCountry; }

            set 
            {
                // if (string.IsNullOrEmpty(value))
                // {
                    _CustCountry = value;
                // }
                // else
                // {
                //     throw new Exception("Country must be entered.");
                // }

            }
        }
        private string _CustomerEmail;

        public string CustomerEmail
        {
            get { return _CustomerEmail; }

            set 
            {
                // if (string.IsNullOrEmpty(value))
                // {
                    _CustomerEmail = value;
                // }
                // else
                // {
                //     throw new Exception("Email must have a input.");
                // }

            }
        }
        private string _Password;
        public string CPassword
        {
            get { return _Password; }

            set 
            {
                // if (string.IsNullOrEmpty(value))
                // {
                    _Password = value;
                // }
                // else
                // {
                //     throw new Exception("Password must have an input.");
                // }
 
            }
        }

        //Default Class Constructor
        public Customers()
        {
            CFirstName ="";
            CLastName = "";
            CDateofBirth = "";
            CustomerAddress = "";
            CustomerState = "";
            CustomerCity = "";
            CustomerZipcode = "";
            CustCountry = "";
            CustomerEmail = "";
            CPassword = "";
        }

        public override string ToString()
        {
            return $"Customer Id: {CustomerID}\nFirst Name: {CFirstName}\nLast name: {CLastName}\nDate of Birth {CDateofBirth}" +
            $"\nAddress: {CustomerAddress}\nCustomer State: {CustomerState}\nCustomer City: {CustomerCity}" +
            $"\nCustomer Country: {CustCountry}\nEmail: {CustomerEmail}";
        }
    }
}