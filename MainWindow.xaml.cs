/* ************************************************************
 * For students to work on assignments and project.
 * Permission required material. Contact: xyuan@uwindsor.ca 
 * ************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using BookStoreLIB;

namespace BookStoreGUI
{
    /// Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            var userData = new UserData();
            var dlg = new LoginDialog();
            dlg.Owner = this;
            dlg.ShowDialog();

            string username = dlg.nameTextBox.Text;
            string pwd = dlg.passwordTextBox.Password;
            Match match = null;

            Regex r = new Regex("^[a-zA-Z][0-9a-zA-Z]{5,}");

            MatchCollection regexCheck = r.Matches(pwd);
            if (r.Matches(pwd).Count > 0)
            {
                match = regexCheck[0];
            }


            if (username == "" || pwd == "")
            {
                MessageBox.Show("Please fill in all the slots.");
            }
            else
            {
                if (match != null && match.Length == pwd.Length)
                {
                    if (userData.LogIn(username, pwd) == true)
                    {
                        this.statusTextBlock.Text = "You are logged in as User #" + userData.UserID;
                        MessageBox.Show("You are logged in as User # " + userData.UserID);
                    }
                    else
                        MessageBox.Show("You could not be verified. Please try again.");
                }
                else
                {
                    MessageBox.Show("A valid password needs to have at least six characters starting with a letter containing both letters and numbers.");
                }
            }
        }
        private void exitButton_Click(object sender, RoutedEventArgs e) { this.Close(); }
        public MainWindow() { InitializeComponent(); }
        private void Window_Loaded(object sender, RoutedEventArgs e) { }
        private void addButton_Click(object sender, RoutedEventArgs e) { }
        private void chechoutButton_Click(object sender, RoutedEventArgs e) { }
    }
}
