using Evento.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.Web.Models.Events
{
    public class EventViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "TitleRequired")]
        [StringLength(40, ErrorMessage = "TitleLength", MinimumLength = 6)]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "DateStartRequired")]
       
        [Display(Name = "DateStart")]
        public DateTime DateStart { get; set; }
        [Required(ErrorMessage = "DateFinishRequired")]
        [Display(Name = "DateFinish")]
        public DateTime DateFinish { get; set; }
        [Required(ErrorMessage = "DescriptionRequired")]
        [StringLength(4000, ErrorMessage = "DescriptionLength", MinimumLength = 6)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public string Place { get; set; }

        public string Latitude { get; set; }

        public string Longtitude { get; set; }
        public string Tags { get; set; }
        public bool IsOwner { get; set; }
        public bool IsSubscribed { get; set; }
        public byte[] Photo { get; set; }
        public virtual Category Category { get; set; }

    }
}
