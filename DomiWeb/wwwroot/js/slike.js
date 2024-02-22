$(document).ready(function () {
    // Rukovanje klikom na malu sliku
    $('.small-image').click(function () {
        var smallImageUrl = $(this).attr('src');

        // Postavljanje izvora velike slike
        $('#large-image').attr('src', smallImageUrl);

        // Prikazivanje kontejnera za veliku sliku
        $('#large-image-container').show();
    });

    // Rukovanje klikom na gumb "Zatvori"
    $('#close-button').click(function () {
        closeLargeImage();
    });

    // Sakrivanje velike slike klikom izvan nje ili pritiskom na tipku Escape
    $(document).on('click keydown', function (event) {
        if (!$(event.target).closest('.small-image').length && !$(event.target).closest('#large-image-container').length && (event.key === 'Escape' || event.keyCode === 27)) {
            closeLargeImage();
        }
    });

    function closeLargeImage() {
        $('#large-image').attr('src', '');
        $('#large-image-container').hide();
    }
});
