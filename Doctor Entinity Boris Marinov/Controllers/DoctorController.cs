using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/doctors")]
[ApiController]
public class DoctorController : ControllerBase
{
    private static List<Doctor> doctors = new List<Doctor>();

    [HttpGet]
    public IActionResult GetDoctors()
    {
        return Ok(doctors);
    }

    [HttpGet("{id}")]
    public IActionResult GetDoctor(int id)
    {
        var doctor = doctors.Find(d => d.DoctorId == id);
        if (doctor == null)
            return NotFound();

        return Ok(doctor);
    }

    [HttpPost]
    public IActionResult AddDoctor([FromBody] Doctor newDoctor)
    {
        newDoctor.DoctorId = doctors.Count + 1;
        doctors.Add(newDoctor);
        return CreatedAtAction(nameof(GetDoctor), new { id = newDoctor.DoctorId }, newDoctor);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDoctor(int id, [FromBody] Doctor updatedDoctor)
    {
        var existingDoctor = doctors.Find(d => d.DoctorId == id);
        if (existingDoctor == null)
            return NotFound();

        existingDoctor.FirstName = updatedDoctor.FirstName;
        existingDoctor.LastName = updatedDoctor.LastName;
        existingDoctor.Specialization = updatedDoctor.Specialization;
        existingDoctor.Email = updatedDoctor.Email;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDoctor(int id)
    {
        var doctorToRemove = doctors.Find(d => d.DoctorId == id);
        if (doctorToRemove == null)
            return NotFound();

        doctors.Remove(doctorToRemove);
        return NoContent();
    }
}
