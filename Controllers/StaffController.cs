using HospitaManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HospitaManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly HospitalmgtContext _context;
        private readonly ILogger<StaffController> _logger;

        public StaffController(HospitalmgtContext context, ILogger<StaffController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Staff
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
        {
            return await _context.Staff.ToListAsync();
        }

        // GET: api/Staff/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaff(int id)
        {
            var staff = await _context.Staff.FindAsync(id);

            if (staff == null)
            {
                _logger.LogWarning("Staff with ID {Id} not found.", id);
                return NotFound();
            }

            return staff;
        }

        // POST: api/Staff
        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Staff.Add(staff);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStaff), new { id = staff.StaffId }, staff);
        }

        // PUT: api/Staff/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(int id, Staff staff)
        {
            if (id != staff.StaffId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(staff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Staff/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StaffExists(int id)
        {
            return _context.Staff.Any(e => e.StaffId == id);
        }
    }
}
