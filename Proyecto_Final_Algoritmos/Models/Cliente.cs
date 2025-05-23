﻿using System;


namespace Proyecto_Final_Algoritmos
{
	public class Cliente
	{
		// Declaracion de variables para el constructor
		private String nombre;
		private String apellido;
		private int dni;
		
		public Cliente(String nombre, String apellido, int dni)
		{
			// Creacion del objeto y sus atributos;
			this.nombre = nombre;
			this.apellido = apellido;
			this.dni = dni;
		}
		
		// Creación de propiedad la cual utilizamos para asignarle valor a las variables privadas
		public String Nombre {
			get {
				return nombre; //get, nos devuelve el valor de la variable
			} 
			set {
				nombre = value; //determinamos el valor de la variable cuando instanciemos
			}
		}
    
		public int Dni {
			get {
				return dni;
			}
			set {
				dni = value;
			}
		}
    	
		public String Apellido {
			get {
				return apellido;
			}
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