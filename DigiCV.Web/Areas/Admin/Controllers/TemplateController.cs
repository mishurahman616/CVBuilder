using Autofac;
using DigiCV.Infrastructure.Features.Exceptions;
using DigiCV.Web.Areas.Admin.Models;
using DigiCV.Web.Models;
using DigiCV.Web.Utilities;
using Microsoft.AspNetCore.Mvc; 

namespace DigiCV.Web.Areas.Admin.Controllers;
[Area("Admin")]
public class TemplateController : Controller
{ 
    ILifetimeScope _scope;
    ILogger<TemplateController> _logger;

    public TemplateController(ILifetimeScope scope, ILogger<TemplateController> logger)
    {
        _scope = scope;
        _logger = logger;
    }


    // GET
    public IActionResult Index()
    {
        var model = _scope.Resolve<TemplateListModel>();
        return View(model);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public  IActionResult Create(TemplateCreateModel model)
    {
        model.ResolveDependency(_scope);
        if (ModelState.IsValid)
        {
            try
            {
                model.CreateTemplateName();
                model.CreateTemplate();
                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = "Successfully added a new Template.",
                    Type = ResponseTypes.Success
                });
                return RedirectToAction("Index");
            }
            catch (DuplicateNameException ex)
            {
                _logger.LogError(ex, ex.Message);
                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = ex.Message,
                    Type = ResponseTypes.Danger
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Server Error");

                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = "There was a problem in creating Template.",
                    Type = ResponseTypes.Danger
                });
            }
        }
        return View(model);
    }
}