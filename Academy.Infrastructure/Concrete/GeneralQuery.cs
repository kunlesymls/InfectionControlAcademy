using Academy.DAL.Context;
using Academy.Infrastructure.Abstractions;

namespace Academy.Infrastructure.Concrete
{
    public class GeneralQuery : IGeneralQuery
    {
        private AcademyDbContext _db { get; }

        public GeneralQuery(AcademyDbContext db)
        {
            _db = db;
        }

    }
}
