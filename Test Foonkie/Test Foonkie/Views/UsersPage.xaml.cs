using Test_Foonkie.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test_Foonkie.Views
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class UsersPage : ContentPage
   {

      UsersViewModel vm = new UsersViewModel();

      public UsersPage()
      {
         InitializeComponent();
         BindingContext = vm;

      }
   }
}