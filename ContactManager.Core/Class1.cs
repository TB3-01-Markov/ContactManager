using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Core
{
    public interface IConsole
    {
        public void WriteLine(string message);
        public void Write(string message);
        public string ReadLine();
    }



    /*
    public class Class1
    {
        //IReadOnlyList<Contact> ConMemo = new IReadOnlyList<Contact>();
        InMemoryContactRepository Mem = new InMemoryContactRepository();
        public Contact SetContact()
        {
            Contact Con = new Contact();

            Console.Write("Enter name: ");
            Con.SetName(Mem);

            Console.Write("Enter phone: ");
            Con.SetPhone();

            Console.Write("Enter email: ");
            Con.SetEmail();

            return Con;
        }
    }
    */
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        /*
                private int Id;
                private string Name;
                private string Phone;
                private string Email;

                public void SetContact(InMemoryContactRepository Memo)
                {
                  //  Memo.Add(this);
                }

                public void SetId(InMemoryContactRepository Memo)
                {
                    IReadOnlyList<Contact> ConL = Memo.GetAll();
                    //int id = ConL.Where(......);
                    //Id = ConL.Count;
                    //Id =  this.Id + 1;

                }

                public int GetId()
                {
                    return Id;
                }

                public void SetName(InMemoryContactRepository Memo)
                {

                    IReadOnlyList<Contact> ConL = Memo.GetAll();
                    string n = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(n) && n.Length < 100)
                    {
                        //if(!ConL.Where(Name.Contains(n)))
                        //if(!ConL.Any(Name.Contains(n));
                        //bool c = ConL.Contains(n);
                        // if(!Memo.GetAll().Contains(GetName()==n))
                        //bool b = ConL.Any(this.Name.Contains(n));
                        Name = n;
                    }
                    else
                    {
                        Console.WriteLine("Invalid name");
                    }
                }

                public string GetName()
                {
                    return Name;
                }

                public void SetPhone()
                {
                    string p = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(p))
                    {
                        if (p.Length > 2 && p.Length < 20)
                        {
                            foreach(char c in p)
                            {
                                if(!char.IsDigit(c)||c!='+'||c!=' '|| c!='(' || c!=')')
                                {
                                    Console.WriteLine("Invalid phone");
                                }
                            }
                            Phone = p;
                        }
                        else Console.WriteLine("Invalid phone");
                    }
                    else
                    {
                        Console.WriteLine("Invalid phone");
                    }
                }

                public string GetPhone()
                {
                    return Phone;
                }

                public void SetEmail()
                {
                    string e = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(e) && e.Contains("@") && e.Length>5)
                    {
                        Email = e;
                    }
                    else
                    {
                        Console.WriteLine("Invalid email");
                    }
                }

                public string GetEmail()
                {
                    return Email;
                }
        */
    }
    public class InMemoryContactRepository
    {
        private List<Contact> contactenList = new List<Contact>();
        private int nextId = 1;
        public void Add(Contact contact)
        {
            //if (!contactenlist.Contains(contact)) contactenlist.Add(contact);
            contact.Id = nextId;
            nextId = nextId + 1;
            contactenList.Add(contact);
        }

        public IReadOnlyList<Contact> GetAll()
        {
            return contactenList;
        }
    }
    /*
    public class OrderApplicationService
    {
        private readonly OrderRepository repository;
        private readonly PaymentGateway paymentGateway;

        public OrderApplicationService(
            OrderRepository repository,
            PaymentGateway paymentGateway)
        {
            this.repository = repository;
            this.paymentGateway = paymentGateway;
        }

        public void PlaceOrder(Order order)
        {
            order.Place();
            paymentGateway.Charge(order.TotalAmount);
            repository.Add(order);
        }
    }
    */
    public class ContactService
    {
        private readonly InMemoryContactRepository repository;

        public ContactService(InMemoryContactRepository Mem)
        {
            repository = Mem;
        }

        public void AddContact(string name, string phone, string email)
        {
            var contact = new Contact {Name = name, Phone = phone, Email = email};

            repository.Add(contact);
        }
        public List<Contact> GetAllContacts()
        {
            return repository.GetAll().ToList();
        }
    }

    public class Menu(IConsole console, ContactService service)
    {
        public int Run()
        {
            var running = true;
            while (running)
            {
                ShowMenu();
                running = HandleChoice(console.ReadLine());
            }
            return 0;
        }

        private void ShowMenu()
        {
            console.WriteLine("1. Contact Toevoegen");
            console.WriteLine("2. Contacten Tonen");
            console.WriteLine("q. Exit");
            console.Write("Maak uw keuze:");
        }

        private bool HandleChoice(string choice)
        {
            switch (choice)
            {
                case "1": HandleAddContact(); break;
                case "2": HandleShowContacts(); break;
                case "q": return false;
                default: console.WriteLine("Ongeldige optie."); break;
            }
            return true;
        }
        private void HandleAddContact()
        {
            console.Write("Enter de naam: ");
            var name = console.ReadLine();
 
            console.Write("Enter phone: ");
            var phone = console.ReadLine();

            console.Write("Enter email: ");
            var email = console.ReadLine();

            service.AddContact(name, phone, email);
            console.WriteLine($"Contact +added+: {name}");

        }
        private void HandleShowContacts()
        {
            var contacts = service.GetAllContacts();

            if (contacts.Count > 0)
            {
                foreach (var c in contacts)
                {
                    console.WriteLine($"ID: {c.Id}");
                    console.WriteLine($"Naam: {c.Name}");
                    console.WriteLine($"Email: {c.Email}");
                    console.WriteLine($"Phone: {c.Phone}");

                    console.WriteLine("-------------------");
                }
                
            }
            else console.WriteLine("Geen contacten gevonden.");

        }

    }
}