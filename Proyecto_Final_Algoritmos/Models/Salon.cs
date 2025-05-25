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
				if (s.Nombre_servicio == nombre_serv_a_buscar){
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

		public void reservar_salon(Cliente cliente, int mes_salon, int dia_salon, String tipo, Encargado encargado, int costo_total, int senia, string nombre_servicio, string descripcion_serv, int cant_solicitada, int costo_unitario) {
			//Se agregan parametros al metodo para luego asignarle los valores en el main
			bool yareservado = false;//bool para hacer verificacion si esta reservado o no
			foreach (Evento e in calendario.ListaDeEventos)//recorremos la lista de eventos la cual esta en la clase calendario
			{
				if (e.Mes_reserva == mes_salon && e.Dia_reserva == mes_salon)
				{//si el mes reservado que se encuentra en la lista de reservas es igual al mes ingresado por parametro 
					Console.WriteLine("Esta fecha ya esta reservada");
					bool yareservado = true;//entonces la fecha ya se encuentra reservada, el bool cambia a verdadero
					break;// y finaliza if
				}

			}
			if (yareservado != true) {// si el bool no cambia su valor en el if entonces se va a cumplir esta condicional ya que esa fecha no estaba reservada y no cambio el bool
				ServicioItem nuevoServicio = new ServicioItem(nombre_servicio, descripcion_serv, cant_solicitada);//entonces se instancia el servicio el cual los datos los pasamos por parametros
				Evento nuevoEvento = new Evento(cliente, mes_salon, dia_salon, tipo, encargado, costo_total, senia);//lo mismo con todos los demas datos del evento
				calendario.agendar_turno(nuevoEvento);//una vez instanciado todo se pasa el evento al metodo de agendar turno de calendario
													  //el cual realiza toda la comprobacion de que esta en el mes indicado con la cantidad de dias ideales, y si cumple todo se guarda en ListaDeEventos con todos los datos del evento y los servicios contratados
				Console.WriteLine("Se ha realizado la reserva exitosamente!");
			}
			// Añadir un evento + servicios | ! No es un solo servicio el que se agrega (hay que usar un while, lo hago yo)
			// Comprobar si ya está reservado y levantar excepción | ! Faltaria levantar la excepcion
			// Asignar un encargado | ! El encargado se asigna con un random()
			
			//Para usar este metodo hay que poner cada parametro igual
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
		
		public ArrayList Servicios{
			get {
				return servicios;
			}
		}
	}
}
