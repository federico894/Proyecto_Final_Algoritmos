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
		public static void mostrar_menu(Salon salon){
			bool salir = false;

			while(!salir){
				Console.WriteLine("\n\n\n");
				Console.WriteLine("¡Bienvenid@ al administrador del salón {0}!", s.Nombre);
				Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-");
				Console.WriteLine("Elige una opción:'");
				Console.WriteLine("1) Agregar un servicio");
				Console.WriteLine("2) Eliminar un servicio");
				Console.WriteLine("3) Dar de 'alta' un empleado/encargado");
				Console.WriteLine("4) Dar de 'baja' un empleado/encargado");
				Console.WriteLine("5) Reservar el salón para un evento");
				Console.WriteLine("6) Cancelar un evento");
				Console.WriteLine("7) Consultar información relevante");
				Console.WriteLine("8) Salir");
				
				String eleccion = Console.ReadLine();
				
				switch(eleccion){
					case "1":
						// Agregar un servicio
						break;
					case "2":
						// Eliminar un servicio
						break;
					case "3":
						// Dar de alta un empleado
						break;
					case "4":
						// Dar de baja un empleado
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
		
		public static void mostrar_info(Salon salon){
			// Submenu de mostrar info relevante

			Console.WriteLine("\n\n");
			Console.WriteLine("Elige una opción:'");
			Console.WriteLine("a) Listar eventos");
			Console.WriteLine("b) Listar clientes");
			Console.WriteLine("c) Listar empleados");
			Console.WriteLine("d) Listar eventos de un mes determinado");
			Console.WriteLine("e) Salir");
			
			String eleccion = Console.ReadLine();
				
			switch(eleccion){
				case "a":
					// Listar eventos
					break;
				case "b":
					// Listar clientes
					foreach (Cliente cliente in salon.Clientes) {
						Console.WriteLine("Cliente: {0} | Dni: {1}", cliente.Name, cliente.Dni);
					}
					break;
				case "c":
					// Listar empleados
					break;
				case "d":
					// Listar eventos
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
		
		public static void menu_eventos(){
			// Listar eventos
			/*
			foreach (Evento e in Calendario.ListaDeEventos) {
				Console.WriteLine("| Evento a nombre de: " + e.Cliente.Name + " | DNI " + e.Cliente.Dni + " | Fecha de Reserva: " + e.Dia_reserva + "/" + e.Mes_reserva + " |");
			}*/
		}
		
		public static void menu_clientes(){
			// Listar clientes
		}
		
		public static void menu_empleados(){
			// Listar empleados
		}
		
		public static void menu_eventos_mes(){
			// Listar eventos de un mes determinado
		}
	}
}