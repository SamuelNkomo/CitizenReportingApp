using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace CitizenReportingApp
{
    public partial class IssuesPage : Page
    {
        public IssuesPage()
        {
            InitializeComponent();
            LoadIssues();
        }

        // Load reported issues from text files
        private void LoadIssues()
        {
            try
            {
                string[] issueFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "Issue_*.txt");
                lstIssues.Items.Clear();
                foreach (var file in issueFiles)
                {
                    lstIssues.Items.Add(Path.GetFileName(file));
                }

                if (issueFiles.Length == 0)
                {
                    MessageBox.Show("No reported issues found.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"File read error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Display the details of the selected issue
        private void btnViewDetails_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lstIssues.SelectedItem != null)
                {
                    string selectedFile = lstIssues.SelectedItem.ToString();
                    string issueDetails = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), selectedFile));
                    txtIssueDetails.Text = issueDetails;
                }
                else
                {
                    MessageBox.Show("Please select an issue to view details.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Navigate back to the main menu
        private void btnBackToMain_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.NavigateToMainMenu();
        }
    }
}
