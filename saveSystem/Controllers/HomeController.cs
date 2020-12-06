using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using saveSystem.Domain;
using saveSystem.Domain.Repository;
using saveSystem.Models;

namespace saveSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SubjectRepository subjectRepository;
        private readonly IWebHostEnvironment _hostEnvironment;
        public HomeController(ILogger<HomeController> logger, SubjectRepository subjectRepository, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            this.subjectRepository = subjectRepository;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var model = subjectRepository.GetSubjects();
            return View(model);
        }

        public IActionResult SubjectAdd(int id)
        {
            Subject model = id == default ? new Subject() : subjectRepository.GetSubjectById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SubjectAdd(Subject model)
        {
            if (ModelState.IsValid)
            {
                //save file to wwwroot/Image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(model.SubjectFile.FileName);
                string extention = Path.GetExtension(model.SubjectFile.FileName);
                model.SubjectFileName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                string path = Path.Combine(wwwRootPath + "/FilesPDF/", fileName);
                model.SubjectFileLocation = path;

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await model.SubjectFile.CopyToAsync(fileStream);
                }

                subjectRepository.SaveSubject(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }


        [HttpPost]
        public FileResult OpenPDF(int Id)
        {           
                string PDFpath = subjectRepository.GetSubjectById(Id).SubjectFileLocation;
                byte[] abc = System.IO.File.ReadAllBytes(PDFpath);
                System.IO.File.WriteAllBytes(PDFpath, abc);
                MemoryStream ms = new MemoryStream(abc);
                return new FileStreamResult(ms, "application/pdf");            
        }

        [HttpPost] 
        public IActionResult SubjectDelete(int id)
        {
            subjectRepository.DeleteSubject(id);
            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
