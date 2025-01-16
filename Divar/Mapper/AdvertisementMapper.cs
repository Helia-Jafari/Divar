using Divar.Db;
using Divar.ViewModels;

namespace Divar.Mapper
{
    public class AdvertisementMapper
    {
        public HomeViewModel MapAdvertisementToHomeVM(Advertisement ad) {
            return new HomeViewModel()
            {
                Title=ad.Title,
                Color=ad.Color,
                FunctionKilometers=ad.FunctionKilometers,
                BasePrice=ad.BasePrice,
                CityId=ad.CityId,
                CategoryId = ad.CategoryId,
                City = ad.City,
                Category = ad.Category,
                Id = ad.Id
            };
        }
        public Advertisement MapAddVMToAdvertisement(AddViewModel VM)
        {
            return new Advertisement()
            {
                BasePrice = Convert.ToInt32(VM.BasePrice),
                CityId = VM.CityId,
                CategoryId = VM.CategoryId,
                City = VM.City,
                Category = VM.Category,
                FunctionKilometers = Convert.ToInt32(VM.FunctionKilometers),
                Color = VM.Color,
                Brand = VM.Brand,
                ChassisAndBodyCondition = VM.ChassisAndBodyCondition,
                Description = VM.Description,
                DoYouWantToReplace = VM.DoYouWantToReplace,
                EngineCondition = VM.EngineCondition,
                FrontChassisCondition = VM.FrontChassisCondition,
                Gearbox = VM.Gearbox,
                IsTheChatActivated = VM.IsTheChatActivated,
                IsThePhoneCallActive = VM.IsThePhoneCallActive,
                Latitude = VM.Latitude,
                Longitude = VM.Longitude,
                ItsModel = VM.ItsModel,
                NationalCode = VM.NationalCode,
                RearChassisCondition = VM.RearChassisCondition,
                Nationality = VM.Nationality,
                ThirdPartyInsuranceTerm = VM.ThirdPartyInsuranceTerm,
                Title = VM.Title,
                Status = "Active",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
        }
    }
}
