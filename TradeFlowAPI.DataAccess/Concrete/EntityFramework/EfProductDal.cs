﻿using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TradeFlowAPI.DataAccess.Abstract;
using TradeFlowAPI.Entities.Concrete;

namespace TradeFlowAPI.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product,TradeFlowAPIDbContext>, IProductDal
    {
    }
}
