using Ecommerce.Application.Contracts.Infrastructure;
using Ecommerce.Application.Features.Auths.Users.Commands.LoginUser;
using Ecommerce.Application.Features.Auths.Users.VMs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ecommerce.Api.Controllers;

[Route("api/v1/[controller]/[action]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private IMediator _mediator;
    private IManageImageService _imageService;

    public UsuarioController(IMediator mediator, IManageImageService imageService)
    {
        _mediator = mediator;
        _imageService = imageService;
    }
    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginUserCommand request)
    {
        return await _mediator.Send(request);
    }
}
