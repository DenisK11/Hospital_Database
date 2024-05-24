using Hospital_DataBase_API.Models;
using Hospital_DataBase_API.Models.Dto;

namespace Hospital_DataBase_API.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username, string cnp, string phonenumber);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<User> Register(RegistrationRequestDTO registrationRequestDTO);
    }
}
