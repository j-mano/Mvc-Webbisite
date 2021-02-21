using DataLayer.DataAcess;
using DataLayer.Models;
using Joachim_Johnson_ConsidAplication.Servises.Functions.StoreContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Joachim_Johnson_ConsidAplication.Controllers.DataAcess.StoreContext
{
    public class LoadStores : DatabasConnections.DatabaseConection, IloadStores
    {
        public List<StoreModel> loadALLStores()
        {
            List<StoreModel> loadedStores = new List<StoreModel>();

            Task AsynGetStoreTask = Task.Run(() =>
            {
                try
                {
                    loadedStores = (from Companies in _StoreContextDB.Stores select Companies).ToList();
                }
                catch
                {
                    throw;
                }
            });

            AsynGetStoreTask.Wait();

            return loadedStores;
        }
    }
}
