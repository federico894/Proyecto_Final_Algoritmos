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
			bool yareservado = false;//bool para hacer verificacion si esta reservado o no
			foreach (Evento e in calendario.ListaDeEventos)//recorremos la lista de eventos la cual esta en la clase calendario
			{
				if (e.Mes_reserva == mes_salon && e.Dia_reserva == mes_salon)
				{//si el mes reservado que se encuentra en la lista de reservas es igual al mes ingresado por parametro 
					Console.WriteLine("Esta fecha ya esta reservada");
					yareservado = true;//entonces la fecha ya se encuentra reservada, el bool cambia a verdadero
					break;// y finaliza if
				}

			}
			if (!yareservado) {// si el bool no cambia su valor en el if entonces se va a cumplir esta condicional ya que esa fecha no estaba reservada y no cambio el bool
				Evento nuevoEvento = new Evento(cliente, mes_salon, dia_salon, tipo, encargado, costo_total, senia, lista_de_servicios);//lo mismo con todos los demas datos del evento
				calendario.agendar_turno(nuevoEvento);//una vez instanciado todo se pasa el evento al metodo de agendar turno de calendario
													  //el cual realiza toda la comprobacion de que esta en el mes indicado con la cantidad de dias ideales, y si cumple todo se guarda en ListaDeEventos con todos los datos del evento y los servicios contratados
				Console.WriteLine("Se ha realizado la reserva exitosamente!");
			}
			// Añadir un evento + servicios | ! No es un solo servicio el que se agrega (hay que usar un while, lo hago yo)
			// Comprobar si ya está reservado y levantar excepción | ! Faltaria levantar la excepcion
			// Asignar un encargado | ! El encargado se asigna con un random()
			
			//Para usar este metodo hay que poner cada parametro igual
		}

		public void cancelar_evento(int mes_c, int dia_c, ArrayList eventoenMes)//parametros los cuales pasamos en Program
		{
			if (calendario.ListaDeEventos.Count != 0)//si la lista de eventos no esta vacia entonces
			{
				int posicion_guardada = -1;//declaramos variable para guardar la posicion
				int posicion_bucle = 0;//indice para saber en que indice estamos parados en el foreach
				foreach (Evento e in calendario.ListaDeEventos)//recorremos la lista de eventos
				{//accedemos a sus atributos de mes y dia para hacer la comparacion con los parametros ingresamos
					if (mes_c == e.Mes_reserva && dia_c == e.Dia_reserva)//si el parametro mes es igual a mes y dia reservado
					{
						posicion_guardada = posicion_bucle;//se guarda la posicion la cual es el indice en el cual estamos parados
						Console.WriteLine("El evento a cancelar de la fecha " + e.Dia_reserva + "/" + e.Mes_reserva + " De el cliente " + e.Cliente.Nombre + " " + e.Cliente.Apellido + " DNI: " + e.Cliente.Dni);
						Console.WriteLine("¿Esta seguro desea cancelar el evento?");
						break;
					}
					posicion_bucle++;//termina el recorrido pero antes sumamos para que ahora el indice cambie a 1
				}
				if (posicion_guardada != -1)//si la posicion guardada es != de -1 significa que la fecha se encontro y se guardo
				{
					Evento item = (Evento)eventoenMes[posicion_guardada];//casteamos el evento de esa posicion para luego acceder a sus atributos
					ArrayList siNo = new ArrayList() { "SI", "NO" };//array con 2 opciones 
					bool salir_eleccion = false;//bool para salir del while
					int p_eleccion = 0;//variable para comparar en que posicion estamos parados de las opciones
					while (!salir_eleccion)
					{
						Console.Clear();//Console.Clear para redibujar la consola cada que pulsemos una tecla
						Console.Write("               ");
						Console.WriteLine("El evento a cancelar de la fecha " + item.Dia_reserva + "/" + item.Mes_reserva + " De el cliente " + item.Cliente.Nombre + " " + item.Cliente.Apellido + " DNI: " + item.Cliente.Dni);
						Console.Write("                                       ");
						Console.WriteLine("¿Esta seguro desea cancelar el evento?");
						Console.Write("                                                  ");
						for (int i = 0; i < siNo.Count; i++)//for para recorrer la cantidad de opciones
						{
							if (i == p_eleccion)//si i es igual a la posicion en la que estamos parados 
							{//entonces se le da color a esa eleccion
								Console.ForegroundColor = ConsoleColor.White;
								Console.BackgroundColor = ConsoleColor.Red;
								Console.Write("   " + siNo[i] + "   ");
								Console.ResetColor();//se resetea los colores antes de salir
							}
							else
							{
								Console.Write("   " + siNo[i] + "   ");//esta va a ser la opcion en la que no estamos parados por ende no tiene color
							}
							
						}
						Console.WriteLine(" ");
						ConsoleKeyInfo tecla_pulsada = Console.ReadKey(true);//guardamos la tecla que pulsamos
						if (tecla_pulsada.Key == ConsoleKey.RightArrow && p_eleccion < siNo.Count - 1)//si la tecla pulsada es la flecha derecha
						{//entonces la posicion seleccionada aumenta su valor y pasa a la siguiente opcion
							p_eleccion++;
						}
						else if (tecla_pulsada.Key == ConsoleKey.LeftArrow && p_eleccion > 0)
						{	//si la tecla pulsada es flecha izquierda entonces se resta para volver a la posicion anterior
							p_eleccion--;
						}
						else if (tecla_pulsada.Key == ConsoleKey.Enter && p_eleccion == 0)
						{//si pulsamos enter y estamos en la posicion 0 entonces significa que apretamos Si, entonces se elimina de la lista de eventos
							calendario.ListaDeEventos.RemoveAt(posicion_guardada);//se elimina de la lista de eventos, pasamos como parametro la posicion guardada previamente en el foreach
							Console.WriteLine("Se ha cancelado el evento con exito!");
							salir_eleccion = true;//bool cambia de valor para salir del while
							break;
						}
						else if (tecla_pulsada.Key == ConsoleKey.Enter && p_eleccion == 1)//si la opcion que pulsamos enter es 1 entonces estamos diciendo que no queremos cancelar el evento
						{
							Console.WriteLine("Ok no cancelaremos el evento..");
							salir_eleccion = true;//salimos del while cambiando el valor del bool
							break;
						}

						}
				}
					Console.ReadKey(true);
			}
			else { Console.WriteLine("No tienes reservas para cancelar..."); }// si la lista esta vacia entonces se ejecuta todo lo anterior
			Console.ReadKey(true);
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
