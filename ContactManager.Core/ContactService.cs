namespace ContactManager.Core
{
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
        public void Update(Contact contact){
            if (repository.GetById(contact.Id) != null)
            { 
                repository.Update(contact);
            }
            else
            {
                Console.WriteLine($"Contact met Id={contact.Id}  niet gevonden");
            }
            
        }
        public void ZoekenOpNaam(string naam)
        {
            List<Contact> ConOpNamen = repository.GetByName(naam);
            foreach (var con in ConOpNamen)
            {
                PrintContact(con);
                Console.WriteLine("-------------------");
            }
        }
        public void PrintContact(Contact contact)
        {
            Console.WriteLine($"ID: {contact.Id}");
            Console.WriteLine($"Naam: {contact.Name}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Phone: {contact.Phone}");
        }
        public void Delete(int id)
        {
            
            if (repository.GetById(id) != null)
            {
                var existing = repository.GetById(id);
                Console.WriteLine("Do you want delete contact");
                PrintContact(existing);
                Console.WriteLine("Y/N:");
                string yofn = Console.ReadLine();
                if(yofn == "Y" || yofn == "y")
                {
                    repository.Delete(existing);
                    Console.WriteLine("Contact was deleted.");
                }
                else
                {
                    Console.WriteLine("No division was selected.");
                }
                
            }
            else
            {
                Console.WriteLine($"Contact met Id={id}  niet gevonden");
            }
            

        }
    }
}