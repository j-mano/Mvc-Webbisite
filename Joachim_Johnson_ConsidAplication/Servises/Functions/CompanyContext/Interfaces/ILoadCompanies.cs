using DataLayer.Models;
using System.Collections.Generic;

namespace Joachim_Johnson_ConsidAplication.Servises.Functions.CompanyContext
{
    public interface ILoadCompanies
    {
        List<CompanyModel> LoadMultiCompanies();
    }
}