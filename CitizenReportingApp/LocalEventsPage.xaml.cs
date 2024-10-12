using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CitizenReportingApp
{
    public partial class LocalEventsPage : Page
    {
        private EventManager eventManager = new EventManager();  // Manages event data

        public LocalEventsPage()
        {
            InitializeComponent();
            LoadCategories();
            DisplayAllEvents();
        }

        // Load event categories into ComboBox
        private void LoadCategories()
        {
            List<string> categories = eventManager.GetUniqueCategories();
            cmbCategories.Items.Clear();
            foreach (var category in categories)
            {
                cmbCategories.Items.Add(new ComboBoxItem() { Content = category });
            }
        }

        // Display all events in the ListBox
        private void DisplayAllEvents()
        {
            lstEvents.Items.Clear();
            List<Event> events = eventManager.GetAllEvents();
            foreach (var evnt in events)
            {
                lstEvents.Items.Add($"{evnt.Date.ToShortDateString()} - {evnt.Name} ({evnt.Category})");
            }
        }

        // Search for events based on the selected category and date
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string selectedCategory = cmbCategories.SelectedItem?.ToString();
            DateTime selectedDate = dtpEventDate.SelectedDate ?? DateTime.Today;  // Default to today's date if no date is selected

            if (!string.IsNullOrEmpty(selectedCategory))
            {
                List<Event> searchResults = eventManager.SearchEventsByCategoryAndDate(selectedCategory, selectedDate);
                lstEvents.Items.Clear();
                foreach (var evnt in searchResults)
                {
                    lstEvents.Items.Add($"{evnt.Date.ToShortDateString()} - {evnt.Name} ({evnt.Category})");
                }
            }
            else
            {
                MessageBox.Show("Please select a category to search.");
            }
        }

        // Show recommended events based on previous search patterns
        private void btnRecommendations_Click(object sender, RoutedEventArgs e)
        {
            List<Event> recommendations = eventManager.GetRecommendedEvents();
            lstEvents.Items.Clear();
            foreach (var evnt in recommendations)
            {
                lstEvents.Items.Add($"{evnt.Date.ToShortDateString()} - {evnt.Name} ({evnt.Category})");
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
