using System;
using DockerExample.Domain.Abstractions;

namespace DockerExample.Domain
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;

        public UserAppService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public User GetById(long id)
        {
            var user = this._userRepository.GetById(id);

            return new User(user.Id, user.Name, DateTime.Now);
        }
    }
}
