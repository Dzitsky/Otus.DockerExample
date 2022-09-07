using System.Collections.Generic;
using System.Linq;
using DockerExample.Domain.Abstractions;

namespace DockerExample.DataAccess
{
    /// <summary>
    /// Реализация интерфейса, необходимого домену. По сути - это адаптер, который подключается к порту IUserRepository
    /// </summary>
    public class UserRepository : IUserRepository
    {
        // В данном конкретном адаптере мы храним данные в памяти, но можем безболезненно заменить этот адаптер другим,
        // который будет хранить данные в другом месте.
        private readonly List<UserDataModel> _users = new List<UserDataModel>();

        public UserRepository()
        {
            this._users.AddRange(
                new List<UserDataModel>
                {
                    new UserDataModel(1, "Name #1"),
                    new UserDataModel(1, "Name #2"),
                    new UserDataModel(1, "Name #3"),
                    new UserDataModel(1, "Name #4"),
                    new UserDataModel(1, "Name #5"),
                }
            );
        }

        public UserDataModel GetById(long userId)
        {
            return this._users.First(item => item.Id == userId);
        }
    }
}
