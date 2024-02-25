// sweetAlertScript.js

$(document).ready(function () {
    $('#deleteButton').click(function () {
        Swal.fire({
            title: 'Jeste li sigurni?',
            text: 'Nećete više moći vratiti artikl nazad',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Da, obriši artikl!',
            cancelButtonText: 'Ne, vrati se nazad!'
        }).then((result) => {
            if (result.isConfirmed) {
                // Ako korisnik potvrdi brisanje, submitajte formu
                $('form').submit();
            }
        });
    });
});
