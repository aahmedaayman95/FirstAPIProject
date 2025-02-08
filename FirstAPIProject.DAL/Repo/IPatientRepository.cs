using FirstAPIProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAPIProject.DAL.Repo
{
    public interface IPatientRepository : IRepository<Patient> 
    {

        Task<IEnumerable<Patient>> GetPatientsSortedByNameAsync();
        Task<IEnumerable<Patient>> GetPatientsSortedByAgeAsync();

        Task<IEnumerable<Patient>> GetPatientsSortedByMaleGenderAsync();

        Task<IEnumerable<Patient>> GetPatientsSortedByFemaleGenderAsync();
    }
}
