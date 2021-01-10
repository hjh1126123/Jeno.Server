using Jeno.Common.Enum;
using Jeno.Common.Features;
using Jeno.Common.Utils;
using System;
using Xunit.Abstractions;

namespace Jeno.XUnit.Service
{
    public interface ITestService
    {
        public void OutPutMsg(ITestOutputHelper testOutputHelper, ref int i);

        public void OutPutMemoryInfo(ITestOutputHelper testOutputHelper);
    }

    [DI(autoFacInstanceType: AutoFacInstanceType.Dependency)]
    public class TestService : ITestService
    {
        SystemUtils _systemUtils;

        public TestService(SystemUtils systemUtils)
        {
            _systemUtils = systemUtils;
        }

        public void OutPutMemoryInfo(ITestOutputHelper testOutputHelper)
        {
            var info = _systemUtils.GetComputedInfo();

            testOutputHelper.WriteLine("物理内存使用情况：{0}", info.MemoryPData);
            testOutputHelper.WriteLine("虚拟内存使用情况：{0}", info.MemoryVData);
        }

        public void OutPutMsg(ITestOutputHelper testOutputHelper, ref int i)
        {
            testOutputHelper.WriteLine("测试1：{0}", ++i);
        }
    }
}
