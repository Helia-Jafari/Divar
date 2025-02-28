using Divar.Db;
using Divar.Interfaces;

namespace Divar.Services
{
    public class SellerSearchSpecificationService : ISearchSpecification<Seller>
    {
        public IQueryable<Seller> ApplyFilter(IQueryable<Seller> query, string searchString)
        {
            searchString = searchString.Trim();
            return query.Where(
                seller =>
                seller.FirstName.Contains(searchString) ||
                seller.LastName.Contains(searchString) ||
                seller.PhoneNumber.ToString()==searchString ||
                seller.NationalCode.ToString()==searchString
            );
        }
    }
}
