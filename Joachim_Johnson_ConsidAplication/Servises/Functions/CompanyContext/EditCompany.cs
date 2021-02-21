using DataLayer.Models;
using Joachim_Johnson_ConsidAplication.Controllers.DataAcess.DatabasConnections;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Joachim_Johnson_ConsidAplication.Servises.Functions.CompanyContext
{
    internal class EditCompany : DatabaseConection
    {
        public static async Task<bool> editAsync(CompanyModel UserCreationData)
        {
            bool returnValuePassed = false;

            try
            {
                _CompaniesContextDB.Entry(UserCreationData).State = EntityState.Modified;
                await _CompaniesContextDB.SaveChangesAsync();

                returnValuePassed = true;
            }
            catch
            {
                returnValuePassed = false;
                throw;
            }

            return returnValuePassed;
        }
    }
}