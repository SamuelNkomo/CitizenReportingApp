using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace CitizenReportingApp
{
    public partial class ReportIssuesPage : Page
    {
        public ReportIssuesPage()
        {
            InitializeComponent();
        }

        private void btnAttachMedia_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png|All Files|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                lblAttachment.Text = openFileDialog.FileName;
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string location = txtLocation.Text;
            string category = (cmbCategory.SelectedItem as ComboBoxItem)?.Content.ToString();
            string description = new TextRange(rtbDescription.Document.ContentStart, rtbDescription.Document.ContentEnd).Text;
            string attachmentPath = lblAttachment.Text;

            if (string.IsNullOrEmpty(location))
            {
                MessageBox.Show("Location is required.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(category))
            {
                MessageBox.Show("Category is required.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Description is required.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Save the issue details to a text file
            string fileName = $"Issue_{System.DateTime.Now.Ticks}.txt";
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine($"Location: {location}");
                writer.WriteLine($"Category: {category}");
                writer.WriteLine($"Description: {description.Trim()}");
                writer.WriteLine($"Attachment: {attachmentPath}");
            }

            lblReportDetails.Visibility = Visibility.Visible;
            lblReportDetails.Text = $"Report Submitted:\nLocation: {location}\nCategory: {category}\nDescription: {description.Trim()}\nAttachment: {attachmentPath}";
        }

        private void btnBackToMain_Click(object sender, RoutedEventArgs e)
        {
            // Get the MainWindow instance
            var mainWindow = (MainWindow)Application.Current.MainWindow;

            // Show the main menu content (welcome text and buttons) again
            mainWindow.MainContentPanel.Visibility = Visibility.Visible;

            // Hide the Frame that is hosting the ReportIssuesPage
            mainWindow.MainFrame.Visibility = Visibility.Collapsed;
        }
    }
}