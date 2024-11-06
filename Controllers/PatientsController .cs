using HospitaManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitaManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly HospitalmgtContext _context;

        public PatientsController(HospitalmgtContext context)
        {
            _context = context;
        }

        // GET: api/patients
        // Retrieves a list of all patients
        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            try
            {
                var patients = await _context.Patients.ToListAsync();
                return Ok(patients);
            }
            catch (Exception ex)
            {
                // Log the exception (if a logger is available)
                return StatusCode(500, "An error occurred while retrieving patients.");
            }
        }

        // POST: api/patients
        // Adds a new patient to the database
        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] Patient patient)
        {
            try
            {
                _context.Patients.Add(patient);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetPatient), new { id = patient.PatientId }, patient);
            }
            catch (Exception ex)
            {
                // Log the exception (if a logger is available)
                return StatusCode(500, "An error occurred while adding the patient.");
            }
        }

        // GET: api/patients/{id}
        // Retrieves a patient by their ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            try
            {
                var patient = await _context.Patients.FindAsync(id);
                if (patient == null)
                {
                    return NotFound("Patient not found.");
                }
                return Ok(patient);
            }
            catch (Exception ex)
            {
                // Log the exception (if a logger is available)
                return StatusCode(500, "An error occurred while retrieving the patient.");
            }
        }

        // PUT: api/patients/{id}
        // Updates an existing patient's information
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] Patient patient)
        {
            if (id != patient.PatientId)
            {
                return BadRequest("Patient ID mismatch.");
            }

            try
            {
                _context.Entry(patient).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Patients.Any(p => p.PatientId == id))
                {
                    return NotFound("Patient not found.");
                }
                return StatusCode(500, "A concurrency error occurred while updating the patient.");
            }
            catch (Exception ex)
            {
                // Log the exception (if a logger is available)
                return StatusCode(500, "An error occurred while updating the patient.");
            }
        }

        // DELETE: api/patients/{id}
        // Deletes a patient by their ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            try
            {
                var patient = await _context.Patients.FindAsync(id);
                if (patient == null)
                {
                    return NotFound("Patient not found.");
                }

                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception (if a logger is available)
                return StatusCode(500, "An error occurred while deleting the patient.");
            }



        }

    }
}