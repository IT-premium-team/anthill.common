using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anthill.Common.AzureJob
{
    public class ContainerConfiguration
    {

        public static void RegisterTypes<TLifetime>(IUnityContainer container)
            where TLifetime : LifetimeManager, new()
        {
            container.RegisterType<IJobActivator, JobActivator>();
            container.RegisterType<JobHostConfiguration>();
        }
    }
}
