using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using apinorthwind.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
    public class OrderController : Controller
    {
        string connectionstring =
       "Server=(localdb)\\mssqllocaldb;Database=NorthwindMock;Trusted_Connection=True;MultipleActiveResultSets=true";
        private readonly NorthwindDbContext _context;
        public OrderController(NorthwindDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        [LogApiDetails]
        public async Task<List<Order>> GetAllOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        // GET: OrderController/Details/5
        [HttpGet("id")]
        [LogApiDetails]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {

            var order = await _context.Orders.FindAsync(id);
            return order == null ? NotFound() : Ok(order);
        }
        [HttpPost]
        [LogApiDetails]
        [ProducesResponseType(typeof(int),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(int),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostOrder(Order order)
        {
            await _context.Orders.AddAsync(order);  
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = order.id }, order);
        }
        [HttpPut("id")]
        [LogApiDetails]
        [ProducesResponseType(typeof(int), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(int),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Order order,int id)
        {
            if (id != order.id)
            {
                return BadRequest();
            }
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete]
        [LogApiDetails]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            string sqlCommandText = "DELETE FROM Orders WHERE id =" + id;

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
