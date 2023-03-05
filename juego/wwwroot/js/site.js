//Ajax Function with reload page
$('.AjaxForm').submit(function (e) {
    e.preventDefault();
    const form = $(this);
    const url = form.attr("action");
    const method = form.attr("method");
    const formdata = new FormData(this);
    const data = formdata ? formdata : form.serialize();

    Swal.fire({
        title: 'Atencion',
        text: 'Desea Continuar',
        icon: 'info',
        showCancelButton: true,
        confirmButtonText: 'Sí'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                method: method,
                url: url,
                data: data,
                cache: false,
                contentType: false,
                processData: false,
                success: function (resp) {
                    //console.log(resp);
                    var json = JSON.parse(resp);
                    if (json.Estado === 1) {
                        Swal.fire({
                            title: 'Registro Correcto',
                            text: json.Mensaje,
                            icon: 'success',
                            showCancelButton: false,
                            confirmButtonText: 'Ok!'
                        }).then((result) => {
                            if (result.value) {
                                location.reload();
                            }
                        });
                    } else {
                        Swal.fire('Oooops!!!', json.Mensaje, 'error');
                    }
                },
                error: function (badrequest) {
                    Swal.fire('Oooops!!!', 'Ha Ocurrido un Error, Intentelo Más Tarde Por Favor!', 'error');
                    console.log(badrequest);
                }
            });
        }
    });
});
//on click new button function - from navbar menu.
$('#new').click(function (e) {
    e.preventDefault();
    $('#addModal').modal('show');
});