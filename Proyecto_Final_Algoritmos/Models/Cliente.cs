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
		
		// Creación de propiedad la cual utilizamos para asignarle valor a las variables privadas
		public String Nombre {
			get {
				//get, nos devuelve el valor de la variable
				return nombre;
			} 
			set {
				//determinamos el valor de la variable cuando instanciemos
				nombre = value;
			}
		}
    
		public int Dni {
			get {
				return dni;
			}
			set {
				dni = value;
			}
		}
    	
		public String Apellido {
			get {
				return apellido;
			}
			set{
				apellido = value;
			}
		}
		
		public double Dinero_que_debe {
			get {
				return dinero_que_debe;
			}
			set{
				dinero_que_debe = value;
			}
		}
	}
}