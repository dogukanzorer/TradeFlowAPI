using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeFlowAPI.Entities.Concrete;
using TradeFlowAPI.Entities.Enums;

namespace TradeFlowAPI.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(Guid id);
        IDataResult<List<User>> GetByRole(RoleType role); // Kullanıcıları RoleType'a göre getirme
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(Guid id);
    }
}
