using System;
using System.Collections;

namespace Proyecto_Final_Algoritmos
{
	public class Salon
	{
		private ArrayList empleados;
		private String nombre;
		private Calendario calendario;

		public Salon(String nombre)
		{
			empleados = new ArrayList();
			calendario = new Calendario();
			this.nombre = nombre;
		}
		
		public void subir_empleado(Empleado empleado){
			
		}
		
		public void bajar_empleado(Empleado empleado){
			
		}
		
		public void reservar_salon(Cliente cliente){
			calendario.AgendarTurno(cliente);
			// Añadir un evento + servicios
			// Comprobar si ya está reservado y levantar excepción
			// Asignar un encargado
		}
		
		public void cancelar_evento(){
			// Comprobar fecha de cancelación
		}
		
		public String Nombre{
			get {
				return nombre;
			}
		}
		
		public ArrayList Empleados{
			get {
				return empleados;
			}
		}
		
		public Calendario Calendario{
			get {
				return calendario;
			}
		}
	}
}
