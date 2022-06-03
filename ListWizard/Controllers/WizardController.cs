using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ListWizard.Controllers
{
    public class WizardController : Controller
    {
    
        private readonly ListWizardContext context;
        private readonly FileService fileService;
        public WizardController(ListWizardContext context, FileService fileService)
        {
            this.context = context;
            this.fileService = fileService;
        }
        public async Task<IActionResult> Index()
        {
            var contents = await context.WizardLists.Where(l=>l.IsDeleted == 0).ToListAsync();
            return View(contents);
        }

        public ViewResult CreateNewList()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewList(WizardList wizardList)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetObject("newListInfo", wizardList);
                return RedirectToAction("FileUpload");
            }
 
            return View(wizardList);
        }

        public IActionResult FileUpload()
        {
            Upload upload = new Upload();
            return View(upload);
        }

        [HttpPost]
        public IActionResult FileUpload(Upload uploadedFile)
        {
            if (ModelState.IsValid)
            {
                var result = fileService.FileUploadAsync(uploadedFile).Result;
                return View(result);
            }
            return View(uploadedFile);
        }

        public IActionResult CreateNewListPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult CreateNewListPartial(WizardList wizardList )
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetObject("newListInfo", wizardList);
                return Ok();
            }
            return View();
        }

        public PartialViewResult FileUploadPartial()
        {
            Upload upload = new Upload();
            return PartialView(upload);
        }


        [HttpPost]
        public IActionResult FileUploadPartial(IFormFile uploadedFile)
        {

            //var files = HttpContext.Request.Form.Files.GetFile("uploadedFile");

            if (ModelState.IsValid)
            {
                //var result = fileService.FileUploadAsync(uploadedFile).Result;
                //return View(result);
            }
            return View(uploadedFile);
        }
    }
}
                            
                            
    
    
    
                    
                    
    
    
    
    
    
    
                        