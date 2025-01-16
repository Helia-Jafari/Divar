using Divar.Db;

namespace Divar.ViewModels
{
    public class HomeViewModel
    {
        //public string TitleHome { get; set; }
        //public string ColorHome { get; set; }
        //public string BasePriceHome { get; set; }
        //public string FunctionKilometersHome { get; set; }
        //public string CityHome { get; set; }
        //public string CurrentDate { get; set; }
        //public string SearchHome { get; set; }
        //public string SucceededSearch { get; set; }

        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public int? CategoryId { get; set; }

        public string? Color { get; set; }

        public int? FunctionKilometers { get; set; }

        public decimal? BasePrice { get; set; }

        public int? CityId { get; set; }

        public virtual Category? Category { get; set; }

        public virtual City? City { get; set; }
    }
}
