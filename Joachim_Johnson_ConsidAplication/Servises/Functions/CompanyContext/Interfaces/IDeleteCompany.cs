using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joachim_Johnson_ConsidAplication.Servises.Functions.CompanyContext
{
    interface IDeleteCompany
    {
        Task<bool> DeleteCompanydAsync(Guid id);
    }
}
