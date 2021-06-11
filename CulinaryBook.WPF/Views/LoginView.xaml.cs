using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CulinaryBook.WPF.Views
{
    public partial class LoginView : UserControl
    {
        public ICommand LoginCommand
        {
            get => (ICommand) GetValue(LoginCommandProperty);
            set => SetValue(LoginCommandProperty, value);
        }
        public static readonly DependencyProperty LoginCommandProperty =
            DependencyProperty.Register("LoginCommand", typeof(ICommand), 
                typeof(LoginView), new PropertyMetadata(null));
        public LoginView()
        {
            InitializeComponent();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            if (LoginCommand != null)
            {
                string pass = PbPassword.Password;
                LoginCommand.Execute(pass);
            }
        }
    }
}