﻿using FluentAssertions.AspNetCore.Mvc.Sample.Models;
using System.Collections.Generic;

namespace FluentAssertions.AspNetCore.Mvc.Sample.Services
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetProducts();
    }
}
