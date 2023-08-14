namespace apinorthwind.Models
{
    public class Supplier
    {
        public Supplier() { }
        public int id { get; set; } 
        public string? companyname { get; set; }
        public string? contactTitle { get; set; }
        public string? address_Street { get; set; }
        public string? address_City { get; set;}
        public string? address_PostalCode { get; set;}          
        public string? address_Country { get; set;}
        public string? address_Phone { get; set;}
    }
}
