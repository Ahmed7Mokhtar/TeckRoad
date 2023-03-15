using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeckRoad.Entities.DbSets
{
    public class AppUser : IdentityUser
    {
        [StringLength(250)]
        public string? FirstName { get; set; }
        [StringLength(250)]
        public string? LastName { get; set; }
        [StringLength(250)]
        public string? Address1 { get; set; }
        [StringLength(250)]
        public string? Address2 { get; set; }
        [StringLength(50)]
        public string? PostCode { get; set; }

        [ForeignKey("UserId")]
        public virtual ICollection<UserCategory> UserCategories { get; set; }
    }
}
