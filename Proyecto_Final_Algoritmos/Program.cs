/*
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
			// Preparación del salón
			Salon salon = new Salon("Las Luces Verdes");
			
			mostrar_menu(salon);
		}
		
		// MENU PRINCIPAL
		public static void mostrar_menu(Salon salon)
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
				
				// Apartir de aca entran todos los else if los cuales seran cuando presionemos enter en alguna opcion//entonces compara en que posicion pulsamos Enter y genera la accion de esa opcion elegida
				else if (tecla.Key == ConsoleKey.Enter && posicion == 0) {
					// Agregar un servicio
					Console.Write("Ingrese nombre de servicio: ");
					String nom_serv = Console.ReadLine();
						
					Console.Write("Ingrese descripción del servicio: ");
					String desc_serv = Console.ReadLine();
						
					salon.agregar_servicio(new Servicio(nom_serv, desc_serv));
				
				} else if (tecla.Key == ConsoleKey.Enter && posicion == 1) {
					// Eliminar un servicio
					Console.Clear();
					
					Console.Write("Ingrese nombre de servicio a eliminar: ");
					String nombre_serv_a_buscar = Console.ReadLine();

					Servicio servicio_buscado = salon.buscar_servicio(nombre_serv_a_buscar);
					if (servicio_buscado != null) {
						salon.eliminar_servicio(servicio_buscado);
						Console.WriteLine("Servicio '{0}' eliminado con exito", servicio_buscado.Nombre_servicio);
					} else {
						Console.WriteLine("No se encontró el servicio");
					}
					Console.ReadKey(true);
				
				} else if (tecla.Key == ConsoleKey.Enter && posicion == 2) {
					// Dar de alta un empleado
					Console.Clear();
					
					Console.Write("Ingrese nombre de empleado/encargado: ");
					String nombre = Console.ReadLine();

					Console.Write("Ingrese apellido de empleado/encargado: ");
					String apellido = Console.ReadLine();

					Console.Write("Ingrese nro de legajo: ");
					int legajo = int.Parse(Console.ReadLine());

					Console.Write("Ingrese salario: (Decimales con coma): ");
					double salario = double.Parse(Console.ReadLine());

					Console.Write("Ingrese dni: ");
					int dni = int.Parse(Console.ReadLine());

					Console.Write("Ingrese tarea a desempeñar: ");
					String tarea = Console.ReadLine();

					Console.Write("¿Es encargado? Ingrese 's' o 'n'(Default): ");
					String enc = Console.ReadLine();

					if (enc == "s" || enc == "S") {
						Console.Write("Ingrese el plus que cobra el encargado (Decimales con coma): ");
						double plus = double.Parse(Console.ReadLine());

						Encargado e = new Encargado(nombre, apellido, dni, legajo, salario, tarea, plus);
						salon.subir_empleado(e);
					} else {
						Empleado e = new Empleado(nombre, apellido, dni, legajo, salario, tarea);
						salon.subir_empleado(e);
					}
				} else if (tecla.Key == ConsoleKey.Enter && posicion == 3) {
					Console.Clear();
					// Dar de baja un empleado
					
					Console.Write("Ingrese legajo de empleado/encargado: ");
					int leg = int.Parse(Console.ReadLine());

					Empleado emp = salon.buscar_empleado_por_legajo(leg);

					if (emp != null) {
						salon.bajar_empleado(emp);
						Console.WriteLine("Empleado: {0} {1} ({2}) eliminado con exito", emp.Nombre, emp.Apellido, emp.NroDeLegajo);
					} else {
						Console.WriteLine("No se encontró el empleado");
					}
					Console.ReadKey(true);
				} else if (tecla.Key == ConsoleKey.Enter && posicion == 4) {
					Console.Clear();
					// Reservar el salón para un evento

					// Ingresar info del cliente
					Console.Write("Ingrese nombre del cliente: ");
					String cliente_nombre = Console.ReadLine();

					Console.Write("Ingrese apellido del cliente: ");
					String cliente_apellido = Console.ReadLine();

					Console.Write("Ingrese dni del cliente: ");
					int cliente_dni = int.Parse(Console.ReadLine());

					Cliente c = new Cliente(cliente_nombre, cliente_apellido, cliente_dni);

					// Ingresar fecha y tipo
					Console.Write("Ingrese mes a reservar para el evento: ");
					int mes_reserva = int.Parse(Console.ReadLine());

					Console.Write("Ingrese dia a reservar para el evento: ");
					int dia_reserva = int.Parse(Console.ReadLine());

					Console.Write("Ingrese tipo de evento: ");
					String tipo = Console.ReadLine();

					// Ingresar encargado
					Console.Write("Ingrese legado del encargado: ");
					int legajo_enc_asignado = int.Parse(Console.ReadLine());
					Encargado enc_asignado = (Encargado)salon.buscar_empleado_por_legajo(legajo_enc_asignado);

					// Ingresar costo y senia
					Console.Write("Ingrese costo del evento: ");
					int costo = int.Parse(Console.ReadLine());

					Console.Write("Ingrese seña del evento: ");
					int senia = int.Parse(Console.ReadLine());

					// Pregunto por servicio(S)
					ArrayList lista_de_servicios = new ArrayList();
					String salir_loop;
					int i = 1;

					do {
						Console.Write("¿Desea agregar servicios? S/n ");
						salir_loop = Console.ReadLine().ToLower();
						if (salir_loop != "n") {
							Console.WriteLine("-- Agregando servicio n°{0} --", i);

							Console.Write("Ingrese nombre del servicio: ");
							String servicio_a_agregar = Console.ReadLine();

							//                                      |||
							// ACA SE DEBERIA LEVANTAR LA EXCEPCIÓN vvv
							Servicio s = salon.buscar_servicio(servicio_a_agregar);

							Console.Write("Ingrese cantidad de servicio: ");
							int cantidad = int.Parse(Console.ReadLine());

							Console.Write("Ingrese costo unitario del servicio: ");
							int costo_unit = int.Parse(Console.ReadLine());

							lista_de_servicios.Add(new ServicioItem(s.Nombre_servicio, s.Descripcion_serv, cantidad, costo_unit));
						}
					} while (salir_loop != "n");

					salon.reservar_salon(c, mes_reserva, dia_reserva, tipo, enc_asignado, costo, senia, lista_de_servicios);

				} else if (tecla.Key == ConsoleKey.Enter && posicion == 5) {
					Console.Clear();// Se limpia la consola al entrar a la opcion elegida
					Console.Write("Ingrese el numero de mes del evento:  ");
					int mes_c = int.Parse(Console.ReadLine());//variable para pasar por parametro luego
					
					ArrayList eventoenMes = salon.Calendario.buscar_eventos_por_mes(mes_c);//arraylist el cual llama al metodo el cual guarda la lista de eventos en ese mes
					salon.Calendario.mostrar_fechas_reservadas(eventoenMes);//usamos metodo para ver que fechas ya estan reservadas
					
					Console.WriteLine(" ");//salto de linea en consola
					
					Console.Write("Ingrese el dia del evento:  ");
					
					//Ingresamos el dia del mes el cual vamos a cancelar
					int dia_c = int.Parse(Console.ReadLine());
					
					//si la lista de eventos no esta vacia entonces
					if (salon.Calendario.ListaDeEventos.Count != 0)
					{
						//declaramos variable para guardar la posicion
						int posicion_guardada = -1;
						
						//indice para saber en que indice estamos parados en el foreach
						int posicion_bucle = 0;
						
						//recorremos la lista de eventos
						foreach (Evento e in salon.Calendario.ListaDeEventos)
						{
							//accedemos a sus atributos de mes y dia para hacer la comparacion con los parametros ingresamos
							//si el parametro mes es igual a mes y dia reservado
							if (mes_c == e.Mes_reserva && dia_c == e.Dia_reserva)
							{
								posicion_guardada = posicion_bucle;//se guarda la posicion la cual es el indice en el cual estamos parados
								Console.WriteLine("El evento a cancelar de la fecha " + e.Dia_reserva + "/" + e.Mes_reserva + " De el cliente " + e.Cliente.Nombre + " " + e.Cliente.Apellido + " DNI: " + e.Cliente.Dni);
								Console.WriteLine("¿Esta seguro desea cancelar el evento?");
								break;
							}
							posicion_bucle++; //termina el recorrido pero antes sumamos para que ahora el indice cambie a 1
						}
						if (posicion_guardada != -1)//si la posicion guardada es != de -1 significa que la fecha se encontro y se guardo
						{
							Evento item = (Evento)eventoenMes[posicion_guardada];//casteamos el evento de esa posicion para luego acceder a sus atributos
							String[] siNo = { "Si", "No" };//array con 2 opciones
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
										Console.ResetColor();//se resetea los colores antes de salir
									}
									else
									{
										Console.Write("   " + siNo[i] + "   ");//esta va a ser la opcion en la que no estamos parados por ende no tiene color
									}
								
								}
								Console.WriteLine(" ");
								ConsoleKeyInfo tecla_pulsada = Console.ReadKey(true);//guardamos la tecla que pulsamos
								
								if (tecla_pulsada.Key == ConsoleKey.RightArrow && p_eleccion < siNo.Length - 1)//si la tecla pulsada es la flecha derecha
								{//entonces la posicion seleccionada aumenta su valor y pasa a la siguiente opcion
									p_eleccion++;
								}
								
								else if (tecla_pulsada.Key == ConsoleKey.LeftArrow && p_eleccion > 0)
								{	//si la tecla pulsada es flecha izquierda entonces se resta para volver a la posicion anterior
									p_eleccion--;
								}
								
								else if (tecla_pulsada.Key == ConsoleKey.Enter && p_eleccion == 0)
								{
									//si pulsamos enter y estamos en la posicion 0 entonces significa que apretamos Si, entonces se elimina de la lista de eventos
									salon.cancelar_evento(posicion_guardada);
									Console.WriteLine("Se ha cancelado el evento con exito!");
									salir_eleccion = true;//bool cambia de valor para salir del while
									break;
								}
							
								else if (tecla_pulsada.Key == ConsoleKey.Enter && p_eleccion == 1)//si la opcion que pulsamos enter es 1 entonces estamos diciendo que no queremos cancelar el evento
								{
									Console.WriteLine("No se cancelará el evento, volviendo...");
									salir_eleccion = true;//salimos del while cambiando el valor del bool
									break;
								}
							}
						}
					}
					else
					{
						// si la lista esta vacia entonces se ejecuta todo lo anterior
						Console.WriteLine("No tienes reservas para cancelar...");
					}
					Console.ReadKey(true);
				
				} else if (tecla.Key == ConsoleKey.Enter && posicion == 6) {
					Console.Clear();
					mostrar_info(salon);
				
				} else if (tecla.Key == ConsoleKey.Enter && posicion == 7) { //ultima opcion la cual es salir, y si presionamos Enter finaliza el while
					salir = true;
				
				} else {
					Console.WriteLine("");
				}
			}
		}
		
		public static void mostrar_info(Salon salon)
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
					menu_eventos(salon);
				} else if (tecla_info.Key == ConsoleKey.Enter && posicion_info == 1) {
					menu_clientes(salon);
				} else if (tecla_info.Key == ConsoleKey.Enter && posicion_info == 2) {
					menu_empleados(salon);
				} else if (tecla_info.Key == ConsoleKey.Enter && posicion_info == 3) {
					menu_servicios(salon);
				} else if (tecla_info.Key == ConsoleKey.Enter && posicion_info == 4) {
					Console.Write("\nIngrese el mes (número de 1-12): ");
					int mes_seleccionado = int.Parse(Console.ReadLine());
					menu_eventos_mes(salon, mes_seleccionado);
				} else if (tecla_info.Key == ConsoleKey.Enter && posicion_info == 5) {
					salir_info = true;
				} else {
					Console.WriteLine("");
				}
			}
		}
		
		public static void menu_eventos(Salon salon)
		{
			// Listar eventos
			Console.Clear();
			
			foreach (Evento ev in salon.Calendario.ListaDeEventos) {
				Console.WriteLine("----------------------------------------------");
				Console.WriteLine("| Evento a nombre de: {0} {1}\n - DNI: {2}\n| - Fecha de reserva: {3}/{4}\n| - Tipo de evento: {5}\n| - Encargado {6} {7}\n| - Costo total {8}\n|  - Seña {9}", ev.Cliente.Nombre, ev.Cliente.Apellido, ev.Cliente.Dni, ev.Dia_reserva, ev.Mes_reserva, ev.Tipo_evento, ev.Encargado.Nombre, ev.Encargado.Apellido, ev.Costo_total, ev.Senia);
			}
			Console.WriteLine("----------------------------------------------");
			Console.ReadKey(true);
		}
		
		public static void menu_clientes(Salon salon)
		{
			// Listar clientes
			Console.Clear();
			
			foreach (Cliente cliente in salon.Clientes) {
				Console.WriteLine("----------------------------------------------");
				Console.WriteLine("| Cliente: {0} {1}\n| - Dni: {2}", cliente.Nombre, cliente.Apellido, cliente.Dni);
			}
			Console.WriteLine("----------------------------------------------");
			Console.ReadKey(true);
		}
		
		public static void menu_empleados(Salon salon)
		{
			// Listar empleados
			Console.Clear();
			
			foreach (Empleado empleado in salon.Empleados) {
				Console.WriteLine("----------------------------------------------");
				Console.WriteLine("| Empleado: {0} {1}\n| - Legajo: {2}\n| - DNI: {3}\n| - Salario: {4}\n| - Tarea a desempeñar: {5}", empleado.Nombre, empleado.Apellido, empleado.NroDeLegajo, empleado.Dni, empleado.calcularSalario(), empleado.TareaDesempeniar);
			}
			Console.WriteLine("----------------------------------------------");
			Console.ReadKey(true);
		}
		
		public static void menu_servicios(Salon salon)
		{
			// Listar clientes
			Console.Clear();
			
			foreach (Servicio servicio in salon.Servicios) {
				Console.WriteLine("----------------------------------------------");
				Console.WriteLine("| Servicio: {0}\n| - Descripción: {1}", servicio.Nombre_servicio, servicio.Descripcion_serv);
			}
			Console.WriteLine("----------------------------------------------");
			Console.ReadKey(true);
		}
		
		public static void menu_eventos_mes(Salon salon, int mes_seleccionado)
		{
			// Listar eventos de un mes determinado
			Console.Clear();
			
			// Busco eventos en ese mes
			ArrayList eventos_en_ese_mes = salon.Calendario.buscar_eventos_por_mes(mes_seleccionado);
			
			// Imprimo esos eventos
			foreach (Evento ev in eventos_en_ese_mes) {
				Console.WriteLine("----------------------------------------------");
				Console.WriteLine("| Evento a nombre de: {0} {1}\n| - DNI: {2}\n| - Fecha de reserva: {3}/{4}\n| - Tipo de evento: {5}\n| - Encargado {6} {7}\n| - Costo total {8}\n|  - Seña {9}", ev.Cliente.Nombre, ev.Cliente.Apellido, ev.Cliente.Dni, ev.Dia_reserva, ev.Mes_reserva, ev.Tipo_evento, ev.Encargado.Nombre, ev.Encargado.Apellido, ev.Costo_total, ev.Senia);
			}
			Console.WriteLine("----------------------------------------------");
			Console.ReadKey(true);
		}
		
		public static void mostrar_logo()
		{
			String dir = @"..\..\Logos\Logo.txt"; // Directorio del logo
			//Console.WriteLine("Directorio actual: {0}" Environment.CurrentDirectory);
			
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