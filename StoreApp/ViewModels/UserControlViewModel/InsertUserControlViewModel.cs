using StoreApp.Commands;
using StoreApp.Models;
using StoreApp.Repository;
using StoreApp.ViewModels.BaseViewModel;
using StoreApp.ViewModels.MainWindowViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.ViewModels.UserControlViewModel
{
    public class InsertUserControlViewModel : BaseViewModels
    {
        public RelayCommand InsertCommand { get; set; }
        public RelayCommand BackCommand { get; set; }

        private ObservableCollection<Category> allCategory;

        public ObservableCollection<Category> AllCategory
        {
            get { return allCategory; }
            set { allCategory = value; OnPropertyChanged(); }
        }

        public Repositories ProductsRepo { get; set; }

        private string pName;

        public string PName
        {
            get { return pName; }
            set { pName = value; OnPropertyChanged(); }
        }

        private int pPrice;

        public int PPrice
        {
            get { return pPrice; }
            set { pPrice = value; OnPropertyChanged(); }
        }

        private int pQuantity;

        public int PQuantity
        {
            get { return pQuantity; }
            set { pQuantity = value; OnPropertyChanged(); }
        }


        public async Task GetAllCategories()
        {
            await ProductsRepo.GetAllCategories(AllCategory);
        }


        public InsertUserControlViewModel()
        {

            ProductsRepo = new Repositories();
            GetAllCategories();

            InsertCommand = new RelayCommand((obj) =>
            {

                ProductsRepo.Insert(PName, PPrice, PQuantity);
                PName = String.Empty;
                PPrice = 0;
                PQuantity = 0;
            });

            BackCommand = new RelayCommand((obj) =>
            {
                var vm = new MainViewModel();
            });
        }
    }
}
