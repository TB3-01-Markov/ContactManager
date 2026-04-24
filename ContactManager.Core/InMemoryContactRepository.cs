namespace ContactManager.Core
{

    public class InMemoryContactRepository : IContactRepository
    {
        private List<Contact> contactenList = new List<Contact>();
        private int nextId = 1;
        private static string path = "data/contacts.txt";
       // private FileStream fs = IsFile();
        //private StreamWriter sw = File.CreateText(path);
        //private StreamReader sr = File.OpenText(path);
        

        private void EnsurePathExists()
        {
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }

            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }
        public static FileStream IsFile()
        {
            FileStream fst;
            if (File.Exists(path) != true)
            {
                fst = File.Create(path);
            }
            else
            {
                fst = File.OpenRead(path);
            }
            return fst;
        }
        public string ContactToString(Contact c)
        {
            string sCon = $"{c.Id}<&>{c.Name}<&>{c.Email}<&>{c.Phone}";
            return sCon;
        }
        public Contact StringToContact(String s)
        {
            //if (string.IsNullOrWhiteSpace(s)) return null;
            Contact c = new Contact();
            string[] cF = s.Split("<&>");
            c.Id = int.Parse(cF[0]);
            c.Name = cF[1];
            c.Email = cF[2];
            c.Phone = cF[3];
            return c;

        }
   

        public List<Contact> LoadContacten()
        {
            StreamReader sr = File.OpenText(path);
            List<Contact> colist = new List<Contact>();
            string [] text = File.ReadAllLines(path);
            //string[] allText = sr.ReadToEnd().Split('\n');
            foreach (string s in text)
            {
               // colist.Add(StringToContact(s));
                Contact contact = StringToContact(s);
                if (contact != null) colist.Add(contact);
            }
            return colist;
        }
   
        public void SaveContacten(List<Contact> licon){
            StreamWriter sw = File.CreateText(path);
            string inFile="";
            foreach (Contact c in licon){
                    inFile+=ContactToString(c)+'\n';
            }
            sw.Write(inFile);
        }
        public void SaveContacten2()
        {
            string[] lines = new string[contactenList.Count];

            for (int i = 0; i < contactenList.Count; i++)
            {
                Contact c = contactenList[i];
                lines[i] = ContactToString(c);
            }

            File.WriteAllLines(path, lines);
        }
        public void Add(Contact contact)
        {
            //if (!contactenlist.Contains(contact)) contactenlist.Add(contact);
            contact.Id = nextId;
            nextId = nextId + 1;
            contactenList.Add(contact);
        }
        public void Delete(Contact contact)
        {

            contactenList.Remove(contact);
        }
        public void Update(Contact contact)
        {
            var existing = GetById(contact.Id);
            existing.Name = contact.Name;
            existing.Phone = contact.Phone;
            existing.Email = contact.Email;
        }
        public IReadOnlyList<Contact> GetAll()
        {
            return contactenList;
        }
        public Contact GetById(int id)
        {
            foreach (var c in contactenList)
            {
                if (c.Id == id) return c;
            }
            throw new Exception("Contact not found");
        }
        public List<Contact> GetByName(string name)
        {
            List<Contact> cList = new List<Contact>();
            foreach (var c in contactenList)
            {
                if (c.Name.Contains(name) == true)
                {
                    cList.Add(c);
                }
            }
            return cList;
            throw new Exception("Contact not found");
        }
    }
}

