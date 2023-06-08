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

        public async void CallCategoryUC()
        {
            await GetAllCategories();

            App.MyCategories.Children.Clear();
            CategoriesUserControl categoriesUC;
            CategoriesUserControlViewModel categoryUcViewModel;
            for (int i = 0; i < AllCategories.Count; i++)
            {
                categoriesUC = new CategoriesUserControl();
                categoryUcViewModel = new CategoriesUserControlViewModel();
                categoryUcViewModel.CategoryName = AllCategories[i].Name;
                categoriesUC.DataContext = categoryUcViewModel;
                App.MyCategories.Children.Add(categoriesUC);
            }
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
            CallCategoryUC();

            InsertCommand = new RelayCommand((obj) =>
            {
                //InsertUserControl insertUC = new InsertUserControl();
                //InsertUCViewModel insertUCVM = new InsertUCViewModel();
                //App.MyGrid.Children.Clear();
                //App.MyGrid.Children.Add(insertUC);
            });

        }
    }
}
