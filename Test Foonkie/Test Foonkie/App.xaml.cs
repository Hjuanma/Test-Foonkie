using MonkeyCache.FileStore;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test_Foonkie
{
   public partial class App : Application
   {
      public App()
      {
         InitializeComponent();
         Barrel.ApplicationId = "FoonkieCache";
         MainPage = new NavigationPage(new MainPage());
      }

      protected override void OnStart()
      {
      }

      protected override void OnSleep()
      {
      }

      protected override void OnResume()
      {
      }
   }
}
