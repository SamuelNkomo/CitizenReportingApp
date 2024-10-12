using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace CitizenReportingApp
{
    public partial class ReportIssuesPage : Page
    {
        private string attachedFilePath = null;  // Store the attached file path

        public ReportIssuesPage()
        {
            InitializeComponent();
        }

        // Attach Media button logic
        private void btnAttachMedia_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png|All Files|*.*";

                if (openFileDialog.ShowDialog() == true)
                {
                    attachedFilePath = openFileDialog.FileName;
                    lblAttachment.Text = $"Selected file: {Path.GetFileName(attachedFilePath)}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Submit Report button logic
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string location = txtLocation.Text.Trim();
                string category = (cmbCategory.SelectedItem as ComboBoxItem)?.Content.ToString();
                string description = new TextRange(rtbDescription.Document.ContentStart, rtbDescription.Document.ContentEnd).Text.Trim();

                if (string.IsNullOrEmpty(location) || string.IsNullOrEmpty(category))
                {
                    MessageBox.Show("Location and Category are required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                string fileName = $"Issue_{DateTime.Now.Ticks}.txt";

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.WriteLine($"Location: {location}");
                    writer.WriteLine($"Category: {category}");
                    writer.WriteLine($"Description: {description}");
                    writer.WriteLine($"Date: {DateTime.Now}");

                    if (!string.IsNullOrEmpty(attachedFilePath))
                    {
                        writer.WriteLine($"Attachment: {attachedFilePath}");
                    }
                }

                MessageBox.Show("Report submitted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearForm();
            }
            catch (IOException ex)
            {
                MessageBox.Show($"File write error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Clear the form fields
        private void ClearForm()
        {
            txtLocation.Clear();
            cmbCategory.SelectedItem = null;
            rtbDescription.Document.Blocks.Clear();
            lblAttachment.Text = "No file selected";
            attachedFilePath = null;
        }

        // Back to Main Menu
        private void btnBackToMain_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.NavigateToMainMenu();
        }
    }
}
