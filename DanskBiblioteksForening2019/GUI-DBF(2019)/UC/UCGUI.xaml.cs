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
using REPO_DBF_2019_;

namespace GUI_DBF_2019_
{
    /// <summary>
    /// Interaction logic for UCGUI.xaml
    /// </summary>
    public partial class UCGUI : UserControl
    {
        ClassBiz _CB;
        public UCGUI(ClassBiz inClass, Grid gridRight)
        {
            InitializeComponent();
            _CB = inClass;
            UCGUIGrid.DataContext = _CB;
        }

        private void EditBook_Click(object sender, RoutedEventArgs e)
        {
            UCAddBook UCAB = new UCAddBook(UCGUIGrid, _CB);
            ((Grid)Parent).Children.Add(UCAB);
        }

        private void CreateNewBook_Click(object sender, RoutedEventArgs e)
        {
            ClassBog cBOG = new ClassBog();
            UCAddBook UCAB = new UCAddBook(UCGUIGrid, cBOG, _CB);
            ((Grid)Parent).Children.Add(UCAB);
        }
    }
}
