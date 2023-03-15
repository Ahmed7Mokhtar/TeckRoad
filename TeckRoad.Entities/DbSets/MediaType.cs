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
    public class MediaType : IPrimaryProperties
    {
        public int Id { get; set; }
        [Required]
        [StringLength(2000, MinimumLength = 2)]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Thumbnail Image Path")]
        public string ThumbnailImagePath { get; set; }

        [ForeignKey("MediaTypeId")]
        public virtual ICollection<CategoryItem>? CategoryItems { get; set; }
    }
}
