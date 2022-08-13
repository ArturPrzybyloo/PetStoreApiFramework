namespace PetStoreApiFramework.Dto
{
    public class ApiResponseDto
    {
        // Status code of response
        public int Code { get; set; }
        // Type of response
        public string Type { get; set; }
        // Message of response
        public string Message { get; set; }

    }
}
