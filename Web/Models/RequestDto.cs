using static Fakesturant.Web.Utility.SD;

namespace Fakesturant.Web.Models.DTOs
{
    
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessTables { get; set; }
    }
}
