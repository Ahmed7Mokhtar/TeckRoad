using System.ComponentModel.DataAnnotations;

namespace TeckRoad.Entities.Interfaces
{
    public interface IPrimaryProperties
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
