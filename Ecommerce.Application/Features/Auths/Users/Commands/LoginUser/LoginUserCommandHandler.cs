using AutoMapper;
using Ecommerce.Application.Contracts.Identity;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Features.AddressFe.VMs;
using Ecommerce.Application.Features.Auths.Users.VMs;
using Ecommerce.Application.Persistence;
using Ecommerce.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Features.Auths.Users.Commands.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthResponse>
{
    private readonly UserManager<Usuario> _userManager;
    private readonly SignInManager<Usuario> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public LoginUserCommandHandler(
        UserManager<Usuario> userManager,
        SignInManager<Usuario> signInManager,
        RoleManager<IdentityRole> roleManager,
        IAuthService authService,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _authService = authService;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<AuthResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email) ?? throw new NotFoundException(nameof(Usuario), request.Email);
        if (!user.IsActive) throw new Exception("El usuario esta bloqueado, contate o admin");

        var resultado = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (!resultado.Succeeded) throw new Exception("Las credenciales son erroneas");

        var recordDirecion = await _unitOfWork.Repository<Address>().GetEntityAsync(
            x => x.Username == user.UserName);
        var roles = await _userManager.GetRolesAsync(user);
        var authResponse = new AuthResponse();

        authResponse.Id = user.Id;
        authResponse.UserName = user.UserName;
        authResponse.Apellido = user.Apellido;
        authResponse.Avatar = user.AvatarURL;
        authResponse.Email = user.Email;
        authResponse.Nombre = user.Nombre;
        authResponse.Telefono = user.Telefono;
        authResponse.DireccionEnvio = _mapper.Map<AddressVm>(recordDirecion);
        authResponse.Token = _authService.CreateToken(user, roles);
        authResponse.Roles = roles;

        return authResponse;
    }
}
