﻿using Core.DataAccess;
using TradeFlowAPI.Entities.Concrete;

namespace TradeFlowAPI.DataAccess.Abstract
{
    public interface IPaymentDal : IEntityRepository<Payment>
    {

    }
}