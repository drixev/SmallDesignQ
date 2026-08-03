namespace GenerateService.Infraestructure.Security.Authentication;

public interface IJwtService
{
    string GenerateToken(string userName);
}