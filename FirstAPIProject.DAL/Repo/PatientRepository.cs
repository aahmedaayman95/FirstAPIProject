using FirstAPIProject.DAL.Context;
using FirstAPIProject.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAPIProject.DAL.Repo
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(ClinicDBContext context) : base(context) { }

        public bool PatientExists(int? id)
        {
            return _context.Patients.Any(e => e.Id == id);
        }

        public async Task<IEnumerable<Patient>> GetPatientsSortedByNameAsync()
        {
            return await _context.Patients.OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<IEnumerable<Patient>> GetPatientsSortedByAgeAsync()
        {
            return await _context.Patients.OrderBy(p => p.Age).ToListAsync();
        }

        public async Task<IEnumerable<Patient>> GetPatientsSortedByMaleGenderAsync()
        {
            return await _context.Patients.Where(p => p.Gender == (int)Gender.Male).ToListAsync();
        }

        public async Task<IEnumerable<Patient>> GetPatientsSortedByFemaleGenderAsync()
        {
            return await _context.Patients.Where(p => p.Gender == (int)Gender.Female).ToListAsync();
        }
    }
}
