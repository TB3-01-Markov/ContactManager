
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

});
