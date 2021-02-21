using System;
using System.Linq;
using System.Threading.Tasks;

namespace Joachim_Johnson_ConsidAplication.Controllers.DataAcess.StoreContext
{
    internal class DeleteStore : DatabasConnections.DatabaseConection
    {
        internal static async Task<bool> delete(Guid id)
        {
            bool ReturnBoolDeletePassed = false;

            try{
                _StoreContextDB.Stores.Remove(_StoreContextDB.Stores.Single(a => a.id == id));
                await _StoreContextDB.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return ReturnBoolDeletePassed;
        }
    }
}