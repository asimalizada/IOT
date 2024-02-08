﻿using Ninject;
using Ninject.Modules;

namespace IOTSystem.IoC
{
    internal class InstanceFactory
    {
        public static T GetInstance<T>(NinjectModule module)
        {
            var kernel = new StandardKernel(module);
            return kernel.Get<T>();
        }

        public static T GetInstance<T>(INinjectModule[] modules)
        {
            var kernel = new StandardKernel(modules);
            return kernel.Get<T>();
        }
    }
}
