using DataLayer.Models;
using Joachim_Johnson_ConsidAplication.Controllers.DataAcess.DatabasConnections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Joachim_Johnson_ConsidAplication.Servises.Functions.CompanyContext
{
    public class LoadCompanies : DatabaseConection, ILoadCompanies
    {
        // Returning an list of all companies in the database. Meant to be used by all controllers
        public List<CompanyModel> LoadMultiCompanies()
        {
            List<CompanyModel> DisplayListCompanies = new List<CompanyModel>();

            Task AsynGetCompaniesTask = Task.Run(() =>
            {
                try
                {
                    DisplayListCompanies = (from Companies in _CompaniesContextDB.Companies select Companies).ToList();
                }
                catch
                {
                    throw;
                }
            });
            AsynGetCompaniesTask.Wait();

            return DisplayListCompanies;
        }
    }
}
