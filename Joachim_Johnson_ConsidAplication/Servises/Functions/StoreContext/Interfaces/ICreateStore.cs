using DataLayer.Models;
using System.Threading.Tasks;

namespace Joachim_Johnson_ConsidAplication.Servises.Functions.StoreContext.Interfaces
{
    interface ICreateStore
    {
        Task<bool> createStore(StoreModel StoreUserCreationData);
    }
}
