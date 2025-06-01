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
		
		public Servicio buscar_servicio(String nombre_serv_a_buscar){
			foreach (Servicio s in servicios) {
				if (s.Nombre_servicio.ToLower() == nombre_serv_a_buscar.ToLower()){
					return s;
				}
			}
			return null;
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

		public void reservar_salon(Cliente cliente, int mes_salon, int dia_salon, String tipo, Encargado encargado, int costo_total, int senia, ArrayList lista_de_servicios) {
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
			if (!yareservado) {// si el bool no cambia su valor en el if entonces se va a cumplir esta condicional ya que esa fecha no estaba reservada y no cambio el bool
				Evento nuevoEvento = new Evento(cliente, mes_salon, dia_salon, tipo, encargado, costo_total, senia, lista_de_servicios);//lo mismo con todos los demas datos del evento
				//una vez instanciado todo se pasa el evento al metodo de agendar turno de calendario
				//el cual realiza toda la comprobacion de que esta en el mes indicado con la cantidad de dias ideales, y si cumple todo se guarda en ListaDeEventos con todos los datos del evento y los servicios contratados
				calendario.agendar_turno(nuevoEvento);
				Console.WriteLine("Se ha realizado la reserva exitosamente!");
			}
			
			agregar_cliente(cliente);
			
			// COSITAS QUE FALTAN HACER
			// ! Comprobar si ya está reservado y levantar excepción | ! Faltaria levantar la excepcion
		}

		public void cancelar_evento(int posicion_guardada)//parametros los cuales pasamos en Program
		{
			//se elimina de la lista de eventos, pasamos como parametro la posicion guardada previamente en el foreach
			calendario.ListaDeEventos.RemoveAt(posicion_guardada);
		}
		
		public void agregar_cliente(Cliente c){
			clientes.Add(c);
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
		
		public ArrayList Servicios{
			get {
				return servicios;
			}
		}
	}
}
