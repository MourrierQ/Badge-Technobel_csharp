using Badge.ModelClient.Models;
using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.UI.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private string _DisplayName;

        public string DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; }
        }

        private decimal _Price;

        public decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }


        public ProductViewModel(Product p)
        {
            DisplayName = p.ProductName;
            Price = p.Price;
        }

    }
}
