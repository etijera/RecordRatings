//$(document).ready(function () {
//    // [17, 74, 6, 39, 20, 85, 7]
//    //[82, 23, 66, 9, 99, 6, 2]
//    var data1 = [[gd(2012, 1, 1), 17], [gd(2012, 1, 2), 74], [gd(2012, 1, 3), 6], [gd(2012, 1, 4), 39], [gd(2012, 1, 5), 20], [gd(2012, 1, 6), 85], [gd(2012, 1, 7), 7]];

//    var data2 = [[gd(2012, 1, 1), 82], [gd(2012, 1, 2), 23], [gd(2012, 1, 3), 66], [gd(2012, 1, 4), 9], [gd(2012, 1, 5), 119], [gd(2012, 1, 6), 6], [gd(2012, 1, 7), 9]];
//    $("#canvas_dahs").length && $.plot($("#canvas_dahs"), [
//                data1, data2
//            ], {
//                series: {
//                    lines: {
//                        show: false,
//                        fill: true
//                    },
//                    splines: {
//                        show: true,
//                        tension: 0.4,
//                        lineWidth: 1,
//                        fill: 0.4
//                    },
//                    points: {
//                        radius: 0,
//                        show: true
//                    },
//                    shadowSize: 2
//                },
//                grid: {
//                    verticalLines: true,
//                    hoverable: true,
//                    clickable: true,
//                    tickColor: "#d5d5d5",
//                    borderWidth: 1,
//                    color: '#fff'
//                },
//                colors: ["rgba(38, 185, 154, 0.38)", "rgba(3, 88, 106, 0.38)"],
//                xaxis: {
//                    tickColor: "rgba(51, 51, 51, 0.06)",
//                    mode: "time",
//                    tickSize: [1, "day"],
//                    //tickLength: 10,
//                    axisLabel: "Date",
//                    axisLabelUseCanvas: true,
//                    axisLabelFontSizePixels: 12,
//                    axisLabelFontFamily: 'Verdana, Arial',
//                    axisLabelPadding: 10
//                    //mode: "time", timeformat: "%m/%d/%y", minTickSize: [1, "day"]
//                },
//                yaxis: {
//                    ticks: 8,
//                    tickColor: "rgba(51, 51, 51, 0.06)"
//                },
//                tooltip: false
//            });

//    function gd(year, month, day) {
//        return new Date(year, month - 1, day).getTime();
//    }
//});

//$(function () {
//    $('#world-map-gdp').vectorMap({
//        map: 'world_mill_en',
//        backgroundColor: 'transparent',
//        zoomOnScroll: false,
//        series: {
//            regions: [{
//                values: gdpData,
//                scale: ['#E6F2F0', '#149B7E'],
//                normalizeFunction: 'polynomial'
//            }]
//        },
//        onRegionTipShow: function (e, el, code) {
//            el.html(el.html() + ' (GDP - ' + gdpData[code] + ')');
//        }
//    });
//});

var icons = new Skycons({
    "color": "#73879C"
}),
            list = [
                "clear-day", "clear-night", "partly-cloudy-day",
                "partly-cloudy-night", "cloudy", "rain", "sleet", "snow", "wind",
                "fog"
            ],
            i;

for (i = list.length; i--; )
    icons.set(list[i], list[i]);

icons.play();

var doughnutData = [
            {
                value: 30,
                color: "#455C73"
            },
            {
                value: 30,
                color: "#9B59B6"
            },
            {
                value: 60,
                color: "#BDC3C7"
            },
            {
                value: 100,
                color: "#26B99A"
            },
            {
                value: 120,
                color: "#3498DB"
            }
        ];
var myDoughnut = new Chart(document.getElementById("canvas1").getContext("2d")).Doughnut(doughnutData);

//$(document).ready(function () {

//    var cb = function (start, end, label) {
//        console.log(start.toISOString(), end.toISOString(), label);
//        $('#reportrange span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
//    }

