using DataLayer.Models;
using Joachim_Johnson_ConsidAplication.Controllers.DataAcess.DatabasConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Joachim_Johnson_ConsidAplication.Servises.Functions.CompanyContext
{
    public class Create : DatabaseConection, ICreate
    {
        public  async Task<bool> create(CompanyModel UserCreationData)
        {
            bool returnValuePassed = false;

            try
            {
                UserCreationData.Id = Guid.NewGuid();

                CompanyModel Companyidcheck = _CompaniesContextDB.Companies.Find(UserCreationData.Id);

                while (Companyidcheck != null)
                {
                    UserCreationData.Id = Guid.NewGuid();
                    Companyidcheck = await _CompaniesContextDB.Companies.FindAsync(UserCreationData.Id);
                }

                _CompaniesContextDB.Companies.Add(UserCreationData);
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

        async Task<bool> ICreate.create(CompanyModel UserCreationData)
        {
            bool returnValuePassed = false;

            try
            {
                UserCreationData.Id = Guid.NewGuid();

                CompanyModel Companyidcheck = _CompaniesContextDB.Companies.Find(UserCreationData.Id);

                while (Companyidcheck != null)
                {
                    UserCreationData.Id = Guid.NewGuid();
                    Companyidcheck = await _CompaniesContextDB.Companies.FindAsync(UserCreationData.Id);
                }

                _CompaniesContextDB.Companies.Add(UserCreationData);
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