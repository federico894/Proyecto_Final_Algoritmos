/*
 (Main Program File)
*/
using System;

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
						salon.agregar_servicio();
						break;
					case "2":
						// Eliminar un servicio
						salon.eliminar_servicio();
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
						Console.WriteLine("Saliendo...");
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
			Console.WriteLine("Elige una opción:'");
			Console.WriteLine("a) Listar eventos");
			Console.WriteLine("b) Listar clientes");
			Console.WriteLine("c) Listar empleados");
			Console.WriteLine("d) Listar eventos de un mes determinado");
			Console.WriteLine("e) Salir");
			
			String eleccion = Console.ReadLine();
				
			switch (eleccion) {
				case "a":
					// Listar eventos
					menu_eventos(salon);
					break;
				case "b":
					// Listar clientes
					menu_clientes(salon);
					break;
				case "c":
					// Listar empleados
					menu_empleados(salon);
					break;
				case "d":
					// Listar eventos de un mes determinado
					menu_eventos_mes(salon);
					break;
				case "e":
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
			/*
			foreach (Evento e in Calendario.ListaDeEventos) {
				Console.WriteLine("| Evento a nombre de: " + e.Cliente.Name + " | DNI " + e.Cliente.Dni + " | Fecha de Reserva: " + e.Dia_reserva + "/" + e.Mes_reserva + " |");
			}*/
			Console.ReadKey(true);
		}
		
		public static void menu_clientes(Salon salon)
		{
			// Listar clientes
			foreach (Cliente cliente in salon.Clientes) {
				Console.WriteLine("Cliente: {0} {1} | Dni: {2}", cliente.Nombre, cliente.Apellido, cliente.Dni);
			}
			Console.ReadKey(true);
		}
		
		public static void menu_empleados(Salon salon)
		{
			// Listar empleados
			foreach (Empleado empleado in salon.Empleados) {
				Console.WriteLine("Empleado: {0} {1} | Legajo: {2} | Dni: {3} | Salario: {4} | Tarea a desempeñar: {5}", empleado.Nombre, empleado.Apellido, empleado.NroDeLegajo, empleado.Dni, empleado.calcularSalario(), empleado.TareaDesempeniar);
			}
			Console.ReadKey(true);
		}
		
		public static void menu_eventos_mes(Salon salon)
		{
			// Listar eventos de un mes determinado
			Console.ReadKey(true);
		}
	}
}