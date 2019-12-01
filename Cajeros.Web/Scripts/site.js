$(document).ready(function () {

    $(".iframe").click(function (e) {
        e.preventDefault();
        var ruta = $(this).attr("href");
        abrirIframe(ruta);
    });
});

function abrirIframe(ruta) {
    $.fancybox.open({ href: ruta, autoDimensions: true, type: 'iframe' });
}