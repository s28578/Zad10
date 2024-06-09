using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebApplication1.DTO;
using WebApplication1.Entities;

namespace WebApplication1.Controllers;


[Route("api/[controller]")]
[ApiController]
public class HospitalController: ControllerBase
{
    private readonly HospitalDbContext _dbContext;

    public HospitalController(HospitalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetPatients()
    {
        IList<Patient> patients = await _dbContext.Patients.ToListAsync();
        return Ok(patients);
    }
    [HttpPost]
    //public async Task<IActionResult> GetPatients(Patient patient, Prescription prescription, Doctor doctor)
    public async Task<IActionResult> PostPrescription(PrescriptionDTO presc)
    {
        //PrescriptionDTO med
        
         // Patient patientCheck = null;
         // patientCheck = await _dbContext.Patients
         //     .Where(pat=>pat.IdPatient == presc.PatientDto.IdPatient)
         //     .SingleAsync();
         
         
         
        //  if (!await _dbContext.Patients.Where(pat=>pat.IdPatient == presc.PatientDto.IdPatient).AnyAsync())
        //  {
        //      Patient patientAdded = new Patient
        //      {
        //          Birthdate = presc.PatientDto.Birthdate,
        //          FirstName = presc.PatientDto.FirstName,
        //          // IdPatient = presc.PatientDto.IdPatient,
        //          LastName = presc.PatientDto.LastName,
        //          Prescriptions = []
        //      };
        //     await _dbContext.Patients.AddAsync(patientAdded);
        // }
         
         foreach(MedicamentDTO med in presc.MedicamentDtos)
         {
             if (!await _dbContext.Meds.Where(medicament => medicament.IdMedicament == med.IdMedicament).AnyAsync())
             {
                 return NotFound("Brak leku o Id = " + med.IdMedicament + " w bazie.");
             }
         }
        
        if (presc.DueDate < presc.Date)
        {
            return BadRequest("Wrong dates!");
        }

        if (presc.MedicamentDtos.Count > 10)
        {
            return BadRequest("Za dużo leków!");
        }

        await _dbContext.Prescription.AddAsync(new Prescription
        {
            Date=presc.Date,
            DueDate = presc.DueDate,
            IdPatient = presc.PatientDto.IdPatient,
            IdDoctor = 1
        });
        
        //
        // _dbContext.SaveChangesAsync();
        //IList<Patient> patients = await _dbContext.Patients.ToListAsync();
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpDelete("del/{idMedicament:int}")]
    public async Task<IActionResult> DeleteMedicament(int idMedicament)
    {
        var medToRemove = new Medicament
        {
            IdMedicament = idMedicament
        };
        _dbContext.Attach(medToRemove);

        _dbContext.Remove(medToRemove);
        await _dbContext.SaveChangesAsync();

        return Ok();
    }
}

//INSERT INTO Patient (FirstName,LastName,Birthdate)
//VALUES ('Mark','Twain','1984-06-01 00:00:00.000'); 

//return StatusCode(StatusCodes.Status201Created);
// return StatusCode((int)HttpStatusCode.OK, "data");
// return Created("uri", "data");
// return ValidationProblem("message");
// return Forbid("message");
// return Challenge();
// return Accepted("data or message");
// return Unauthorized("message");
// return NotFound("Message");
// return BadRequest("Error description");
//return Ok(ret);
