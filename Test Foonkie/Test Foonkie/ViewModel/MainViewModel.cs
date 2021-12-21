using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Test_Foonkie.ViewModel
{
   public class MainViewModel : INotifyPropertyChanged
   {
      public event PropertyChangedEventHandler PropertyChanged;

      public ICommand GoToMailCommand { get; private set; }

      public MainViewModel()
      {
         GoToMailCommand = new Command(
            execute: async () =>
            {
               await SendEmail("I want a quote", "I need you to build an application");
            });
      }

      public async Task SendEmail(string subject, string body, List<string> recipients = null)
      {
         try
         {
            var message = new EmailMessage
            {
               Subject = subject,
               Body = body,
               To = recipients,
            };
            await Email.ComposeAsync(message);
         }
         catch (FeatureNotSupportedException fbsEx)
         {
            // Email is not supported on this device
         }
         catch (Exception ex)
         {
            // Some other exception occurred
         }
      }

      bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
      {
         if (Object.Equals(storage, value))
            return false;

         storage = value;
         OnPropertyChanged(propertyName);
         return true;
      }

      protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
   }
}
