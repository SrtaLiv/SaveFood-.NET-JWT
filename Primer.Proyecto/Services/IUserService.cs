using Primer.Proyecto.DTO;
using Primer.Proyecto.Models;

namespace Primer.Proyecto.Services;

public interface IUserService
{
    public List<User> findAll();
    public User findById(int id);
    public User save(User userSec);
    public void deleteById(int id);
    public void update(User userSec);
    public String encriptPassword(String password);
    public User? FindByUser(String email);
    //User updateUserImage(UserSec user, MultipartFile file) throws IOException;

    public String? Login(UserDTO user);
}