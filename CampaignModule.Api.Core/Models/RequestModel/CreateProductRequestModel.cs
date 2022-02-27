﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignModule.Api.Core.Models.RequestModel
{
    public class CreateProductRequestModel
    {
        public string ProductCode { get; set; }
        public double Price { get; set; }
        public double CurrentPrice { get; set; }
        public int Stock { get; set; }
    }
}
