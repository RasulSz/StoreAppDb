using StoreApp.ViewModels.BaseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.ViewModels.UserControlViewModel
{
    public class ProductsUserControlViewModel : BaseViewModels
    {
        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; OnPropertyChanged(); }
        }

        private int productQuantity;

        public int ProductQuantity
        {
            get { return productQuantity; }
            set { productQuantity = value; OnPropertyChanged(); }
        }

        private string productPrice;

        public string ProductPrice
        {
            get { return productPrice; }
            set { productPrice = value; OnPropertyChanged(); }
        }
    }
}
