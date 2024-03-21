using System;
using System.Collections.Generic;
using System.Linq;

namespace IOTSystem.Business.Concrete
{
    internal class BaseService
    {
        protected TTarget Map<TCurrent, TTarget>(TCurrent source)
        {
            var data = Activator.CreateInstance<TTarget>();

            var targetProperties = source.GetType().GetProperties();
            var destinationProperties = data.GetType().GetProperties();

            foreach (var dp in destinationProperties)
            {
                var val = targetProperties.FirstOrDefault(p => p.Name == dp.Name)?.GetValue(source);
                dp.SetValue(data, val);
            }

            return data;
        }

        protected List<TTarget> Map<TCurrent, TTarget>(List<TCurrent> source)
        {
            var result = new List<TTarget>();

            foreach (var item in source)
            {
                result.Add(Map<TCurrent, TTarget>(item));
            }

            return result;
        }
    }
}
