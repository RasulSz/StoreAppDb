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


        public Repositories ProductsRepository { get; set; }


        public MainViewModel()
        {
            ProductsRepository = new Repositories();
            AllProducts = ProductsRepo.GetAllProduct();

            AllCategories = ProductsRepo.GetAllCategories();

            ProductUC productUC;
            ProductsViewModel productsViewModel;
            for (int i = 0; i < AllProducts.Count; i++)
            {
                productUC = new ProductUC();
                productsViewModel = new ProductsViewModel();
                productsViewModel.ProductName = AllProducts[i].Name;
                productsViewModel.ProductPrice = $"{AllProducts[i].Price} $";
                productsViewModel.ProductQuantity = AllProducts[i].Quantity;
                productsViewModel.ImagePath = AllProducts[i].ImagePath;
                productUC.DataContext = productsViewModel;
                App.MyGrid.Children.Add(productUC);
            }

            CategoriesUC categoriesUC;
            CategoryUcViewModel categoryUcViewModel;
            for (int i = 0; i < AllCategories.Count; i++)
            {
                categoriesUC = new CategoriesUC();
                categoryUcViewModel = new CategoryUcViewModel();
                categoryUcViewModel.CategoryName = AllCategories[i].Name;
                categoriesUC.DataContext = categoryUcViewModel;
                App.MyWrapPanel.Children.Add(categoriesUC);
            }

            InsertCommand = new RelayCommand((obj) =>
            {

            });
        }
