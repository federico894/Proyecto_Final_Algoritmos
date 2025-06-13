using System;


namespace Proyecto_Final_Algoritmos
{
	public class Cliente
	{
		// Declaracion de variables para el constructor
		private String nombre;
		private String apellido;
		private int dni;
		private double dinero_que_debe;
		
		public Cliente(String nombre, String apellido, int dni)
		{
			// Creacion del objeto y sus atributos;
			this.nombre = nombre;
			this.apellido = apellido;
			this.dni = dni;
		}
		
		public void reducir_dinero(double dinero){
			dinero_que_debe = dinero_que_debe - dinero;
		}
		
		public void aumentar_dinero(double dinero){
			dinero_que_debe = dinero_que_debe + dinero;
		}
		
		public void mostrar_info(){
			Console.WriteLine("----------------------------------------------");
			Console.WriteLine("| Cliente: {0} {1}\n| - Dni: {2}\n| - Dinero que debe: ${3}", nombre, apellido, dni, dinero_que_debe);
		}
		
		// Creación de propiedad la cual utilizamos para asignarle valor a las variables privadas
		public String Nombre {
			get {
				//get, nos devuelve el valor de la variable
				return nombre;
			}
		}
    
		public int Dni {
			get {
				return dni;
			}
		}
    	
		public String Apellido {
			get {
				return apellido;
			}
		}
		
		public double Dinero_que_debe {
			get {
				return dinero_que_debe;
			}
		}
	}
}