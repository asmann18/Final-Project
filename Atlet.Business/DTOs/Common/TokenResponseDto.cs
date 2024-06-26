﻿using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.Common;

public class TokenResponseDto:IDto
{
    public TokenResponseDto(string token,DateTime expires,string userName,string role)
    {
        Token=token;
        Expires=expires;    
        UserName=userName;
        Role=role;

    }
    public string Token { get; init; }
    public DateTime Expires { get; init; }
    public string UserName { get ; init; }
    public string Role { get; set; }
}
