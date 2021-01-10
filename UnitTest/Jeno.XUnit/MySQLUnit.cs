using System;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Jeno.XUnit
{
    public class MySQLUnit
    {
        private readonly ITestOutputHelper output;

        public MySQLUnit(ITestOutputHelper tempOutput)
        {
            output = tempOutput;
        }

        [Fact(DisplayName = "获取所有实体对象")]
        public void GetAllEntity()
        {
            if (output != null)
            {
                output.WriteLine("进入测试");
            }
            else { Console.WriteLine("进入测试"); }

            var types = Dto.Mananger.Instance.GetTypesByTableAttribute();


            foreach (var @type in types)
            {
                if (output != null)
                {
                    output.WriteLine(type.FullName);
                }
                else { Console.WriteLine(type.FullName); }
            }


        }

        [Fact(DisplayName = "初始化数据库")]
        public void InitDB()
        {
            try
            {
                Redis.Mananger.Instance.BuildCluster(new Redis.RedisModel(ip: "127.0.0.1", port: 1400),
                    new Redis.RedisModel(ip: "127.0.0.1", port: 1401),
                    new Redis.RedisModel(ip: "127.0.0.1", port: 1402));

                Dto.Mananger.Instance.Init("Server=localhost;Database=my_server;UID=root;Password=hjh1126123", SqlSugar.DbType.MySql, "hjh1126123");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
