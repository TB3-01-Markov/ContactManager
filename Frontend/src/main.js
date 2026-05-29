

const contactSection = document.getElementById("contactadd-section");

const tbody = document.getElementById("tbodycontacten");
//const openPopup = document.getElementById('openPopup');
const closePopup = document.getElementById('upcancel-btn');
const popupOverlay = document.getElementById('popupOverlay');
const saveUpdate = document.getElementById('upsave-btn');
let currentRow = null;

//renderContacts();





popupOverlay.addEventListener('click', (event) => {
    if (event.target === popupOverlay)  popupOverlay.classList.remove('active');
});
closePopup.addEventListener('click', () => popupOverlay.classList.remove('active'));
