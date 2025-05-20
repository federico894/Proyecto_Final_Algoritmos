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
