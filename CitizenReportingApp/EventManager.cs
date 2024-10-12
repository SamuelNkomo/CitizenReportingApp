using System;
using System.Collections.Generic;
using System.Linq;

public class Event
{
    public string Name { get; set; }
    public string Category { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }

    public Event(string name, string category, DateTime date, string description)
    {
        Name = name;
        Category = category;
        Date = date;
        Description = description;
    }
}

public class EventManager
{
    private SortedDictionary<DateTime, Queue<Event>> eventsByDate = new SortedDictionary<DateTime, Queue<Event>>();  // Events sorted by date
    private HashSet<string> eventCategories = new HashSet<string>();  // Unique categories
    private Dictionary<string, int> searchPatterns = new Dictionary<string, int>();  // Tracks search patterns

    public EventManager()
    {
        // Sample data
        AddEvent(new Event("Music Festival", "Music", DateTime.Today.AddDays(2), "Enjoy live performances."));
        AddEvent(new Event("Food Fair", "Food", DateTime.Today.AddDays(5), "Taste food from around the world."));
        AddEvent(new Event("Art Exhibition", "Art", DateTime.Today.AddDays(10), "Explore local art exhibits."));
    }

    // Add an event to the manager
    public void AddEvent(Event evnt)
    {
        if (!eventsByDate.ContainsKey(evnt.Date))
        {
            eventsByDate[evnt.Date] = new Queue<Event>();
        }
        eventsByDate[evnt.Date].Enqueue(evnt);  // Add event to the queue for the date
        eventCategories.Add(evnt.Category);  // Store unique categories
    }

    // Retrieve all events
    public List<Event> GetAllEvents()
    {
        List<Event> allEvents = new List<Event>();
        foreach (var eventQueue in eventsByDate.Values)
        {
            allEvents.AddRange(eventQueue);
        }
        return allEvents;
    }

    // Search for events by category and date
    public List<Event> SearchEventsByCategoryAndDate(string category, DateTime date)
    {
        TrackSearchPattern(category);  // Track the search for recommendations
        List<Event> results = new List<Event>();
        foreach (var eventQueue in eventsByDate.Values)
        {
            results.AddRange(eventQueue.Where(e => e.Category.Equals(category, StringComparison.OrdinalIgnoreCase) && e.Date.Date == date.Date));
        }
        return results;
    }

    // Track search patterns for recommendation system
    private void TrackSearchPattern(string category)
    {
        if (searchPatterns.ContainsKey(category))
        {
            searchPatterns[category]++;
        }
        else
        {
            searchPatterns[category] = 1;
        }
    }

    // Retrieve recommended events based on search patterns
    public List<Event> GetRecommendedEvents()
    {
        if (searchPatterns.Count == 0) return new List<Event>();  // No recommendations if no searches made
        var topCategory = searchPatterns.OrderByDescending(x => x.Value).First().Key;  // Most searched category
        return GetAllEvents().Where(e => e.Category.Equals(topCategory, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    // Retrieve unique categories for filtering
    public List<string> GetUniqueCategories()
    {
        return eventCategories.ToList();
    }
}
