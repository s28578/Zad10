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
         Patient patientAdded = null;
         if (!await _dbContext.Patients.Where(pat=>pat.IdPatient == presc.PatientDto.IdPatient).AnyAsync())
         {
             patientAdded = new Patient
             {
                 Birthdate = presc.PatientDto.Birthdate,
                 FirstName = presc.PatientDto.FirstName,
                 // IdPatient = presc.PatientDto.IdPatient,
                 LastName = presc.PatientDto.LastName,
                 Prescriptions = []
             };
            await _dbContext.Patients.AddAsync(patientAdded);
        }
        //
        // if (prescription.DueDate < prescription.Date)
        // {
        //     throw new Exception();
        // }
        //
        // _dbContext.SaveChangesAsync();
        //IList<Patient> patients = await _dbContext.Patients.ToListAsync();
        await _dbContext.SaveChangesAsync();
        return Ok(patientAdded);
    }
}

//INSERT INTO Patient (FirstName,LastName,Birthdate)
//VALUES ('Mark','Twain','1984-06-01 00:00:00.000'); 