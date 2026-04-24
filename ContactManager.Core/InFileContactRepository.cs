using System;
using System.Collections.Generic;
using System.IO;

namespace ContactManager.Core
    {
        public class FileContactRepository : IContactRepository
        {
            private List<Contact> contactenList = new List<Contact>();
            private int nextId = 1;

            private static string path = "data/contacts.txt";

            public FileContactRepository()
            {
                EnsurePathExists();
                LoadFromFile();
            }

            private void EnsurePathExists()
            {
                if (!Directory.Exists("data"))
                {
                    Directory.CreateDirectory("data");
                }
            }

            private void LoadFromFile()
            {
                if (!File.Exists(path))
                    return;

                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    Contact c = StringToContact(line);

                    if (c != null)
                    {
                        contactenList.Add(c);
                    }
                }

                if (contactenList.Count > 0)
                {
                    nextId = contactenList[contactenList.Count - 1].Id + 1;
                }
            }

            private void SaveToFile()
            {
                string[] lines = new string[contactenList.Count];

                for (int i = 0; i < contactenList.Count; i++)
                {
                    lines[i] = ContactToString(contactenList[i]);
                }

                File.WriteAllLines(path, lines);
            }

            private string ContactToString(Contact c)
            {
                return $"{c.Id}<&>{c.Name}<&>{c.Email}<&>{c.Phone}";
            }

            private Contact StringToContact(string s)
            {
                string[] parts = s.Split("<&>");

                if (parts.Length < 4)
                    return null;

                return new Contact
                {
                    Id = int.Parse(parts[0]),
                    Name = parts[1],
                    Email = parts[2],
                    Phone = parts[3]
                };
            }

            public void Add(Contact contact)
            {
                contact.Id = nextId++;
                contactenList.Add(contact);
                SaveToFile();
            }

            public void Delete(Contact contact)
            {
                contactenList.Remove(contact);
                SaveToFile();
            }

            public void Update(Contact contact)
            {
                var existing = GetById(contact.Id);

                existing.Name = contact.Name;
                existing.Email = contact.Email;
                existing.Phone = contact.Phone;

                SaveToFile();
            }

            public IReadOnlyList<Contact> GetAll()
            {
                return contactenList;
            }

            public Contact GetById(int id)
            {
                foreach (var c in contactenList)
                {
                    if (c.Id == id)
                        return c;
                }

                throw new Exception("Contact not found");
            }

            public List<Contact> GetByName(string name)
            {
                List<Contact> result = new List<Contact>();

                foreach (var c in contactenList)
                {
                    if (c.Name.Contains(name))
                    {
                        result.Add(c);
                    }
                }

                return result;
            }
        }
    }


    /*
    class Test
    {
        public static void InFile()
        {
            string path = @"c:\Contacten.txt";
            
            FileStream fs;
            StreamWriter sw; 
            StreamReader sr;
            if (File.Exists(path) != true)
            {
                fs = File.Create(path);
            }
         
                sw = File.CreateText(path);
                sr = File.OpenText(path);
                using (sw)
                {
                    // sw.WriteLine("Hello");
                }

                using (sr)
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            
        }
    }
    public class InFileContactRepository : IContactRepository
    {
        //File.WriteAllText("voorbeeld.txt", "Hallo wereld!");
        private List<Contact> contactenList = new List<Contact>();
        private int nextId = 1;

        private static string path = @"c:\Contacten.txt";
        private FileStream fs = IsFile();
        private StreamWriter sw = File.CreateText(path);
        private StreamReader sr = File.OpenText(path);

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
            Contact c = new Contact();
            string[] cF = s.Split("<&>");
            c.Id = int.Parse(cF[0]);
            c.Name = cF[1];
            c.Email = cF[2];
            c.Phone = cF[3];
            return c;

        }
        public void Add(Contact contact)
        {
            //if (!contactenlist.Contains(contact)) contactenlist.Add(contact);
            contact.Id = nextId;
            nextId = nextId + 1;
            using (sw)
            {
                sw.WriteLine(ContactToString(contact));
                // sw.WriteLine("Hello");
            }
            //contactenList.Add(contact);
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
            List<Contact> colist = new List<Contact>();
            string[] allText = sr.ReadToEnd().Split('\n');
            foreach (string s in allText)
            {
                colist.Add(StringToContact(s));
            }
            return colist;
            //return contactenList;
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
}*/