using System.Collections.Generic;
using System.Linq;
using ReadingIsGood.Business.DTO.Request;
using ReadingIsGood.Business.DTO.Response;
using ReadingIsGood.Data.Entity;
using ReadingIsGood.Data.Interface;

namespace ReadingIsGood.Data.Service
{
    public class UserService : IUserService
    {
        private readonly IJwtService _jwtService;

        private readonly List<User> _users = new List<User>()
        {
            new User {Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test"}
        };

        public UserService(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            if (user == null) return null;

            var token = _jwtService.GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }
    }
}