using DomiWeb.Data;
using DomiWeb.Models;
using DomiWeb.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.IO;
using System.Linq.Expressions;
using System.Security.Claims;

namespace DomiWeb.Controllers
{
    public class ArtiklController : Controller
    {
        private readonly IArtiklRepository _artiklRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ArtiklController(IArtiklRepository db, IWebHostEnvironment webHostEnvironment)
        {
            _artiklRepo = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            try
            {
                List<Artikl> objArtiklList = _artiklRepo.GetAll().ToList();

                return View(objArtiklList);

            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;

                return View("Error");
            }

        }

        [Authorize(Roles = Models.HelperClass.Role_Admin)]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = Models.HelperClass.Role_Admin)]
        [HttpPost]
        public IActionResult Create(Artikl obj, IFormFile file)
        {

            if (ModelState.IsValid)
            {

                if (file != null && file.Length > 0)
                {
                    var imagePath = Path.Combine("wwwroot/images", Path.GetFileName(file.FileName));
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    obj.ImageUrl = "/images/" + file.FileName;
                }

                _artiklRepo.Add(obj);
                _artiklRepo.Save();

                TempData["success"] = "Artikl je uspješno kreiran";

                return RedirectToAction("Index");

            }

            return View();

        }

      
        [Authorize(Roles = Models.HelperClass.Role_Admin)]
        public IActionResult Edit(int? id)
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }


                Artikl? artiklFromDb = _artiklRepo.Get(u => u.Id == id);

                if (artiklFromDb == null)
                {
                    return NotFound();
                }
                return View(artiklFromDb);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Models.HelperClass.Role_Admin)]
        public IActionResult Edit(Artikl obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var artiklFromDb = _artiklRepo.Get(u => u.Id == obj.Id); 

                if (artiklFromDb == null)
                {
                    return NotFound();
                }

                // Ažuriramo sve  podatke
                artiklFromDb.Naziv = obj.Naziv;
                artiklFromDb.Kategorija = obj.Kategorija;
                artiklFromDb.Cijena = obj.Cijena;

                // Ako korisnik šalje novu sliku, ažuriramo putanju slike
                if (file != null && file.Length > 0)
                {
                    // Uklonite postojeću sliku ako postoji
                    if (!string.IsNullOrEmpty(artiklFromDb.ImageUrl))
                    {
                        var staraPutanja = Path.Combine(_webHostEnvironment.WebRootPath, "images", Path.GetFileName(artiklFromDb.ImageUrl));
                        if (System.IO.File.Exists(staraPutanja))
                        {
                            System.IO.File.Delete(staraPutanja);
                        }
                    }

                    // Spremamo novu sliku
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", Path.GetFileName(file.FileName));
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    artiklFromDb.ImageUrl = "/images/" + file.FileName;
                }


                _artiklRepo.Update(artiklFromDb);
                _artiklRepo.Save();

                TempData["success"] = "Artikl je uspješno izmijenjen";

                return RedirectToAction("Index");
            }

            return View(obj);
        }

      

        [Authorize(Roles = Models.HelperClass.Role_Admin)]
        public IActionResult Delete(int? id)
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }

                Artikl? artiklFromDb = _artiklRepo.Get(u => u.Id == id);
            if (artiklFromDb == null)
                {
                    return NotFound();
                }
                return View(artiklFromDb);
            }

        [Authorize(Roles = Models.HelperClass.Role_Admin)]
        [HttpPost, ActionName("Delete")]
            public IActionResult DeletePOST(int? id)

            {
                Artikl? obj = _artiklRepo.Get(u => u.Id == id);

             if (obj == null)
                {
                    return NotFound();
                }

                _artiklRepo.Remove(obj);
                _artiklRepo.Save();

                TempData["success"] = "Artikl je uspješno uklonjen";

                return RedirectToAction("Index");



            }

            public IActionResult ExportToExcel()
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                // Dohvati podatke iz baze koje želimo spremiti u Excel
                var data = _artiklRepo.GetAll().ToList();

            // Kreiraj novu ExcelPackage
              using (var package = new ExcelPackage())
                {
                    // Dodaj listu u ExcelPackage
                    var worksheet = package.Workbook.Worksheets.Add("Artikli");

                    // Postavi zaglavlje tablice
                    worksheet.Cells["A1"].Value = "ID";
                    worksheet.Cells["B1"].Value = "Naziv";
                    worksheet.Cells["C1"].Value = "Kategorija";
                    worksheet.Cells["D1"].Value = "Cijena";

                    // Popuni podatke u tablicu
                    int row = 2;
                    foreach (var artikl in data)
                    {
                        worksheet.Cells["A" + row].Value = artikl.Id;
                        worksheet.Cells["B" + row].Value = artikl.Naziv;
                        worksheet.Cells["C" + row].Value = artikl.Kategorija;
                        worksheet.Cells["D" + row].Value = artikl.Cijena;
                        row++;
                    }

                    // Spremi ExcelPackage u memoriju
                    byte[] fileContents = package.GetAsByteArray();

                    // Vrati Excel datoteku klijentu
                    return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Artikli.xlsx");
                }


            }


        [Authorize(Roles = Models.HelperClass.Role_User)]
        public IActionResult Ocijeni(int id)
         {
            var obj = _artiklRepo.Get(u => u.Id == id);
            return View(obj);
         }


        [HttpPost]
        [Authorize(Roles = Models.HelperClass.Role_User)]
        public IActionResult Ocijeni(int id, int ocjena)
        {
            var obj = _artiklRepo.Get(u => u.Id == id);

            // Provjera je li korisnik već ocijenio artikl
            if (obj != null && obj.Ocjena == 0)
            {
                // Ako korisnik nije ocijenio, postavi ocjenu i spremi u bazu
                obj.Ocjena = ocjena;
                _artiklRepo.Save();

                TempData["success"] = "Artikl je uspješno ocijenjen!";
            }

            return RedirectToAction("Index");
        }


    }
}


