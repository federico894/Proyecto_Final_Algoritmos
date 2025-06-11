using System;
using System.Collections;


namespace Proyecto_Final_Algoritmos
{
	public class Calendario
	{
		// Arraylist meses el cual almacena atraves de un for 12 meses
		private ArrayList meses;
		private ArrayList listaDeEventos;
		
		// No pasamos los parametros dia y mes debido a que en el metodo agendarTurno lo pasamos por consola con Console.Readline
		public Calendario()
		{
			meses = new ArrayList();
			listaDeEventos = new ArrayList();
			
			// Inicializamos el metodo para que el arraylist ya tenga la cant de meses y no este vacio
			inicializarMeses();
		}

		private void inicializarMeses()
		{
			// Bucle en cual en cada recorrido el valor de i aumenta y
			for (int i = 0; i < 12; i++) {
				// Ejecuta el case correspondiente el cual almacena la cant de dias que tiene ese mes
				switch (i) {
					case 0:
						// Por ejemplo aca case 0 seria mes 1 entonces Add(31) dias a enero
						meses.Add(31);
						break;
					case 1:
						// ! Agrega solo el numero pero no es que agrega esa cant de objetos
						meses.Add(28);
						break;
					case 2:
						meses.Add(31);
						break;
					case 3:
						meses.Add(30);
						break;
					case 4:
						meses.Add(31);
						break;
					case 5:
						meses.Add(30);
						break;
					case 6:
						meses.Add(31);
						break;
					case 7:
						meses.Add(31);
						break;
					case 8:
						meses.Add(30);
						break;
					case 9:
						meses.Add(31);
						break;
					case 10:
						meses.Add(30);
						break;
					case 11:
						meses.Add(31);
						break;

				}
			}
		}

		public void agendar_turno(Evento nuevoEvento)
		{
			//Pasamos los datos del evento el cual tambien contiene los servicios
			//ahora accedemos al atributo del mes sin tener que usar parametro en este metodo y sin console.readline
			if (nuevoEvento.Mes_reserva < 1 || nuevoEvento.Mes_reserva > 12) {//Condicional por si ponemos un numero invalido
				Console.WriteLine("Mes invalido");
				return;
			}
        
			//Aca casteamos el mes, ya que es un arraylist lo pasamos a int
			//y entre [] agregamos el dato que entramos con Console.readline, el cual va a hacer que nos posicionemos
			//en el indice correcto al cual le pertenece ese mes (-1 ya que el mes que introducimos es 1 numero mas alto que el indice que empieza de 0)
			int diaMaximos = (int)meses[nuevoEvento.Mes_reserva - 1];
			
			//aca tambien accedemos al atributo dia
			if (nuevoEvento.Dia_reserva < 1 || nuevoEvento.Dia_reserva > diaMaximos) {
				//Aca utilizamos el mes que casteamos a int,
				//para verificar si el dia que elegimos es mayor a la de ese mes entonces es un dato ingresado invalido
				Console.WriteLine("Dia invalido");
				return;
			}

			//y usamos de parametros los datos ingresados previamente por consola
			//Evento nuevoEvento = new Evento(cliente, diaElegido, mesElegido);//instanciamos la clase reserva
        
			//el objeto instanciado lo agregamos a la lista de reservas
			listaDeEventos.Add(nuevoEvento);//Se agrega a la lista los eventos con sus servicios y datos
		}
		
		public void Borrar_evento(Evento evento)//metodo para borrar el evento de la lista sin tener que acceder a las propiedades para usar .Remove
		{
			listaDeEventos.Remove(evento);
		}
		
		public ArrayList buscar_eventos_por_mes(int mes_seleccionado)
		{
			ArrayList eventos_en_ese_mes = new ArrayList();
			foreach (Evento evento in listaDeEventos)
			{
				if (evento.Mes_reserva == mes_seleccionado)
				{
					eventos_en_ese_mes.Add(evento);
				}
			}
			return eventos_en_ese_mes;
		}
		public void mostrar_fechas_reservadas(ArrayList eventoenMes)
		{
			//metodo para ver fechas reservadas
			
			if (ListaDeEventos.Count != 0)
			{
				foreach (Evento item in eventoenMes)
				{
					Console.Write("Fechas reservada: ");
					Console.Write(item.Dia_reserva + "/" + item.Mes_reserva + "  ");
				}
			}
		}
		
		public bool ya_reservado(Evento nuevoEvento){
			//recorremos la lista de eventos la cual esta en la clase calendario
			foreach (Evento e in ListaDeEventos)
			{
				if (e.Mes_reserva == nuevoEvento.Mes_reserva && e.Dia_reserva == nuevoEvento.Dia_reserva)
				{
					return true;
				}
			}
			return false;
		}
		
		public bool cancela_con_antelacion(int diaEvento, int mesEvento)
		{
			int dias = calcular_diferencias_dias(diaEvento, mesEvento);
			if (dias > 30)// aca hacemos la comparacion para combrobar si ya paso mas de un mes
			{
				return true;
			}
			return false;
		}

		private int calcular_diferencias_dias(int diaEvento, int mesEvento)
		{
			int diaActual = DateTime.Now.Day;//obtenemos el dia actual de nuestro sistema y lo guardamos en una variable
			int mesActual = DateTime.Now.Month;//lo mismo pero ahora obtenemos el dia actual
			int diferenciaDias = 0; // variable para almacenar cuantos dias de diferencias hay
			if (mesEvento == mesActual)
			{//si el evento ocurre en el mismo mes del sistema entonces solo se resta el dia del evento - el dia actual para obtener la diferencia
				diferenciaDias = diaEvento - diaActual;
			}
			else//si el evento no ocurre en el mes actual
			{
				int cant_dias_mes_actual = (int)meses[mesActual - 1];// casteamos y accedemos a un valor de el arraylist meses para obtener la cant del dia de ese mes
				diferenciaDias += cant_dias_mes_actual - diaActual;//calculamos cuandos dias quedan desde el dia actual hasta el fin del mes
				//ejemp si diaEnMesActual tiene 30 dias y le restamos el dia actual queda la diferencia de dias
				for (int m = mesActual + 1; m < mesEvento; m++)//inicializamos bucle para sumar los dias completos de los meses que allan intermedios por eso mesActual + 1, sin incluir mes actual y mes del evento
				{
					int diasEnMes = (int)meses[m - 1];//nos devuelve la cant de dias del mes intermedio
					diferenciaDias += diasEnMes;// los sumamos a la diferencia
				}
				diferenciaDias += diaEvento;//se suman el dia del evento 
				//esto nos deja el total de dias que faltan desde el dia actual hasta el dia del evento
			}
			return diferenciaDias;
		}
    
		public ArrayList ListaDeEventos
		{
			get{
				return listaDeEventos;
			}
		}
		
		public ArrayList Meses{
			get{
				return meses;
			}
		}
	}

}
