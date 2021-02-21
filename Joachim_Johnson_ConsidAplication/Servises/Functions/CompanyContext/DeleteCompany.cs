using DataLayer.Models;
using Joachim_Johnson_ConsidAplication.Controllers.DataAcess.DatabasConnections;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Joachim_Johnson_ConsidAplication.Servises.Functions.CompanyContext
{
    public class DeleteCompany : DatabaseConection, IDeleteCompany
    {

        public async Task<bool> DeleteCompanydAsync(Guid id)
        {
            CompanyModel CompanyToDelete = new CompanyModel();

            Boolean returnDeleteSucess = false;

            // Remove Company and belonging stores.
            try
            {
                var SelectedCompanyBelongingStores = _StoreContextDB.Stores
                    .Where(b => b.CompanyId == id).ToList();

                foreach (var store in SelectedCompanyBelongingStores)
                {
                    _StoreContextDB.Stores.Remove(_StoreContextDB.Stores.Single(a => a.id == store.id));
                }

                await _StoreContextDB.SaveChangesAsync();

                _CompaniesContextDB.Companies.Remove(_CompaniesContextDB.Companies.Single(a => a.Id == id));
                await _CompaniesContextDB.SaveChangesAsync();

                returnDeleteSucess = true;
            }
            catch
            {
                throw;
            }

            return returnDeleteSucess;
        }
    }
}