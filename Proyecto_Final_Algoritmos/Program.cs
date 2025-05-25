/*
 (Main Program File)
*/
using System;
using System.Collections;

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
			bool salir = false;

			while (!salir) {
				Console.Clear();
				Console.WriteLine("\n");
				Console.WriteLine("¡Bienvenid@ al administrador del salón {0}!", salon.Nombre);
				Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-");
				Console.WriteLine("Elige una opción:");
				Console.WriteLine("1) Agregar un servicio");
				Console.WriteLine("2) Eliminar un servicio");
				Console.WriteLine("3) Dar de 'alta' un empleado/encargado");
				Console.WriteLine("4) Dar de 'baja' un empleado/encargado");
				Console.WriteLine("5) Reservar el salón para un evento");
				Console.WriteLine("6) Cancelar un evento");
				Console.WriteLine("7) Consultar información relevante");
				Console.WriteLine("8) Salir");
				
				String eleccion = Console.ReadLine();
				
				switch (eleccion) {
					case "1":
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
						if (servicio_buscado != null){
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
						
						if (emp != null){
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
						while(salir_loop != 0){
							Console.WriteLine("-- Agregando servicio n°{0} --",i);
							
							Console.WriteLine("Ingrese nombre del servicio:");
							String servicio_a_agregar = Console.ReadLine();
							
							//                                      |||
							// ACA SE DEBERIA LEVANTAR LA EXCEPCIÓN vvv
							Servicio s = salon.buscar_servicio(servicio_a_agregar);
							
							Console.WriteLine("Ingrese cantidad de servicio:");
							String cantidad = Console.ReadLine();
							
							Console.WriteLine("Ingrese costo unitario del servicio:");
							String costo_unit = Console.ReadLine();
							
							lista_de_servicios.Add(new ServicioItem(s.Nombre_servicio, s.Descripcion_serv, cantidad, costo_unit));
						}
						
						salon.reservar_salon(c,mes_reserva,dia_reserva,tipo,enc_asignado, costo, senia, lista_de_servicios);
						
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
				}
			}
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
	}
}