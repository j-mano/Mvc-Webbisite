using DataLayer.Models;
using Joachim_Johnson_ConsidAplication.Servises.Functions.StoreContext.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Joachim_Johnson_ConsidAplication.Controllers.DataAcess.StoreContext
{
    public class LoadSpecificStore : DatabasConnections.DatabaseConection, ILoadSpecifikStore
    {
        public async Task<StoreModel> SpecificStoreAsync(Guid id)
        {
            StoreModel returnModel = new StoreModel();

            returnModel = await _StoreContextDB.Stores.FindAsync(id);

            return returnModel;
        }

    }
}