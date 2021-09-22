using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HotDesktop.ViewModel
{
    public class WorkplaceViewModel
    {
        public int WorkplaceId { get; set; }
        [Display (Name = "Номер рабочего места")]
        public string WorkplaceNumber { get; set; }

        [Display(Name = "Изображение рабочего места")]
        public string WorkplaceImage { get; set; }

        [Display(Name = "Статус бронирования")]
        public int BookingStatusId { get; set; }
        public HttpPostedFileBase Image { get; set; }

        [Display(Name = "Описание рабочего места")]
        public string WorkplaceDescription { get; set; }
        public List<SelectListItem> ListOfBookingStatus { get; set; }
    }
}