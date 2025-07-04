﻿/*
 (Main Program File)
*/
using System;
using System.Collections;
using System.IO;

namespace Proyecto_Final_Algoritmos
{
	class Program
	{
		public static void Main(string[] args)
		{
			mostrar_menu();
		}
		
		// MENU PRINCIPAL
		public static void mostrar_menu()
		{
			String[] opciones = {
				"Agregar un servicio",
				"Eliminar un servicio",
				"Dar de 'alta' un empleado/encargado",
				"Dar de 'baja' un empleado/encargado",
				"Reservar el salón para un evento",
				"Cancelar un evento",
				"Consultar informacion relevante",
				"Salir"
			};
			
			// Entero el cual va a ser la posicion en la cual estemos en el menu
			int posicion = 0;
			bool salir = false;
			
			// Bucle while para que muestre el menu una y otra vez hasta que el bool salir sea igual a true
			while (!salir) {
				
				// ConsoleClear limpia toda la consola, esto para cada que el usuario presione una tecla no se acumulen lineas nuevas
				Console.Clear();
				
				// Cargar y mostrar el logo
				mostrar_logo();
				
				Console.WriteLine("Elija una opción:\n");
				
				// for para recorrer la lista de opciones y posicionarnos en su indice
				for (int i = 0; i < opciones.Length; i++) {
					
					// si el indice es igual a la posicion//con Console.ForegroundColor le asignamos el color de letra
					if (i == posicion) {
						Console.ForegroundColor = ConsoleColor.White;
						
						// con Console.BackgroundColor le asignamos  un color de fondo
						Console.BackgroundColor = ConsoleColor.Green;
						
						// Imprimimos en consola la opcion en la cual estamos parados con los colores previamentes asignados
						Console.WriteLine(opciones[i]);
						
						// Aca reseteamos el color para que las siguientes lineas de texto no sean afectadas
						Console.ResetColor();
						
					}
					
					// y cuando vallamos hacia una opcion distinta la linea que estaba en verde anteriormente vuelve a su color default ya que la consola se redibuja con ConsoleClear
					else {
						// este else imprime las lineas siguientes sin los colores, se complementa con el resetcolor
						Console.WriteLine(opciones[i]);
					}
				}
				
				// variable la cual guarda la tecla que presionamos
				ConsoleKeyInfo tecla = Console.ReadKey(true);
				
				// y que la posicion sea menor a la cantidad de elementos de la lista
				// usamos la propiedad .Key para acceder a la variable tecla y saber cual presionamos
				// ConsoleKey.DownArrow representa la tecla flecha hacia abajo, por lo cual hacemos la comparacion con la tecla.Key
				if (tecla.Key == ConsoleKey.DownArrow && posicion < opciones.Length - 1) {
					
					// para luego sumarle 1 a nuestra posicion entonces esto cambia nuestro for y entonces colorea el siguiente elemento de la lista
					posicion++;
					
				}
				
				// Aca todo lo mismo solo que es flecha hacia arriba entonces se resta posicion y basicamente volvemos a la opcion anterior
				else if (tecla.Key == ConsoleKey.UpArrow && posicion > 0) {
					posicion--;
				}
				
				// Apartir de aca entran todos los else if los cuales seran cuando
				// presionemos enter en alguna opcion
				// entonces compara en que posicion pulsamos Enter y
				// genera la accion de esa opcion elegida

				// Agregar un servicio
				else if (tecla.Key == ConsoleKey.Enter && posicion == 0) {
					Console.Clear();
					
					Console.Write("Ingrese nombre de servicio: ");
					String nom_serv = Console.ReadLine();
						
					Console.Write("Ingrese descripción del servicio: ");
					String desc_serv = Console.ReadLine();
						
					Salon.agregar_servicio(new Servicio(nom_serv, desc_serv));
				
				} else if (tecla.Key == ConsoleKey.Enter && posicion == 1) {
					// Eliminar un servicio
					Console.Clear();
					
					Console.Write("Ingrese nombre de servicio a eliminar: ");
					String nombre_serv_a_buscar = Console.ReadLine();

					Servicio servicio_buscado = Salon.buscar_servicio(nombre_serv_a_buscar);
					
					if (servicio_buscado != null) {
						Salon.eliminar_servicio(servicio_buscado);
						Console.WriteLine("Servicio '{0}' eliminado con exito", servicio_buscado.Nombre_servicio);
					} else {
						Console.WriteLine("No se encontró el servicio");
					}
					
					Console.ReadKey(true);
				
				}
				
				// Dar de alta un empleado
				else if (tecla.Key == ConsoleKey.Enter && posicion == 2) {
					
					Console.Clear();
					
					Console.Write("Ingrese nombre de empleado/encargado: ");
					String nombre = Console.ReadLine();

					Console.Write("Ingrese apellido de empleado/encargado: ");
					String apellido = Console.ReadLine();

					int legajo = pedir_int("Ingrese nro de legajo: ");

					double salario = pedir_double("Ingrese salario: (Decimales con coma): $");

					int dni = pedir_int("Ingrese dni: ");

					Console.Write("Ingrese tarea a desempeñar: ");
					String tarea = Console.ReadLine();

					Console.Write("¿Es encargado? Ingrese 's' o 'n'(Default): ");
					String enc = Console.ReadLine();

					if (enc == "s" || enc == "S") {
						double plus = pedir_double("Ingrese el plus que cobra el encargado (Decimales con coma): $");

						Encargado e = new Encargado(nombre, apellido, dni, legajo, salario, tarea, plus);
						Salon.subir_empleado(e);
					} else {
						Empleado e = new Empleado(nombre, apellido, dni, legajo, salario, tarea);
						Salon.subir_empleado(e);
					}
				}
				
				// Dar de baja un empleado
				else if (tecla.Key == ConsoleKey.Enter && posicion == 3) {
					Console.Clear();
					
					int leg = pedir_int("Ingrese legajo de empleado/encargado: ");

					Empleado emp = Salon.buscar_empleado_por_legajo(leg);

					if (emp != null) {
						Salon.bajar_empleado(emp);
						Console.WriteLine("Empleado: {0} {1} ({2}) eliminado con exito", emp.Nombre, emp.Apellido, emp.NroDeLegajo);
					} else {
						Console.WriteLine("No se encontró el empleado");
					}
					
					Console.ReadKey(true);
				}
				
				// Reservar el salón para un evento
				else if (tecla.Key == ConsoleKey.Enter && posicion == 4) {
					Console.Clear();
					
					// Ingresar info del cliente
					String cliente_nombre, cliente_apellido;
					Cliente cliente_del_evento;
					
					int cliente_dni = pedir_int("Ingrese dni del cliente: ");
					Cliente client_busq = Salon.buscar_cliente(cliente_dni);
					
					if(client_busq == null){
						// No se encontró un cliente en el programa
						Console.Write("Ingrese nombre del cliente: ");
						cliente_nombre = Console.ReadLine();
	
						Console.Write("Ingrese apellido del cliente: ");
						cliente_apellido = Console.ReadLine();
						
						cliente_del_evento = new Cliente(cliente_nombre, cliente_apellido, cliente_dni);
						
						Salon.agregar_cliente(cliente_del_evento);
					} else {
						// Se encontró un cliente con ese dni
						Console.WriteLine("Se encontró el cliente {0} {1}", client_busq.Nombre, client_busq.Apellido);
						cliente_apellido = client_busq.Apellido;
						cliente_nombre = client_busq.Nombre;
						cliente_del_evento = client_busq;
					}
					
					// Ingresar fecha y tipo
					int mes_reserva = pedir_int("Ingrese mes a reservar para el evento: ");

					int dia_reserva = pedir_int("Ingrese dia a reservar para el evento: ");

					Console.Write("Ingrese tipo de evento: ");
					String tipo = Console.ReadLine();

					// Ingresar encargado
					Encargado enc_asignado = pedir_encargado("Ingrese legado del encargado: ");
					
					// Ingresar senia
					double senia = pedir_double("Ingrese seña del evento: $");
					
					// Se crea el evento sin servicios
					Evento nuevoEvento = new Evento(cliente_del_evento, mes_reserva, dia_reserva, tipo, enc_asignado, senia);

					// Pregunto por servicio(S)
					bool salir_loop = false;
					int p_eleccion= 0;
					String[] siOno = { "Si", "No" };
					
					while (!salir_loop)
					{
						Console.Clear();
						Console.Write("¿Desea agregar servicios?");
						for (int i = 0; i < siOno.Length; i++)
						{
							if (i == p_eleccion)
							{
								Console.Write("  ");
								Console.ForegroundColor = ConsoleColor.White;
								Console.BackgroundColor = ConsoleColor.Green;
								Console.Write(" " + siOno[i] + " ");
								Console.ResetColor();
							}
							else { Console.Write("  "); Console.Write(" " + siOno[i] + " "); }
						}
						
						ConsoleKeyInfo teclaq = Console.ReadKey(true);
						
						if (teclaq.Key == ConsoleKey.RightArrow && p_eleccion < siOno.Length - 1)
						{
							p_eleccion++;
						}
						
						else if (teclaq.Key == ConsoleKey.LeftArrow && p_eleccion > 0)
						{
							p_eleccion--;
						}
						
						else if (teclaq.Key == ConsoleKey.Enter && p_eleccion == 0 && Salon.Servicios.Count != 0)
						{
							Console.Clear();
							Console.WriteLine("Servicios Disponibles:");
							foreach (Servicio servicio in Salon.Servicios)
							{
								Console.WriteLine("----------------------------------------------");
								Console.WriteLine(" | " + servicio.Nombre_servicio + " | ");
							}
							Console.WriteLine("----------------------------------------------");
							Console.Write("¿Cual servicio desea agregar?:  ");
							String servicio_a_agregar = Console.ReadLine();

							Servicio servicio_encontrado = Salon.buscar_servicio(servicio_a_agregar);

							int cantidad = pedir_int("Ingrese cantidad de servicio: ");

							double costo_unit = pedir_double("Ingrese costo unitario del servicio: $");
							
							// Agregar los servicios
							nuevoEvento.agregar_servicio(new ServicioItem(servicio_encontrado, cantidad, costo_unit));
							
							Console.WriteLine("\nServicio agregado con exito!");
							Console.ReadKey(true);
						}
						
						else if (teclaq.Key == ConsoleKey.Enter && p_eleccion == 0 && Salon.Servicios.Count == 0)
						{
							Console.WriteLine("\nNo hay servicios disponibles en este momento");
							salir_loop = true;
							Console.ReadKey(true);
							break;
						}
						
						else if (teclaq.Key == ConsoleKey.Enter && p_eleccion == 1)
						{
							salir_loop = true;
							break;
						}
					}

					// Calculamos el costo total del evento a partir de los servicios contratados
					nuevoEvento.calcularCostoTotal();
					
					try {
						// Reservamos en calendario
						Salon.reservar_salon(nuevoEvento);
						
						// Le restamos el dinero al cliente
						cliente_del_evento.aumentar_dinero(nuevoEvento.Costo_total - senia);
						
						// Fin
						Console.WriteLine("\nReserva realizada con exito!");
						Console.ReadKey(true);
					}
					catch (ReservaExistenteException ex) {
						Console.WriteLine("\nError: {0}", ex.Message);
						Console.ReadKey(true);
					}
				}
				
				// Eliminar un evento
				else if (tecla.Key == ConsoleKey.Enter && posicion == 5) {
					// Se limpia la consola al entrar a la opcion elegida
					Console.Clear();
					
					//variable para pasar por parametro luego
					int mes_c = pedir_int("Ingrese el numero de mes del evento: ");
					
					//arraylist el cual llama al metodo el cual
					// guarda la lista de eventos en ese mes
					ArrayList eventoenMes = Salon.Calendario.buscar_eventos_por_mes(mes_c);
					
					//Ingresamos el dia del mes el cual vamos a cancelar
					int dia_c;
					
					//si la lista de eventos no esta vacia entonces
					if (Salon.Calendario.ListaDeEventos.Count != 0 && eventoenMes.Count != 0)
					{	
						//usamos metodo para ver que fechas ya estan reservadas
						Salon.Calendario.mostrar_fechas_reservadas(eventoenMes);
						dia_c = pedir_int("Ingrese el dia del evento: ");
						
						//declaramos variable para guardar el evento a eliminar
						Evento evento_a_eliminar = null;
						
						//recorremos la lista de eventos
						foreach (Evento e in Salon.Calendario.ListaDeEventos)
						{
							//accedemos a sus atributos de mes y dia para hacer la comparacion con los parametros ingresamos
							//si el parametro mes es igual a mes y dia reservado
							if (mes_c == e.Mes_reserva && dia_c == e.Dia_reserva)
							{
								evento_a_eliminar = e;//entonces se guarda este evento en la variable
								break;
							}
						}
						
						if (evento_a_eliminar != null)
						{
							//array con 2 opciones
							String[] siNo = { "Si", "No" };
							
							//bool para salir del while
							bool salir_eleccion = false;
							
							//variable para comparar en que posicion estamos parados de las opciones
							int p_eleccion = 0;
							
							while (!salir_eleccion)
							{
								//Console.Clear para redibujar la consola cada que pulsemos una tecla
								Console.Clear();
								Console.Write("               ");
								Console.WriteLine("Evento a cancelar de la fecha " + evento_a_eliminar.Dia_reserva + "/" + evento_a_eliminar.Mes_reserva + " a nombre de " + evento_a_eliminar.Cliente.Nombre + " " + evento_a_eliminar.Cliente.Apellido + " (" + evento_a_eliminar.Cliente.Dni + ")");
								Console.Write("                                       ");
								Console.WriteLine("¿Esta seguro desea cancelar el evento?");
								Console.Write("                                                  ");
								
								//for para recorrer la cantidad de opciones
								for (int i = 0; i < siNo.Length; i++)
								{
									//si i es igual a la posicion en la que estamos parados
									if (i == p_eleccion) 
									{
										//entonces se le da color a esa eleccion
										Console.ForegroundColor = ConsoleColor.White;
										Console.BackgroundColor = ConsoleColor.Red;
										Console.Write("   " + siNo[i] + "   ");
										
										//se resetea los colores antes de salir
										Console.ResetColor();
									}
									
									else
									{
										//esta va a ser la opcion en la que no estamos parados por ende no tiene color
										Console.Write("   " + siNo[i] + "   ");
									}
								}
								Console.Write("\n");
								
								//guardamos la tecla que pulsamos
								ConsoleKeyInfo tecla_pulsada = Console.ReadKey(true);
								
								if (tecla_pulsada.Key == ConsoleKey.RightArrow && p_eleccion < siNo.Length - 1)//si la tecla pulsada es la flecha derecha
								{
									//entonces la posicion seleccionada aumenta su valor y pasa a la siguiente opcion
									p_eleccion++;
								}
								
								else if (tecla_pulsada.Key == ConsoleKey.LeftArrow && p_eleccion > 0)
								{	
									//si la tecla pulsada es flecha izquierda entonces se resta para volver a la posicion anterior
									p_eleccion--;
								}
								
								else if (tecla_pulsada.Key == ConsoleKey.Enter && p_eleccion == 0)
								{
									//si pulsamos enter y estamos en la posicion 0 entonces significa que apretamos Si, entonces se cancela el evento
									Salon.cancelar_evento(evento_a_eliminar);
									Console.WriteLine("\nSe ha cancelado el evento con exito!");
									
									//bool cambia de valor para salir del while
									salir_eleccion = true;
									break;
								}
							
								//si la opcion que pulsamos enter es 1 entonces estamos diciendo que no queremos cancelar el evento
								else if (tecla_pulsada.Key == ConsoleKey.Enter && p_eleccion == 1)
								{
									Console.WriteLine("No se cancelará el evento, volviendo...");
									//salimos del while cambiando el valor del bool
									salir_eleccion = true;
									break;
								}
							}
						} else {
							Console.WriteLine("No existe la fecha ingresada...");
						}
					}
					
					else
					{
						// si la lista esta vacia entonces se ejecuta todo lo anterior
						Console.WriteLine("No tienes reservas para cancelar...");
					}
					Console.ReadKey(true);
				
				}
				
				// Mostrar info adicional
				else if (tecla.Key == ConsoleKey.Enter && posicion == 6) {
					Console.Clear();
					mostrar_info();
				
				}
				
				// ultima opcion la cual es salir, y si presionamos Enter finaliza el while
				else if (tecla.Key == ConsoleKey.Enter && posicion == 7) {
					salir = true;
				
				}
				
				// usuario hizo algo que no deberia
				else {
					Console.WriteLine("");
				}
			}
		}
		
