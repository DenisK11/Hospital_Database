using Hospital_DataBase_API.Data;
using Hospital_DataBase_API.Models;
using Hospital_DataBase_API.Models.Dto;
using Hospital_DataBase_API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;

namespace Hospital_DataBase_API.Controllers
{
    [Route("api/UsersAuth")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly ISectionRepository _dbSection;
        private readonly IUserRepository _userRepo;
        protected APIResponse _response;

        private readonly ApplicationDbContext _userContext;

        public UsersController(IUserRepository userRepo, ISectionRepository dbSection, ApplicationDbContext userContext)
        {
            _userRepo = userRepo;
            _response = new();
            _dbSection = dbSection;
            _userContext = userContext;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var loginResponse = await _userRepo.Login(model);
            if(loginResponse != null)
            {
                if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Username or password is incorect");
                    return BadRequest(_response);
                } else
                {
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = true;
                    _response.Result = loginResponse;
                    return Ok(_response);
                }
            }

            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.IsSuccess = false;
            _response.ErrorMessages.Add("Username or password is incorect");
            return BadRequest(_response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
        {
           
            if (await _dbSection.GetAsync(u => u.Name.ToLower() == model.SectionName.ToLower()) == null)
            {
                ModelState.AddModelError("CustomError", "Section Name is Invalid!");
                return BadRequest(ModelState);
            }

            bool ifUserNameUnique = _userRepo.IsUniqueUser(model.UserName, model.CNP, model.PhoneNumber);
            if (!ifUserNameUnique)
            {
                _response.StatusCode = HttpStatusCode.BadRequest; 
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("User already exists");
                return BadRequest(_response);
            }
            var user = await _userRepo.Register(model);
            if (user == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Error while registering");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IEnumerable<User>> Get() => await _userContext.Users.ToListAsync();

        [HttpGet("string")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByRole(string role)
        {

            List<User> list = new List<User>();

            foreach (var user in _userContext.Users )
            {
                if (user.Role == role)
                    list.Add(user);

            }

            return list == null ? NotFound() : Ok(list);
        }

    }
}
