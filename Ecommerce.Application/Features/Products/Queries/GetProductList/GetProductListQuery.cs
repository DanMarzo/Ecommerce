using MediatR;
using Ecommerce.Domain;

namespace Ecommerce.Application.Features.Products.Queries.GetProductList;

public class GetProductListQuery : IRequest<List<Product>>
{

}
