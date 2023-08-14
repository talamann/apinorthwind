namespace apinorthwind.Models
{
    public class Employee
    {
        public Employee() { }

        public int? Id { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Title { get; set; }
        public string? TitleOfCourtesy { get; set; }
        public string? BirthDate { get; set; }
        public string? HireDate { get; set; }
        public string? Notes { get; set; }
        public string? ReportsTo { get; set; }
    }
}
