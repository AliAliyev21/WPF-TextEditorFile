using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
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

namespace WpfAppFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string autoSaveFilePath; 
        private bool isAutoSaveEnabled = false; 

        public MainWindow()
        {
            InitializeComponent();
            TextBoxFileName.Text = "Select File = > = >";
        }

        public object ToastNotificationManager { get; private set; }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "TXT files|*.txt";
            var result = openFileDialog.ShowDialog();

            if (result == true)
            {
                string filePath = openFileDialog.FileName;
                if (File.Exists(filePath))
                {
                    TextBoxFileName.Text = System.IO.Path.GetFileName(filePath);
                    Text.Text = File.ReadAllText(filePath);
                    autoSaveFilePath = filePath;
                }
            }

        }



        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(autoSaveFilePath))
            {
                File.WriteAllText(autoSaveFilePath, Text.Text);
                ShowNotification(Notifi.NotifTextSavedSuccessfully(autoSaveFilePath));
            }
            else
            {
                SaveAs();
            }
        }

        private void SaveAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "C:\\";
            saveFileDialog.Filter = "TXT files|*.txt";
            var result = saveFileDialog.ShowDialog();

            if (result == true)
            {
                string filePath = saveFileDialog.FileName;
                File.WriteAllText(filePath, Text.Text);
                autoSaveFilePath = filePath;
                ShowNotification(Notifi.NotifTextSavedSuccessfully(autoSaveFilePath));
            }
        }

        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            Text.Cut();
            Text.Focus();
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            Text.Copy();
            Text.Focus();
        }

        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            Text.Paste();
            Text.Focus();
        }

        private void SelectAll_Click(object sender, RoutedEventArgs e)
        {
            Text.SelectAll();
            Text.Focus();
        }

        private void AutoSave_Checked(object sender, RoutedEventArgs e)
        {
            isAutoSaveEnabled = true;
            ShowNotification(Notifi.NotifAutoSaveIsChecked(true));

        }

        private void AutoSave_Unchecked(object sender, RoutedEventArgs e)
        {
            isAutoSaveEnabled = false;
            ShowNotification(Notifi.NotifAutoSaveIsChecked(false));
        }

        private void Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isAutoSaveEnabled && !string.IsNullOrEmpty(autoSaveFilePath))
            {
                
                File.WriteAllText(autoSaveFilePath, Text.Text);               
            }
        }

        private void ShowNotification(string message)
        {
            MessageBox.Show(message);
        }

    }
}
