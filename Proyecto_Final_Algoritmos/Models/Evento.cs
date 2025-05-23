using System;
using System.Collections;

namespace Proyecto_Final_Algoritmos
{
	public class Evento
	{
		private Cliente cliente;
		private int mes_reserva;
    	private int dia_reserva;
		private String tipo_evento;
		private ArrayList servicios;
		private Encargado encargado;
		private int costo_total;
		private int senia; // No Ñ :c

		public Evento(Cliente cliente, int mes, int dia, String tipo, ArrayList servicios, Encargado encargado, int costo_total, int senia)
		{
			// Constructor para instanciar la reserva
			this.cliente = cliente;
			this.tipo_evento = tipo;
			this.servicios = servicios;
			this.encargado = encargado;
			this.costo_total = costo_total;
			this.senia = senia;
			this.dia_reserva = dia;
			this.mes_reserva = mes;
		}

		public void agregar_servicio(Servicio s)
		{
			servicios.Add(s);//Agregamos el servicio al arraylist servicios
		}

		public void eliminar_servicio() {
			Console.WriteLine("Ingrese el nombre del servicio que desea eliminar: ")
			string nombre = Console.ReadLine(); //Ingreso de nombre del servicio a eliminar
			bool encontrado = false;//Declaracion de booleano falso para luego verificar que se encontro el servicio
			for (int i = 0; i < servicios.Count; i++)//for para recorrer el indice del arraylist servicios
			{
				Servicios s = (Servicios)servicios[i]//hacemos un casteo del objeto para que sea de tipo Servicios y asi poder acceder a sus propiedades
				if (servicios[i].Nombre_servicio == nombre)
				{//Si el nombre del servicio en el indice en el cual estamos parado es igual al nombre que ingresamos 
					servicios.Remove(s);//entonces se remueve ese servicio completo porque se encontro
					Console.WriteLine("¡Servicio eliminado con exito!")
					encontrado = true;//ahora encontrado cambia su valor a true 
					break;
				}
			}
			if (encontrado != true) { // Si encontrado sigue siendo false entonces no se encontro el servicio a eliminar
				Console.WriteLine("No se encontro el servicio a eliminar.");
			}
		}
		
		public ArrayList Servicios{
			get {
				return servicios;
			}
		}
		
		public Cliente Cliente{
			get {
				return cliente;
			}
		}
		
		public int Mes_reserva{
			get {
				return mes_reserva;
			}
		}
		
		public int Dia_reserva{
			get {
				return dia_reserva;
			}
		}
		
		public String Tipo_evento{
			get {
				return tipo_evento;
			}
		}
		
		public Encargado Encargado{
			get {
				return encargado;
			}
		}
		
		public int Costo_total{
			get {
				return costo_total;
			}
		}
		
		public int Senia{
			get {
				return senia;
			}
		}
	}
}
