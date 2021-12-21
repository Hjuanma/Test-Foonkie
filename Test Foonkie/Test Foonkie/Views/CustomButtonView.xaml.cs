
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test_Foonkie.Views
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class CustomButtonView : ContentView
   {
      public CustomButtonView()
      {
         InitializeComponent();
      }

      public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(CustomButtonView), default(string), propertyChanged: TitleTextPropertyChanged);

      public static readonly BindableProperty ButtonComandProperty = BindableProperty.Create(nameof(ButtonComand), typeof(ICommand), typeof(CustomButtonView), default(ICommand), propertyChanged: ButtonComandPropertyChanged);

      private static void ButtonComandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
      {
         var control = (CustomButtonView)bindable;
         control.button.Command = newValue as Command;
      }

      private static void TitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
      {
         var control = (CustomButtonView)bindable;
         control.button.Text = newValue.ToString();
      }



      public ICommand ButtonComand
      {
         get => (Command)GetValue(ButtonComandProperty);
         set => SetValue(ButtonComandProperty, value);
      }

      public string Text
      {
         get => (string)GetValue(TextProperty);
         set => SetValue(TextProperty, value);
      }
   }
}