namespace WebApplication1.Dto.Values
{
    public class PageResultDto<T>
    {
        public T Value { get; set; }
        public int TotalItem { get; set; }
    }
}
