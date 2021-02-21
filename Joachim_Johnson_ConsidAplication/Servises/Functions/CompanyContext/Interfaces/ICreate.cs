using DataLayer.Models;
using System.Threading.Tasks;

namespace Joachim_Johnson_ConsidAplication.Servises.Functions.CompanyContext
{
    internal interface ICreate
    {
        Task<bool> create(CompanyModel UserCreationData);
    }
}