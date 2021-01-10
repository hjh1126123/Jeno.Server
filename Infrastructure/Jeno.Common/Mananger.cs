using Autofac;
using Jeno.Common.Features;
using Jeno.Common.Utils;
using Masuit.Tools.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Jeno.Common
{


    public class Mananger
    {
        /// <summary>
        /// 惰性单例
        /// </summary>
        private static readonly Lazy<Mananger> lazy = new Lazy<Mananger>(() =>
        {
            return new Mananger();
        });

        /// <summary>
        /// DI工厂
        /// </summary>
        private ContainerBuilder _containerBuilder;

        /// <summary>
        /// ID工厂
        /// </summary>
        private SnowFlake _snowFlake;

        private Mananger()
        {
            _containerBuilder = new ContainerBuilder();

            _snowFlake = SnowFlake.GetInstance();
        }

        public static Mananger Instance { get { return lazy.Value; } }

        private IContainer _container;

        /// <summary>
        /// 获取autofac的构建实体
        /// </summary>
        /// <returns></returns>
        public T Get<T>()
        {
            if (_container == null)
                _container = _containerBuilder.Build();

            return _container.Resolve<T>();
        }

        /// <summary>
        /// 载入工具库到DI
        /// </summary>
        public void UtilsLoad()
        {
            IocLoad(this.GetType().Assembly);
        }

        /// <summary>
        /// 载入所有拥有AutoFacService特性的对象到DI
        /// </summary>
        /// <param name="assemblies"></param>
        public void IocLoad(params Assembly[] assemblies)
        {
            try
            {
                foreach (var assembly in assemblies)
                {
                    var types = assembly.GetTypes();
                    foreach (var _type in types)
                    {
                        if (_type.IsClass)
                        {
                            var cusAttribute = _type.GetCustomAttribute<DI>();
                            var interfaces = _type.GetInterfaces();

                            if (cusAttribute != null)
                            {
                                SwitchRegisterType(_containerBuilder, _type, cusAttribute.AutoFacInstanceType);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据特性属性注册不同类型的DI
        /// </summary>
        /// <param name="containerBuilder"></param>
        /// <param name="type"></param>
        /// <param name="autoFacInstanceType"></param>
        private void SwitchRegisterType(ContainerBuilder containerBuilder, Type @type, Enum.AutoFacInstanceType autoFacInstanceType)
        {
            var interfaces = type.GetInterfaces();
            if (interfaces.Length <= 0)
            {
                if (type.IsGenericType)
                {
                    switch (autoFacInstanceType)
                    {
                        case Enum.AutoFacInstanceType.Dependency:
                            containerBuilder.RegisterGeneric(type).InstancePerDependency();
                            break;

                        case Enum.AutoFacInstanceType.LifetimeScope:
                            containerBuilder.RegisterGeneric(type).InstancePerLifetimeScope();
                            break;

                        case Enum.AutoFacInstanceType.MatchingLifetimeScope:
                            containerBuilder.RegisterGeneric(type).InstancePerMatchingLifetimeScope();
                            break;

                        case Enum.AutoFacInstanceType.SingleInstance:
                            containerBuilder.RegisterGeneric(type).SingleInstance();
                            break;

                        default:
                            containerBuilder.RegisterGeneric(type).InstancePerDependency();
                            break;
                    }
                }
                else
                {
                    switch (autoFacInstanceType)
                    {
                        case Enum.AutoFacInstanceType.Dependency:
                            containerBuilder.RegisterType(type).InstancePerDependency();
                            break;

                        case Enum.AutoFacInstanceType.LifetimeScope:
                            containerBuilder.RegisterType(type).InstancePerLifetimeScope();
                            break;

                        case Enum.AutoFacInstanceType.MatchingLifetimeScope:
                            containerBuilder.RegisterType(type).InstancePerMatchingLifetimeScope();
                            break;

                        case Enum.AutoFacInstanceType.SingleInstance:
                            containerBuilder.RegisterType(type).SingleInstance();
                            break;

                        default:
                            containerBuilder.RegisterType(type).InstancePerDependency();
                            break;
                    }
                }
            }
            else
            {
                if (type.IsGenericType)
                {
                    switch (autoFacInstanceType)
                    {
                        case Enum.AutoFacInstanceType.Dependency:
                            containerBuilder.RegisterGeneric(type).As(interfaces).InstancePerDependency();
                            break;

                        case Enum.AutoFacInstanceType.LifetimeScope:
                            containerBuilder.RegisterGeneric(type).As(interfaces).InstancePerLifetimeScope();
                            break;

                        case Enum.AutoFacInstanceType.MatchingLifetimeScope:
                            containerBuilder.RegisterGeneric(type).As(interfaces).InstancePerMatchingLifetimeScope();
                            break;

                        case Enum.AutoFacInstanceType.SingleInstance:
                            containerBuilder.RegisterGeneric(type).As(interfaces).SingleInstance();
                            break;

                        default:
                            containerBuilder.RegisterGeneric(type).As(interfaces).InstancePerDependency();
                            break;
                    }
                }
                else
                {
                    switch (autoFacInstanceType)
                    {
                        case Enum.AutoFacInstanceType.Dependency:
                            containerBuilder.RegisterType(type).As(interfaces).InstancePerDependency();
                            break;

                        case Enum.AutoFacInstanceType.LifetimeScope:
                            containerBuilder.RegisterType(type).As(interfaces).InstancePerLifetimeScope();
                            break;

                        case Enum.AutoFacInstanceType.MatchingLifetimeScope:
                            containerBuilder.RegisterType(type).As(interfaces).InstancePerMatchingLifetimeScope();
                            break;

                        case Enum.AutoFacInstanceType.SingleInstance:
                            containerBuilder.RegisterType(type).As(interfaces).SingleInstance();
                            break;

                        default:
                            containerBuilder.RegisterType(type).As(interfaces).InstancePerDependency();
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 获取ID
        /// </summary>
        /// <param name="prefix">ID前缀</param>
        /// <returns></returns>
        public string GetUniqueID(string prefix)
        {
            return prefix + _snowFlake.GetLongId();
        }
    }
}
