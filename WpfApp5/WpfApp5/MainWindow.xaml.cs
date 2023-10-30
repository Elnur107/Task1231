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
using System.IO;

namespace WpfApp5
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
        private void OpenFile(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                filePathTextBox.Text = dlg.FileName;
                contentTextBox.Text = File.ReadAllText(dlg.FileName);
            }
        }

        private void SaveFile(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(filePathTextBox.Text))
            {
                File.WriteAllText(filePathTextBox.Text, contentTextBox.Text);
            }
            else
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                if (dlg.ShowDialog() == true)
                {
                    File.WriteAllText(dlg.FileName, contentTextBox.Text);
                    filePathTextBox.Text = dlg.FileName;
                }
            }
        }

        private void CutText(object sender, RoutedEventArgs e)
        {
            contentTextBox.Cut();
        }

        private void CopyText(object sender, RoutedEventArgs e)
        {
            contentTextBox.Copy();
        }

        private void PasteText(object sender, RoutedEventArgs e)
        {
            contentTextBox.Paste();
        }

        private void SelectAllText(object sender, RoutedEventArgs e)
        {
            contentTextBox.SelectAll();
        }
    }
}
