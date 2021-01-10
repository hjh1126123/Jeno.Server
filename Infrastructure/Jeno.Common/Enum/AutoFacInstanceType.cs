using System;
using System.Collections.Generic;
using System.Text;

namespace Jeno.Common.Enum
{
    public enum AutoFacInstanceType
    {
        /// <summary>
        /// 对每一个依赖或每一次调用创建一个新的唯一的实例。这也是默认的创建实例的方式。
        /// </summary>
        Dependency = 0,

        /// <summary>
        /// 在一个生命周期域中，每一个依赖或调用创建一个单一的共享的实例，且每一个不同的生命周期域，实例是唯一的，不共享的。
        /// </summary>
        LifetimeScope = 1,

        /// <summary>
        /// 在一个做标识的生命周期域中，每一个依赖或调用创建一个单一的共享的实例。打了标识了的生命周期域中的子标识域中可以共享父级域中的实例。若在整个继承层次中没有找到打标识的生命周期域，则会抛出异常
        /// </summary>
        MatchingLifetimeScope = 2,

        /// <summary>
        /// 每一次依赖组件或调用Resolve()方法都会得到一个相同的共享的实例。其实就是单例模式。
        /// </summary>
        SingleInstance = 3
    }
}
