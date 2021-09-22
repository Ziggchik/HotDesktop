using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotDesktop.Models;
using HotDesktop.ViewModel;

namespace HotDesktop.Controllers
{
    public class WorkplaceController : Controller
    {
        private HotDeskEntities objHotDeskEntities;
        public WorkplaceController()
        {
            objHotDeskEntities = new HotDeskEntities();
        }
        public ActionResult Index()
        {
            WorkplaceViewModel objWorkplaceViewModel = new WorkplaceViewModel();
            objWorkplaceViewModel.ListOfBookingStatus = (from obj in objHotDeskEntities.BookingStatus
                select new SelectListItem()
                {
                    Text = obj.BookingStatus,
                    Value = obj.BookingStatusId.ToString()
                }).ToList();

            return View(objWorkplaceViewModel);
        }
        [HttpPost]
        public ActionResult Index(WorkplaceViewModel objWorkplaceViewModel)
        {
            string ImageUniqueName = Guid.NewGuid().ToString();
            string ActualImageName = ImageUniqueName + Path.GetExtension(objWorkplaceViewModel.Image.FileName);
            objWorkplaceViewModel.Image.SaveAs(Server.MapPath("~/WorkplaceImages/" + ActualImageName));
            Workplace objWorkplace = new Workplace();
            {
                //WorkplaceNumber = objWorkplaceViewModel.WorkplaceNumber;
                //WorkplaceDescription = objWorkplaceViewModel.WorkplaceDescription;
                //BookingStatusId = objWorkplaceViewModel.BookingStatusId;
                //IsActive = true;
                //WorkplaceImage = ActualImageName;
            };
            objHotDeskEntities.Workplaces.Add(objWorkplace);
            objHotDeskEntities.SaveChanges();
            return Json(new {message = "Место успешно создано", sucess = true }, JsonRequestBehavior.AllowGet);
        }
    }
}