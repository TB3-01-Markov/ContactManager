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

