using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeFlowAPI.Business.Abstract;
using TradeFlowAPI.DataAccess.Abstract;
using TradeFlowAPI.Entities.Concrete;
using TradeFlowAPI.Entities.Enums;

namespace TradeFlowAPI.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal) { 
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult("User Added!");
        }

        public IResult Delete(Guid id)
        {
           var user = _userDal.Get(u => u .Id == id);
            if(user == null)
            {
                return new ErrorResult("No User found to delete");
            }
            _userDal.Delete(user);
            return new SuccessResult("Successfully deleted by user");
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),"User listed!");
        }

        public IDataResult<User> GetById(Guid id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
        }

        public IDataResult<List<User>> GetByRole(RoleType role)
        {
            // RoleType enum'unda geçerli bir değer kontrolü
            if (!Enum.IsDefined(typeof(RoleType), role))
            {
                return new ErrorDataResult<List<User>>("undifend role plan!"); // Hata mesajı ile dön
            }

            var users = _userDal.GetAll(u => u.Role == role); // Belirtilen role sahip kullanıcıları al
            return new SuccessDataResult<List<User>>(users);
        }

        public IResult Update(User user)
        {
            var existingUser = _userDal.Get(u => u.Id == user.Id);

            if (existingUser == null)
            {
                return new ErrorResult("User Not found."); // Hata durumu döndür
            }

            // Sadece belirtilen alanları güncelle
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password; // Şifre güncellemeleri için genellikle hash'lenmesi gerekir
            existingUser.Role = user.Role;

            // Güncellenmiş kullanıcıyı veritabanına kaydet
            _userDal.Update(existingUser);

            return new SuccessResult("Succesffuly user updated."); // Başarı durumu döndür
        }
    }
    
}
