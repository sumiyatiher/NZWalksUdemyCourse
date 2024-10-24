using Microsoft.AspNetCore.Identity;

namespace NZWalkz.API.Repo.TokenJWTRepo
{
    public interface IToken
    {
        string CreateToken(IdentityUser user, List<string> roles);
    }
}
