using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace OneBot.FrameworkDemo.Services
{
    public interface IDatabaseService
    {
        // 
        // �����������ݱ�ʵ�����Լ���΢���ĵ�
        //

        public int SaveChanges();

        public DatabaseFacade Database { get; }
    }
}
