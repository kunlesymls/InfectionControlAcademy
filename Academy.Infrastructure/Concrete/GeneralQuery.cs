using Academy.DAL.Context;
using Academy.Infrastructure.Abstractions;
using Academy.Models.Core;
using System.Linq;

namespace Academy.Infrastructure.Concrete
{
    public class GeneralQuery : IGeneralQuery
    {
        private AcademyDbContext _db { get; }

        public GeneralQuery(AcademyDbContext db)
        {
            _db = db;
        }

        public Staff GetStaffDetail(string userName)
        {
            return _db.Staffs.FirstOrDefault(x => x.Email.Equals(userName));
        }
    }
}
