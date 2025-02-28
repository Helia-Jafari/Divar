using Divar.Db;
using Divar.ViewModels;

namespace Divar.Mapper
{
    public class SellerMapper
    {
        public static SellerViewModel MapSellerToSellerVM(Seller seller)
        {
            return new SellerViewModel()
            {
                Id = seller.Id,
                FirstName = seller.FirstName,
                LastName = seller.LastName,
                NationalCode = seller.NationalCode,
                PhoneNumber = seller.PhoneNumber
            };
        }
        public static SellerDetailsViewModel MapSellerToSellerDetailsVM(Seller seller)
        {
            var v = new SellerDetailsViewModel()
            {
                Id = seller.Id,
                FirstName = seller.FirstName,
                LastName = seller.LastName,
                NationalCode = seller.NationalCode,
                PhoneNumber = seller.PhoneNumber
            };
            return v;
        }
        //پایینی بلا استفاده
        public static SellerDetailsViewModel MapSellerToSellerEditVM(SellerEditViewModel VM)
        {
            return new SellerDetailsViewModel()
            {
                Id = VM.Id,
                FirstName = VM.FirstName,
                LastName = VM.LastName,
                PhoneNumber = VM.PhoneNumber,
                NationalCode = VM.NationalCode,
                UpdateDate = VM.UpdateDate
            };
        }
        public static Seller MapAccountSignUpVMToSeller(SellerSignUpViewModel VM)
        {
            return new Seller()
            {
                NationalCode = VM.NationalCode,
                FirstName = VM.FirstName,
                LastName = VM.LastName,
                PhoneNumber = VM.PhoneNumber,
                Status = "Active",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
        }
        public static Seller MapSellerEditVMToSeller(SellerEditViewModel VM)
        {
            var v = new Seller()
            {
                Id = VM.Id,
                NationalCode = VM.NationalCode,
                PhoneNumber = VM.PhoneNumber,
                FirstName = VM.FirstName,
                LastName = VM.LastName,
                Status = VM.Status,
                UpdateDate = DateTime.Now,
                InsertDate = VM.InsertDate
            };
            return v;
        }
        public static SellerEditViewModel MapSellerToSellerEditVM(Seller seller)
        {
            var v = new SellerEditViewModel()
            {
                Id = seller.Id,
                NationalCode = seller.NationalCode,
                PhoneNumber = seller.PhoneNumber,
                FirstName = seller.FirstName,
                LastName = seller.LastName,
                Status =seller.Status,
                InsertDate = seller.InsertDate
            };
            return v;
        }
    }
}
