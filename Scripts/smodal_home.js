/* Control spinner Home -- Hernan :)*/
var SModal_home = function (v_nombre, v_ruta, v_width, v_height, v_tipo, v_titulo) {
    this.v_ruta = v_ruta;
    this.v_width = v_width;
    this.v_height = v_height;
    this.v_tipo = v_tipo;
    this.v_nombre = v_nombre;
    this.v_titulo = v_titulo;

    $('#' + this.v_nombre).addClass("dv_content");
    $('#' + this.v_nombre).append('<div class="dv_todo"></div>');
    $('#' + this.v_nombre).append('<div id="dx' + this.v_nombre + '"></div>');
    $("#dx" + this.v_nombre).addClass("dv_modal");
    $('#dx' + this.v_nombre).css('width', (this.v_width));
    $('#dx' + this.v_nombre).css('height', this.v_height);
    var vx_width = (screen.width - this.v_width) / 2;
    //var vx_height=(screen.height-this.v_height)/3; //se deshabilita solo por esta vez
    var vx_height = "5";
    //$('#dx' + this.v_nombre).css("top", vx_height);
    $('#dx' + this.v_nombre).css("top", "10");
    $('#dx' + this.v_nombre).css("left", vx_width);
    $('#dx' + this.v_nombre).append('<div id="dx_close' + this.v_nombre + '" >X</div>');
    $("#dx_close" + this.v_nombre).addClass("dv_op");
    //$('#dx'+this.v_nombre).append('<EMBED SRC="video.mp4" WIDTH="'+(this.v_width-10).toString()+'" HEIGHT="'+(this.v_height-10).toString()+'" autostart="false" CONTROLLER="true" KIOSKMODE="true" BGCOLOR="#000000"></embed> ');
    //$('#dx'+this.v_nombre).append('<EMBED SRC="video.mp4" WIDTH="'+(this.v_width-10).toString()+'" HEIGHT="'+(this.v_height-10).toString()+'" ></embed> ');

    if (this.v_titulo.length != 0) {
        $('#dx' + this.v_nombre).append('<div class="dv_home_titulo"  style="width:' + (this.v_width - 10).toString() + ';"><b style="padding-left:10px;">' + this.v_titulo + '</b></div>');
    }




    if (this.v_tipo == "video") {
        $('#dx' + this.v_nombre).append('<video width="' + (this.v_width - 10).toString() + '" height="' + (this.v_height - 10).toString() + '" controls> <source src="' + this.v_ruta + '" type="video/mp4"><source src="video.ogg" type="video/ogg"></video>');
    }
    if (this.v_tipo == "imagen") {
        $('#dx' + this.v_nombre).append('<img src="' + this.v_ruta + '" width="' + (this.v_width - 10).toString() + '" height="' + (this.v_height - 10).toString() + '" />');
    }





    $('#dx_close' + this.v_nombre).click(function () {

        /*$('.dv_content').remove();*/
        $('#dv_modal_home').removeClass('dv_content');
        $('.dv_todo').remove();
        $('.dv_modal').remove();
        $('.dv_op').remove();

        /*$('.dv_content').css('display','none');
        $('.dv_modal').css('display','none');
        $('.dv_op').css('display','none');
        $('div').remove('.dv_modal');
        //alert(screen.height);
        SModal_home=null;*/
    });


};