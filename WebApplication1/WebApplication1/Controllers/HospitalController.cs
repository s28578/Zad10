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

    [HttpPost]
    //public async Task<IActionResult> GetPatients(Patient patient, Prescription prescription, Doctor doctor)
    public async Task<IActionResult> GetPatients(PrescriptionDTO med)
    {
        // Patient patientCheck = null;
        // patientCheck = await _dbContext.Patients
        //     .Where(pat=>pat.IdPatient == patient.IdPatient)
        //     .SingleAsync();
        // if (patientCheck == null)
        // {
        //     _dbContext.Patients.AddAsync(patient);
        // }
        //
        // if (prescription.DueDate < prescription.Date)
        // {
        //     throw new Exception();
        // }
        //
        // _dbContext.SaveChangesAsync();
        return Ok();
    }
}