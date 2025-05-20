using System;
using System.Collections;

namespace Proyecto_Final_Algoritmos
{
	public class Salon
	{
		private ArrayList empleados;
		private ArrayList clientes;
		private ArrayList servicios;
		private String nombre;
		private Calendario calendario;

		public Salon(String nombre)
		{
			empleados = new ArrayList();
			calendario = new Calendario();
			clientes = new ArrayList();
			servicios = new ArrayList();
			this.nombre = nombre;
		}
		
		public void buscar_servicio(String nombre_serv){
			foreach (Servicio s in servicios) {
			}
		}
		
		public void agregar_servicio(Servicio servicio){
			servicios.Add(servicio);
		}
		
		public void eliminar_servicio(Servicio servicio){
			servicios.Remove(servicio);
		}
		
		public void subir_empleado(Empleado empleado){
			empleados.Add(empleado);
		}
		
		public void bajar_empleado(Empleado empleado){
			empleados.Remove(empleado);
		}
		
		public Empleado buscar_empleado_por_legajo(int legajo){
			foreach (Empleado empleado in empleados) {
				if(empleado.NroDeLegajo == legajo){
					return empleado;
				}
			}
			return null;
		}
		
		public void reservar_salon(Cliente cliente){
			calendario.agendar_turno(cliente);
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
		
		public ArrayList Clientes{
			get {
				return clientes;
			}
		}
	}
}
