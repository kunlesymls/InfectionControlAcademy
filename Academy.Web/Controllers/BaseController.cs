using Academy.Infrastructure.Abstractions;
using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

using System.Collections.Generic;
using System.IO;
using System.Security.Claims;

namespace Academy.Web.Controllers
{
    public class BaseController : Controller
    {
        public string staffId;
        public string userId;
        public string applicantId;

        public IMapper _mapper;
        public IGeneralQuery _query;
        public readonly ITrainingQuery _trainingQuery;
        public readonly IApplicantQuery _applicantQuery;

        public BaseController(IMapper mapper, IGeneralQuery query)
        {
            _mapper = mapper;
            _query = query;
        }

        public BaseController(IMapper mapper, IGeneralQuery query, ITrainingQuery trainingQuery) : this(mapper, query)
        {
            _trainingQuery = trainingQuery;
        }

        public BaseController(IMapper mapper, IGeneralQuery query, IApplicantQuery applicantQuery) : this(mapper, query)
        {
            _applicantQuery = applicantQuery;
        }

        public BaseController(IMapper mapper, IGeneralQuery query, ITrainingQuery trainingQuery, 
                                IApplicantQuery applicantQuery) : this(mapper, query, trainingQuery)
        {
            _applicantQuery = applicantQuery;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                var staff = _query.GetStaffDetail(userId);
                if (staff != null)
                {
                    staffId = staff.StaffId;
                }
            }
        }       

        public string GetEmailTemplate()
        {
            string body = string.Empty;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\register.html");

            using (StreamReader reader = new StreamReader(path))
            {
                body = reader.ReadToEnd();
            }
            return body;
        }

        public List<string> LevelOrder()
        {
            var levelOrder = new List<string>
            {
                "100","200","300","400","500","600","700","800","900"
            };
            return levelOrder;
        }

        public List<string> ProjectStatus()
        {
            var levelOrder = new List<string>
            {
                "In Progress","Completed"
            };
            return levelOrder;
        }
    }
}