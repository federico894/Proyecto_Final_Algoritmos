using System;
using System.Collections;

namespace Proyecto_Final_Algoritmos
{
	public class Evento
	{
		private String nombre_cliente;
		private int dni_cliente;
		private DateTime fecha;
		private String tipo_evento;
		private ArrayList servicios;
		private Encargado encargado;
		private int costo_total;
		private int senia; // No Ñ :c

		public Evento(String nombre_cliente, int dni_cliente, DateTime fecha, String tipo, ArrayList servicios, Encargado encargado, int costo_total, int senia)
		{
			this.nombre_cliente = nombre_cliente;
			this.dni_cliente = dni_cliente;
			this.fecha = fecha;
			this.tipo_evento = tipo;
			this.servicios = servicios;
			this.encargado = encargado;
			this.costo_total = costo_total;
			this.senia = senia;
		}
		
		public ArrayList Servicios{
			get {
				return servicios;
			}
			set {
				servicios = value;
			}
		}
	}
}
