using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OneBot.FrameworkDemo.Models.VO;

namespace OneBot.FrameworkDemo.Services.Implements
{
    public class MySqlDataBaseService : DataBaseService
    {
        private readonly DatabaseManagementModel _connectionInfo;

        public MySqlDataBaseService(IOptions<DatabaseManagementModel> databaseManagementModel)
        {
            _connectionInfo = databaseManagementModel.Value;
        }

        public MySqlDataBaseService(DatabaseManagementModel databaseManagementModel)
        {
            _connectionInfo = databaseManagementModel;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (_connectionInfo.Type.ToLower() == "mysql")
            {
                options.UseMySql(_connectionInfo.ConnectionInformation,
                    new MySqlServerVersion(new Version(_connectionInfo.ServerVersion)));
            } else if (_connectionInfo.Type.ToLower() == "mariadb")
            {
                options.UseMySql(_connectionInfo.ConnectionInformation,
                    new MariaDbServerVersion(new Version(_connectionInfo.ServerVersion)));
            }
            else throw new ArgumentOutOfRangeException();
        
        }   
    }
}
