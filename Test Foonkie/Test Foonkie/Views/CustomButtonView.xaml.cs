
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

      private static void TitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
      {
         var control = (CustomButtonView)bindable;
         control.button.Text = newValue.ToString();
      }

      public string Text
      {
         get => (string)GetValue(TextProperty);
         set => SetValue(TextProperty, value);
      }
   }
}