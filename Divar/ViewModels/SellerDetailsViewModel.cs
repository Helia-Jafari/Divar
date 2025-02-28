namespace Divar.ViewModels
{
    public class SellerDetailsViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string NationalCode { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public DateTime UpdateDate { get; set; }
    }
}
