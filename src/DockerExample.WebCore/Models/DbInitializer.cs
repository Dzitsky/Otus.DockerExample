namespace DockerExample.WebCore.Models
{
    /// <summary>
    /// Класс, для заполнения БД. Используется, чтобы проверить, что приложение корректно запустилось
    /// и подключилось к контейнеру с PostgreSQL в докере
    /// </summary>
    public class DbInitializer
    {
        private readonly DockerDbContext _context;

        public DbInitializer(DockerDbContext context)
        {
            this._context = context;
        }

        public void Initialize()
        {
            // Просто удаляем БД, создаём новую и создаём одного пользователя в таблице Users
            this._context.Database.EnsureDeleted();
            this._context.Database.EnsureCreated();

            this._context.AddRange(
                new UserModel{ Id = 1, Name = "Admin" }
            );

            this._context.SaveChanges();
        }
    }
}