//    var optionSet1 = {
//        startDate: moment().subtract(29, 'days'),
//        endDate: moment(),
//        minDate: '01/01/2012',
//        maxDate: '12/31/2015',
//        dateLimit: {
//            days: 60
//        },
//        showDropdowns: true,
//        showWeekNumbers: true,
//        timePicker: false,
//        timePickerIncrement: 1,
//        timePicker12Hour: true,
//        ranges: {
//            'Today': [moment(), moment()],
//            'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
//            'Last 7 Days': [moment().subtract(6, 'days'), moment()],
//            'Last 30 Days': [moment().subtract(29, 'days'), moment()],
//            'This Month': [moment().startOf('month'), moment().endOf('month')],
//            'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
//        },
//        opens: 'left',
//        buttonClasses: ['btn btn-default'],
//        applyClass: 'btn-small btn-primary',
//        cancelClass: 'btn-small',
//        format: 'MM/DD/YYYY',
//        separator: ' to ',
//        locale: {
//            applyLabel: 'Submit',
//            cancelLabel: 'Clear',
//            fromLabel: 'From',
//            toLabel: 'To',
//            customRangeLabel: 'Custom',
//            daysOfWeek: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'],
//            monthNames: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
//            firstDay: 1
//        }
//    };
//    $('#reportrange span').html(moment().subtract(29, 'days').format('MMMM D, YYYY') + ' - ' + moment().format('MMMM D, YYYY'));
//    $('#reportrange').daterangepicker(optionSet1, cb);
//    $('#reportrange').on('show.daterangepicker', function () {
//        console.log("show event fired");
//    });
//    $('#reportrange').on('hide.daterangepicker', function () {
//        console.log("hide event fired");
//    });
//    $('#reportrange').on('apply.daterangepicker', function (ev, picker) {
//        console.log("apply event fired, start/end dates are " + picker.startDate.format('MMMM D, YYYY') + " to " + picker.endDate.format('MMMM D, YYYY'));
//    });
//    $('#reportrange').on('cancel.daterangepicker', function (ev, picker) {
//        console.log("cancel event fired");
//    });
//    $('#options1').click(function () {
//        $('#reportrange').data('daterangepicker').setOptions(optionSet1, cb);
//    });
//    $('#options2').click(function () {
//        $('#reportrange').data('daterangepicker').setOptions(optionSet2, cb);
//    });
//    $('#destroy').click(function () {
//        $('#reportrange').data('daterangepicker').remove();
//    });
//});

/// <summary>
/// onloadPage
/// Inicializar al momento de cargar ka ventana
/// </summary>
function onloadPage() {
    setInterval(inicializarIframe, 1000);
}

/// <summary>
/// inicializarIframe
/// Inicializar el iframe_AreaTrabajo al momento de cargar
/// </summary>
function inicializarIframe() {
    var objIframe = document.getElementById("iframe_AreaTrabajo");
    var iAlto = 0;
    if (objIframe !== null) {
        var objBody = objIframe.contentWindow.document.getElementsByTagName("body")[0];
        if (objBody !== undefined && objBody !== null) {
            iAlto = objBody.clientHeight;
            if (iAlto > 600) {
                objIframe.height = iAlto + 100;
            } else {
                objIframe.height = 600;
            }
        }
        objIframe.style.display = "block";
    }
}
/// <summary>
/// CerrarModal
/// Ocultar div cargando
/// </summary>
function CerrarModal() {
    $(".BloquearUI").hide();
}
/// <summary>
/// redireccionar
/// Manejo de las paginas que se abriran en la maqueta
/// </summary>
function redireccionar(sUrl) {
    try {
       
        objDiv = document.getElementById('div_AreaTarbajo');
        if (objDiv !== null) {
            $(".BloquearUI").show();
            sIframe = '<iframe src="' + sUrl + '" frameborder="0" onload="inicializarIframe();CerrarModal();"  scrolling="no" marginheight="0" marginwidth="0" style="width: 100%;display:none;" id="iframe_AreaTrabajo"></iframe>'
            objDiv.innerHTML = sIframe;
        }
    } catch (e) {
        MostrarMensaje("ERROR linkInicio(): [ " + e.name + " - " + e.message + " ]", "E");
    }
}


function editarPerfil() {

    var sUrl = "Funcionales/Usuarios/Usuarios.aspx?Editar=1&IdUsuario=" + $("#hidden_IdUsuario").val() + "&Rol=" + $.parseJSON($("#hidden_Usuario").val())[0].RolUsuario;
    redireccionar(sUrl);
}


function CerrarSesion() {
    try {
        var Parameter = {};
        WebMethod("MaquetaPrincipal.aspx/CerrarSesion", Parameter, "EndCallBackCerrarSesion");
    } catch (Ex) {
        MostrarMensaje("ERROR CerrarSesion(): [ " + Ex.name + " - " + Ex.message + " ]", "E");
    }
}

function EndCallBackCerrarSesion(Parameter, sResult) {
    try {
        if (sResult != undefined) {
            if (sResult.sCode)
                MostrarMensaje(sResult.sMessage, "E");
            else
                location.href = "Index.aspx";
        }
    } catch (Ex) {
        MostrarMensaje("ERROR EndCallBackCerrarSesion(): [ " + Ex.name + " - " + Ex.message + " ]", "E");
    }
}

