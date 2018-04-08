using System;

namespace GLReferences
{
    // Summary:
    //     Specifies how a command string is interpreted.
    public enum Fechas
    {
        // Summary:
        //     Especifica el primer dia del mes actual (Default.)
        Hoy = 0,
        // Summary:
        //     Especifica el primer dia del mes actual (Default.)
        Primer_dia_del_Mes = 1,
        //
        // Summary:
        //     Especifica la misma fecha actual con un mes de atrazo
        Hace_un_Mes = 2,
        //
        // Summary:
        //     Especifica la misma fecha actual con un año de atrazo
        Hace_un_Año = 3,
        //
        // Summary:
        //     Especifica la fecha mas alejada
        El_origen_de_los_tiempos = 4,
        //
        // Summary:
        //     Especifica la fecha de inicio del año
        primer_dia_del_año = 5

    }

    public enum FechasProximas
    {
        // Summary:
        //     Especifica el dia actual (Default.)
        Hoy = 0,
        // Summary:
        //     Especifica el dia siguiente a la fecha actual
        Al_dia_siguiente = 1,
        //
        // Summary:
        //     Especifica el dia de la semana siguiente a la fecha actual
        A_la_semana_siguiente = 2,
        //
        // Summary:
        //     Especifica el dia del mes siguiente a la fecha actual
        Al_mes_siguiente = 3,
        //
        // Summary:
        //     Especifica el dia del año siguiente a la fecha actual
        Al_año_siguiente = 4,
        //
        // Summary:
        //     Especifica la fecha de inicio del año
        ultimo_dia_del_año = 5
    }

    public enum FechasAnteriores
    {
        // Summary:
        //     Especifica el dia actual (Default.)
        Hoy = 0,
        // Summary:
        //     Especifica el dia siguiente a la fecha actual
        Al_dia_anterior = 1,
        //
        // Summary:
        //     Especifica el dia de la semana siguiente a la fecha actual
        A_la_semana_anterior = 2,
        //
        // Summary:
        //     Especifica el dia del mes siguiente a la fecha actual
        Al_mes_anterior = 3,
        //
        // Summary:
        //     Especifica el dia del año siguiente a la fecha actual
        Al_año_anterior = 4
    }

    public enum OrdenarPor
    {
        // Summary:
        //     Especifica que la consulta realizada en el FrmShowit sea ordenada por le campo nombre.
        CampoNombre = 0,
        // Summary:
        //     Especifica que la consulta realizada en el FrmShowit sea ordenada por le campo codigo.
        CampoCodigo = 1,
        //
        // Summary:
        //     Especifica que la consulta realizada en el FrmShowit sea ordenada por le campo Id.
        CampoId = 2
    }
}
