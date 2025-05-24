
using System;

namespace Proyecto_Final_Algoritmos
{

	public class Servicio
	{
		private string nombre_servicio;
		private string descripcion_serv;
		private int cant_solicitada; //Se agrego atributo de cantidad solicitada del servicio
		private int costo_unitario;//Se agrego costo para cada servicio

		public Servicio(string nombre_servicio, string descripcion_serv, int cant_solicitada, int costo_unitario)
		{
			this.nombre_servicio = nombre_servicio;
			this.descripcion_serv = descripcion_serv;
			this.cant_solicitada = cant_solicitada;
			this.costo_unitario = costo_unitario;
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
		public int Cant_solicitada
		{
			get { return cant_solicitada; }
			set { cant_solicitada = value; }
		}
		public int Costo_unitario
		{
			get { return costo_unitario; }
			set{ costo_unitario = value; }
		}
	}
}
