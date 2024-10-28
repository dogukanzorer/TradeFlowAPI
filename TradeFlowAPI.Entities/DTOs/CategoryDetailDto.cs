﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeFlowAPI.Entities.DTOs
{
       public class CategoryDetailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ParentCategoryName { get; set; } // Yalnızca gösterilmek istenen alan
        public Guid? ParentCategoryId { get; set; }
    }


}
