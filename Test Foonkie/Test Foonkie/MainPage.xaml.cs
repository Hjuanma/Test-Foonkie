using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Foonkie.ViewModel;
using Xamarin.Forms;

namespace Test_Foonkie
{
   public partial class MainPage : ContentPage
   {
      public MainViewModel vm;
      public MainPage()
      {
         InitializeComponent();
         BindingContext = vm = new MainViewModel();
      }
   }
}
