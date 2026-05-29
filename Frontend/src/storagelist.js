var contactsList = [];
var ContactList = [];
class StorageContact{
    constructor(Contact) {
        this.contact = Contact;
    }

    voorstel() {
        //console.log("Hallo, ik ben " + this.naam + " en ik ben " + this.leeftijd + " jaar oud.");
    }
}
function addContact(name, phone, email) {

    let lastId = 0;
    if (contactsList.length > 0) {
        lastId = contactsList[contactsList.length - 1].id;
    }

    contactsList.push(new Contact(lastId + 1, name, phone, email));
    renderContacts();
}
function deleteContactById(id) {
    contactsList = contactsList.filter(c => c.id !== id);
}
let idUpContact = 0;

function updateContact(uNaam, uPhone, uMail) {
    if (uNaam == null || String(uNaam).trim() === "") {
        alert("Naam mag niet empty!");
        console.log("empty / null / whitespace");
        return false;
    }
    else {
        const con = contactsList.find(c => c.id === idUpContact);
        con.name = uNaam;
        con.phone = uPhone;
        con.email = uMail;
        return true;

    }
}