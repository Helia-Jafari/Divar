using Divar.Db;

namespace Divar.ViewModels
{
    public class HomeEditViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int? CategoryId { get; set; }

        public string? Longitude { get; set; }

        public string? Latitude { get; set; }

        public string? Brand { get; set; }

        public string? ItsModel { get; set; }

        public string? Color { get; set; }

        public int? FunctionKilometers { get; set; }

        public string? ChassisAndBodyCondition { get; set; }

        public decimal? BasePrice { get; set; }

        public string? EngineCondition { get; set; }

        public string? ThirdPartyInsuranceTerm { get; set; }

        public string? Gearbox { get; set; }

        public bool DoYouWantToReplace { get; set; }

        public bool IsTheChatActivated { get; set; }

        public bool IsThePhoneCallActive { get; set; }

        public string? FrontChassisCondition { get; set; }

        public string? RearChassisCondition { get; set; }

        public string Nationality { get; set; } = null!;

        public string NationalCode { get; set; } = null!;

        public int? CityId { get; set; }

        public virtual Category? Category { get; set; }

        public virtual City? City { get; set; }

        public DateTime InsertDate { get; set; }

        public DateTime UpdateDate { get; set; }

        //public string Status { get; set; } = null!;
    }
}
