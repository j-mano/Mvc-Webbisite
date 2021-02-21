using DataLayer.Models;
using Joachim_Johnson_ConsidAplication.Controllers.DataAcess.DatabasConnections;
using Joachim_Johnson_ConsidAplication.Models;
using Joachim_Johnson_ConsidAplication.Servises.Functions.StoreContext.Interfaces;
using System;
using System.Threading.Tasks;

namespace Joachim_Johnson_ConsidAplication.Controllers.Functions.StoreContext
{
    public class CreateStore : DatabaseConection, ICreateStore
    {
        public async Task<bool> createStore(StoreModel StoreUserCreationData)
        {
            bool returnbool;
            try
            {
                StoreModel Companyidcheck = await _StoreContextDB.Stores.FindAsync(StoreUserCreationData.id);

                while (Companyidcheck != null)
                {
                    StoreUserCreationData.id = Guid.NewGuid();
                    Companyidcheck = _StoreContextDB.Stores.Find(StoreUserCreationData.id);
                }

                if (StoreUserCreationData.Longitude == null && StoreUserCreationData.Latitude == null)
                {
                    try
                    {
                        ICordinatesModells RecivedApiCordinates = Servises.GoogleAdressToGeoPos.getCordByPos(StoreUserCreationData.Adress, StoreUserCreationData.City);

                        StoreUserCreationData.Latitude = RecivedApiCordinates.lat;
                        StoreUserCreationData.Longitude = RecivedApiCordinates.lng;
                    }
                    catch
                    {
                        throw;
                    }
                }

                _StoreContextDB.Stores.Add(StoreUserCreationData);
                await _StoreContextDB.SaveChangesAsync();

                returnbool = true;
            }
            catch
            {
                returnbool = false;
                throw;
            }
            return returnbool;
        }
    }
}