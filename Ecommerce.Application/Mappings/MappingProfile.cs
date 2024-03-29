using AutoMapper;
using Ecommerce.Application.Features.Images.Queries.Vms;
using Ecommerce.Application.Features.Products.Vms;
using Ecommerce.Application.Features.Reviews.Queries.Vms;
using Ecommerce.Domain;

namespace Ecommerce.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductVm>()
            .ForMember(x => x.CategoryNombre, x => x.MapFrom(x => x.Category!.Nombre))
            .ForMember(x => x.NumeroReviews, x => x.MapFrom(x => x.Reviews == null ? 0 : x.Reviews.Count))
            .ReverseMap();

        CreateMap<Image, ImageVm>().ReverseMap();
        CreateMap<Review, ReviewVm>().ReverseMap();
    }
}
