using DataLayer.Models;
using System;
using System.Threading.Tasks;

namespace Joachim_Johnson_ConsidAplication.Servises.Functions.StoreContext.Interfaces
{
    interface ILoadSpecifikStore
    {
        Task<StoreModel> SpecificStoreAsync(Guid id);
    }
}
