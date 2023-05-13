using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Dto.Page
{
    public class FilterDto
    {
        [FromQuery(Name ="pageSize")]
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        private string _name;
        [FromQuery(Name ="name")]
        public string Name {
            get => _name;
            set => _name = value?.Trim(); 
        }

    }
}
