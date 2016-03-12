using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Wiki.BLL.DTO;
using Wiki.BLL.Interfaces;
using Wiki.WEB.Models;

namespace Wiki.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRecordLogic _recordLogic;

        public HomeController(IRecordLogic recordLogic)
        {
            _recordLogic = recordLogic;
        }

        public ActionResult Index()
        {
            var records = _recordLogic.GetAll();

            Mapper.CreateMap<RecordDTO, RecordViewModel>();
            var recordsView = Mapper.Map<IEnumerable<RecordDTO>, List<RecordViewModel>>(records);

            return View(recordsView);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecordViewModel model)
        {
            if (ModelState.IsValid)
            {
                Mapper.CreateMap<RecordViewModel, RecordDTO>();

                var record = Mapper.Map<RecordViewModel, RecordDTO>(model);
                _recordLogic.Add(record);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}