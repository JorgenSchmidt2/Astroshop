using Astroshop.Core.Interfaces;
using Astroshop.Core.Responses;

namespace Data.Services
{
    public class UserService : IUser
    {
        public Task<Response> LoginUser(object input)
        {
            throw new NotImplementedException();
        }

        public Task<Response> RecoverPassword(object input)
        {
            throw new NotImplementedException();
        }

        public Task<Response> RegisterUser(object input)
        {
            throw new NotImplementedException();
        }

        public Task<Response> TranslateUserToken(object input)
        {
            throw new NotImplementedException();
        }
    }
}