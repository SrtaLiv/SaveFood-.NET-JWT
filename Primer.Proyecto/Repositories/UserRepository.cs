using Primer.Proyecto.Bd;
using Primer.Proyecto.Models;

namespace Primer.Proyecto.Repositories;

public class UserRepository : IUserRepository
{
    
    private readonly BloggingContext _context;

    public UserRepository(BloggingContext context)
    {
        _context = context;
    }
    
    public User? findUserEntityByUsername(string username)
    {
        return _context.Users.FirstOrDefault(x => x.Username == username);
    }

    public List<User> getUsers()
    {
        return _context.Users.ToList();
    }

    public User getUserById(int userId)
    {
        return _context.Users.Find(userId);
    }

    public User save(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public void delete(int userId)
    {
        var user = _context.Users.Find(userId);
        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }

    public User updateUser(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
        return user;
    }

    public List<User> findAll()
    {
        return  _context.Users.ToList();
    }
}