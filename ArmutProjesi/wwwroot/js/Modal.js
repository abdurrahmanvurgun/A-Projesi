// teklif viewine uygun bir modal oluştur
// modal içerisinde teklifin detayları ve onay butonu olmalı


// Modal Element
var modal = document.querySelector('.ngb-modal-window');

// Open Modal Function
function openModal() {
    modal.style.display = 'block';
}

// Close Modal Function
function closeModal() {
    modal.style.display = 'none';
}

// Event Listener for Close Button
var closeButton = document.querySelector('.ayva-modal__close-button');
closeButton.addEventListener('click', closeModal);

// Event Listener for Modal Overlay
modal.addEventListener('click', function (event) {
    if (event.target === modal) {
        closeModal();
    }
});

//// Event Listener for Next Button
//var nextButton = document.getElementById('next-button');
//nextButton.addEventListener('click', function (event) {
//    // Perform action when Next button is clicked
//});
