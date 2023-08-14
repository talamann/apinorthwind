namespace apinorthwind.Models
{
    public class Customer
    {
        public Customer() { }
        public string id { get; set; }
        public string companyname { get; set; }
        public string contactName { get; set; }
        public string contacttitle { get; set; }
        public string address_Street { get; set; }
        public string address_City { get; set;}
        public string address_Region { get; set;}   
        public string address_Country { get; set;}
        public string address_Phone { get; set; }     
    }
}
