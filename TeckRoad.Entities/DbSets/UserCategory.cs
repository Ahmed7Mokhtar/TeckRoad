using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeckRoad.Entities.DbSets
{
    public class UserCategory
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
