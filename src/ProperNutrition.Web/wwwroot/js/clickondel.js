const DEL_BUTTON = document.getElementById("del");

function showAlert() {
    alert("Do you want deleted item?");
}

function run() {
    DEL_BUTTON.addEventListener("click", showAlert);
}

document.addEventListener("DOMContentLoaded", run);