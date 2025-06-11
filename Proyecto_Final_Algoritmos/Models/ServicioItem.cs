using System;

namespace Proyecto_Final_Algoritmos
{
	public class ServicioItem
	{
		private Servicio servicio_asociado;
		private int cant_solicitada; // Se agrego atributo de cantidad solicitada del servicio
		private double costo_unitario; // Se agrego costo para cada servicio
		
		public ServicioItem(Servicio servicio_asociado, int cant_solicitada, double costo_unitario)
		{
			this.servicio_asociado = servicio_asociado;
			this.cant_solicitada = cant_solicitada;
			this.costo_unitario = costo_unitario;
		}
		
		public Servicio Servicio_asociado
		{
			get {
				return servicio_asociado;
			}
		}
		
		public int Cant_solicitada
		{
			get {
				return cant_solicitada;
			}
		}
		public double Costo_unitario
		{
			get {
				return costo_unitario;
			}
		}
		
		public void mostrar_info(){
			Console.WriteLine("|  - {0}\n|   - Cantidad: {1}\n|   - Precio unitario: ${2}", servicio_asociado.Nombre_servicio, cant_solicitada, costo_unitario);
		}
	}
}
