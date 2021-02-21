using DataLayer.Models;
using Joachim_Johnson_ConsidAplication.Controllers.DataAcess.DatabasConnections;
using Joachim_Johnson_ConsidAplication.Servises.Functions.StoreContext.Interfaces;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Joachim_Johnson_ConsidAplication.Servises.Functions.StoreContext
{
    internal class EditStore : DatabaseConection, IEditStore
    {
        public async Task<bool> EditStor(StoreModel UserCreationData)
        {
            bool passBoolReturn = false;

            try
            {
                _StoreContextDB.Entry(UserCreationData).State = EntityState.Modified;
                
                await _StoreContextDB.SaveChangesAsync();

                passBoolReturn = true;
            }
            catch
            {
                passBoolReturn = false;
                throw;
            }

            return passBoolReturn;
        }
    }
}