		public static void mostrar_info()
		{
			// Submenu de mostrar info relevante
			String[] opciones_info = {
				"Listar eventos",
				"Listar clientes",
				"Listar empleados",
				"Listar servicios",
				"Listar eventos de un mes determinado",
				"Salir"
			};
			
			int posicion_info = 0;
			bool salir_info = false;
			
			while (!salir_info) {
				Console.Clear();
				
				mostrar_logo();
				
				Console.WriteLine("Elija una opción:\n");
			
				for (int j = 0; j < opciones_info.Length; j++) {
					
					if (j == posicion_info) {
						Console.ForegroundColor = ConsoleColor.White;
						Console.BackgroundColor = ConsoleColor.Green;
						Console.WriteLine(opciones_info[j]);
						Console.ResetColor();
						
					} else {
						Console.WriteLine(opciones_info[j]);
					}
				}
				
				ConsoleKeyInfo tecla_info = Console.ReadKey(true);
				
				if (tecla_info.Key == ConsoleKey.DownArrow && posicion_info < opciones_info.Length - 1) {
					posicion_info++;
				} else if (tecla_info.Key == ConsoleKey.UpArrow && posicion_info > 0) {
					posicion_info--;
				} else if (tecla_info.Key == ConsoleKey.Enter && posicion_info == 0) {
					menu_eventos();
				} else if (tecla_info.Key == ConsoleKey.Enter && posicion_info == 1) {
					menu_clientes();
				} else if (tecla_info.Key == ConsoleKey.Enter && posicion_info == 2) {
					menu_empleados();
				} else if (tecla_info.Key == ConsoleKey.Enter && posicion_info == 3) {
					menu_servicios();
				} else if (tecla_info.Key == ConsoleKey.Enter && posicion_info == 4) {
					int mes_seleccionado = pedir_int("\nIngrese el mes (número de 1-12): ");
					menu_eventos_mes(mes_seleccionado);
				} else if (tecla_info.Key == ConsoleKey.Enter && posicion_info == 5) {
					salir_info = true;
				} else {
					Console.WriteLine("");
				}
			}
		}
		
