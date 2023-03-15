using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeckRoad.Entities.Interfaces;

namespace TeckRoad.Entities.DbSets
{
    public class CategoryItem
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Pls select a valid mediatype!")]
        [Display(Name = "Media Type")]
        public int MediaTypeId { get; set; }
        
        [NotMapped]
        public virtual ICollection<SelectListItem>? MediaTypes { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}")]
        [Display(Name = "Release Date")]
        public DateTime DateTimeItemReleased { get; set; } = DateTime.UtcNow;

        [NotMapped]
        public int ContentId { get; set; }

    }
}
