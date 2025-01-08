using Divar.Db;
using Divar.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Divar.Services
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly DivarContext _context;

        public AdvertisementService(DivarContext context)
        {
            _context = context;
        }

        public async Task<List<Advertisement>> GetAllAdvertisementsAsync()
        {
            return await _context.Advertisements.ToListAsync();
        }

        public async Task<Advertisement> CreateAdvertisementAsync(Advertisement model)
        {
            model.Status = "Active";
            model.InsertDate = DateTime.Now;
            model.UpdateDate = DateTime.Now;

            var myModel = new Advertisement()
            {
                CategoryId = model.CategoryId,
                CityId = model.CityId,
                Brand = model.Brand,
                ItsModel = model.ItsModel,
                Color = model.Color,
                FunctionKilometers = Convert.ToInt32(model.FunctionKilometers),
                ChassisAndBodyCondition = model.ChassisAndBodyCondition,
                BasePrice = Convert.ToInt32(model.BasePrice),
                EngineCondition = model.EngineCondition,
                RearChassisCondition = model.RearChassisCondition,
                FrontChassisCondition = model.FrontChassisCondition,
                ThirdPartyInsuranceTerm = model.ThirdPartyInsuranceTerm,
                Gearbox = model.Gearbox,
                DoYouWantToReplace = model.DoYouWantToReplace,
                IsTheChatActivated = model.IsTheChatActivated,
                IsThePhoneCallActive = model.IsThePhoneCallActive,
                Title = model.Title,
                Description = model.Description,
                Nationality = model.Nationality,
                NationalCode = model.NationalCode,
                Status = model.Status,
                InsertDate = model.InsertDate,
                UpdateDate = model.UpdateDate,
                //Category =
                //{
                //    Title =model.Category.Title,
                //    Description=model.Category.Description,
                //    Status=model.Category.Status,
                //    Icon=model.Category.Icon,
                //    ParentId=model.Category.ParentId,
                //    Advertisements = model.Category.Advertisements
                //},
                //AdvertisementImages = model.AdvertisementImages,
                //City = model.City,
                //Latitude = model.Latitude,
                //Longitude = model.Longitude,
            };

            await _context.Advertisements.AddAsync(myModel);
            await _context.SaveChangesAsync();

            return myModel;
        }
    }
}
