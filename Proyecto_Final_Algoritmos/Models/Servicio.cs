/*
 * Created by SharpDevelop.
 * User: fede
 * Date: 13/5/2025
 * Time: 12:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Proyecto_Final_Algoritmos
{
	public class Servicio
	{
		private string nombre_servicio;
		private string descripcion_serv;
		
		public Servicio(string nombre_servicio, string descripcion_serv)
		{ 	this.nombre_servicio = nombre_servicio;
			this.descripcion_serv = descripcion_serv;
		}
			
		public string nombre_serv{
		get{return nombre_servicio;}
		set{nombre_servicio= value;}
		}
		public string descripcion{
		get{return descripcion_serv;}
		set{descripcion_serv = value;}
		}
	}
}
