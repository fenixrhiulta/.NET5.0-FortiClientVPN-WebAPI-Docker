namespace WebApi.Domain.DTO
{
    public class GetAddressResponse
    {
        public string Street_Address { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip_Postalcode { get; set; }
        public bool IsReturned { get; set; }
    }
}
