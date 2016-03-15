using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace Wiki.WEB.Models
{
    public class RecordViewModel
    {
        [Display(Name = "#")]
        public int Id { get; set; }

        [Display(Name = "URL")]
        [Required]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Длина от 6 символов")]
        public string Url { get; set; }

        [Display(Name = "Заголовок")]
        public string Header { get; set; }

        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        [Display(Name = "Результат")]
        public string Result { get; set; }

        [Display(Name = "Успешно")]
        public bool IsSuccess { get; set; }

        public bool IsDeleted { get; set; }
    }
}