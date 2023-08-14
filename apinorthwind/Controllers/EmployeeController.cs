using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using apinorthwind.Data;
using Microsoft.EntityFrameworkCore;
using apinorthwind.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data.SqlClient;
using System.Web.Http.Cors;
using apinorthwind.Logging;

namespace apinorthwind.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(origins: "https://localhost:44386", headers: "*", methods: "*")]
    public class EmployeeController : Controller

    {
        string connectionstring =
        "Server=(localdb)\\mssqllocaldb;Database=NorthwindMock;Trusted_Connection=True;MultipleActiveResultSets=true";
        private readonly NorthwindDbContext _context;

        public EmployeeController(NorthwindDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        [LogApiDetails]
        public async Task<List<Employee>> Get()
        {
            return await _context.Employee.ToListAsync();
        }
        [HttpGet("id")]
        [LogApiDetails]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var emp = await _context.Employee.FindAsync(id);
            return emp == null ? NotFound() : Ok(emp);
        }
        [HttpPost]
        [LogApiDetails]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] Employee emp)
        {
            string sqlCommandText = "INSERT INTO Employee (id,lastName,firstName,title,titleOfCourtesy,birthDate,hireDate,reportsTo) VALUES" +
                " (@id, @lastName,@firstName,@title,@titleOfCourtesy,@birthDate,@hireDate,@reportsTo)";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlCommandText, connection))
                {
                    command.Parameters.AddWithValue("@id", emp.Id); // Assuming value1 is a string
                    command.Parameters.AddWithValue("@lastName", emp.LastName);
                    command.Parameters.AddWithValue("@firstName", emp.FirstName);
                    command.Parameters.AddWithValue("@title", emp.Title);
                    command.Parameters.AddWithValue("@titleOfCourtesy", emp.TitleOfCourtesy);
                    command.Parameters.AddWithValue("@birthDate", emp.BirthDate);
                    command.Parameters.AddWithValue("@hireDate", emp.HireDate);
                    command.Parameters.AddWithValue("@notes", emp.Notes);
                    command.Parameters.AddWithValue("@reportsTo", emp.ReportsTo);
                    // Execute the command
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return CreatedAtAction(nameof(GetById), new { id = emp.Id }, emp);
        }
        [HttpPut]
        [LogApiDetails]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Employee emp)
        {
            if (id != emp.Id)
            {
                return BadRequest();
            }
            _context.Entry(emp).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();

        }
        [HttpDelete("id")]
        [LogApiDetails]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteEmp(int id)
        {
            string sqlCommandText = "DELETE FROM Employee WHERE id =" + id;

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlCommandText, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return NoContent();


        }

    }
}

