/*
 * Created by SharpDevelop.
 * User: fede
 * Date: 13/5/2025
 * Time: 12:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace Proyecto_Final_Algoritmos
{
	public class Salon
	{
		private ArrayList eventos;
		private ArrayList empleados;
		private String nombre;

		public Salon(String nombre)
		{
			empleados = new ArrayList();
			eventos = new ArrayList();
			this.nombre = nombre;
		}
		
		public void mostrar_menu(){
			// Menu
		}
		
		public void menu_eventos(){
			// Listar eventos
		}
		
		public void menu_clientes(){
			// Listar clientes
		}
		
		public void menu_empleados(){
			// Listar empleados
		}
		
		public void menu_eventos_mes(){
			// Listar eventos de un mes determinado
		}
		
		public void agregar_evento(){
			
		}
		
		public void eliminar_evento(){
			
		}
		
		public void subir_empleado(){
			
		}
		
		public void bajar_empleado(){
			
		}
		
		public void reservar_salon(){
			// Añadir un evento + servicios
			// Comprobar si ya está reservado y levantar excepción
			// Asignar un encargado
		}
		
		public void cancelar_evento(){
			// Comprobar fecha de cancelación
		}
	}
}
