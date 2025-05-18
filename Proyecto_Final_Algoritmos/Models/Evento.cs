using System;
using System.Collections;

namespace Proyecto_Final_Algoritmos
{
	public class Evento
	{
		private Cliente cliente;
		private DateTime fecha;
		private String tipo_evento;
		private ArrayList servicios;
		private Encargado encargado;
		private int costo_total;
		private int senia; // No Ñ :c

		public Evento(Cliente cliente, DateTime fecha, String tipo, ArrayList servicios, Encargado encargado, int costo_total, int senia)
		{
			// Constructor para instanciar la reserva
			this.cliente = cliente;
			this.fecha = fecha;
			this.tipo_evento = tipo;
			this.servicios = servicios;
			this.encargado = encargado;
			this.costo_total = costo_total;
			this.senia = senia;
		}
		
		public void agregar_servicio(){
			
		}
		
		public void eliminar_servicio(){
			
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
		
		public DateTime Fecha{
			get {
				return fecha;
			}
		}
	}
}
