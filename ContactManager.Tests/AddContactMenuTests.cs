using ContactManager.Core;

namespace ContactManager.Tests;

public class AddContactMenuTests
{
    private readonly InMemoryContactRepository repository = new();
    private readonly ContactService service;
    private readonly FakeConsole console = new();
    private readonly Menu menu;

    public AddContactMenuTests()
    {
        service = new ContactService(repository);
        menu = new Menu(console, service);
    }

    [Fact]
    public void Menu_AddContact_Flow()
    {
        console.Input.Enqueue("1");    
        console.Input.Enqueue("Elvis"); 
        console.Input.Enqueue("q");    
        menu.Run();
        List<string> expected =
            [ "1. Contact Toevoegen"
            , "q. Exit"
            , "Maak uw keuze:"
            , "Voer een naam in: "        
            , "Contact toegevoegd: Elvis"     
            , "1. Contact Toevoegen"
            , "q. Exit"
            , "Maak uw keuze:"
            ];
        Assert.Equal(expected, console.Output);
        var contact = repository.GetAll()[0];
        Assert.Equal(1, contact.Id);
        Assert.Contains("Elvis", contact.Name);
    }
}