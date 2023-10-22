using Autofac;
using DigiCV.Infrastructure;
using DigiCV.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DigiCV.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        ILifetimeScope _scope; 

        public UserController(ILifetimeScope scope)
        {
            _scope = scope;
        }

        [Authorize(Policy = "Administrator")]
        public IActionResult Index()
        {
            var model = _scope.Resolve<UserListModel>();

            return View(model);
        }

        public async Task<JsonResult> GetUsers()
        {
            var dataTablesModel = new DataTablesAjaxRequestUtility(Request);
            var model = _scope.Resolve<UserListModel>();

            object data = await model.GetPagedUsersAsync(dataTablesModel);
            return Json(data);
        }
    }
}
