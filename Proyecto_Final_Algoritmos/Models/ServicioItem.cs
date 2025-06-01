using System;

namespace Proyecto_Final_Algoritmos
{
	public class ServicioItem : Servicio
	{
		private int cant_solicitada; // Se agrego atributo de cantidad solicitada del servicio
		private int costo_unitario; // Se agrego costo para cada servicio
		
		public ServicioItem(String nombre_servicio, String descripcion_serv, int cant_solicitada, int costo_unitario)
			: base(nombre_servicio, descripcion_serv)
		{
			this.cant_solicitada = cant_solicitada;
			this.costo_unitario = costo_unitario;
		}
		
		public int Cant_solicitada
		{
			get {
				return cant_solicitada;
			}
			set {
				cant_solicitada = value;
			}
		}
		public int Costo_unitario
		{
			get {
				return costo_unitario;
			}
			set{
				costo_unitario = value;
			}
		}
	}
}
