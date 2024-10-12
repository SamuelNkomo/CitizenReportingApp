using System.Text;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Navigate to the Report Issues page when the button is clicked
        private void btnReportIssues_Click(object sender, RoutedEventArgs e)
        {
            // Hide the main content (welcome text and buttons)
            MainContentPanel.Visibility = Visibility.Collapsed;

            // Show the Frame and make it visible
            MainFrame.Visibility = Visibility.Visible;

            // Navigate to the ReportIssuesPage within the Frame
            MainFrame.Navigate(new ReportIssuesPage());
        }

        // Navigate to the Local Events page
        private void btnLocalEvents_Click(object sender, RoutedEventArgs e)
        {
            // Hide the main content (welcome text and buttons)
            MainContentPanel.Visibility = Visibility.Collapsed;

            // Show the Frame and make it visible
            MainFrame.Visibility = Visibility.Visible;

            // Navigate to the LocalEventsPage
            MainFrame.Navigate(new LocalEventsPage());
        }

        // Navigate to the Service Request Status page
        private void btnServiceRequestStatus_Click(object sender, RoutedEventArgs e)
        {
            // Hide the main content (welcome text and buttons)
            MainContentPanel.Visibility = Visibility.Collapsed;

            // Show the Frame and make it visible
            MainFrame.Visibility = Visibility.Hidden;

            // Navigate to the ServiceRequestStatusPage
        }

        // Navigate to the View Reports page
        private void btnViewReports_Click(object sender, RoutedEventArgs e)
        {
            // Hide the main content (welcome text and buttons)
            MainContentPanel.Visibility = Visibility.Collapsed;

            // Show the Frame and make it visible
            MainFrame.Visibility = Visibility.Visible;

            // Navigate to the IssuesPage (View Reports)
            MainFrame.Navigate(new IssuesPage());
        }

        // Navigate back to the Main Menu
        public void NavigateToMainMenu()
        {
            // Show the main content panel again
            MainContentPanel.Visibility = Visibility.Visible;

            // Hide the Frame when returning to the Main Menu
            MainFrame.Visibility = Visibility.Collapsed;

            // Clear the Frame's content
            MainFrame.Content = null;
        }
    }
}
