using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.Web.Models.Categories
{
    public class CreateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(40, ErrorMessage = "TitleLength")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        
        public byte[] CategoryPhoto { get; set; }
    }
}
