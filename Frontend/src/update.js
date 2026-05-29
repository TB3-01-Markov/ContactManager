
document.querySelector('#tbodycontacten').addEventListener('click', function (e) {
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
