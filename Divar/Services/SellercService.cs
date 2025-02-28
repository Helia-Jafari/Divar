using Divar.Db;
using Divar.Interfaces;
using Divar.Mapper;
using Divar.Repositories;
using Divar.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Divar.Services
{
    public class SellercService : ISellercService
    {
        private readonly DivarContext _context;
        private readonly IGenericRepository<Seller> _sellerRepository;

        private readonly ISearchSpecification<Seller> _sellerSearchSpecificationService;

        //private readonly SellerMapper _sellerMapper;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public SellercService(DivarContext context, IGenericRepository<Seller> sellerRepository, ISearchSpecification<Seller> SellerSearchSpecificationService, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _sellerRepository = sellerRepository;

            //_sellerMapper = sellerMapper;

            _sellerSearchSpecificationService = SellerSearchSpecificationService;

            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IEnumerable<SellerViewModel>> GetAllSellersAsyncSellerVM()
        {
            var VMs = new List<SellerViewModel>();
            var ads = await _sellerRepository.GetAllAsync();
            ads.ToList().ForEach(c => VMs.Add(SellerMapper.MapSellerToSellerVM(c)));
            return VMs;
        }
        public async Task<List<Seller>> SearchSellersAsync(string SearchString)
        {
            var sellers = _context.Sellers.AsQueryable();
            return await _sellerSearchSpecificationService.ApplyFilter(sellers, SearchString).ToListAsync();

        }
        public async Task AddSellerAsync(SellerSignUpViewModel model)
        {

            Seller seller = SellerMapper.MapAccountSignUpVMToSeller(model);
            await _sellerRepository.AddAsync(seller);
            var selll = JsonSerializer.Serialize(seller.Id);
            _httpContextAccessor.HttpContext?.Response.Cookies.Append("sellerId", selll, new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Lax,
                Expires = DateTime.Now.AddHours(24)
            });
        }
        public async Task LogInSellerAsync(string nationalcode)
        {

            var LogedSeller = _context.Sellers.Where(x => x.NationalCode == nationalcode).FirstOrDefault();
        }
        public async Task<SellerDetailsViewModel> GetSellerByIdAsyncSellerDetailsVM(int id)
        {
            var ad = await _sellerRepository.GetByIdAsync(id);
            var VM = SellerMapper.MapSellerToSellerDetailsVM(ad);
            return VM;
        }
        public async Task DeleteSellerAsync(int id)
        {
            await _sellerRepository.DeleteAsync(id);
        }



        public async Task<Seller> UpdateSellerAsync(SellerEditViewModel model)
        {
            Seller seller = SellerMapper.MapSellerEditVMToSeller(model);
            await _sellerRepository.UpdateAsync(seller);
            return seller;
        }
        public async Task<SellerEditViewModel> GetSellerByIdAsyncSellerEditVM(int id)
        {
            var seller = await _sellerRepository.GetByIdAsync(id);
            var VM = SellerMapper.MapSellerToSellerEditVM(seller);
            return VM;
        }
    }
}