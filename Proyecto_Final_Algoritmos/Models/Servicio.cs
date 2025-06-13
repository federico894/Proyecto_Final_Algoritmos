using System;

namespace Proyecto_Final_Algoritmos
{

	public class Servicio
	{
		private String nombre_servicio;
		private String descripcion_serv;

		public Servicio(String nombre_servicio, String descripcion_serv)
		{
			this.nombre_servicio = nombre_servicio;
			this.descripcion_serv = descripcion_serv;
		}
		
		public void mostrar_info(){
			Console.WriteLine("----------------------------------------------");
			Console.WriteLine("| Servicio: {0}\n| - Descripción: {1}", nombre_servicio, descripcion_serv);
		}

		public String Nombre_servicio
		{
			get {
				return nombre_servicio;
			}
		}
		public String Descripcion_serv
		{
			get {
				return descripcion_serv;
			}
		}
	}
}
