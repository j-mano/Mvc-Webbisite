using DataLayer.Models;
using Joachim_Johnson_ConsidAplication.Controllers.DataAcess.DatabasConnections;
using System;
using System.Threading.Tasks;

namespace Joachim_Johnson_ConsidAplication.Servises.Functions.CompanyContext
{
    public class LoadSpecifikCompany : DatabaseConection, ILoacSpecifikCompany
    {
        public async Task<CompanyModel> LoadCompanyAsync(Guid id)
        {
            CompanyModel FindCompany = new CompanyModel();

            try
            {
                FindCompany = await _CompaniesContextDB.Companies.FindAsync(id);
            }
            catch
            {
                throw;
            }

            return FindCompany;
        }
    }
}
