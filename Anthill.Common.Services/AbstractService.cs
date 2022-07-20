using Anthill.Common.Data.Contracts;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anthill.Common.Services
{
    public class AbstractService
    {
        public AbstractService(IUnityContainer container, IDataContextManager dataContextManager)
        {
            MapperFactory = new MapperFactory(container);
            Container = container;
            DataContextManager = dataContextManager;
        }

        protected MapperFactory MapperFactory { get; private set; }

        protected IUnityContainer Container { get; private set; }

        protected IDataContextManager DataContextManager { get; private set; }
    }
}
