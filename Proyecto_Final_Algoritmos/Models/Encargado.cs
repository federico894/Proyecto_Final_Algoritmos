using System;

namespace Proyecto_Final_Algoritmos
{
	public class Encargado:Empleado
	{
		private int plus;
		
		public Encargado(String nombre, String apellido, int dni, int nro_legajo, int salario, String tareaDesempeniar, int plus)
			: base(nombre, apellido, dni, nro_legajo, salario, tareaDesempeniar)
		{
			this.plus = plus;
		}
		
		// Método para obtener sueldo
		public override double calcularSalario(){
			return salario + plus;
		}
	}
}
