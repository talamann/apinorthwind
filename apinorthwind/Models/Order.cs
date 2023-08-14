namespace apinorthwind.Models
{
    public class Order
    {
        public Order() { }
        public int? id { get; set; }
        public string? customerId { get; set; }
        public int? employeeId { get; set; }
        public string? orderDate { get; set; }
        public string? requiredDate { get; set; }
        public string? shippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string? ShipName { get; set; }
        public string? shipAddress_Street { get; set ; }
        public string? shipAddress_City { get; set; }
        public string? shipAddress_Region { get; set; }
        public string? shipAddress_Postalcode { get; set; }
        public string? shipAddress_Country { get; set; }  
        public string? details { get; set; }    
    }
}
