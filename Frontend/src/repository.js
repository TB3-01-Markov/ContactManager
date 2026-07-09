
loadTextFile();


class StorageContact {
    let contactsList = [];
    let idUpContact = 0;
    constructor(Contact) {
        this.contact = Contact;
    }

    voorstel() {
        //console.log("Hallo, ik ben " + this.naam + " en ik ben " + this.leeftijd + " jaar oud.");
    }
    async function loadTextFile() {
        try {
            var path = '../../data/contacts.txt'
            const response = await fetch(path);
            if (!response.ok) {
                throw new Error(`FOUT loadTextFile#1: ${response.status}`);
            }
            const textData = await response.text();
            const lines = textData.split("\n").filter(line => line.trim() !== "");
            contactsList = lines.map(line => stringToContactClass(line.trim()));
            renderContacts();

        }
        catch (error) {
            alert("FOUT loadTextFile#2: " + error.message);
        }
        function stringToContactClass(s) {
            const parts = s.split("<&>");

            return new Contact(
                parseInt(parts[0]),  // id
                parts[1],            // name
                parts[3],            // phone
                parts[2]             // email
            );
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
    

    function updateContact(uNaam, uPhone, uMail) {
        if (uNaam == null || String(uNaam).trim() === "") {
            alert("Naam mag niet empty!");
            console.log("empty / null / whitespace");
            return false;
        
        else {
            const con = contactsList.find(c => c.id === idUpContact);
            con.name = uNaam;
            con.phone = uPhone;
            con.email = uMail;
            return true;
    }
    }
}
/*
function stringToContact(s) {
    const parts = s.split("<&>");
    return {
        id: parseInt(parts[0]),
        name: parts[1],
        email: parts[2],
        phone: parts[3]
    };
}
*/
