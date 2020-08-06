
using Microsoft.AspNetCore.Mvc;

namespace VideoCore.Controllers
{
    [Route("company/[controller]/[action]")]
    public class EmployeeController: Controller
    {
        public ContentResult Index()
        {
            return Content("Hello, from EmployeeController");
        }

        public ContentResult Name()
        {
            return Content("Gustavo Adolfo");
        }

        public ContentResult Country()
        {
            return Content("Brasil");
        }
    }
}
