using FirstAPIProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstAPIProject.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection;

namespace FirstAPIProject.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private ClinicDBContext db;
        public PatientsController(ClinicDBContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public async Task<IEnumerable<Patient>> GetAll()
        {
            return await db.Patients.ToListAsync();

            //IEnumerable<Patient> patients;

            //if (sortOrder == "name")
            //{
            //    patients = await _patientRepository.GetPatientsSortedByNameAsync();
            //}

            //else if (sortOrder == "age")
            //{
            //    patients = await _patientRepository.GetPatientsSortedByAgeAsync();
            //}

            //else if (sortOrder == "male")
            //{
            //    patients = await _patientRepository.GetPatientsSortedByMaleGenderAsync();
            //}

            //else if (sortOrder == "female")
            //{
            //    patients = await _patientRepository.GetPatientsSortedByFemaleGenderAsync();
            //}
            //else
            //{
            //    patients = await _patientRepository.GetAllAsync(); // Default order
            //}

            //patients = db.Patients.ToListAsync();

            //return View(patients);
        }


        [HttpGet("/Api/Patients/SortByName")]
        public async Task<IEnumerable<Patient>> GetPatientsSortedByNameAsync (string name)
        {
            return await db.Patients.OrderBy(p => p.Name).ToListAsync();
        }

        [HttpGet("/Api/Patients/SortByAge")]
        public async Task<IEnumerable<Patient>> GetPatientsSortedByAgeAsync(string name)
        {
            return await db.Patients.OrderBy(p => p.Age).ToListAsync();
        }

        [HttpGet("/Api/Patients/ShowMales")]

        public async Task<IEnumerable<Patient>> GetMalePatient(string name)
        {
            return await db.Patients.Where(p => p.Gender == (int)Gender.Male).ToListAsync();
        }


        [HttpGet("/Api/Patients/ShowFemales")]

        public async Task<IEnumerable<Patient>> GetFemalePatient(string name)
        {
            return await db.Patients.Where(p => p.Gender == (int)Gender.Female).ToListAsync();
        }




        [HttpGet("{id}")]
        //[HttpGet("{id:int}")]
        public async Task <IActionResult> GetById(int? id)
        {
            var patient = await db.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }


        

   

        [HttpPost]
        public ActionResult<Patient> Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                //Patient p = new Patient();
                //p.Name = patient.Name;
                //p.Gender = patient.Gender;
                //p.ContactInfo = patient.ContactInfo;
                //p.Age = patient.Age;
                //p.Appointments = null;

                try
                {
                    db.Patients.Add(patient);
                    db.SaveChanges();
                    return Created("url", patient);
                }

                catch (Exception ex)
                {
                    {
                        return BadRequest(ex.Message);
                    }
                }

            }
            return BadRequest();

        }


        [HttpPut]
        public ActionResult<Patient> Edit(Patient patient)
            
           {



            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(patient).State = EntityState.Modified;
                    db.SaveChanges();
                    return Ok(patient);

                }

                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }


            }


            return BadRequest();


        }

        [HttpDelete("{id}")]
        public ActionResult<Patient> Delete (int id)
        {
            var patient = db.Patients.FirstOrDefault(p => p.Id == id);

            if(patient == null)
            {
                return NotFound();
            }

            db.Patients.Remove(patient);
            db.SaveChanges();
            return Ok(patient);
        }







    }
}
