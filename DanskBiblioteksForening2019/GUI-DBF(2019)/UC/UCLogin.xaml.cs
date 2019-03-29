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
    /// Interaction logic for UCLogin.xaml
    /// </summary>
    public partial class UCLogin : UserControl
    {
        ClassBiz CB;
        public UCLogin(ClassBiz inBiz)
        {
            InitializeComponent();
            CB = inBiz;
            MainGrid.DataContext = CB;
        }

        private void ButtonLogIn_Click_1(object sender, RoutedEventArgs e)
        {
            bool loginSuccess = CB.HandleLogin();
            if (loginSuccess == false)
            {
                LabelError.Visibility = Visibility.Visible;
            }
            else
            {
                ((Grid)Parent).Children.Remove(this);
            }
        }
    }
}