		public static void menu_eventos()
		{
			// Listar eventos
			Console.Clear();
			
			foreach (Evento ev in Salon.Calendario.ListaDeEventos) {
				ev.mostrar_info();
			}
			
			Console.WriteLine("----------------------------------------------");
			Console.ReadKey(true);
		}
		
		public static void menu_clientes()
		{
			// Listar clientes
			Console.Clear();
			
			foreach (Cliente cliente in Salon.Clientes) {
				cliente.mostrar_info();
			}
			Console.WriteLine("----------------------------------------------");
			Console.ReadKey(true);
		}
		
		public static void menu_empleados()
		{
			// Listar empleados
			Console.Clear();
			
			foreach (Empleado empleado in Salon.Empleados) {
				empleado.mostrar_info();
			}
			Console.WriteLine("----------------------------------------------");
			Console.ReadKey(true);
		}
		
		public static void menu_servicios()
		{
			// Listar clientes
			Console.Clear();
			
			foreach (Servicio servicio in Salon.Servicios) {
				servicio.mostrar_info();
			}
			Console.WriteLine("----------------------------------------------");
			Console.ReadKey(true);
		}
		
		public static void menu_eventos_mes(int mes_seleccionado)
		{
			// Listar eventos de un mes determinado
			Console.Clear();
			
			// Busco eventos en ese mes
			ArrayList eventos_en_ese_mes = Salon.Calendario.buscar_eventos_por_mes(mes_seleccionado);
			
			// Imprimo esos eventos
			foreach (Evento ev in eventos_en_ese_mes) {
				ev.mostrar_info();
			}
			Console.WriteLine("----------------------------------------------");
			Console.ReadKey(true);
		}
		
