async function loadTextFile() {
    try {
        
        const response = await fetch('../../data/contacts.txt');
        //const response = await fetch('./data/contacts.txt');
        if (!response.ok) {
            throw new Error(`FOUT loadTextFile#1: ${response.status}`);
        }
        const textData = await response.text();
        const lines = textData.split("\n").filter(line => line.trim() !== "");
        contactsList = lines.map(line => stringToContactClass(line.trim()));
        renderContacts();
        
    } catch (error) {
        alert("FOUT loadTextFile#2: " + error.message);
    }
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

loadTextFile();

