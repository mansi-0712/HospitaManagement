using HospitaManagement.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitaManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly HospitalmgtContext _context;

        public StaffController(HospitalmgtContext context)
        {
            _context = context;
        }

        // GET: api/Staff
        [HttpGet]
        public ActionResult<IEnumerable<Staff>> GetStaff()
        {
            return _context.Staff.ToList();
        }

        // GET: api/Staff/5
        [HttpGet("{id}")]
        public ActionResult<Staff> GetStaff(int id)
        {
            var staff = _context.Staff.Find(id);

            if (staff == null)
            {
                return NotFound();
            }

            return staff;
        }

        // POST: api/Staff
        [HttpPost]
        public ActionResult<Staff> PostStaff(Staff staff)
        {
            _context.Staff.Add(staff);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetStaff), new { id = staff.StaffId }, staff);
        }

        // PUT: api/Staff/5
        [HttpPut("{id}")]
        public IActionResult PutStaff(int id, Staff staff)
        {
            if (id != staff.StaffId)
            {
                return BadRequest();
            }

            _context.Entry(staff).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Staff/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int id)
        {
            var staff = _context.Staff.Find(id);
            if (staff == null)
            {
                return NotFound();
            }

            _context.Staff.Remove(staff);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
