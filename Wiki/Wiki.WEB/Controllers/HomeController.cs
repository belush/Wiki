using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Wiki.BLL.DTO;
using Wiki.BLL.Interfaces;
using Wiki.BLL.Logic;
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
            var recordsView = Mapper.Map<IEnumerable<RecordDTO>, List<RecordViewModel>>(records.OrderByDescending(r=>r.Id));

            return View();
        }

        public ActionResult Analize(RecordViewModel model)
        {
            if (ModelState.IsValid)
            {
                Thread.Sleep(200);

                var newRecord = _recordLogic.RateArticle(model.Url);
                _recordLogic.Add(newRecord);
            }
            var records = _recordLogic.GetAll();

            Mapper.CreateMap<RecordDTO, RecordViewModel>();
            var recordsView = Mapper.Map<IEnumerable<RecordDTO>, List<RecordViewModel>>(records);

            return PartialView(recordsView.OrderByDescending(r => r.Id));
        }

        public ViewResult Edit(int id)
        {
            var record = _recordLogic.Get(1);

            Mapper.CreateMap<RecordDTO, RecordViewModel>();
            var recordsView = Mapper.Map<RecordDTO, RecordViewModel>(record);

            return View(recordsView);
        }

        [HttpPost]
        public ActionResult Edit(RecordViewModel model)
        {
            if (ModelState.IsValid)
            {
                Mapper.CreateMap<RecordViewModel, RecordDTO>();
                var record = Mapper.Map<RecordViewModel, RecordDTO>(model);

                _recordLogic.Edit(record);

                return RedirectToAction("Index");
            }
            return View(model);
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
            return View();
        }

        public ActionResult HowItWork()
        {
            return View();
        }
    }
}