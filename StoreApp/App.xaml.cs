using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StoreApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static WrapPanel MyShow { get; set; } = new WrapPanel();
        public static WrapPanel MyCategories { get; set; } = new WrapPanel();
    }
}
