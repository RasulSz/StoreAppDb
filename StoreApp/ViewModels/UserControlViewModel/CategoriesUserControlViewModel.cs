using StoreApp.ViewModels.BaseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.ViewModels.UserControlViewModel
{
    public class CategoriesUserControlViewModel : BaseViewModels
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

        private string categoryName;

        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; OnPropertyChanged(); }
        }

    }
}
