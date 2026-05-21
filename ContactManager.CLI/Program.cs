using ContactManager.CLI;
using ContactManager.Core;

return
    new Menu(
        new SystemConsole(),
        //new ContactService(new InMemoryContactRepository()))
        new ContactService(new FileContactRepository()))
    .Run();

