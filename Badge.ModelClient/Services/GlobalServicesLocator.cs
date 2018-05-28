using Badge.ModelGlobal.Services;
using Patterns.Locator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.ModelClient.Services
{
    class GlobalServicesLocator:LocatorBase
    {
        private static GlobalServicesLocator _Instance;

        public static GlobalServicesLocator Instance
        {
            get { return _Instance ?? (_Instance = new GlobalServicesLocator()); }
        }

        private GlobalServicesLocator()
        {
            Container.Register<CategoryRepository>();
            Container.Register<ProductRepository>();
        }

        public T GetRepository<T>()
        {
            return Container.GetInstance<T>();
        }

        public CategoryRepository GetCategoryRepository()
        {
            return Container.GetInstance<CategoryRepository>();
        }

        public ProductRepository GetProductRepository()
        {
            return Container.GetInstance<ProductRepository>();
        }

    }
}
