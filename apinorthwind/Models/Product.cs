namespace apinorthwind.Models
{
    public class Product
    {

        public int? id { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public string?QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public int? UnitsOnOrder { get; set; }
        public int? ReorderLevel { get; set; }
        public int? Discontinued { get; set; }
        public string? Name { get; set; }
        public int? Supplier_Id { get; set; }
        public string? Supplier_CompanyName { get; set; }
        public string? Supplier_ContactName { get; set; }
        public string? Supplier_ContactTitle { get; set; }
        public string? Supplier_Address_Street { get; set; }
        public string? Supplier_Address_City { get; set; }
        public string? Supplier_Address_Region { get; set; }
        public int? Supplier_Address_PostalCode { get; set; }
        public string? Supplier_Address_Country { get; set; }
        public string? Supplier_Address_Phone { get; set; }
        public int?  Category_Id { get; set; }
        public string? Category_Description { get; set; }
        public string? Category_Name { get; set; }


    }
}
