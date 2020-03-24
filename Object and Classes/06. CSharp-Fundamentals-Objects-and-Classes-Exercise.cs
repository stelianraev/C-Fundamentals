namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Program
    {
        public static void Main(string[] args)
        {
            OrderByAge();
        }

        // 01. Advertisement Message
        public static void AdvertisementMessage()
        {
            string[] phrases =
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };

            string[] events =
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.", "I feel great!"
            };

            string[] authors =
            {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva"
            };

            string[] cities =
            {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"
            };

            int n = int.Parse(Console.ReadLine());

            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                int phrasesIndex = rnd.Next(0, phrases.Length);
                int eventIndex = rnd.Next(0, events.Length);
                int authorIndex = rnd.Next(0, authors.Length);
                int cityIndex = rnd.Next(0, cities.Length);

                Console.WriteLine($"{phrases[phrasesIndex]} {events[eventIndex]} {authors[authorIndex]} – {cities[cityIndex]}");
            }
        }

        // 02. Articles
        public static void Articles()
        {
            string[] input = Console.ReadLine().Split(", ");

            Article arcticle = new Article(input[0], input[1], input[2]);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split(": ");

                if (command[0] == "Edit")
                {
                    arcticle.Edit(command[1]);
                }
                else if (command[0] == "ChangeAuthor")
                {
                    arcticle.ChangeAuthor(command[1]);
                }
                else if (command[0] == "Rename")
                {
                    arcticle.Rename(command[1]);
                }
            }

            Console.WriteLine(arcticle);
        }

        public class Article
        {
            public Article(string title, string content, string author)
            {
                this.Title = title;
                this.Content = content;
                this.Author = author;
            }

            public string Title { get; set; }

            public string Content { get; set; }

            public string Author { get; set; }

            public void Edit(string content)
            {
                this.Content = content;
            }

            public void ChangeAuthor(string author)
            {
                this.Author = author;
            }

            public void Rename(string title)
            {
                this.Title = title;
            }

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }

        }

        // 03. Articles 2.0
        public static void Articles2()
        {
            int n = int.Parse(Console.ReadLine());

            List<Article2> container = new List<Article2>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");

                Article2 art = new Article2(input[0], input[1], input[2]);

                container.Add(art);
            }

            string sorting = Console.ReadLine();
            List<Article2> result = new List<Article2>();

            if(sorting == "title")
            {
                result = container.OrderBy(x => x.Title).ToList();
            }
            else if(sorting == "content")
            {
                result = container.OrderBy(x => x.Content).ToList();
            }
            else
            {
                result = container.OrderBy(x => x.Author).ToList();
            }

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
        public class Article2
        {
            public Article2(string title, string content, string author)
            {
                this.Title = title;
                this.Content = content;
                this.Author = author;
            }

            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }

        // 04. Students
        public static void Students()
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");

                Student student = new Student(input[0], input[1], double.Parse(input[2]));

                students.Add(student);
            }

            students = students.OrderByDescending(x => x.Grade).ToList();

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        public class Student
        {
            public Student(string firstName, string lastName, double grade)
            {
                this.Firstname = firstName;
                this.Lastname = lastName;
                this.Grade = grade;
            }

            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public double Grade { get; set; }

            public override string ToString()
            {
                return $"{Firstname} {Lastname}: {Grade:F2}";
            }
        }

        // 05. Teamwork Projecct
        public static void TeamworkProject()
        {
            int n = int.Parse(Console.ReadLine());

            var teamList = new List<Teamwork>();

            Teamwork teamContainsFiltes = null;
            Teamwork creatorOrMemberContainFilter = null;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split("-");
                string creator = input[0];
                string teamName = input[1];

                teamContainsFiltes = teamList.Find(x => x.Name == teamName);
                creatorOrMemberContainFilter = teamList.Find(x => x.Creator == creator);

                if (teamContainsFiltes != null)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (creatorOrMemberContainFilter != null)
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                  Teamwork newTeam = new Teamwork(creator, teamName);
                  teamList.Add(newTeam);

                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }

            string command;
            while((command = Console.ReadLine()) != "end of assignment")            
            {
                string[]splitedCommand = command.Split("->");
                string member = splitedCommand[0];
                string team = splitedCommand[1];

                teamContainsFiltes = teamList.Find(x => x.Name == team);
                creatorOrMemberContainFilter = teamList.Find(x => x.Members.Contains(member));
                if(teamContainsFiltes == null)
                {
                    Console.WriteLine($"Team {team} does not exist!");
                }
                else if(creatorOrMemberContainFilter != null || teamContainsFiltes.Creator.Contains(member) || teamContainsFiltes.Members.Contains(member))
                {
                    Console.WriteLine($"Member {member} cannot join team {team}!");
                }
                else
                {
                    teamContainsFiltes.Members.Add(member);
                }
            }

            var filtered = teamList.Where(x => x.Members.Count > 0)
                .OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.Name).ToList();

            var disband = teamList.Where(x => x.Members.Count == 0)
                .OrderBy(x => x.Name).ToList();

            foreach (var item in filtered)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Teams to disband:");
            foreach (var item in disband)
            {
                Console.WriteLine(item.Name);
            }
        }
        public class Teamwork
        {
            public Teamwork(string creator, string name)
            {
                this.Name = name;
                this.Creator = creator;
                this.Members = new List<string>();
            }
            public string Name { get; set; }
            public string Creator { get; set; }
            public List<string> Members { get; set; }
            public override string ToString()
            {
                List<string> sortedMembers = this.Members
                    .OrderBy(a => a)
                    .ToList();

                string output = $"{this.Name}\n";
                output += $"- {this.Creator}\n";

                for (int i = 0; i < sortedMembers.Count; i++)
                {
                    output += $"-- {sortedMembers[i]}\n";

                }
                return output.Trim();
            }
        }

        // 06. Vehicle Catalogue
        public static void VehicleCatalogue()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            StringBuilder sb = new StringBuilder();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] splittedCommand = command.Split(" ");
                string type = splittedCommand[0];
                string model = splittedCommand[1];
                string color = splittedCommand[2];
                int horsepower = int.Parse(splittedCommand[3]);

                if(type == "car")
                {
                    type = "Car";
                }
                else if(type == "truck")
                {
                    type = "Truck";
                }

                Vehicle vehicle = new Vehicle(type, model, color, horsepower);

                vehicles.Add(vehicle);
            }          

            string secondCommand;
            while ((secondCommand = Console.ReadLine()) != "Close the Catalogue")
            {
                var catalogueFilter = vehicles.Find(x => x.Model == secondCommand);

                sb.AppendLine(catalogueFilter.ToString());               
            }

            int carHorsePowerSum = vehicles.Where(x => x.Type == "Car").Sum(x => x.Horsepower);
            int carCount = vehicles.Where(x => x.Type == "Car").Count();
            int truckHorsePowerSum = vehicles.Where(x => x.Type == "Truck").Sum(x => x.Horsepower);
            int truckCount = vehicles.Where(x => x.Type == "Truck").Count();

            double carsHorsePowerTotal = carHorsePowerSum / (double)carCount;
            double truckHorsePowerTotal = truckHorsePowerSum / (double)truckCount;

            if (Double.IsNaN(carsHorsePowerTotal))
            {
                carsHorsePowerTotal = 0;
            }
            else if (Double.IsNaN(truckHorsePowerTotal))
            {
                truckHorsePowerTotal = 0;
            }

            sb.AppendLine($"Cars have average horsepower of: {carsHorsePowerTotal :F2}.");
            sb.AppendLine($"Trucks have average horsepower of: {truckHorsePowerTotal :F2}.");

            Console.WriteLine(sb.ToString());
        }
        public class Vehicle
        {
            public Vehicle(string type, string model, string color, int horsepower)
            {
                this.Type = type;
                this.Model = model;
                this.Color = color;
                this.Horsepower = horsepower;
            }
            public string Type { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public int Horsepower { get; set; }

            public override string ToString()
            {
                return $"Type: {this.Type}\nModel: {this.Model}\nColor: {this.Color}\nHorsepower: {this.Horsepower}";
            }
        }

        // 07. Order by Age
        public static void OrderByAge()
        {
            List<Person> persons = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] splittedInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = splittedInput[0];
                int id = int.Parse(splittedInput[1]);
                int age = int.Parse(splittedInput[2]);

                Person person = new Person(name, age, id);
                persons.Add(person);
            }

            List<Person> sorted = persons.OrderBy(x => x.Age).ToList();
          
            Console.WriteLine(String.Join("\n", sorted));
            
        }
        public class Person
        {
            public Person(string name, int age, int id)
            {
                this.Name = name;
                this.Age = age;
                this.Id = id;
            }
            public string Name { get; set; }
            public int Age { get; set; }
            public int Id { get; set; }
            public override string ToString()
            {
                return $"{this.Name} with ID: {this.Id} is {this.Age} years old.";
            }
        }
    }
}
