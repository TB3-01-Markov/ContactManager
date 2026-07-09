//const openPopup = document.getElementById('openPopup');
const closePopup = document.getElementById('upcancel-btn');
const popupOverlay = document.getElementById('popupOverlay');

//renderContacts();





popupOverlay.addEventListener('click', (event) => {
    if (event.target === popupOverlay) popupOverlay.classList.remove('active');
});
closePopup.addEventListener('click', () => popupOverlay.classList.remove('active'));