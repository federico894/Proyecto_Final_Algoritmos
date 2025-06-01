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

		public String Nombre_servicio
		{
			get {
				return nombre_servicio;
			}
			set {
				nombre_servicio = value;
			}
		}
		public String Descripcion_serv
		{
			get {
				return descripcion_serv;
			}
			set {
				descripcion_serv = value;
			}
		}
	}
}
