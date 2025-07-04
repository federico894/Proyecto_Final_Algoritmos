﻿using System;
using System.Collections;

namespace Proyecto_Final_Algoritmos
{
	public static class Salon
	{
		private static ArrayList empleados;
		private static ArrayList clientes;
		private static ArrayList servicios;
		private static Calendario calendario;
		private static String nombre = "Salon de fiestas"; // Nombre genérico por defecto

		static Salon()
		{
			empleados = new ArrayList();
			calendario = new Calendario();
			clientes = new ArrayList();
			servicios = new ArrayList();
		}
		
		public static void agregar_servicio(Servicio servicio){
			servicios.Add(servicio);
		}
		
		public static void eliminar_servicio(Servicio servicio){
			servicios.Remove(servicio);
		}
		
		public static Servicio buscar_servicio(String nombre_serv_a_buscar){
			foreach (Servicio s in servicios) {
				if (s.Nombre_servicio.ToLower() == nombre_serv_a_buscar.ToLower()){
					return s;
				}
			}
			
			// No se encontró
			return null;
		}
		
		public static void subir_empleado(Empleado empleado){
			empleados.Add(empleado);
		}
		
		public static void bajar_empleado(Empleado empleado){
			empleados.Remove(empleado);
		}
		
		public static Empleado buscar_empleado_por_legajo(int legajo){
			foreach (Empleado empleado in empleados) {
				if(empleado.NroDeLegajo == legajo){
					return empleado;
				}
			}
			
			// No se encontró
			return null;
		}

		//Se agregan parametros al metodo para luego asignarle los valores en el main
		public static void reservar_salon(Evento nuevoEvento) {
			
			if(calendario.ya_reservado(nuevoEvento)){
				throw new ReservaExistenteException();
			}
			
			//metodo de agendar turno de calendario el cual realiza toda la comprobacion de que esta en el mes indicado con la cantidad de 
			//dias ideales, y si cumple todo se guarda en ListaDeEventos con todos los datos del evento y los servicios contratados
			calendario.agendar_turno(nuevoEvento);
		}
		
		public static void cancelar_evento(Evento evento) // Parametros los cuales pasamos en Program
		{
			if(calendario.cancela_con_antelacion(evento.Dia_reserva, evento.Mes_reserva)){
				evento.Cliente.reducir_dinero(evento.Costo_total - evento.Senia);
			}
			
			//se elimina de la lista de eventos
			calendario.Borrar_evento(evento);
		}
		
		public static void agregar_cliente(Cliente c){
			clientes.Add(c);
		}
		
		public static Cliente buscar_cliente(int cliente_dni){
			foreach (Cliente c in clientes) {
				if (c.Dni == cliente_dni){
					return c;
				}
			}
			
			// No se encontró
			return null;
		}
		
		public static String Nombre{
			get {
				return nombre;
			}
		}
		
		public static ArrayList Empleados{
			get {
				return empleados;
			}
		}
		
		public static Calendario Calendario{
			get {
				return calendario;
			}
		}
		
		public static ArrayList Clientes{
			get {
				return clientes;
			}
		}
		
		public static ArrayList Servicios{
			get {
				return servicios;
			}
		}
	}
}
