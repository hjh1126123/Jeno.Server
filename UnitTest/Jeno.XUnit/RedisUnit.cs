using System;

namespace Jeno.XUnit
{
    public class RedisUnit
    {
        public void Go()
        {
            try
            {
                Redis.Mananger.Instance.BuildCluster(new Redis.RedisModel(ip: "127.0.0.1", port: 1400),
                   new Redis.RedisModel(ip: "127.0.0.1", port: 1401),
                   new Redis.RedisModel(ip: "127.0.0.1", port: 1402));


                Redis.Mananger.Instance.Get().Set("A", Guid.NewGuid().ToString());

                Console.WriteLine("成功");

                while (true)
                {
                    Console.WriteLine("输入get获取redis内容");

                    var put = Console.ReadLine();

                    switch (put)
                    {
                        case "get":
                            var res = Redis.Mananger.Instance.Get().Get("A");

                            Console.WriteLine(res);
                            break;
                    }
                }


            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
        }
    }
}
