using System;

namespace DockerExample.Domain
{
    public interface IUserAppService
    {
        User GetById(long id);
    }

    public class User
    {
        public long Id { get; }

        public string Name { get; }

        public DateTime AccessTime { get; }

        public User(long id, string name, DateTime accessTime)
        {
            this.Id = id;
            this.Name = name;
            this.AccessTime = accessTime;
        }
    }
}
