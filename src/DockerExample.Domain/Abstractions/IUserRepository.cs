namespace DockerExample.Domain.Abstractions
{
    /// <summary>
    /// Объявляем интерфейс (ПОРТ), который необходим нашему домену для работоспособности.
    /// Наш домен будет зависеть от этого интерфейса, но не от конкретной реализации.
    /// Плюс, т.к. этот интерфейс определён в самом проекте Domain, то наш доменный проект не зависит от других проектов
    /// </summary>
    public interface IUserRepository
    {
        UserDataModel GetById(long userId);
    }

    public class UserDataModel
    {
        public long Id { get; }

        public string Name { get; }

        public UserDataModel(long id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
