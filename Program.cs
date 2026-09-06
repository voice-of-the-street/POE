using System;
using System.Collections.Generic;
using System.Linq;

namespace RaceDay
{
    // =========================
    // ORGANISER
    // =========================
    class Organiser
    {
        public int OrganiserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Organiser(int id, string name, string email)
        {
            OrganiserID = id;
            Name = name;
            Email = email;
        }
    }

    // =========================
    // PARTICIPANT
    // =========================
    class Participant
    {
        public int ParticipantID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Participant(int id, string name, string email)
        {
            ParticipantID = id;
            Name = name;
            Email = email;
        }
    }

    // =========================
    // EVENT
    // =========================
    class RaceEvent
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string Location { get; set; }
        public DateTime EventDate { get; set; }
        public int OrganiserID { get; set; }

        public RaceEvent(
            int id,
            string name,
            string location,
            DateTime date,
            int organiserID)
        {
            EventID = id;
            EventName = name;
            Location = location;
            EventDate = date;
            OrganiserID = organiserID;
        }
    }

    // =========================
    // CATEGORY
    // =========================
    class EventCategory
    {
        public int CategoryID { get; set; }
        public int EventID { get; set; }
        public string CategoryName { get; set; }
        public decimal EntryFee { get; set; }

        public EventCategory(
            int id,
            int eventID,
            string categoryName,
            decimal entryFee)
        {
            CategoryID = id;
            EventID = eventID;
            CategoryName = categoryName;
            EntryFee = entryFee;
        }
    }

    // =========================
    // ENROLMENT
    // =========================
    class Enrolment
    {
        public int EnrolmentID { get; set; }
        public int ParticipantID { get; set; }
        public int CategoryID { get; set; }
        public DateTime EnrolmentDate { get; set; }
        public string Status { get; set; }

        public Enrolment(
            int id,
            int participantID,
            int categoryID,
            DateTime enrolmentDate,
            string status)
        {
            EnrolmentID = id;
            ParticipantID = participantID;
            CategoryID = categoryID;
            EnrolmentDate = enrolmentDate;
            Status = status;
        }
    }

    // =========================
    // MAIN PROGRAM
    // =========================
    class Program
    {
        static List<Organiser> organisers = new List<Organiser>();
        static List<Participant> participants = new List<Participant>();
        static List<RaceEvent> events = new List<RaceEvent>();
        static List<EventCategory> categories = new List<EventCategory>();
        static List<Enrolment> enrolments = new List<Enrolment>();

        static void Main(string[] args)
        {
            SeedData();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("==============================================");
                Console.WriteLine("              RACEDAY SYSTEM");
                Console.WriteLine("==============================================");
                Console.WriteLine();
                Console.WriteLine("1. View Organisers");
                Console.WriteLine("2. View Participants");
                Console.WriteLine("3. View Events");
                Console.WriteLine("4. View Event Categories");
                Console.WriteLine("5. View Enrolments");
                Console.WriteLine("6. View Event Details");
                Console.WriteLine("7. Search Events");
                Console.WriteLine("0. Exit");
                Console.WriteLine();
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayOrganisers();
                        break;

                    case "2":
                        DisplayParticipants();
                        break;

                    case "3":
                        DisplayEvents();
                        break;

                    case "4":
                        DisplayCategories();
                        break;

                    case "5":
                        DisplayEnrolments();
                        break;

                    case "6":
                        DisplayEventDetails();
                        break;

                    case "7":
                        SearchEvents();
                        break;

                    case "0":
                        Console.WriteLine();
                        Console.WriteLine("Thank you for using RaceDay.");
                        return;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice.");
                        Pause();
                        break;
                }
            }
        }

        // =========================
        // SAMPLE DATA
        // =========================
        static void SeedData()
        {
            // Organisers
            organisers.Add(
                new Organiser(
                    1,
                    "Mpumalanga Running Club",
                    "info@mprunning.co.za"
                )
            );

            organisers.Add(
                new Organiser(
                    2,
                    "Lowveld Cycling Events",
                    "events@lowveldcycling.co.za"
                )
            );

            // Participants
            participants.Add(
                new Participant(
                    1,
                    "Thabo Mokoena",
                    "thabo@example.com"
                )
            );

            participants.Add(
                new Participant(
                    2,
                    "Lerato Nkosi",
                    "lerato@example.com"
                )
            );

            participants.Add(
                new Participant(
                    3,
                    "Sipho Dlamini",
                    "sipho@example.com"
                )
            );

            participants.Add(
                new Participant(
                    4,
                    "Nomsa Mthembu",
                    "nomsa@example.com"
                )
            );

            // Events
            events.Add(
                new RaceEvent(
                    1,
                    "Mbombela City Run",
                    "Mbombela",
                    new DateTime(2026, 10, 10),
                    1
                )
            );

            events.Add(
                new RaceEvent(
                    2,
                    "Lowveld Cycle Challenge",
                    "White River",
                    new DateTime(2026, 11, 7),
                    2
                )
            );

            // Categories for Event 1
            categories.Add(
                new EventCategory(
                    1,
                    1,
                    "5 KM Fun Run",
                    80.00m
                )
            );

            categories.Add(
                new EventCategory(
                    2,
                    1,
                    "10 KM Run",
                    120.00m
                )
            );

            categories.Add(
                new EventCategory(
                    3,
                    1,
                    "21 KM Half Marathon",
                    180.00m
                )
            );

            // Categories for Event 2
            categories.Add(
                new EventCategory(
                    4,
                    2,
                    "20 KM Mountain Bike",
                    150.00m
                )
            );

            categories.Add(
                new EventCategory(
                    5,
                    2,
                    "40 KM Road Bike",
                    250.00m
                )
            );

            categories.Add(
                new EventCategory(
                    6,
                    2,
                    "80 KM Challenge",
                    350.00m
                )
            );

            // Enrolments
            enrolments.Add(
                new Enrolment(
                    1,
                    1,
                    2,
                    new DateTime(2026, 9, 1),
                    "Confirmed"
                )
            );

            enrolments.Add(
                new Enrolment(
                    2,
                    2,
                    1,
                    new DateTime(2026, 9, 2),
                    "Confirmed"
                )
            );

            enrolments.Add(
                new Enrolment(
                    3,
                    3,
                    5,
                    new DateTime(2026, 9, 3),
                    "Confirmed"
                )
            );

            enrolments.Add(
                new Enrolment(
                    4,
                    4,
                    3,
                    new DateTime(2026, 9, 4),
                    "Pending"
                )
            );
        }

        // =========================
        // DISPLAY ORGANISERS
        // =========================
        static void DisplayOrganisers()
        {
            Console.Clear();

            Console.WriteLine("==============================================");
            Console.WriteLine("                 ORGANISERS");
            Console.WriteLine("==============================================");

            foreach (Organiser organiser in organisers)
            {
                Console.WriteLine();
                Console.WriteLine("ID    : " + organiser.OrganiserID);
                Console.WriteLine("Name  : " + organiser.Name);
                Console.WriteLine("Email : " + organiser.Email);
            }

            Pause();
        }

        // =========================
        // DISPLAY PARTICIPANTS
        // =========================
        static void DisplayParticipants()
        {
            Console.Clear();

            Console.WriteLine("==============================================");
            Console.WriteLine("                PARTICIPANTS");
            Console.WriteLine("==============================================");

            foreach (Participant participant in participants)
            {
                Console.WriteLine();
                Console.WriteLine("ID    : " + participant.ParticipantID);
                Console.WriteLine("Name  : " + participant.Name);
                Console.WriteLine("Email : " + participant.Email);
            }

            Pause();
        }

        // =========================
        // DISPLAY EVENTS
        // =========================
        static void DisplayEvents()
        {
            Console.Clear();

            Console.WriteLine("==============================================");
            Console.WriteLine("                   EVENTS");
            Console.WriteLine("==============================================");

            foreach (RaceEvent raceEvent in events)
            {
                Organiser organiser = organisers
                    .FirstOrDefault(o => o.OrganiserID == raceEvent.OrganiserID);

                Console.WriteLine();
                Console.WriteLine("Event ID   : " + raceEvent.EventID);
                Console.WriteLine("Event Name : " + raceEvent.EventName);
                Console.WriteLine("Location   : " + raceEvent.Location);
                Console.WriteLine("Date       : " + raceEvent.EventDate.ToString("dd MMMM yyyy"));

                if (organiser != null)
                {
                    Console.WriteLine("Organiser  : " + organiser.Name);
                }

                Console.WriteLine("----------------------------------------------");
            }

            Pause();
        }

        // =========================
        // DISPLAY CATEGORIES
        // =========================
        static void DisplayCategories()
        {
            Console.Clear();

            Console.WriteLine("==============================================");
            Console.WriteLine("              EVENT CATEGORIES");
            Console.WriteLine("==============================================");

            foreach (EventCategory category in categories)
            {
                RaceEvent raceEvent = events
                    .FirstOrDefault(e => e.EventID == category.EventID);

                Console.WriteLine();
                Console.WriteLine("Category ID : " + category.CategoryID);
                Console.WriteLine("Category    : " + category.CategoryName);
                Console.WriteLine("Entry Fee   : R" + category.EntryFee.ToString("0.00"));

                if (raceEvent != null)
                {
                    Console.WriteLine("Event       : " + raceEvent.EventName);
                }

                Console.WriteLine("----------------------------------------------");
            }

            Pause();
        }

        // =========================
        // DISPLAY ENROLMENTS
        // =========================
        static void DisplayEnrolments()
        {
            Console.Clear();

            Console.WriteLine("==============================================");
            Console.WriteLine("                 ENROLMENTS");
            Console.WriteLine("==============================================");

            foreach (Enrolment enrolment in enrolments)
            {
                Participant participant = participants
                    .FirstOrDefault(
                        p => p.ParticipantID == enrolment.ParticipantID
                    );

                EventCategory category = categories
                    .FirstOrDefault(
                        c => c.CategoryID == enrolment.CategoryID
                    );

                Console.WriteLine();
                Console.WriteLine("Enrolment ID : " + enrolment.EnrolmentID);

                if (participant != null)
                {
                    Console.WriteLine("Participant  : " + participant.Name);
                }

                if (category != null)
                {
                    Console.WriteLine("Category     : " + category.CategoryName);

                    RaceEvent raceEvent = events
                        .FirstOrDefault(
                            e => e.EventID == category.EventID
                        );

                    if (raceEvent != null)
                    {
                        Console.WriteLine("Event        : " + raceEvent.EventName);
                    }

                    Console.WriteLine(
                        "Entry Fee    : R" +
                        category.EntryFee.ToString("0.00")
                    );
                }

                Console.WriteLine(
                    "Enrolled     : " +
                    enrolment.EnrolmentDate.ToString("dd MMMM yyyy")
                );

                Console.WriteLine("Status       : " + enrolment.Status);

                Console.WriteLine("----------------------------------------------");
            }

            Pause();
        }

        // =========================
        // EVENT DETAILS
        // =========================
        static void DisplayEventDetails()
        {
            Console.Clear();

            Console.WriteLine("==============================================");
            Console.WriteLine("              EVENT DETAILS");
            Console.WriteLine("==============================================");
            Console.WriteLine();

            Console.Write("Enter Event ID: ");

            if (!int.TryParse(Console.ReadLine(), out int eventID))
            {
                Console.WriteLine("Please enter a valid number.");
                Pause();
                return;
            }

            RaceEvent raceEvent = events
                .FirstOrDefault(e => e.EventID == eventID);

            if (raceEvent == null)
            {
                Console.WriteLine();
                Console.WriteLine("Event not found.");
                Pause();
                return;
            }

            Organiser organiser = organisers
                .FirstOrDefault(
                    o => o.OrganiserID == raceEvent.OrganiserID
                );

            Console.WriteLine();
            Console.WriteLine("Event       : " + raceEvent.EventName);
            Console.WriteLine("Location    : " + raceEvent.Location);
            Console.WriteLine(
                "Date        : " +
                raceEvent.EventDate.ToString("dd MMMM yyyy")
            );

            if (organiser != null)
            {
                Console.WriteLine("Organiser   : " + organiser.Name);
            }

            Console.WriteLine();
            Console.WriteLine("Categories");
            Console.WriteLine("----------------------------------------------");

            List<EventCategory> eventCategories = categories
                .Where(c => c.EventID == eventID)
                .ToList();

            foreach (EventCategory category in eventCategories)
            {
                Console.WriteLine(
                    category.CategoryID +
                    ". " +
                    category.CategoryName +
                    " - R" +
                    category.EntryFee.ToString("0.00")
                );
            }

            Pause();
        }

        // =========================
        // SEARCH EVENTS
        // =========================
        static void SearchEvents()
        {
            Console.Clear();

            Console.WriteLine("==============================================");
            Console.WriteLine("                 SEARCH EVENTS");
            Console.WriteLine("==============================================");
            Console.WriteLine();

            Console.Write("Enter event name or location: ");

            string search = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(search))
            {
                Console.WriteLine("Search cannot be empty.");
                Pause();
                return;
            }

            List<RaceEvent> results = events
                .Where(
                    e =>
                        e.EventName.Contains(
                            search,
                            StringComparison.OrdinalIgnoreCase
                        )
                        ||
                        e.Location.Contains(
                            search,
                            StringComparison.OrdinalIgnoreCase
                        )
                )
                .ToList();

            Console.WriteLine();

            if (results.Count == 0)
            {
                Console.WriteLine("No events found.");
            }
            else
            {
                Console.WriteLine("Search Results");
                Console.WriteLine("----------------------------------------------");

                foreach (RaceEvent raceEvent in results)
                {
                    Console.WriteLine(
                        raceEvent.EventID +
                        ". " +
                        raceEvent.EventName +
                        " - " +
                        raceEvent.Location +
                        " - " +
                        raceEvent.EventDate.ToString("dd/MM/yyyy")
                    );
                }
            }

            Pause();
        }

        // =========================
        // PAUSE
        // =========================
        static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
        }
    }
}