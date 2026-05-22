const toggleBtn = document.getElementById("contactaddbar-btn");
const contactSection = document.getElementById("contactadd-section");

toggleBtn.addEventListener("click", () => {
    contactSection.classList.toggle("hidden");
});