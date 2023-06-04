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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace aiLoginPage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            string username = this.nameTextBox.Text;
            string pwd = this.pwdTextBox.Password;
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
            else if (match != null && match.Length == pwd.Length)
            {
                MessageBox.Show("Thank you for providing the input.");
            } else
            {
                MessageBox.Show("A valid password needs to have at least six characters with both letters and numbers.");
            }
        }

    }
}
