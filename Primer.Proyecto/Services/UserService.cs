using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Primer.Proyecto.DTO;
using Primer.Proyecto.Models;
using Primer.Proyecto.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Primer.Proyecto.Services;

public class UserService : IUserService
{
    private readonly IConfiguration configuration;
    private IUserRepository userRepository;

    public UserService(IConfiguration configuration, IUserRepository userRepository)
    {
        this.configuration = configuration;
        this.userRepository = userRepository;
    }

    public List<User> findAll()
    {
        
        throw new NotImplementedException();
    }

    public User findById(int id)
    {
        throw new NotImplementedException();
    }

    public User save(User userSec)
    {
        return userRepository.save(userSec);
    }

    public void deleteById(int id)
    {
        userRepository.delete(id);
    }

    public void update(User userSec)
    {
        userRepository.updateUser(userSec);
    }
    
    public User? FindByUser(string username)
    {
        return userRepository.findUserEntityByUsername(username);
    }
    
    public string? Login(UserDTO res)
    {
        var user = userRepository.findUserEntityByUsername(res.Username);

        if (user == null || user.PasswordHash != res.Password)
            return null;
        
        string encryptedPassword = encriptPassword(res.Password);
        res.Password = encryptedPassword;
        
        // 1. crea los claims
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        // 2. obtiene la clave del appsettings.json
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // 3. crear el token
        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(60),
            signingCredentials: creds
        );

        // 4. devuelve el JWT como string
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
    public string encriptPassword(string password)
    {
        using (var sha256 = System.Security.Cryptography.SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
    }
}