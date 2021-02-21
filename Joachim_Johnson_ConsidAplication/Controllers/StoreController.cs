using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DataLayer.DataAcess;
using DataLayer.Models;
using System.Threading.Tasks;
using System.Data.Entity;
using Joachim_Johnson_ConsidAplication.NewFolder1;
using Joachim_Johnson_ConsidAplication.Models;
using Joachim_Johnson_ConsidAplication.Servises.Functions.CompanyContext;
using Joachim_Johnson_ConsidAplication.Controllers.Functions.StoreContext;
using Joachim_Johnson_ConsidAplication.Controllers.DataAcess.StoreContext;

namespace Joachim_Johnson_ConsidAplication.Controllers
{
    public class StoreController : Controller, IErrorMessageControllers
    {
        public string viebagMessage(Exception e)
        {
            ViewBag.error = "Error Connecting. Couse: " + e;
            return ViewBag.error;
        }

        // GET: Store
        public ActionResult Index(LoadStores LoadStoreService)
        {
            ViewBag.error = "";
            List <StoreModel> loadedStores = new List<StoreModel>();

            try
            {
                loadedStores = LoadStoreService.loadALLStores();
            }
            catch(Exception e)
            {
                Console.Write(e);
                ViewBag.error = viebagMessage(e);
            }

            return View(loadedStores);
        }

        // GET: Store/Details/5
        public async Task<ActionResult> Details(Guid id, LoadSpecifikCompany LoadSpecifikCompanyServis, LoadSpecificStore LoadSpecificStoreService)
        {
            ViewBag.error = "";
            ViewBag.Companyname = "companyName";
            StoreModel StoreDetails = new StoreModel();

            try
            {
                StoreDetails = await LoadSpecificStoreService.SpecificStoreAsync(id);
                ViewBag.Companyname = await LoadSpecifikCompanyServis.LoadCompanyAsync(id);
            }
            catch (Exception e)
            {
                ViewBag.error = viebagMessage(e);
            }

            return View(StoreDetails);
        }

        // GET: Store/Create
        public ActionResult Create(LoadCompanies LoadCompaniesService)
        {
            try
            {
                // Filling companies to select in droppdownlist
                ViewBag.CompaniesList = new SelectList(LoadCompaniesService.LoadMultiCompanies(), "Id", "Name");
            }
            catch(Exception e)
            {
                ViewBag.CompaniesList = new SelectList("---emty list---");
                Console.Write("Unable to get list of companies. Couse: " + e);
                viebagMessage(e);
            }

            return View();
        }

        // POST: Store/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StoreModel StoreUserCreationData, FormCollection form, LoadCompanies LoadCompaniesService, CreateStore CreateStoreService)
        {
            ViewBag.CompaniesList = new SelectList(LoadCompaniesService.LoadMultiCompanies(), "Id", "Name");

            ViewBag.error = "";
            StoreUserCreationData.CompanyId = new Guid(form["CompanyID"]);

            // Reciving values from list
            try
            {
                if (StoreUserCreationData.CompanyId == null || StoreUserCreationData.CompanyId == Guid.Empty)
                {
                    Console.Write(StoreUserCreationData.CompanyId);
                    ViewBag.error = "Please select a company the store shoude belong to.";
                    return View();
                }
            }
            catch(Exception e)
            {
                ViewBag.error = viebagMessage(e);
            }

            try
            {
                await CreateStoreService.createStore(StoreUserCreationData);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.error = viebagMessage(e);

                return View();
            }
        }

        // GET: Store/Edit/5
        public async Task<ActionResult> Edit(Guid id, FormCollection form, LoadCompanies LoadCompaniesService, LoadSpecificStore LoadSpecificStoreService)
        {
            ViewBag.error = "";

            try
            {
                // Filling companies to select in droppdownlist
                ViewBag.CompaniesList = new SelectList(LoadCompaniesService.LoadMultiCompanies(), "Id", "Name");
            }
            catch (Exception e)
            {
                ViewBag.CompaniesList = new SelectList("---emty list---");
                ViewBag.error = viebagMessage(e);
            }

            StoreModel StoreDetails = new StoreModel();
            try
            {
                StoreDetails = await LoadSpecificStoreService.SpecificStoreAsync(id);
                StoreDetails.id = id;
            }
            catch (Exception e)
            {
                Console.Write(e);
                ViewBag.error = viebagMessage(e);
            }

            return View(StoreDetails);
        }

        // POST: Store/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(StoreModel UserCreationData, FormCollection form)
        {
            StoresContext _StoreContextDB = new StoresContext();
            ViewBag.error = "";

            UserCreationData.CompanyId = new Guid(form["CompanyID"]);

            if (UserCreationData.Longitude == null && UserCreationData.Latitude == null)
            {
                try
                {
                    ICordinatesModells RecivedApiCordinates = Servises.GoogleAdressToGeoPos.getCordByPos(UserCreationData.Adress, UserCreationData.City);

                    UserCreationData.Latitude   = RecivedApiCordinates.lat;
                    UserCreationData.Longitude  = RecivedApiCordinates.lng;
                }
                catch
                {
                    throw;
                }
            }

            try
            {
                _StoreContextDB.Entry(UserCreationData).State = EntityState.Modified;

                await _StoreContextDB.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.error = viebagMessage(e);
                return View();
            }
        }

        // GET: Store/Delete/5
        public async Task<ActionResult> Delete(Guid Id, LoadSpecificStore LoadSpecificStoreService)
        {
            ViewBag.Error = "";

            StoreModel StoreToDelete = new StoreModel();
            try
            {
                StoreToDelete = await LoadSpecificStoreService.SpecificStoreAsync(Id);
            }
            catch (Exception e)
            {
                Console.Write(e);
                ViewBag.Error = "Selected store could not be handled. couse" + e;
            }

            return View(StoreToDelete);
        }

        // POST: Store/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Delete(StoreModel UserCreationData, FormCollection form)
        {
            ViewBag.Error = "";

            try
            {
                /*_db.Stores.Remove(_db.Stores.Single(a => a.id == UserCreationData.id));
                await _db.SaveChangesAsync();*/

                await DataAcess.StoreContext.DeleteStore.delete(UserCreationData.id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = viebagMessage(e);
                return View();
            }
        }
    }
}
