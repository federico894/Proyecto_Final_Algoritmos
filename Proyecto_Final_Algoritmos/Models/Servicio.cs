
using System;

namespace Proyecto_Final_Algoritmos
{

	public class Servicio
	{
		private string nombre_servicio;
		private string descripcion_serv;

		public Servicio(string nombre_servicio, string descripcion_serv)
		{
			this.nombre_servicio = nombre_servicio;
			this.descripcion_serv = descripcion_serv;
		}

		public string Nombre_servicio
		{
			get { return nombre_servicio; }
			set { nombre_servicio = value; }
		}
		public string Descripcion_serv
		{
			get { return descripcion_serv; }
			set { descripcion_serv = value; }
		}
	}
}
