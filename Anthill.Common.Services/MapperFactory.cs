using Anthill.Common.Services.Contracts;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anthill.Common.Services
{
    /// <summary>
    /// Provides implementation for default mapper factory.
    /// </summary>
    public class MapperFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapperFactory" /> class.
        /// </summary>
        public MapperFactory(IUnityContainer container)
        {
            Container = container;
        }

        /// <summary>
        /// The IoC container.
        /// </summary>
        private IUnityContainer Container { get; set; }

        /// <summary>
        /// Returns instances of mappers from IoC container.
        /// </summary>
        public TMapper CreateMapper<TMapper>()
            where TMapper : IMapper
        {
            return Container.Resolve<TMapper>();
        }
    }
}
