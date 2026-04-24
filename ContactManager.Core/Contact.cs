namespace ContactManager.Core
{
    
    
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
                            foreach(char  c in p)
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
}