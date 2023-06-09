﻿/* ************************************************************
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
using System.Data;
using BookStoreLIB;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using BookStoreDATA;

namespace BookStoreGUI
{
    /// Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {
        DataSet dsBookCat;
        UserData userData;
        BookOrder bookOrder;

        private void exitButton_Click(object sender, RoutedEventArgs e) { this.Close(); }
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
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


            if (dlg.DialogResult==true && (username == "" || pwd == ""))
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
                    if (dlg.DialogResult == true)
                        MessageBox.Show("A valid password needs to have at least six characters starting with a letter containing both letters and numbers.");
                }
            }
        }
        
        public MainWindow() { InitializeComponent(); }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BookCatalog bookCat = new BookCatalog();
            dsBookCat = bookCat.GetBookInfo();
            this.DataContext = dsBookCat.Tables["Category"];
            bookOrder = new BookOrder();
            userData = new UserData();
            this.orderListView.ItemsSource = bookOrder.OrderItemList;
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            OrderItemDialog orderItemDialog = new OrderItemDialog();
            DataRowView selectedRow;
            selectedRow = (DataRowView)this.ProductsDataGrid.SelectedItems[0];
            orderItemDialog.isbnTextBox.Text = selectedRow.Row.ItemArray[0].ToString();
            orderItemDialog.titleTextBox.Text = selectedRow.Row.ItemArray[2].ToString();
            orderItemDialog.priceTextBox.Text = selectedRow.Row.ItemArray[4].ToString();
            orderItemDialog.Owner = this;
            orderItemDialog.ShowDialog();
            if (orderItemDialog.DialogResult == true)
            {
                string isbn = orderItemDialog.isbnTextBox.Text;
                string title = orderItemDialog.titleTextBox.Text;
                double unitPrice = double.Parse(orderItemDialog.priceTextBox.Text);
                int quantity = int.Parse(orderItemDialog.quantityTextBox.Text);
                bookOrder.AddItem(new OrderItem(isbn, title, unitPrice, quantity));
            } 
        }
        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.orderListView.SelectedItem != null)
            {
                var selectedOrderItem = this.orderListView.SelectedItem as OrderItem;
                bookOrder.RemoveItem(selectedOrderItem.BookID);
            }
        }
        private void chechoutButton_Click(object sender, RoutedEventArgs e)
        {
            int orderId;
            if (CheckUserLoggedIn())
            {
                PlaceAnOrder placeAnOrderDialog = new PlaceAnOrder();
                DALUserInfo userInfo = new DALUserInfo();
                placeAnOrderDialog.PlaceAnOrderUIChanges(bookOrder.ItemNumbers(), bookOrder.GetOrderTotal(), userInfo.GetFullName(userData.UserID));
                placeAnOrderDialog.ShowDialog();
                orderId = bookOrder.PlaceOrder(userData.UserID);
                MessageBox.Show("Your order has been placed. Your order id is " +
                orderId.ToString());
            }
            else
            {
                MessageBox.Show("Please log in before proceeding to checkout.");
            }
        }

        public bool CheckUserLoggedIn()
        {
            if (userData.UserID > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
