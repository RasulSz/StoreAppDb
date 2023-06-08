using StoreApp.Commands;
using StoreApp.Models;
using StoreApp.ViewModels.BaseViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApp.Repository;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using StoreApp.ViewModels.UserControlViewModel;
using StoreApp.Views.UserControls;

namespace StoreApp.ViewModels.MainWindowViewModel
{
    public class MainViewModel : BaseViewModels
    {
        public RelayCommand InsertCommand { get; set; }

        private ObservableCollection<Product> allProducts;

        public ObservableCollection<Product> AllProducts
        {
            get { return allProducts; }
            set { allProducts = value; }
        }

        private ObservableCollection<Category> allCategories;

        public ObservableCollection<Category> AllCategories
        {
            get { return allCategories; }
            set { allCategories = value; }
        }


        public Repositories ProductsRepo { get; set; }

        public async Task GetAllCategories()
        {
            await ProductsRepo.GetAllCategories(AllCategories);
        }

        public async Task GetAllProducts()
        {
            await ProductsRepo.GetAllProduct(AllProducts);
        }

      

        public async void CallProductUC()
        {
            await GetAllProducts();

            App.MyShow.Children.Clear();
            ProductsUserControl productUC;
            ProductsUserControlViewModel productsViewModel;
            for (int i = 0; i < AllProducts.Count; i++)
            {
                productUC = new ProductsUserControl();
                productsViewModel = new ProductsUserControlViewModel();
                productsViewModel.ProductName = AllProducts[i].Name;
                productsViewModel.ProductPrice = $"{AllProducts[i].Price} $";
                productsViewModel.ProductQuantity = AllProducts[i].Quantity;
                productUC.DataContext = productsViewModel;
                App.MyShow.Children.Add(productUC);
            }
        }

        public MainViewModel()
        {
            AllProducts = new ObservableCollection<Product>();
            AllCategories = new ObservableCollection<Category>();
            ProductsRepo = new Repositories();

            CallProductUC();

            InsertCommand = new RelayCommand((obj) =>
            {
                InsertUserControl insertUC = new InsertUserControl();
                InsertUserControlViewModel insertUCVM = new InsertUserControlViewModel();
                App.MyShow.Children.Clear();
                App.MyShow.Children.Add(insertUC);
            });
        }
    }
}
