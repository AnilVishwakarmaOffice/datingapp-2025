using System;
using API.DTOs;
using API.Entities;
using API.Interfaces;

namespace API.Extensions;

public static class AppUserExtensions
{
    public static UserDto ToDto(this AppUser user, ITokenService _tokenService)
    {
        return new UserDto
        {
            Id = user.Id.ToString(),
            Email = user.Email,
            DisplayName = user.DisplayName,
            ImageUrl = user.ImageUrl,
            Token = _tokenService.CreateToken(user)
        };
    }

}
