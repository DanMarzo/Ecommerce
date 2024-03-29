using MediatR;
using Ecommerce.Domain;
using Ecommerce.Application.Features.Products.Vms;

namespace Ecommerce.Application.Features.Products.Queries.GetProductList;

public class GetProductListQuery : IRequest<IReadOnlyList<ProductVm>>
{

}
