using Academy.Models.Core;
using Academy.ViewModels.CoreVm;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Academy.Infrastructure.Abstractions
{
    public interface IGeneralQuery
    {
        Staff GetStaffDetail(string userName);
        Task<List<ProfessionalCategoryVm>> ProfessionalCategoryList();
        Task<List<ApplicantCreateEditVm>> ApplicantList();
    }
}
