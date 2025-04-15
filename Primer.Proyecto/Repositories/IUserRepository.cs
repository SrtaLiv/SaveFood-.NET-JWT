using Primer.Proyecto.Models;

namespace Primer.Proyecto.Repositories;

public interface IUserRepository
{
    User? findUserEntityByUsername(String username);
    List<User> getUsers();
    User getUserById(int userId);
    User save(User user);
    void delete(int userId);
    User updateUser(User user);
}