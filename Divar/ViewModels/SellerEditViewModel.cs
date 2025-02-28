namespace Divar.ViewModels
{
    public class SellerEditViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string NationalCode { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;
        public string Status { get; set; } = null!;

        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
