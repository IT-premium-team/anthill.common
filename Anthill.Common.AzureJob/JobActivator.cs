using Microsoft.Azure.WebJobs.Host;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anthill.Common.AzureJob
{
    public class JobActivator : IJobActivator
    {
        private readonly IUnityContainer _container;

        public JobActivator(IUnityContainer container)
        {
            _container = container;
        }

        public T CreateInstance<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
