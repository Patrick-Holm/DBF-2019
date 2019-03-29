using BIZ_DBF_2019_;
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

namespace GUI_DBF_2019_
{
    /// <summary>
    /// Interaction logic for UCNewBook.xaml
    /// </summary>
    public partial class UCNewBook : UserControl
    {
        ClassBiz CLB = new ClassBiz();
        public UCNewBook(Grid UCGUIGrid)
        {
            InitializeComponent();
            
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {       

            if (String.IsNullOrEmpty(tbisbn.Text)|| String.IsNullOrEmpty(tbforfatter.Text)|| String.IsNullOrEmpty(tbforlag.Text)|| String.IsNullOrEmpty(tbgenre.Text)|| String.IsNullOrEmpty(tbindkoeb.Text)|| String.IsNullOrEmpty(tbtitel.Text)|| String.IsNullOrEmpty(tbtype.Text)|| String.IsNullOrEmpty(tbudgivelsesdag.Text))
            {
                string caption = "Udfyld Manglende Felter";
                string message = "Udfyld Venligst Alle Felter.";
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons);
            }
            else
            {
                CLB.addbook(CLB.bog);
                ((Grid)Parent).Children.Remove(this);
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            ((Grid)Parent).Children.Remove(this);
        }

        bool hasBeenClicked = false;

        private void Isbn_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked = true;
            }
            hasBeenClicked = false;
        }

        private void Titel_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked = true;
            }
            hasBeenClicked = false;
        }

        private void Udgivelsesdag_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked = true;
            }
            hasBeenClicked = false;

        }

        private void Forfatter_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked = true;
            }
            hasBeenClicked = false;
        }

        private void Forlag_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked = true;
            }
            hasBeenClicked = false;
        }

        private void Genre_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked = true;
            }
            hasBeenClicked = false;
        }

        private void Type_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked = true;
            }
            hasBeenClicked = false;
        }

        private void Indkoeb_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked = true;
            }
            hasBeenClicked = false;
        }
    }
}
