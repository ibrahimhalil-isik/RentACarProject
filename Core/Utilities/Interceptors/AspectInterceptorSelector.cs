using Castle.DynamicProxy;
using Core.Aspects.Autofac.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{

    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);

            //Bu kod bütün methodları Log'a dahil eder...
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));

            // Bu kod bütün methodları PerformanceAspect'e dahil eder...
            classAttributes.Add(new PerformanceAspect(5));
            
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
