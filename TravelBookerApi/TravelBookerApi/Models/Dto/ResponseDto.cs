namespace TravelBookerApi.Models.Dto
    //archivo para verificar respuestas de la api
{
    public class ResponseDto
    {
        public object? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Mensaje { get; set; } = "";
    }
}
