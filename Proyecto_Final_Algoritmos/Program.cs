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

			/*while (!salir) {
				Console.Clear();*/
				ArrayList opciones = new ArrayList(){"Agregar un servicio", "Eliminar un servicio", "Dar de 'alta' un empleado/encargado", "Dar de 'baja' un empleado/encargado", "Reservar el salón para un evento", "Cancelar un evento", "Consultar informacion relevante", "Salir"};
				int posicion = 0;//entero el cual va a ser la posicion en la cual estemos en el menu
				bool salir = false;
				while (salir != true)//bucle while para que muestre el menu una y otra vez hasta que el bool salir sea igual a true
				{
					Console.Clear();//ConsoleClear limpia toda la consola, esto para cada que el usuario presione una tecla no se acumulen lineas nuevas
					mostrar_logo();
					Console.WriteLine("\n");
					Console.WriteLine("¡Bienvenid@ al administrador del salón {0}!", salon.Nombre);
					Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-");
					Console.WriteLine(" ");
					for (int i = 0; i < opciones.Count; i++)//for para recorrer la lista de opciones y posicionarnos en su indice
					{
					if (i == posicion) //si el indice es igual a la posicion
					{//con Console.ForegroundColor le asignamos el color de letra
						Console.ForegroundColor = ConsoleColor.White;
						//con Console.BackgroundColor le asignamos  un color de fondo
						Console.BackgroundColor = ConsoleColor.Green;
						Console.WriteLine(opciones[i]); //Imprimimos en consola la opcion en la cual estamos parados con los colores previamentes asignados
						Console.ResetColor();//Aca reseteamos el color para que las siguientes lineas de texto no sean afectadas
							//y cuando vallamos hacia una opcion distinta la linea que estaba en verde anteriormente vuelve a su color default ya que la consola se redibuja con ConsoleClear
						}
					else
					{
						Console.WriteLine(opciones[i]);//este else imprime las lineas siguientes sin los colores, se complementa con el resetcolor
					}
					}
					ConsoleKeyInfo tecla = Console.ReadKey(true);// variable la cual guarda la tecla que presionamos

					if (tecla.Key == ConsoleKey.DownArrow && posicion < opciones.Count - 1)//usamos la propiedad .Key para acceder a la variable tecla y saber cual presionamos
					{   //ConsoleKey.DownArrow representa la tecla flecha hacia abajo, por lo cual hacemos la comparacion con la tecla.Key
					//y que la posicion sea menor a la cantidad de elementos de la lista 
						posicion++;//para luego sumarle 1 a nuestra posicion entonces esto cambia nuestro for y entonces colorea el siguiente elemento de la lista
					}
					else if (tecla.Key == ConsoleKey.UpArrow && posicion > 0)
					{ //Aca todo lo mismo solo que es flecha hacia arriba entonces se resta posicion y basicamente volvemos a la opcion anterior 
						posicion--;
					}
					else if (tecla.Key == ConsoleKey.Enter && posicion == 0)//Apartir de aca entran todos los else if los cuales seran cuando presionemos enter en alguna opcion
					{//entonces compara en que posicion pulsamos Enter y genera la accion de esa opcion elegida
						Console.Clear();//se limpia consola para que no se vea el menu
						Console.WriteLine("Ingrese nombre de servicio");
						String nom_serv = Console.ReadLine();

						Console.WriteLine("Ingrese descripción del servicio");
						String desc_serv = Console.ReadLine();

						salon.agregar_servicio(new Servicio(nom_serv, desc_serv));
					}
					else if (tecla.Key == ConsoleKey.Enter && posicion == 1)
					{	Console.Clear();
						Console.WriteLine("Ingrese nombre de servicio a eliminar");
						String nombre_serv_a_buscar = Console.ReadLine();

						Servicio servicio_buscado = salon.buscar_servicio(nombre_serv_a_buscar);
						if (servicio_buscado != null) {
							salon.eliminar_servicio(servicio_buscado);
							Console.WriteLine("Servicio '{0}' eliminado con exito", servicio_buscado.Nombre_servicio);
						} else {
							Console.WriteLine("No se encontró el servicio");
						}
						Console.ReadKey(true);
					}
					else if (tecla.Key == ConsoleKey.Enter && posicion == 2)
					{	Console.Clear();
						// Dar de alta un empleado
						Console.WriteLine("Ingrese nombre de empleado/encargado:");
						String nombre = Console.ReadLine();

						Console.WriteLine("Ingrese apellido de empleado/encargado:");
						String apellido = Console.ReadLine();

						Console.WriteLine("Ingrese nro de legajo:");
						int legajo = int.Parse(Console.ReadLine());

						Console.WriteLine("Ingrese salario: (Decimales con coma)");
						double salario = double.Parse(Console.ReadLine());

						Console.WriteLine("Ingrese dni:");
						int dni = int.Parse(Console.ReadLine());

						Console.WriteLine("Ingrese tarea a desempeñar:");
						String tarea = Console.ReadLine();

						Console.WriteLine("¿Es encargado? Ingrese 's' o 'n'(Default):");
						String enc = Console.ReadLine();

						if (enc == "s" || enc == "S") {
							Console.WriteLine("Ingrese el plus que cobra el encargado (Decimales con coma):");
							double plus = double.Parse(Console.ReadLine());

							Encargado e = new Encargado(nombre, apellido, dni, legajo, salario, tarea, plus);
							salon.subir_empleado(e);
						} else {
							Empleado e = new Empleado(nombre, apellido, dni, legajo, salario, tarea);
							salon.subir_empleado(e);
						}
					}
					else if (tecla.Key == ConsoleKey.Enter && posicion == 3)
					{	Console.Clear();
						// Dar de baja un empleado
						Console.WriteLine("Ingrese legajo de empleado/encargado:");
						int leg = int.Parse(Console.ReadLine());

						Empleado emp = salon.buscar_empleado_por_legajo(leg);

						if (emp != null) {
							salon.bajar_empleado(emp);
							Console.WriteLine("Empleado: {0} {1} ({2}) eliminado con exito", emp.Nombre, emp.Apellido, emp.NroDeLegajo);
						} else {
							Console.WriteLine("No se encontró el empleado");
						}
						Console.ReadKey(true);
					}
					else if (tecla.Key == ConsoleKey.Enter && posicion == 4)
					{	Console.Clear();
						// Reservar el salón para un evento

						// Ingresar info del cliente
						Console.WriteLine("Ingrese nombre del cliente:");
						String cliente_nombre = Console.ReadLine();

						Console.WriteLine("Ingrese apellido del cliente:");
						String cliente_apellido = Console.ReadLine();

						Console.WriteLine("Ingrese dni del cliente:");
						int cliente_dni = int.Parse(Console.ReadLine());

						Cliente c = new Cliente(cliente_nombre, cliente_apellido, cliente_dni);

						// Ingresar fecha y tipo
						Console.WriteLine("Ingrese mes a reservar para el evento:");
						int mes_reserva = int.Parse(Console.ReadLine());

						Console.WriteLine("Ingrese dia a reservar para el evento:");
						int dia_reserva = int.Parse(Console.ReadLine());

						Console.WriteLine("Ingrese tipo de evento:");
						String tipo = Console.ReadLine();

						// Ingresar encargado
						Console.WriteLine("Ingrese legado del encargado");
						int legajo_enc_asignado = int.Parse(Console.ReadLine());
						Encargado enc_asignado = (Encargado)salon.buscar_empleado_por_legajo(legajo_enc_asignado);

						// Ingresar costo y senia
						Console.WriteLine("Ingrese costo del evento");
						int costo = int.Parse(Console.ReadLine());

						Console.WriteLine("Ingrese senia del evento");
						int senia = int.Parse(Console.ReadLine());

						// Pregunto por servicio(S)
						ArrayList lista_de_servicios = new ArrayList();
						String salir_loop;
						int i = 1;

						do {
							Console.WriteLine("¿Desea agregar servicios? S/n");
							salir_loop = Console.ReadLine().ToLower();
							if (salir_loop != "n") {
								Console.WriteLine("-- Agregando servicio n°{0} --", i);

								Console.WriteLine("Ingrese nombre del servicio:");
								String servicio_a_agregar = Console.ReadLine();

								//                                      |||
								// ACA SE DEBERIA LEVANTAR LA EXCEPCIÓN vvv
								Servicio s = salon.buscar_servicio(servicio_a_agregar);

								Console.WriteLine("Ingrese cantidad de servicio:");
								int cantidad = int.Parse(Console.ReadLine());

								Console.WriteLine("Ingrese costo unitario del servicio:");
								int costo_unit = int.Parse(Console.ReadLine());

								lista_de_servicios.Add(new ServicioItem(s.Nombre_servicio, s.Descripcion_serv, cantidad, costo_unit));
							}
						}
						while (salir_loop != "n");

						salon.reservar_salon(c, mes_reserva, dia_reserva, tipo, enc_asignado, costo, senia, lista_de_servicios);

					}
					else if (tecla.Key == ConsoleKey.Enter && posicion == 5)
					{	Console.Clear();
						salir = true;
					}
					else if (tecla.Key == ConsoleKey.Enter && posicion == 6)
					{	Console.Clear();
						mostrar_info(salon);
					}
					else if (tecla.Key == ConsoleKey.Enter && posicion == 7)
					{ //ultima opcion la cual es salir, y si presionamos Enter finaliza el while
						salir = true;
					}
					//Se elimina breaks para que vuelva al menu una vez finalizada una opcion
				}
				/*switch (tecla.Key && posicion) {
					case false:
						// Agregar un servicio
						Console.WriteLine("Ingrese nombre de servicio");
						String nom_serv = Console.ReadLine();

						Console.WriteLine("Ingrese descripción del servicio");
						String desc_serv = Console.ReadLine();

						salon.agregar_servicio(new Servicio(nom_serv, desc_serv));
						break;
					case "2":
						// Eliminar un servicio
						Console.WriteLine("Ingrese nombre de servicio a eliminar");
						String nombre_serv_a_buscar = Console.ReadLine();

						Servicio servicio_buscado = salon.buscar_servicio(nombre_serv_a_buscar);
						if (servicio_buscado != null) {
							salon.eliminar_servicio(servicio_buscado);
							Console.WriteLine("Servicio '{0}' eliminado con exito", servicio_buscado.Nombre_servicio);
						} else {
							Console.WriteLine("No se encontró el servicio");
						}
						Console.ReadKey(true);
						break;

					case "3":
						// Dar de alta un empleado
						Console.WriteLine("Ingrese nombre de empleado/encargado:");
						String nombre = Console.ReadLine();

						Console.WriteLine("Ingrese apellido de empleado/encargado:");
						String apellido = Console.ReadLine();

						Console.WriteLine("Ingrese nro de legajo:");
						int legajo = int.Parse(Console.ReadLine());

						Console.WriteLine("Ingrese salario: (Decimales con coma)");
						double salario = double.Parse(Console.ReadLine());

						Console.WriteLine("Ingrese dni:");
						int dni = int.Parse(Console.ReadLine());

						Console.WriteLine("Ingrese tarea a desempeñar:");
						String tarea = Console.ReadLine();

						Console.WriteLine("¿Es encargado? Ingrese 's' o 'n'(Default):");
						String enc = Console.ReadLine();

						if (enc == "s" || enc == "S") {
							Console.WriteLine("Ingrese el plus que cobra el encargado (Decimales con coma):");
							double plus = double.Parse(Console.ReadLine());

							Encargado e = new Encargado(nombre, apellido, dni, legajo, salario, tarea, plus);
							salon.subir_empleado(e);
						} else {
							Empleado e = new Empleado(nombre, apellido, dni, legajo, salario, tarea);
							salon.subir_empleado(e);
						}
						break;
					case "4":
						// Dar de baja un empleado
						Console.WriteLine("Ingrese legajo de empleado/encargado:");
						int leg = int.Parse(Console.ReadLine());

						Empleado emp = salon.buscar_empleado_por_legajo(leg);

						if (emp != null) {
							salon.bajar_empleado(emp);
							Console.WriteLine("Empleado: {0} {1} ({2}) eliminado con exito", emp.Nombre, emp.Apellido, emp.NroDeLegajo);
						} else {
							Console.WriteLine("No se encontró el empleado");
						}
						Console.ReadKey(true);
						break;
					case "5":
						// Reservar el salón para un evento

						// Ingresar info del cliente
						Console.WriteLine("Ingrese nombre del cliente:");
						String cliente_nombre = Console.ReadLine();

						Console.WriteLine("Ingrese apellido del cliente:");
						String cliente_apellido = Console.ReadLine();

						Console.WriteLine("Ingrese dni del cliente:");
						int cliente_dni = int.Parse(Console.ReadLine());

						Cliente c = new Cliente(cliente_nombre, cliente_apellido, cliente_dni);

						// Ingresar fecha y tipo
						Console.WriteLine("Ingrese mes a reservar para el evento:");
						int mes_reserva = int.Parse(Console.ReadLine());

						Console.WriteLine("Ingrese dia a reservar para el evento:");
						int dia_reserva = int.Parse(Console.ReadLine());

						Console.WriteLine("Ingrese tipo de evento:");
						String tipo = Console.ReadLine();

						// Ingresar encargado
						Console.WriteLine("Ingrese legado del encargado");
						int legajo_enc_asignado = int.Parse(Console.ReadLine());
						Encargado enc_asignado = (Encargado)salon.buscar_empleado_por_legajo(legajo_enc_asignado);

						// Ingresar costo y senia
						Console.WriteLine("Ingrese costo del evento");
						int costo = int.Parse(Console.ReadLine());

						Console.WriteLine("Ingrese senia del evento");
						int senia = int.Parse(Console.ReadLine());

						// Pregunto por servicio(S)
						ArrayList lista_de_servicios = new ArrayList();
						String salir_loop;
						int i = 1;

						do {
							Console.WriteLine("¿Desea agregar servicios? S/n");
							salir_loop = Console.ReadLine().ToLower();
							if (salir_loop != "n") {
								Console.WriteLine("-- Agregando servicio n°{0} --", i);

								Console.WriteLine("Ingrese nombre del servicio:");
								String servicio_a_agregar = Console.ReadLine();

								//                                      |||
								// ACA SE DEBERIA LEVANTAR LA EXCEPCIÓN vvv
								Servicio s = salon.buscar_servicio(servicio_a_agregar);

								Console.WriteLine("Ingrese cantidad de servicio:");
								int cantidad = int.Parse(Console.ReadLine());

								Console.WriteLine("Ingrese costo unitario del servicio:");
								int costo_unit = int.Parse(Console.ReadLine());

								lista_de_servicios.Add(new ServicioItem(s.Nombre_servicio, s.Descripcion_serv, cantidad, costo_unit));
							}
						}
						while (salir_loop != "n");

						salon.reservar_salon(c, mes_reserva, dia_reserva, tipo, enc_asignado, costo, senia, lista_de_servicios);

						break;
					case "6":
						// Cancelar un evento
						break;
					case "7":
						// Consultar información relevante
						mostrar_info(salon);
						break;
					case "8":
						salir = true;
						break;
					default:
						Console.WriteLine("Opción incorrecta");
						Console.ReadKey(true);
						break;
				}*/
			//}
		}
		
		public static void mostrar_info(Salon salon)
		{
			// Submenu de mostrar info relevante
			Console.Clear();
			Console.WriteLine("\n");
			Console.WriteLine("Elige una opción:");
			Console.WriteLine("a) Listar eventos");
			Console.WriteLine("b) Listar clientes");
			Console.WriteLine("c) Listar empleados");
			Console.WriteLine("d) Listar servicios");
			Console.WriteLine("e) Listar eventos de un mes determinado");
			Console.WriteLine("f) Salir");
			
			String eleccion = Console.ReadLine();
				
			switch (eleccion) {
				case "a":
					// Listar eventos
					menu_eventos(salon);
					Console.ReadKey(true);
					break;
				case "b":
					// Listar clientes
					menu_clientes(salon);
					Console.ReadKey(true);
					break;
				case "c":
					// Listar empleados
					menu_empleados(salon);
					Console.ReadKey(true);
					break;
				case "d":
					// Listar servicios
					menu_servicios(salon);
					Console.ReadKey(true);
					break;
				case "e":
					// Listar eventos de un mes determinado
					Console.WriteLine("Ingrese el mes");
					int mes_seleccionado = int.Parse(Console.ReadLine());
					menu_eventos_mes(salon, mes_seleccionado);
					Console.ReadKey(true);
					break;
				case "f":
					Console.WriteLine("Volviendo al menú principal...");
					Console.ReadKey(true);
					break;
				default:
					Console.WriteLine("Opción incorrecta");
					Console.ReadKey(true);
					break;
			}
		}
		
		public static void menu_eventos(Salon salon)
		{
			// Listar eventos
			foreach (Evento ev in salon.Calendario.ListaDeEventos) {
				Console.WriteLine("| Evento a nombre de: {0} {1} | DNI: {2} | Fecha de reserva: {3}/{4} | Tipo de evento: {5} | Encargado {6} {7} | Costo total {8} | Seña {9} |", ev.Cliente.Nombre, ev.Cliente.Apellido, ev.Cliente.Dni, ev.Dia_reserva, ev.Mes_reserva, ev.Tipo_evento, ev.Encargado.Nombre, ev.Encargado.Apellido, ev.Costo_total, ev.Senia);
			}
		}
		
		public static void menu_clientes(Salon salon)
		{
			// Listar clientes
			foreach (Cliente cliente in salon.Clientes) {
				Console.WriteLine("Cliente: {0} {1} | Dni: {2}", cliente.Nombre, cliente.Apellido, cliente.Dni);
			}
		}
		
		public static void menu_empleados(Salon salon)
		{
			// Listar empleados
			foreach (Empleado empleado in salon.Empleados) {
				Console.WriteLine("Empleado: {0} {1} | Legajo: {2} | Dni: {3} | Salario: {4} | Tarea a desempeñar: {5}", empleado.Nombre, empleado.Apellido, empleado.NroDeLegajo, empleado.Dni, empleado.calcularSalario(), empleado.TareaDesempeniar);
			}
		}
		
		public static void menu_servicios(Salon salon)
		{
			// Listar clientes
			foreach (Servicio servicio in salon.Servicios) {
				Console.WriteLine("Servicio: {0} | Descripción: {1}", servicio.Nombre_servicio, servicio.Descripcion_serv);
			}
		}
		
		public static void menu_eventos_mes(Salon salon, int mes)
		{
			// Listar eventos de un mes determinado
			Console.WriteLine("Ingrese el mes (número de 1-12):");
			int mes_seleccionado = int.Parse(Console.ReadLine());
			
			// Busco eventos en ese mes
			ArrayList eventos_en_ese_mes = salon.Calendario.buscar_eventos_por_mes(mes_seleccionado);
			
			// Imprimo esos eventos
			foreach (Evento ev in eventos_en_ese_mes) {
				Console.WriteLine("| Evento a nombre de: {0} {1} | DNI: {2} | Fecha de reserva: {3}/{4} | Tipo de evento: {5} | Encargado {6} {7} | Costo total {8} | Seña {9} |", ev.Cliente.Nombre, ev.Cliente.Apellido, ev.Cliente.Dni, ev.Dia_reserva, ev.Mes_reserva, ev.Tipo_evento, ev.Encargado.Nombre, ev.Encargado.Apellido, ev.Costo_total, ev.Senia);
			}
		}
		
		public static void mostrar_logo(){
			String dir = @"..\..\Logos\Logo.txt"; // Directorio del logo
			//Console.WriteLine("Directorio actual: {0}" Environment.CurrentDirectory);
			
			// Verifico si existe el logo
	        if (File.Exists(dir))
	        {
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