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
		
		public void subir_empleado(){
			
		}
		
		public void bajar_empleado(){
			
		}
		
		public void reservar_salon(){
			eventos.Add();
			// Añadir un evento + servicios
			// Comprobar si ya está reservado y levantar excepción
			// Asignar un encargado
		}
		
		public void cancelar_evento(){
			// Comprobar fecha de cancelación
		}
		
		public void mostrar_menu(){
			// Menu
		}
		
		public void menu_eventos(){
			// Listar eventos
			foreach (Evento e in eventos) {
				Console.WriteLine("| Reserva a nombre de: " + e.Cliente.Name + " | DNI " + e.Cliente.Dni + " | Fecha de Reserva: " + e.Fecha.Date + " |");
			}
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
	}
}
