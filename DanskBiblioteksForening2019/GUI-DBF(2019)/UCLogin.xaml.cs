﻿using System;
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
        public UCLogin()
        {
            InitializeComponent();
        }

        private void ButtonLogIn_Click(object sender, RoutedEventArgs e)
        {
            if (false)
            {

            }
            else
            {
                LabelError.Visibility = Visibility.Visible;
            }
        }
    }
}
