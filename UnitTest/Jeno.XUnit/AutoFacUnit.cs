using Jeno.XUnit.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Xunit;
using System.Reflection;
using Xunit.Abstractions;
using Jeno.Common.Features;

namespace Jeno.XUnit
{
    public class AutoFacUnit
    {
        private readonly ITestOutputHelper output;

        public AutoFacUnit(ITestOutputHelper tempOutput)
        {
            output = tempOutput;
        }

        [Fact(DisplayName = "初始化DI")]
        public void Init()
        {
            Common.Mananger.Instance.UtilsLoad();
            Common.Mananger.Instance.IocLoad(Assembly.GetExecutingAssembly());
        }

        [Fact(DisplayName = "输出内存信息")]
        public void OutPutMemory()
        {
            Init();

            Common.Mananger.Instance.Get<ITestService>().OutPutMemoryInfo(output);
        }

        [Fact(DisplayName = "输出特性信息")]
        public void OutputAssembly()
        {
            Type autoFacServiceType = typeof(DI);

            if (typeof(TestService).IsDefined(autoFacServiceType, true))
            {
                output.WriteLine("符合对象");
            }
            else
            {
                output.WriteLine("不符合对象");
            }
        }

        [Fact(DisplayName = "AutoFac效率测试")]
        public void AutoFacTest()
        {
            Init();

            int i = 0;

            for (var j = 0; j < 1000000; j++)
            {
                try
                {
                    Common.Mananger.Instance.Get<ITestService>().OutPutMsg(output, ref i);
                    Common.Mananger.Instance.Get<TestService2>().OutPutMsg(output, ref i);
                    Common.Mananger.Instance.Get<TestService3>().OutPutMsg(output, ref i);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        [Fact(DisplayName = "生成ID")]
        public void GetID()
        {
            output.WriteLine(Common.Mananger.Instance.GetUniqueID("100001"));
        }
    }
}
