
const contactSection = document.getElementById("contactadd-section");
const toggleBtn = document.getElementById("contactaddbar-btn");
toggleBtn.addEventListener("click", () => contactSection.classList.toggle("hidden"));

const saveBtn = document.getElementById("addsave-btn");
saveBtn.addEventListener("click", () => {
    const name = document.getElementById("addName").value;
    const phone = document.getElementById("addPhone").value;
    const email = document.getElementById("addEmail").value;

    addContact(name, phone, email);


    contactSection.classList.add("hidden");
});

const cancelBtn = document.getElementById("addcancel-btn");
cancelBtn.addEventListener("click", () => {
    contactSection.classList.add("hidden");
});


document.querySelector('#tbodycontacten').addEventListener('click', function (e) {
    if (e.target.classList.contains('delete-btn')) {
        const ok = confirm("Delete?");
        if (!ok) return;
        const id = Number(e.target.closest('tr').querySelector('.td-id').textContent);
        deleteContactById(id);
        //const id = Number(e.target.dataset.id);
        //contactsList.remove(id);
        // renderContacts();

        e.target.closest('tr').remove();
    }
    if (e.target.classList.contains('update-btn')) {
        popupOverlay.classList.add('active');

        //idUpContact = Number(e.target.dataset.id);
        idUpContact = Number(e.target.closest('tr').querySelector('.td-id').textContent);

        const tr = e.target.closest('tr');
        currentRow = tr;

        const upname = currentRow.querySelector(".td-name").textContent;
        const upphone = currentRow.querySelector(".td-phone").textContent;
        const upemail = currentRow.querySelector(".td-mail").textContent;


        document.getElementById("upName").value = upname
        document.getElementById("upPhone").value = upphone
        document.getElementById("upEmail").value = upemail

    }
});



const saveUpdate = document.getElementById('upsave-btn');
let currentRow = null;



saveUpdate.addEventListener('click', () => {
    //currentRow = e.target.closest('tr');
    if (currentRow) {
        const uNaam = document.getElementById("upName").value;
        const uPhone = document.getElementById("upPhone").value;
        const uMail = document.getElementById("upEmail").value;



        if (updateContact(uNaam, uPhone, uMail)) {
            currentRow.querySelector(".td-name").textContent = uNaam;
            currentRow.querySelector(".td-phone").textContent = uPhone;
            currentRow.querySelector(".td-mail").textContent = uMail;
        }
        currentRow = null;
        idUpContact = null;
    }
    popupOverlay.classList.remove('active');
});
