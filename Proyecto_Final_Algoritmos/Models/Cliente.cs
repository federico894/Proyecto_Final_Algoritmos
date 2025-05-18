using System;
using System.Collections;


namespace Proyecto_Final
{

public class Cliente
{
    //Declaracion de variables para el constructor
    private string nombre;
    private int dni;
    public string NameReserva
    {//Creación de propiedad la cual utilizamos para asignarle valor a las variables privadas
        get { return nombre; }//get, nos devuelve el valor de la variable
        set { nombre = value; }//determinamos el valor de la variable cuando instanciemos
    }
    public int DniReserva
    {
        get { return dni; }
        set { dni = value; }
    }
    public ArrayList listClientes = new ArrayList(); //Lista la cual almacenara cada cliente
    public Cliente()
    {//Creacion del objeto y sus atributos(definimos atributos con set, por eso el constructor esta vacio);
    }

    public void NewReserva(Reserva reserva)
    {
        listClientes.Add(reserva);
    }

    public void MostrarDatosReserva()
    {
        foreach (Reserva r in listClientes)
        {
            Console.WriteLine("| Reserva a nombre de: " + NameReserva +" | DNI "+DniReserva+ " | Fecha de Reserva: " + r.diaReservado + "/" + r.mesReservado+" |");
        }
    }

}
}