using Badge.ModelClient.Models;
using Badge.UI.Repositories;
using MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.UI.ViewModels
{
    public class CategoryViewModel: ViewModelBase
    {
        private string _CategoryName;

        public string CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }

        private ObservableCollection<ProductViewModel> _Products;

        public ObservableCollection<ProductViewModel> Products
        {
            get
            {
                return _Products ?? (_Products = new ObservableCollection<ProductViewModel>()); 
            }
            set { _Products = value; }
        }

        public CategoryViewModel(string name, int id)
        {
            CategoryName = name;
            IEnumerable<Product> prods = RepositoryLocator.Instance.GetProductRepository().GetByCategory(id);
            
            if(prods != null)
            {
                foreach(Product p in prods)
                {
                    Products.Add(new ProductViewModel(p));
                }
            }
        }

    }
}
