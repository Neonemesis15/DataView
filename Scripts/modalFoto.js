//modalfoto

function renderModalFoto(renderTo, nombreFoto) {
   var modalDiv = renderTo + renderTo;
    
   if ($.trim(nombreFoto) == "")
       nombreFoto = 'http://sige.lucky.com.pe/Pages/Modulos/Operativo/Reports/FotoAndroid/img_noDisponible.jpg';

    var control = '<div id="' + modalDiv + '" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">'
                + '<div class="modal-header">'
                + '<button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>'
                + '<h3 id="myModalLabel">Foto</h3>'
                + '</div>'
                + '<div class="modal-body" style="text-align:center;">';
    control += '<div>';
    control += '<IMG SRC="'+nombreFoto+'" WIDTH=256 HEIGHT=200 BORDER=2 VSPACE=3 HSPACE=3 ALT="Foto">';
    control += '</div>';
    control += '</div>'
                + '<div class="modal-footer">'
                + '<button class="btn" data-dismiss="modal" aria-hidden="true">Cerrar</button>'
                + '</div>'
                + '</div>';
    $('#' + renderTo).html(control);
    
    $('#' + modalDiv).modal({
        keyboard: true
    });
}

function renderModalListaFoto(renderTo, ListaFoto, fotoPDV) {
    var modalDiv = renderTo + renderTo;

    

    //if (ListaFoto.length == 0)
        nombreFoto = 'http://services.lucky.com.pe:8082/Pages/Modulos/Operativo/Reports/FotoAndroid/img_noDisponible.jpg';

    var urlImg = "http://services.lucky.com.pe:8082/Pages/Modulos/Operativo/Reports/FotoAndroid/";
    var totalFotos = ListaFoto.length;
    style="max-width:95%;border:6px dashed #545565;"
    var control = '<div id="' + modalDiv + '" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">'
                + '<div class="modal-header">'
                + '<button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>'
                + '<h3 id="myModalLabel">Foto</h3>'
                + '</div>'
                + '<div class="modal-body" style="text-align:center;height:250px;">';
    control += '<div>';
    control += '<IMG SRC="' + fotoPDV + '" WIDTH=188 HEIGHT=147 BORDER=2 VSPACE=3 HSPACE=3 ALT="Foto" style="max-width:95%;border:6px dashed #CC0000;" >';

    for (i = 0; i < 5; i++) {
        ListaFoto.length
        if (i < ListaFoto.length)
            control += '<IMG SRC="' + ListaFoto[i].Nombre_Foto + '" WIDTH=188 HEIGHT=147 BORDER=2 VSPACE=3 HSPACE=3 ALT="Foto" >';
        else
            control += '<IMG SRC="' + nombreFoto + '" WIDTH=188 HEIGHT=100 BORDER=2 VSPACE=3 HSPACE=3 ALT="Foto">';

        if(i==0 || i==2)
            control += '<br>'
        
    }
    control += '</div>';
    control += '</div>'
                + '<div class="modal-footer">'
                + '<button class="btn" data-dismiss="modal" aria-hidden="true">Cerrar</button>'
                + '</div>'
                + '</div>';
    $('#' + renderTo).html(control);

    $('#' + modalDiv).modal({
        keyboard: true
    });
}