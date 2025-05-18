using System;
using System.Collections;


namespace Proyecto_Final
{

	public class Cliente
	{
		// Declaracion de variables para el constructor
		private String nombre;
		private int dni;
		
    	// Creación de propiedad la cual utilizamos para asignarle valor a las variables privadas
		public String Name {
			get { return nombre; } //get, nos devuelve el valor de la variable
			set { nombre = value; } //determinamos el valor de la variable cuando instanciemos
		}
    
		public int Dni {
			get { return dni; }
			set { dni = value; }
		}
    
		
		public Cliente(String nombre, int dni)
		{
			// Creacion del objeto y sus atributos;
			this.nombre = nombre;
			this.dni = dni;
			
			
		}

		/*
		// Lista la cual almacenara cada cliente
		public ArrayList listClientes = new ArrayList();
		
		public void NewReserva(Reserva reserva)
		{
			listClientes.Add(reserva);
		}

		public void MostrarDatosReserva()
		{
			foreach (Reserva r in listClientes) {
				Console.WriteLine("| Reserva a nombre de: " + NameReserva + " | DNI " + DniReserva + " | Fecha de Reserva: " + r.diaReservado + "/" + r.mesReservado + " |");
			}
		}*/

	}
}