namespace Web.Models
{
    public class ResponseDto
    {
        public object? Result { get; set; }
        public bool IsSuccssful { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
