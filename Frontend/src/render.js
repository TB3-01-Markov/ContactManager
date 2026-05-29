
function renderContacts() {
    tbody.innerHTML = "";
    contactsList.forEach(contact => {
        const row = document.createElement("tr");
        row.id = "tr-contact";
        row.innerHTML = `
            <td class="td-id">${contact.id}</td>
            <td class="td-name">${contact.name}</td>
            <td class="td-phone">${contact.phone}</td>
            <td class="td-mail">${contact.email}</td>
            <td>
                <button class="blue-button update-btn">UPDATE</button>
                <button class="red-button delete-btn">DELETE</button>
            </td>`;
        tbody.appendChild(row);
    });
}