using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Event> events = new List<Event>();

        List<Event> newEvents = new List<Event>
        {
            new Event(1, "Event 1", new DateTime(2023, 07, 12, 16, 30, 00), new DateTime(2023, 07, 12, 18, 00, 00)),
            new Event(2, "Event 2", new DateTime(2023, 07, 12, 18, 30, 00), new DateTime(2023, 07, 12, 19, 00, 00)),
        };

        foreach (var newEvent in newEvents)
        {
            if (IsOverlap(events, newEvent))
            {
                Console.WriteLine($"Overlap detected for Event ID: {newEvent.iD}");
            }
            else
            {
                events.Add(newEvent);
            }
        }

        foreach (Event @event in events)
        {
            Console.WriteLine(@event.ToString());
        }
    }

    static bool IsOverlap(List<Event> events, Event newEvent)
    {
        foreach (Event existingEvent in events)
        {
            if (existingEvent.Overlap(newEvent))
            {
                return true;
            }
        }
        return false;
    }
}

class Event
{
    private int ID;
    private string Description;
    private DateTime StartTime;
    private DateTime EndTime;

    public int iD
    {
        get { return ID; }
        set { ID = value; }
    }

    public string description
    {
        get { return Description; }
        set { Description = value; }
    }

    public DateTime starttime
    {
        get { return StartTime; }
        set { StartTime = value; }
    }

    public DateTime endtime
    {
        get { return EndTime; }
        set { EndTime = value; }
    }

    public Event(int eventId, string description, DateTime startTime, DateTime endTime)
    {
        if (endTime <= startTime)
        {
            throw new ArgumentException("End time must be after start time");
        }

        ID = eventId;
        Description = description;
        StartTime = startTime;
        EndTime = endTime;
    }

    public bool Overlap(Event other)
    {
        return (other.starttime < this.EndTime) && (other.endtime > this.StartTime);
    }

    public override string ToString()
    {
        return $"Event ID: {ID}, Description: {Description}, Start Time: {StartTime}, End Time: {EndTime}";
    }
}