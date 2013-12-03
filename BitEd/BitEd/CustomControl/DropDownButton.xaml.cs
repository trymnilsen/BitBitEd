using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace BitEd.CustomControl
{
    /// <summary>
    /// Interaction logic for DropDownButton.xaml
    /// </summary>
    public partial class DropDownButton : UserControl
    {
        public DropDownButton()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClickButton.ContextMenu.IsOpen = true;
            e.Handled = true;
        }
    }
}
