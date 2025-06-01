using System;
using System.Collections;

namespace Proyecto_Final_Algoritmos
{
	public static class Salon
	{
		private static ArrayList empleados;
		private static ArrayList clientes;
		private static ArrayList servicios;
		private static Calendario calendario;
		
		// Nombre genérico por defecto
		private static String nombre = "Salon de fiestas";

		static Salon()
		{
			empleados = new ArrayList();
			calendario = new Calendario();
			clientes = new ArrayList();
			servicios = new ArrayList();
		}
		
		public static Servicio buscar_servicio(String nombre_serv_a_buscar){
			foreach (Servicio s in servicios) {
				if (s.Nombre_servicio.ToLower() == nombre_serv_a_buscar.ToLower()){
					return s;
				}
			}
			return null;
		}
		
		public static void agregar_servicio(Servicio servicio){
			servicios.Add(servicio);
		}
		
		public static void eliminar_servicio(Servicio servicio){
			servicios.Remove(servicio);
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
			return null;
		}

		public static void reservar_salon(Cliente cliente, int mes_salon, int dia_salon, String tipo, Encargado encargado, double costo_total, double senia, ArrayList lista_de_servicios) {
			//Se agregan parametros al metodo para luego asignarle los valores en el main
			
			//bool para hacer verificacion si esta reservado o no
			bool yareservado = false;
			
			//recorremos la lista de eventos la cual esta en la clase calendario
			foreach (Evento e in calendario.ListaDeEventos)
			{
				if (e.Mes_reserva == mes_salon && e.Dia_reserva == mes_salon)
				{
					//si el mes reservado que se encuentra en la lista de reservas es igual al mes ingresado por parametro
					Console.WriteLine("Esta fecha ya esta reservada");
					//entonces la fecha ya se encuentra reservada, el bool cambia a verdadero
					yareservado = true;
					// y finaliza if
					break;
				}

			}
			
			// si el bool no cambia su valor en el if entonces se va a cumplir esta condicional ya que esa fecha no estaba reservada y no cambio el bool
			if (!yareservado) {
				
				//lo mismo con todos los demas datos del evento
				Evento nuevoEvento = new Evento(cliente, mes_salon, dia_salon, tipo, encargado, costo_total, senia, lista_de_servicios);
				
				//una vez instanciado todo se pasa el evento al metodo de agendar turno de calendario
				//el cual realiza toda la comprobacion de que esta en el mes indicado con la cantidad de dias ideales, y si cumple todo se guarda en ListaDeEventos con todos los datos del evento y los servicios contratados
				calendario.agendar_turno(nuevoEvento);
				Console.WriteLine("Se ha realizado la reserva exitosamente!");
			}
			
			agregar_cliente(cliente);
			
			// COSITAS QUE FALTAN HACER
			// ! Comprobar si ya está reservado y levantar excepción | ! Faltaria levantar la excepcion
		}

		public static void cancelar_evento(int posicion_guardada) // Parametros los cuales pasamos en Program
		{
			//se elimina de la lista de eventos, pasamos como parametro la posicion guardada previamente en el foreach
			calendario.ListaDeEventos.RemoveAt(posicion_guardada);
		}
		
		public static void agregar_cliente(Cliente c){
			clientes.Add(c);
		}
		
		public static String Nombre{
			get {
				return nombre;
			}
			set{
				nombre = value;
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
