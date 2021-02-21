using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DataLayer.DataAcess;
using System.Data.Entity;
using DataLayer.Models;
using System.Threading.Tasks;
using Joachim_Johnson_ConsidAplication.NewFolder1;
using Joachim_Johnson_ConsidAplication.Servises.Functions.CompanyContext;

namespace Joachim_Johnson_ConsidAplication.Controllers
{
    public class CompanyController : Controller , IErrorMessageControllers
    {
        public string viebagMessage(Exception e)
        {
            ViewBag.error = "Error Connecting. Couse: " + e;
            return ViewBag.error;
        }

        // GET: Company
        public ActionResult Index(LoadCompanies LoadCompaniesService)
        {
            ViewBag.error = "";
            List<CompanyModel> DisplayListCompanies = new List<CompanyModel>();

            try
            {
                DisplayListCompanies = LoadCompaniesService.LoadMultiCompanies();
            }
            catch (Exception e)
            {
                ViewBag.error = viebagMessage(e);
            }

            return View(DisplayListCompanies);
        }

        // GET: Company/Details/5
        public async Task<ActionResult> Details(Guid id, LoadSpecifikCompany LoadSpecifikStoreServis)
        {
            CompanyModel FindCompany = await LoadSpecifikStoreServis.LoadCompanyAsync(id);

            return View(FindCompany);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CompanyModel UserCreationData, Servises.Functions.CompanyContext.Create t)
        {
            ViewBag.error = "";

            try
            {
                await t.create(UserCreationData);
                //await Servises.Functions.CompanyContext.Create.create(UserCreationData);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.error = viebagMessage(e);
                return View();
            }
        }

        // GET: Company/Edit/5
        public async Task<ActionResult> Edit(Guid id, LoadSpecifikCompany LoadSpecifikStoreServis)
        {
            CompanyModel FindCompany = new CompanyModel();

            ViewBag.Error = "";

            try
            {
                FindCompany = await LoadSpecifikStoreServis.LoadCompanyAsync(id);

                if (FindCompany == null || FindCompany.Id == Guid.Empty)
                {
                    ViewBag.Error = "Could not find Company. Company been removed by anywon while edeting?";
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = "Error while finding the information about the company. Exeption:" + e;
            }

            return View(FindCompany);
        }

        // POST: Company/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CompanyModel UserCreationData)
        {
            CompaniesContext _db = new DataLayer.DataAcess.CompaniesContext();

            ViewBag.Error = "";

            try
            {
                _db.Entry(UserCreationData).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = "" + e;
                return View();
            }
        }

        // GET: Company/Delete/5
        public async Task<ActionResult> Delete(Guid id, LoadSpecifikCompany LoadSpecifikStoreServis)
        {
            ViewBag.Error = "";

            CompanyModel CompanyToDelete = new CompanyModel();
            try
            {
                CompanyToDelete = await LoadSpecifikStoreServis.LoadCompanyAsync(id);
            }
            catch (Exception e)
            {
                Console.Write(e);
                ViewBag.Error = viebagMessage(e);
            }

            return View(CompanyToDelete);
        }

        // POST: Company/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(CompanyModel SelectedCompany, DeleteCompany DeleteCompanyService)
        {
            ViewBag.error = "";
            Boolean areSure = false;

            try
            {
                if (areSure)
                {
                    ViewBag.error = "Varning, All stores belonging to this store is going to be removed aswell, Press again to confirm.";
                    areSure = true;
                    return View();
                }
                else
                {
                    await DeleteCompanyService.DeleteCompanydAsync(SelectedCompany.Id);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ViewBag.error = "Could not delete: " + e;
                return View();
            }
        }
    }
}
