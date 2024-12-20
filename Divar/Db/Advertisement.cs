using Divar.Controllers;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Divar.Db;

public partial class Advertisement
{

    private readonly IStringLocalizer<Advertisement> _localizer;

    public Advertisement()
    {
    }

    public Advertisement(IStringLocalizer<Advertisement> localizer)
    {
        _localizer = localizer;
    }

    public int Id { get; set; }
    [Required(ErrorMessage = "This fild is required")]
    //[Required(ErrorMessage = (string)_localizer["RequiredInputError"])]
    //[Required(ErrorMessage = _localizer["RequiredInputError"])]
    [MinLength(6, ErrorMessage = "This fild must have at least 6 charackters")]
    [Display(Name = "Title")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "This fild is required")]
    public string Description { get; set; } = null!;

    public int? CategoryId { get; set; }

    public string? Longitude { get; set; }

    public string? Latitude { get; set; }

    [Required(ErrorMessage = "This fild is required")]
    public string? Brand { get; set; }

    [Required(ErrorMessage = "This fild is required")]
    public string? ItsModel { get; set; }

    [Required(ErrorMessage = "This fild is required")]
    public string? Color { get; set; }

    [Required(ErrorMessage = "This fild is required")]
    public int? FunctionKilometers { get; set; }

    [Required(ErrorMessage = "This fild is required")]
    public string? ChassisAndBodyCondition { get; set; }

    [Required(ErrorMessage = "This fild is required")]
    [Range(10000000,999999999,ErrorMessage = "The base price must be between 10000000 and 999999999")]
    public decimal? BasePrice { get; set; }

    public string? EngineCondition { get; set; }

    public string? ThirdPartyInsuranceTerm { get; set; }

    public string? Gearbox { get; set; }

    public bool DoYouWantToReplace { get; set; }

    public bool IsTheChatActivated { get; set; }

    public bool IsThePhoneCallActive { get; set; }

    public DateTime InsertDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public string Status { get; set; } = null!;

    public string? FrontChassisCondition { get; set; }

    public string? RearChassisCondition { get; set; }

    public string Nationality { get; set; } = null!;

    [Required(ErrorMessage = "This fild is required")]
    [MinLength(10, ErrorMessage = "This fild must have 10 charackters")]
    [MaxLength(10, ErrorMessage = "This fild must have 10 charackters")]
    public string NationalCode { get; set; } = null!;

    public int? CityId { get; set; }

    public virtual ICollection<AdvertisementImage> AdvertisementImages { get; set; } = new List<AdvertisementImage>();

    public virtual Category? Category { get; set; }

    public virtual City? City { get; set; }
}
