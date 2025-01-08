﻿using Divar.Db;
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
        public async Task<List<Advertisement>> SearchAdvertisementsAsync(string SearchString)
        {



            SearchString = SearchString.Trim();


            //return await _context.Advertisements
            //    .Where(m => m.Title.Contains(SearchString) ||
            //    m.Color.Contains(SearchString) ||
            //    m.BasePrice.ToString().Contains(SearchString) ||
            //    m.FunctionKilometers.ToString().Contains(SearchString) ||
            //    _context.Categories.Where(a => a.Id == m.CategoryId).FirstOrDefault().Title.Contains(SearchString) ||
            //    _context.Cities.Where(city => city.Id == m.CityId).FirstOrDefault().Name.Contains(SearchString))
            //    .ToListAsync();

            //return await _context.Advertisements
            //    .Where(async m => m.Title.Contains(SearchString) || 
            //    m.Color.Contains(SearchString) || 
            //    m.BasePrice.ToString().Contains(SearchString) || 
            //    m.FunctionKilometers.ToString().Contains(SearchString) || 
            //    await _context.Categories.Where(a => a.Id == m.CategoryId).FirstOrDefaultAsync().Title.Contains(SearchString) || 
            //    await _context.Cities.Where(city => city.Id == m.CityId).FirstOrDefaultAsync().Name.Contains(SearchString))
            //    .ToListAsync();

            //var categories = await _context.Categories.ToListAsync();
            //var cities = await _context.Cities.ToListAsync();
            //return await _context.Advertisements.Where(m =>
            //    m.Title.Contains(SearchString) ||
            //    m.Color.Contains(SearchString) ||
            //    m.BasePrice.ToString().Contains(SearchString) ||
            //    m.FunctionKilometers.ToString().Contains(SearchString) ||
            //    categories.Where(a => a.Id == m.CategoryId).FirstOrDefault().Title.Contains(SearchString) ||
            //    cities.Where(city => city.Id == m.CityId).FirstOrDefault().Name.Contains(SearchString))
            //    .ToListAsync();

            //var categories = await _context.Categories.ToListAsync();
            //var cities = await _context.Cities.ToListAsync();
            //return await _context.Advertisements.Where(m =>
            //    m.Title.Contains(SearchString) ||
            //    m.Color.Contains(SearchString) ||
            //    m.BasePrice.ToString().Contains(SearchString) ||
            //    m.FunctionKilometers.ToString().Contains(SearchString) ||
            //    categories.Any(a => a.Id == m.CategoryId && a.Title.Contains(SearchString)) ||
            //    cities.Any(city => city.Id == m.CityId && city.Name.Contains(SearchString))
            //).ToListAsync();

            //var allAds = await _context.Advertisements.ToListAsync();
            //var categories = await _context.Categories.ToListAsync();
            //var cities = await _context.Cities.ToListAsync();
            //return allAds.Where(m =>
            //    m.Title.Contains(SearchString) ||
            //    m.Color.Contains(SearchString) ||
            //    m.BasePrice.ToString().Contains(SearchString) ||
            //    m.FunctionKilometers.ToString().Contains(SearchString) ||
            //    categories.Where(a => a.Id == m.CategoryId).FirstOrDefault().Title.Contains(SearchString) ||
            //    cities.Where(city => city.Id == m.CityId).FirstOrDefault().Name.Contains(SearchString))
            //    .ToList();

            //var allAds = await _context.Advertisements.ToListAsync();
            //var categories = await _context.Categories.ToListAsync();
            //var cities = await _context.Cities.ToListAsync();
            //return allAds.Where(m =>
            //    m.Title.Contains(SearchString) ||
            //    m.Color.Contains(SearchString) ||
            //    m.BasePrice.ToString().Contains(SearchString) ||
            //    m.FunctionKilometers.ToString().Contains(SearchString) ||
            //    categories.Any(a => a.Id == m.CategoryId && a.Title.Contains(SearchString)) ||
            //    cities.Any(city => city.Id == m.CityId && city.Name.Contains(SearchString))
            //).ToList();

            return await _context.Advertisements
                .Where(m => m.Title.Contains(SearchString) ||
                m.Color.Contains(SearchString) ||
                m.BasePrice.ToString().Contains(SearchString) ||
                m.FunctionKilometers.ToString().Contains(SearchString) ||
                m.Category.Title.Contains(SearchString) ||
                m.City.Name.Contains(SearchString))
                .ToListAsync();


            //var ads = _context.Advertisements.Where(m => cats.Where(a => a == catsDictionary["breadcrumbs" + m.Id.ToString()]).FirstOrDefault().AsQueryable().Where(a => a.Title.ToString().Contains(SearchString)).FirstOrDefault().Title.ToString().Contains(SearchString)).ToList();
            //var avs = _context.Advertisements
            //    .Where(m =>
            //    {
            //        // ???? ???? ????????? ??????
            //         var categoriesList = cats.FirstOrDefault(a => a == catsDictionary["breadcrumbs" + m.Id.ToString()]);
            //        // ??? ????????? ???? ?? ? ????? ?? ???? SearchString ???? ????? ????
            //        var c = categoriesList.FirstOrDefault(a => a.Title.ToString().Contains(SearchString));
            //        return c.Title.Contains(SearchString);
            //    })
            //    .ToList();
            //var adv = _context.Advertisements.Where(m => cats.Where(a => a == catsDictionary["breadcrumbs" + m.Id.ToString()]).FirstOrDefault().Where(a => a.Title.ToString().Contains(SearchString)).FirstOrDefault().Title.ToString().Contains(SearchString)).ToList();
            //var ads = _context.Advertisements.Where(m => m.Title.Contains(SearchString) || m.Color.Contains(SearchString) || m.BasePrice.ToString().Contains(SearchString) || m.FunctionKilometers.ToString().Contains(SearchString) || _context.Categories.Where(a => a.Id == m.CategoryId).FirstOrDefault().Title.Contains(SearchString) || _context.Cities.Where(city => city.Id == m.CityId).FirstOrDefault().Name.Contains(SearchString) || cats.Where(a => a == catsDictionary["breadcrumbs" + m.Id.ToString()]).FirstOrDefault().AsQueryable().Where(a => a.Title.ToString().Contains(SearchString)).FirstOrDefault().Title.ToString().Contains(SearchString)).ToList();

            decimal price;
            bool isDigit = decimal.TryParse(SearchString, out price);
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
