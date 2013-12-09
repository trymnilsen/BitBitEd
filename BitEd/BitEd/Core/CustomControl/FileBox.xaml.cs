using Microsoft.Win32;
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

namespace BitEd.CustomControl
{
    /// <summary>
    /// Interaction logic for FileBox.xaml
    /// </summary>
    public partial class FileBox : UserControl
    {
        public FileBox()
        {
            InitializeComponent();
        }

        private void OpenButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            bool? dialogResult = fileDialog.ShowDialog();
            if (dialogResult == true)
            {
                FileTextBox.Text = fileDialog.FileName;
            }
        }
    }
}