		public static int pedir_int(String mensaje){
			Console.Write(mensaje);
			String valor_str = Console.ReadLine();
			int valor;
			
			// Si no es un entero
			if(!int.TryParse(valor_str, out valor)){
				Console.WriteLine("\nIngrese un valor válido por favor\n");
				
				// usamos recursion hasta que el usuario se digne a entrar un valor correcto
				valor = pedir_int(mensaje);
			}else{
				return valor;
			}
			return valor;
		}
		
		public static double pedir_double(String mensaje){
			Console.Write(mensaje);
			String valor_str = Console.ReadLine();
			double valor;
			
			// Si no es un entero
			if(!double.TryParse(valor_str, out valor)){
				Console.WriteLine("\nIngrese un valor válido por favor\n");
				
				// usamos recursion hasta que el usuario se digne a entrar un valor correcto
				valor = pedir_int(mensaje);
			}else{
				return valor;
			}
			return valor;
		}
		
		public static Encargado pedir_encargado(String mensaje){
			int legajo_asignado_str = pedir_int(mensaje);
			Encargado valor;
			try{
				valor = (Encargado)Salon.buscar_empleado_por_legajo(legajo_asignado_str);
			}catch(InvalidCastException ex){
				Console.WriteLine("Ha ingresado un empleado que no es un Encargado!");
				Console.ReadKey(true);
				
				// usamos recursion hasta que el usuario se digne a entrar un valor correcto
				valor = pedir_encargado(mensaje);
			}
			
			
			// Si no es un entero
			if(valor == null){
				Console.WriteLine("\nNo se encontró el encargado, intentelo nuevamente\n");
				
				// usamos recursion hasta que el usuario se digne a entrar un valor correcto
				valor = pedir_encargado(mensaje);
			}else{
				return valor;
			}
			return valor;
		}
		
		public static void mostrar_logo()
		{
			String dir = @"..\..\Logos\Logo.txt"; // Directorio del logo
			// Sacar el directorio actual --> Console.WriteLine("Directorio actual: {0}" Environment.CurrentDirectory);
			
			// Verifico si existe el logo
			if (File.Exists(dir)) {
				Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
				String contenido_del_arch = File.ReadAllText(dir);
				Console.WriteLine(contenido_del_arch);
				Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
				Console.WriteLine("\n");
			} else {
				Console.WriteLine("*---------------------------*");
				Console.WriteLine("| No se pudo cargar el logo |");
				Console.WriteLine("*---------------------------*");
			}
		}
	}
}
