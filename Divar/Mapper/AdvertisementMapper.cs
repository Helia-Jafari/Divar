using Divar.Db;
using Divar.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Divar.Mapper
{
    public static class AdvertisementMapper
    {
        public static HomeViewModel MapAdvertisementToHomeVM(Advertisement ad) {
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
        public static HomeDetailsViewModel MapAdvertisementToHomeDetailsVM(Advertisement ad)
        {
            var v= new HomeDetailsViewModel()
            {
                Title = ad.Title,
                Color = ad.Color,
                FunctionKilometers = ad.FunctionKilometers,
                BasePrice = ad.BasePrice,
                CityId = ad.CityId,
                CategoryId = ad.CategoryId,
                City = ad.City,
                Category = ad.Category,
                Id = ad.Id,
                Description = ad.Description,
                Brand = ad.Brand,
                ItsModel = ad.ItsModel,
                ChassisAndBodyCondition = ad.ChassisAndBodyCondition,
                EngineCondition = ad.EngineCondition,
                ThirdPartyInsuranceTerm = ad.ThirdPartyInsuranceTerm,
                Gearbox = ad.Gearbox,
                DoYouWantToReplace = ad.DoYouWantToReplace,
                IsTheChatActivated = ad.IsTheChatActivated,
                IsThePhoneCallActive = ad.IsThePhoneCallActive,
                FrontChassisCondition = ad.FrontChassisCondition,
                RearChassisCondition = ad.RearChassisCondition,
                UpdateDate = ad.UpdateDate,
                InsertDate = ad.InsertDate
            };
            return v;
        }
        public static HomeDetailsViewModel MapAdvertisementToHomeDetailsVM(HomeEditViewModel VM)
        {
            return new HomeDetailsViewModel()
            {
                Title = VM.Title,
                Color = VM.Color,
                FunctionKilometers = VM.FunctionKilometers,
                BasePrice = VM.BasePrice,
                CityId = VM.CityId,
                CategoryId = VM.CategoryId,
                City = VM.City,
                Category = VM.Category,
                Id = VM.Id,
                Description=VM.Description,
                Brand=VM.Brand,
                ItsModel=VM.ItsModel,
                ChassisAndBodyCondition=VM.ChassisAndBodyCondition,
                EngineCondition=VM.EngineCondition,
                ThirdPartyInsuranceTerm=VM.ThirdPartyInsuranceTerm,
                Gearbox=VM.Gearbox,
                DoYouWantToReplace=VM.DoYouWantToReplace,
                IsTheChatActivated=VM.IsTheChatActivated,
                IsThePhoneCallActive=VM.IsThePhoneCallActive,
                FrontChassisCondition=VM.FrontChassisCondition,
                RearChassisCondition=VM.RearChassisCondition,
                UpdateDate=VM.UpdateDate
            };
        }
        public static Advertisement MapAddVMToAdvertisement(AddViewModel VM)
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
        public static Advertisement MapHomeEditVMToAdvertisement(HomeEditViewModel VM)
        {
            var v= new Advertisement()
            {
                Id=VM.Id,
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
                UpdateDate = DateTime.Now,
                InsertDate = VM.InsertDate
            };
            return v;
        }
        public static HomeEditViewModel MapAdvertisementToHomeEditVM(Advertisement ad)
        {
            var v = new HomeEditViewModel()
            {
                Id=ad.Id,
                BasePrice = ad.BasePrice,
                CityId = ad.CityId,
                CategoryId = ad.CategoryId,
                City = ad.City,
                Category = ad.Category,
                FunctionKilometers = ad.FunctionKilometers,
                Color = ad.Color,
                Brand = ad.Brand,
                ChassisAndBodyCondition = ad.ChassisAndBodyCondition,
                Description = ad.Description,
                DoYouWantToReplace = ad.DoYouWantToReplace,
                EngineCondition = ad.EngineCondition,
                FrontChassisCondition = ad.FrontChassisCondition,
                Gearbox = ad.Gearbox,
                IsTheChatActivated = ad.IsTheChatActivated,
                IsThePhoneCallActive = ad.IsThePhoneCallActive,
                Latitude = ad.Latitude,
                Longitude = ad.Longitude,
                ItsModel = ad.ItsModel,
                NationalCode = ad.NationalCode,
                RearChassisCondition = ad.RearChassisCondition,
                Nationality = ad.Nationality,
                ThirdPartyInsuranceTerm = ad.ThirdPartyInsuranceTerm,
                Title = ad.Title,
                InsertDate = ad.InsertDate,
                Status = ad.Status
            };
            return v;
        }
    }
}
