using HospitaManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitaManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillingController : ControllerBase
    {
        private readonly HospitalmgtContext _context;

        public BillingController(HospitalmgtContext context)
        {
            _context = context;
        }

        // GET: api/billing
        // Retrieves a list of all billing records
        [HttpGet]
        public async Task<IActionResult> GetBillingRecords()
        {
            try
            {
                var billingRecords = await _context.Billings.ToListAsync();
                return Ok(billingRecords);
            }
            catch (Exception ex)
            {
                // Log the exception if a logger is available
                return StatusCode(500, "An error occurred while retrieving billing records.");
            }
        }

        // POST: api/billing
        // Adds a new billing record to the database
        [HttpPost]
        public async Task<IActionResult> AddBillingRecord([FromBody] Billing billing)
        {
            try
            {
                _context.Billings.Add(billing);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetBillingRecord), new { id = billing.BillingId }, billing);
            }
            catch (Exception ex)
            {
                // Log the exception if a logger is available
                return StatusCode(500, "An error occurred while adding the billing record.");
            }
        }

        // GET: api/billing/{id}
        // Retrieves a specific billing record by its ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBillingRecord(int id)
        {
            try
            {
                var billing = await _context.Billings.FindAsync(id);
                if (billing == null)
                {
                    return NotFound("Billing record not found.");
                }
                return Ok(billing);
            }
            catch (Exception ex)
            {
                // Log the exception if a logger is available
                return StatusCode(500, "An error occurred while retrieving the billing record.");
            }
        }

        // PUT: api/billing/{id}
        // Updates an existing billing record
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBillingRecord(int id, [FromBody] Billing billing)
        {
            if (id != billing.BillingId)
            {
                return BadRequest("Billing ID mismatch.");
            }

            try
            {
                _context.Entry(billing).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent(); // Successfully updated, no content to return
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Billings.Any(b => b.BillingId == id))
                {
                    return NotFound("Billing record not found.");
                }
                return StatusCode(500, "A concurrency error occurred while updating the billing record.");
            }
            catch (Exception ex)
            {
                // Log the exception if a logger is available
                return StatusCode(500, "An error occurred while updating the billing record.");
            }
        }

        // DELETE: api/billing/{id}
        // Deletes a specific billing record by its ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBillingRecord(int id)
        {
            try
            {
                var billing = await _context.Billings.FindAsync(id);
                if (billing == null)
                {
                    return NotFound("Billing record not found.");
                }

                _context.Billings.Remove(billing);
                await _context.SaveChangesAsync();

                return NoContent(); // Successfully deleted, no content to return
            }
            catch (Exception ex)
            {
                // Log the exception if a logger is available
                return StatusCode(500, "An error occurred while deleting the billing record.");
            }
        }
    }

}
