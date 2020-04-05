using Academy.Models.Core;

namespace Academy.Infrastructure.Abstractions
{
    public interface IGeneralQuery
    {
        Staff GetStaffDetail(string userName);
    }
}
