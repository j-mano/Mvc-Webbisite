using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joachim_Johnson_ConsidAplication.Servises.Functions.StoreContext.Interfaces
{
    interface IEditStore
    {
        Task<bool> EditStor(StoreModel UserCreationData);
    }
}
