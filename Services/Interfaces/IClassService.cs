using WebApplication1.Entities;

namespace WebApplication1.Services.Interfaces
{
    public interface IClassService
    {
        public int ClassId { get; set; }
        public List<int> StudentId { get; set; }

    }
}
