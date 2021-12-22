using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Foonkie.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test_Foonkie.Views
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class UserDetailPage : ContentPage
   {
      private User user;

      public User User { get => user; set => SetView(value); }

      private void SetView(User value)
      {
         user = value;
         Avatar.Source = user.Avatar;
         FirstName.Text = user.FirstName;
         LastName.Text = user.LastName;
         Email.Text = user.Email;

      }

      public UserDetailPage()
      {
         InitializeComponent();
      }
   }
}