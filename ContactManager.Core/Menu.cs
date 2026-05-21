namespace ContactManager.Core
{
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
            console.WriteLine("3. Contact Update");
            console.WriteLine("4. Contact Delete");
            console.WriteLine("5. Contact Zoeken-op-Naam");
            //console.WriteLine("6. Contacten Load-from-File");
            //console.WriteLine("7. Contact Save-in-File");
            console.WriteLine("q. Exit");
            console.Write("Maak uw keuze:");
        }

        private bool HandleChoice(string choice)
        {
            switch (choice)
            {
                case "1": HandleAddContact(); break;
                case "2": HandleShowContacts(); break;
                case "3": HandleUpdateContact(); break;
                case "4": HandleDeleteContact(); break;
                case "5": HandleZoekenOpNaamContact(); break;
              //  case "6": HandleLoadFromFileContact(); break;
               // case "7": HandleSaveInFileContact(); break;
                case "q": return false;
                default: console.WriteLine("geen optie"); break;
            }
            return true;
        }
        private void HandleLoadFromFileContact() {
            service.LoadContacts();
            console.WriteLine("Contacten loaded");
        }
        private void HandleSaveInFileContact() {
            service.SaveContacts();
            console.WriteLine("Contacten saved");
        }
        private void ShowOpNaamContact(string contNaam)
        {
            List<Contact> ConOpNamen = service.ZoekenOpNaam(contNaam);
            foreach (var contact in ConOpNamen)
            {
                PrintContact(contact);
            }
        }
        private void HandleZoekenOpNaamContact()
        {
            console.Write("Enter de Naam van contact: ");
            string contNaam = console.ReadLine();
            ShowOpNaamContact(contNaam);
        }
     
        
        private void HandleDeleteContact()
        {
            console.Write("Enter de ID van contact voor delete: ");

            var ids = console.ReadLine();

            if (!int.TryParse(ids, out int idn))
            {
                console.WriteLine("Invalid ID");
                return;
            }

            var contact = service.existed(idn);

            if (contact == null)
            {
                console.WriteLine($"Contact met Id={ids}  niet gevonden");
                return;
            }


            console.WriteLine("Do you want delete contact?");
            PrintContact(contact);
            console.Write("Y/N: ");

            string answer = console.ReadLine();

            if (answer == "Y" || answer == "y")
            {
                bool deleted = service.Delete(contact);

                if (deleted)
                {
                    console.WriteLine("Contact was deleted.");
                }
            }
            else
            {
                console.WriteLine("Delete canceled.");
            }
        }
        public void PrintContact(Contact contact)
        {
            console.WriteLine($"ID: {contact.Id}");
            console.WriteLine($"Naam: {contact.Name}");
            console.WriteLine($"Email: {contact.Email}");
            console.WriteLine($"Phone: {contact.Phone}");
            console.WriteLine("-------------------");
        }
        private void UpdateContact(int idn)
        {
            Contact conUp = new Contact();
            conUp.Id = idn;

            console.Write("Enter de nieuwe naam: ");
            var name = console.ReadLine();
            conUp.Name = name;

            console.Write("Enter de nieuwe phone: ");
            var phone = console.ReadLine();
            conUp.Phone = phone;
            console.Write("Enter de nieuwe email: ");
            var email = console.ReadLine();
            conUp.Email = email;

            bool isUpdate = service.Update(conUp);
            if (isUpdate == true)
            {
                console.WriteLine("Contact was updated.");
            }
            else
            {
                console.WriteLine($"Contact met Id={idn}  niet gevonden");
            }
        }
        private void HandleUpdateContact()
        {
            console.Write("Enter de ID van contact: ");
            var ids = console.ReadLine();
            int idn = int.Parse(ids);
            UpdateContact(idn);
        }
        private void HandleAddContact()
        {
            console.Write("Enter de naam: ");
            var name = console.ReadLine();
 
            console.Write("Enter phone: ");
            var phone = console.ReadLine();

            console.Write("Enter email: ");
            var email = console.ReadLine();
            int iscm = service.IsContactNaam(name);
            if (iscm>0)
            {
                console.WriteLine($"Er bestaat al een contactpersoon met de naam [{name}].");
                ShowOpNaamContact(name);
                console.WriteLine("Als u nog een contactpersoon met dezelfde naam wilt toevoegen, drukt u op -Y.");
                console.WriteLine("Als u een bestaande contactpersoon wilt toevoegen of bijwerken, drukt u op -U.");
                console.WriteLine("Als u het toevoegen van de contactpersoon wilt annuleren en terug wilt keren naar het hoofdmenu, drukt u Enter.");
                var keizen = console.ReadLine();
                if (keizen == "y" || keizen == "Y")
                {
                    service.AddContact(name, phone, email);
                    console.WriteLine($"Contact toegevoegd: {name}");
                }
                if (keizen == "u" || keizen == "U") {
                    if (iscm == 1)
                    {
                        UpdateContact(service.ZoekenOpNaam(name).First().Id);
                    }
                    else HandleUpdateContact();
                
                }
                else
                {
                    console.WriteLine("return naar hoofdmenu");
                    return;
                }
            }

            service.AddContact(name, phone, email);
            console.WriteLine($"Contact toegevoegd: {name}");

        }
        private void HandleShowContacts()
        {
            var contacts = service.GetAllContacts();

            if (contacts.Count > 0)
            {
                foreach (var c in contacts)
                {
                    PrintContact(c);
                }
                
            }
            else console.WriteLine("Geen contacten");

        }

    }
}