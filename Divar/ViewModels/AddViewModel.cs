using Divar.Db;
using System.ComponentModel.DataAnnotations;
using Divar.Localization;
namespace Divar.ViewModels

{
    public class AddViewModel
    {
        [Required(ErrorMessageResourceName = "RequiredInputErrorMassage", ErrorMessageResourceType = typeof(Divar.Localization.ViewModels_AddViewModel))]
        //[Required(ErrorMessage = "This fild is required")]
        //[Required(ErrorMessage = (string)_localizer["RequiredInputError"])]
        //[Required(ErrorMessage = _localizer["RequiredInputError"])
        [MinLength(6, ErrorMessageResourceName = "TitleMinLengthErrorMassage", ErrorMessageResourceType = typeof(Divar.Localization.ViewModels_AddViewModel))]
        //[MinLength(6)]
        [Display(Name = "Title")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessageResourceName = "RequiredInputErrorMassage", ErrorMessageResourceType = typeof(Divar.Localization.ViewModels_AddViewModel))]
        public string Description { get; set; } = null!;

        public int? CategoryId { get; set; }

        public string? Longitude { get; set; }

        public string? Latitude { get; set; }

        [Required(ErrorMessageResourceName = "RequiredInputErrorMassage", ErrorMessageResourceType = typeof(Divar.Localization.ViewModels_AddViewModel))]
        public string? Brand { get; set; }

        [Required(ErrorMessageResourceName = "RequiredInputErrorMassage", ErrorMessageResourceType = typeof(Divar.Localization.ViewModels_AddViewModel))]
        public string? ItsModel { get; set; }

        [Required(ErrorMessageResourceName = "RequiredInputErrorMassage", ErrorMessageResourceType = typeof(Divar.Localization.ViewModels_AddViewModel))]
        public string? Color { get; set; }

        [Required(ErrorMessageResourceName = "RequiredInputErrorMassage", ErrorMessageResourceType = typeof(Divar.Localization.ViewModels_AddViewModel))]
        public int? FunctionKilometers { get; set; }

        [Required(ErrorMessageResourceName = "RequiredInputErrorMassage", ErrorMessageResourceType = typeof(Divar.Localization.ViewModels_AddViewModel))]
        public string? ChassisAndBodyCondition { get; set; }

        [Required(ErrorMessageResourceName = "RequiredInputErrorMassage", ErrorMessageResourceType = typeof(Divar.Localization.ViewModels_AddViewModel))]
        [Range(10000000, 999999999, ErrorMessageResourceName = "BasePriseRangeErrorMassage", ErrorMessageResourceType = typeof(Divar.Localization.ViewModels_AddViewModel))]
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

        [Required(ErrorMessageResourceName = "RequiredInputErrorMassage", ErrorMessageResourceType = typeof(Divar.Localization.ViewModels_AddViewModel))]
        [MinLength(10, ErrorMessageResourceName = "NationalCodeLengthErrorMassage", ErrorMessageResourceType = typeof(Divar.Localization.ViewModels_AddViewModel))]
        [MaxLength(10, ErrorMessageResourceName = "NationalCodeLengthErrorMassage", ErrorMessageResourceType = typeof(Divar.Localization.ViewModels_AddViewModel))]
        public string NationalCode { get; set; } = null!;

        public int? CityId { get; set; }

        public virtual Category? Category { get; set; }

        public virtual City? City { get; set; }
    }
}
