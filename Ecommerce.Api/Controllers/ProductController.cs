﻿using Ecommerce.Application.Features.Products.Queries.GetProductList;
using Ecommerce.Application.Features.Products.Vms;
using Ecommerce.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ecommerce.Api.Controllers;

[Route("api/v1/[controller]/[action]")]
[ApiController]
public class ProductController : ControllerBase
{
    private IMediator _mediator;
    public ProductController(IMediator mediator) => _mediator = mediator;

    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ProductVm>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IReadOnlyList<ProductVm>>> GetProductList()
    {
        var query = new GetProductListQuery();
        var productos = await _mediator.Send(query);
        return Ok(productos);
    }
}
