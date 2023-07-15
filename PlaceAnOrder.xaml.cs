using BookStoreLIB;
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

namespace BookStoreGUI
{
    /// <summary>
    /// Interaction logic for PlaceAnOrder.xaml
    /// </summary>
    public partial class PlaceAnOrder : Window
    {
        public PlaceAnOrder()
        {
            InitializeComponent();
        }

        public void PlaceAnOrderUIChanges(int itemNumber, double itemTotal, string userName)
        {
            double deliveryCharge = 5.0;
            double beforeTaxTotal = itemTotal + deliveryCharge;
            double tax = beforeTaxTotal * 0.2;
            double inTotal = itemTotal + tax;
            shippingToText.Text = userName;
            placeonOrderItems.Content = "Items (" + itemNumber + ")";
            placeonOrderText.Text = "$" + itemTotal.ToString();
            shippingHandlingText.Text = "$" + deliveryCharge.ToString();
            totalBeforeTax.Text = "$" + beforeTaxTotal.ToString();
            estimatedGst.Text = "$" + tax.ToString();
            orderTotal.Text = "$" + inTotal.ToString();
        }
    }
}
