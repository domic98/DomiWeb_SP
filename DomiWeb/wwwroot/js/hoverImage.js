// hoverImage.js

let timer;

function prikaziSliku() {
    clearTimeout(timer);
    document.getElementById('slikaContainer').style.display = 'block';

    timer = setTimeout(function () {
        sakrijSliku();
    }, 5000);
}

function sakrijSliku() {
    document.getElementById('slikaContainer').style.display = 'none';
    clearTimeout(timer);
}
