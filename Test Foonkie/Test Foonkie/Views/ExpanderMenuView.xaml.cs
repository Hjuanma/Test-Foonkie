using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test_Foonkie.Views
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class ExpanderMenuView : ContentView
   {
      public ExpanderMenuView()
      {
         InitializeComponent();
      }

      private async void AddIconClicked(object sender, EventArgs e)
      {

         if (!(App.Current.MainPage.Navigation.NavigationStack.LastOrDefault() is UsersPage))
         {
            await Navigation.PushAsync(new UsersPage());
         }
      }
      private async void HomeIconClicked(object sender, EventArgs e)
      {
         if(!(App.Current.MainPage.Navigation.NavigationStack.LastOrDefault() is MainPage))
         {
            await App.Current.MainPage.Navigation.PopToRootAsync();
         }
      }


   }
}