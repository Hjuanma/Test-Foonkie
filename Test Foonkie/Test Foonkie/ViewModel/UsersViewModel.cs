using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Test_Foonkie.Models;
using Test_Foonkie.Services;
using Test_Foonkie.Views;
using Xamarin.Forms;

namespace Test_Foonkie.ViewModel
{
   public class UsersViewModel : INotifyPropertyChanged
   {

      private ObservableCollection<User> _sers;
      public ICommand ViewDetail { get; private set; }

      public ObservableCollection<User> Users
      {
         get { return _sers; }
         set { SetProperty(ref _sers, value); }
      }


      public UsersViewModel()
      {
         GetData();

         ViewDetail = new Command<User>(
            async (User user) =>
            {
               var page = new UserDetailPage();
               page.BindingContext = user;
               await App.Current.MainPage.Navigation.PushAsync(page);
            });
      }

      private async void GetData()
      {
         var page1 = await PersistenceService.GetAsync<List<User>>("https://reqres.in/api/users?page=1");
         var page2 = await PersistenceService.GetAsync<List<User>>("https://reqres.in/api/users?page=2");

         var userList = page1.Union(page2);

         Users = new ObservableCollection<User>(userList);

      }

      #region INotifyPropertyChanged

      public event PropertyChangedEventHandler PropertyChanged;

      protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
      {
         if (object.Equals(storage, value))
            return false;

         storage = value;
         OnpropertyChanged(propertyName);
         return true;
      }

      private void OnpropertyChanged(string propertyName)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
      #endregion
   }
}
