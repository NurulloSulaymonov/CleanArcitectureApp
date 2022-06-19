using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;

public class ProfileService : Profile
{
    public ProfileService()
    {
        CreateMap<CategoryDto, Category>();
        CreateMap<ProductDto, Product>();
    }
}
