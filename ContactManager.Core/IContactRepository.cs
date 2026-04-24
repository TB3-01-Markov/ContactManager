namespace ContactManager.Core
{
    public interface IContactRepository
    {
        void Add(Contact contact);
        void Delete(Contact contact);
        IReadOnlyList<Contact> GetAll();
        Contact GetById(int id);
        List<Contact> GetByName(string name);
        void Update(Contact contact);
    }
    /*
    public interface IContactRepository
    {

        private readonly OrderRepository repository;

        public OrderService(OrderRepository repository)
        {
            this.repository = repository;
        }

        public void Add(Order order)
        {
            repository.Add(order);
        }
        public void Add(Order order)
        {
            using var connection = new SqlConnection("...");
            // SQL insert
        }
        Add(entity);
        GetAll()
        GetById(id)
        Update(entity)
        Delete(id)
    }

    */
}