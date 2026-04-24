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
            console.WriteLine("6. Contacten Load-from-File");
            console.WriteLine("7. Contact Save-in-File");
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
                case "6": HandleLoadFromFileContact(); break;
                case "7": HandleSaveInFileContact(); break;
                case "q": return false;
                default: console.WriteLine("geen optie"); break;
            }
            return true;
        }
        private void HandleLoadFromFileContact() { }
        private void HandleSaveInFileContact() { }
        private void HandleZoekenOpNaamContact()
        {
            console.Write("Enter de Naam van contact: ");
            string contNaam = console.ReadLine();
            service.ZoekenOpNaam(contNaam);
        }
        private void HandleDeleteContact()
        {
            console.Write("Enter de ID van contact: ");
            var ids = console.ReadLine();
            int idn = int.Parse(ids);
            service.Delete(idn);
        }
        private void HandleUpdateContact()
        {
            Contact conUp = new Contact();
            console.Write("Enter de ID van contact: ");
            var ids = console.ReadLine();
            int idn = int.Parse(ids);
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
            // Contact conUp = new Contact(idn, name, phone, email);

            service.Update(conUp);

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

            console.WriteLine($"Contact toegevoegd: {name}");

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
            else console.WriteLine("Geen contacten");

        }

    }
}