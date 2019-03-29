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
using BIZ_DBF_2019_;


namespace GUI_DBF_2019_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassBiz CB = new ClassBiz();
        public MainWindow()
        {
            InitializeComponent();
            UCGUI ucg = new UCGUI(CB, gridRight);
            UserControlListView uclw = new UserControlListView(CB, gridLeft);
            UCLogin ucLogIN = new UCLogin(CB);
            gridLeft.Children.Add(uclw);
            gridRight.Children.Add(ucg);
            MainGrid.Children.Add(ucLogIN);
        }
    }
}
