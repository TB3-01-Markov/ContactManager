using System.Xml.Linq;

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
        /*
        private readonly InMemoryContactRepository repository;

        public ContactService(InMemoryContactRepository Mem)
        {
            repository = Mem;
        }
        */
        private readonly IContactRepository repository;
  
        public ContactService(IContactRepository repository)
        {
            this.repository = repository;
        }
        public void LoadContacts()
        {
           
        }
        public void SaveContacts()
        {

        }
        public void AddContact(string name, string phone, string email)
        {
            var contact = new Contact {Name = name, Phone = phone, Email = email};
           // if(repository.GetByName(contact.Name)
            repository.Add(contact);
        }
        public List<Contact> GetAllContacts()
        {
            return repository.GetAll().ToList();
        }
        public bool Update(Contact changecontact){
            Contact oudcontact = repository.GetById(changecontact.Id);
            Contact upcontact = new Contact();
            if (oudcontact != null)
            {
                upcontact.Id = changecontact.Id;

                if (!string.IsNullOrWhiteSpace(changecontact.Name)) upcontact.Name = changecontact.Name;
                else upcontact.Name = oudcontact.Name;

                if (!string.IsNullOrWhiteSpace(changecontact.Phone)) upcontact.Phone = changecontact.Phone;
                else upcontact.Phone= oudcontact.Phone;

                if (!string.IsNullOrWhiteSpace(changecontact.Email)) upcontact.Email = changecontact.Email;
                else upcontact.Email= oudcontact.Email;

                repository.Update(upcontact);
                return true;
            }
            else
            {
                return false;
                
            }
            
        }
        public List<Contact> ZoekenOpNaam(string naam)
        {
            List<Contact> ConOpNamen = repository.GetByName(naam);
            return ConOpNamen;
            
        }
      
        public Contact? existed (int id)
        {
            return repository.GetById(id);
        }
        public int IsContactNaam(string name)
        {
            return ZoekenOpNaam(name).Count;
        }
        public bool Delete(Contact contact)
        {

            repository.Delete(contact);
            return true;
        }             
    }
}