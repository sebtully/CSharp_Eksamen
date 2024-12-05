using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.BLL;
using DTO.Model;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_App.Controllers
{
    public class TidsregistreringController : Controller
    {
        private readonly TidsregistreringBLL _bll;

        public TidsregistreringController()
        {
            _bll = new TidsregistreringBLL();
        }

        public IActionResult Index()
        {
            var medarbejdere = _bll.GetAllMedarbejder();
            return View(medarbejdere);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Afdelinger = GetAfdelinger();
            ViewBag.Medarbejdere = GetMedarbejdere();
            ViewBag.Sager = GetSager();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tidsregistrering tidsregistrering)
        {
            if (ModelState.IsValid)
            {
                _bll.AddTidsregistrering(tidsregistrering);
                return RedirectToAction("Index");
            }

            ViewBag.Afdelinger = GetAfdelinger();
            ViewBag.Medarbejdere = GetMedarbejdere();
            ViewBag.Sager = GetSager();
            return View(tidsregistrering);
        }

        [HttpGet]
        public IActionResult AddSag()
        {
            ViewBag.Afdelinger = GetAfdelinger();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSag(Sag sag)
        {
            if (ModelState.IsValid)
            {
                _bll.AddSag(sag);
                return RedirectToAction("Create");
            }

            ViewBag.Afdelinger = GetAfdelinger();
            return View(sag);
        }

        private List<SelectListItem> GetSager()
        {
            var sager = _bll.GetAllSag();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var sag in sager)
            {
                selectListItems.Add(new SelectListItem()
                {
                    Text = sag.Overskrift,
                    Value = sag.SagId.ToString()
                });
            }

            return selectListItems;
        }

        private List<SelectListItem> GetMedarbejdere()
        {
            var medarbejdere = _bll.GetAllMedarbejder();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var medarbejder in medarbejdere)
            {
                selectListItems.Add(new SelectListItem()
                {
                    Text = medarbejder.Navn,
                    Value = medarbejder.MedarbejderId.ToString()
                });
            }

            return selectListItems;
        }

        private List<SelectListItem> GetAfdelinger()
        {
            var afdelinger = _bll.AllAfdeling();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var afdeling in afdelinger)
            {
                selectListItems.Add(new SelectListItem()
                {
                    Text = afdeling.Navn,
                    Value = afdeling.AfdelingId.ToString()
                });
            }

            return selectListItems;
        }
    }
}