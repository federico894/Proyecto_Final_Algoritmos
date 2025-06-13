using System;

namespace Proyecto_Final_Algoritmos
{
	public class ReservaExistenteException : Exception
	{
		public ReservaExistenteException()
			: base("Ya existe una reserva para esa fecha y cliente.")
		{}
	}
}
