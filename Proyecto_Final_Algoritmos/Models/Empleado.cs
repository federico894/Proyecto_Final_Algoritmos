using System;

namespace Proyecto_Final_Algoritmos
{
	public class Empleado
	{
		protected String nombre;
		protected String apellido;
		protected int nro_legajo;
		protected double salario;
		protected String tareaDesempeniar;
		protected int dni;

		public Empleado(String nombre, String apellido, int dni, int nro_legajo, double salario, String tareaDesempeniar)
		{
			this.nombre = nombre;
			this.apellido = apellido;
			this.dni = dni;
			this.nro_legajo = nro_legajo;
			this.salario = salario;
			this.tareaDesempeniar = tareaDesempeniar;
		}
		
		// Método para obtener sueldo
		public virtual double calcularSalario(){
			return salario;
		}
		
		public void mostrar_info(){
			Console.WriteLine("----------------------------------------------");
			Console.WriteLine("| Empleado: {0} {1}\n| - Legajo: {2}\n| - DNI: {3}\n| - Salario: ${4}\n| - Tarea a desempeñar: {5}", nombre, apellido, nro_legajo, dni, calcularSalario(), tareaDesempeniar);
		}
		
		// Todas las propiedades
		public string Nombre {
			get {
				return nombre;
			}
		}
		
		public string Apellido {
			get {
				return apellido;
			}
		}
		
		public int Dni {
			get {
				return dni;
			}
		}
		
		public int NroDeLegajo {
			get {
				return nro_legajo;
			}
		}
		
		public string TareaDesempeniar {
			get {
				return tareaDesempeniar;
			}
		}
	}
}
