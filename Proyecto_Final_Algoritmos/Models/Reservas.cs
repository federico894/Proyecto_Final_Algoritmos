using System;
using System.Collections;


namespace Proyecto_Final{
public class Reserva
{
    private int mes;
    private int dia;
    public int mesReservado
    {
        get { return mes; }
        set { mes = value; }
    }
    public int diaReservado
    {
        get { return dia; }
        set { dia = value; }
    }

    public Reserva(int dia, int mes)//Constructor para instanciar la reserva
    {
        this.mes = mes;
        this.dia = dia;
    }
}

}