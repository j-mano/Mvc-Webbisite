using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joachim_Johnson_ConsidAplication.Servises.Functions.CompanyContext
{
    public interface ILoacSpecifikCompany
    {
        Task<CompanyModel> LoadCompanyAsync(Guid id);
    }
}
