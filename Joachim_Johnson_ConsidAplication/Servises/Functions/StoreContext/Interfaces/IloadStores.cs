using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joachim_Johnson_ConsidAplication.Servises.Functions.StoreContext
{
    public interface IloadStores
    {
        List<StoreModel> loadALLStores();
    }
}