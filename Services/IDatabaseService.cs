using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace OneBot.FrameworkDemo.Services
{
    public interface IDatabaseService
    {
        // 
        // 这里放你的数据表实例，自己看微软文档
        //

        public int SaveChanges();

        public DatabaseFacade Database { get; }
    }
}
