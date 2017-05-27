using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PasswordKeeper;


namespace PasswordKeeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PasswordKeeper.PasswordKepper item;
        public MainWindow()
        {
            item = new PasswordKepper();
            InitializeComponent();

        }



        private void AddPasswordBtn_OnClick(object sender, RoutedEventArgs e)
        {

            item.AddPassword(UsernameTxtBox.Text,DomainTxtBox.Text,PasswordTxtBox.Text);
            item.SavePasswords();
            
        }

        private void GeneratePasswordBtn_OnClick(object sender, RoutedEventArgs e)
        {
            item.LoadPasswords();
           
        }

        private void ViewPasswordsBtn_OnClick(object sender, RoutedEventArgs e)
        {
            ;
        }

    }
}
