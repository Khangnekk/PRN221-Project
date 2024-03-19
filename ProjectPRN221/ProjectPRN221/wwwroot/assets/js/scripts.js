let dropArea = document.getElementById("drop-area");

["dragenter", "dragover", "dragleave", "drop"].forEach((eventName) => {
    dropArea.addEventListener(eventName, preventDefaults, false);
    document.body.addEventListener(eventName, preventDefaults, false);
});

["dragenter", "dragover"].forEach((eventName) => {
    dropArea.addEventListener(eventName, highlight, false);
});

["dragleave", "drop"].forEach((eventName) => {
    dropArea.addEventListener(eventName, unhighlight, false);
});

dropArea.addEventListener("drop", handleDrop, false);

function preventDefaults(e) {
    e.preventDefault();
    e.stopPropagation();
}

function highlight(e) {
    dropArea.classList.add("highlight");
}

function unhighlight(e) {
    dropArea.classList.remove("highlight");
}

function handleDrop(e) {
    let dt = e.dataTransfer;
    let files = dt.files;
    handleFiles(files);
}

function handleFiles(files) {
    [...files].forEach(uploadFile);
}

function uploadFile(file) {
    console.log("Uploading", file.name);
}

dropArea.addEventListener("click", () => {
    fileElem.click();
});

let fileElem = document.getElementById("fileElem");
fileElem.addEventListener("change", function (e) {
    handleFiles(this.files);
});


const importSchedulePopup = document.getElementById("uploadFilePopup");
const btnClose = document.getElementById("btnClose");
const importScheduleText = document.getElementById("impSchedule");

btnClose.addEventListener('click', () => {
    console.log("Click btnClose");
    importSchedulePopup.style.display = 'none';
});

importScheduleText.addEventListener('click', () => {
    console.log("Click importScheduleText");
    importSchedulePopup.style.display = 'block';
});

