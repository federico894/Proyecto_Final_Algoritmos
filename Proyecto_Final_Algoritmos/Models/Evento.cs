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
		private ArrayList servicios_items;
		private Encargado encargado;
		private double costo_total;
		private double senia;

		public Evento(Cliente cliente, int mes, int dia, String tipo, Encargado encargado, double senia)
		{
			// Constructor para instanciar la reserva
			this.cliente = cliente;
			this.tipo_evento = tipo;
			this.encargado = encargado;
			this.costo_total = 0;
			this.senia = senia;
			this.dia_reserva = dia;
			this.mes_reserva = mes;
			servicios_items = new ArrayList();
		}
		
		
		public void agregar_servicio(ServicioItem s)
		{
			servicios_items.Add(s);//Agregamos el servicio al arraylist servicios
		}
		
		public void calcularCostoTotal(){
			double total = 0;
			foreach (ServicioItem s in servicios_items) {
				total = total + (s.Cant_solicitada * s.Costo_unitario);
			}
			costo_total = total;
		}
		
		public void mostrar_info(){
			Console.WriteLine("----------------------------------------------");
			Console.WriteLine("| Evento a nombre de: {0} {1}\n| - DNI: {2}\n| - Fecha de reserva: {3}/{4}\n| - Tipo de evento: {5}\n| - Encargado: {6} {7} ({8})\n| - Costo total: ${9}\n| - Seña: ${10}", cliente.Nombre, cliente.Apellido, cliente.Dni, dia_reserva, mes_reserva, tipo_evento, encargado.Nombre, encargado.Apellido, encargado.NroDeLegajo, costo_total, senia);
			Console.WriteLine("| - Servicios contratados:");
			foreach (ServicioItem s in servicios_items) {
				s.mostrar_info();
			}
		}
		
		public ArrayList Servicios{
			get {
				return servicios_items;
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
		
		public double Costo_total{
			get {
				return costo_total;
			}
		}
		
		public double Senia{
			get {
				return senia;
			}
		}
	}
}
