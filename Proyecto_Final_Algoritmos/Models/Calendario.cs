using System;
using System.Collections;


namespace Proyecto_Final_Algoritmos
{
	public class Calendario
	{
		// Arraylist meses el cual almacena atraves de un for 12 meses
		private ArrayList meses;
		private ArrayList listaDeEventos;
                private int mes_actual;
		private int dia_actual;
		
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
		
		public ArrayList buscar_eventos_por_mes(int mes_seleccionado){
			ArrayList eventos_en_ese_mes = new ArrayList();
			foreach (Evento evento in listaDeEventos) {
				if (evento.Mes_reserva == mes_seleccionado){
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
		
		public void buscar_eventos_disponibles()
		{
			//lista para guardar el mes por su numero y no por la cant de dias
			ArrayList mesPorNum = new ArrayList();
			
			//Bucle para llenar la lista con numeros del 1 al 12//es decir, los numeros de los meses
			for (int i = 0; i < meses.Count; i++)
			{
				mesPorNum.Add(i + 1);
			}
			
			//foreach para recorrer la lista creada con la cant de meses
			foreach (int nroMes in mesPorNum)
			{
				//casteo de el item que esta en el indice de mes a tipo int
				//aca recorremos el arraylist de mes nroMes (-1 porque los indice comienzan desde 0)
				//y obtenemos el valor el cual seria el total de dias el cual tiene ese nroMes (por ejemplo nroMes 2 nos paramos en el indice 1 el cual tiene 28 dias)
				int cantDias = (int)meses[nroMes - 1];
				
				//realizamos un for para recorrer los dias que contiene totales de ese mes, por eso < cantDias
				for (int dia = 1; dia <= cantDias; dia++)
				{
					//variable tipo bool para cambiar su valor dentro del if
					bool YaReservado = false;
					foreach (Evento e in listaDeEventos)
					{
						//Si el mes reservado es igual al numero del mes y el diareservado es igual
						if (e.Mes_reserva == nroMes && e.Dia_reserva == dia)
						{
						  	//a dia entonces cambiamos el valor de YaReservado a verdadero y frenamos el if
							YaReservado = true;
							break;
						}
					}
					
					//En caso de que la condicion anterior no se cumpla entonces
					if (!YaReservado)
					{
					 	//mostramos esos meses dia como fecha disponibles
						Console.WriteLine("Fechas disponibles: " + dia + "/" + nroMes);
					}
				}
			}
		}
    
		public ArrayList ListaDeEventos {
			get {
				return listaDeEventos;
			}
		}
		
		public ArrayList Meses{
			get{
				return meses;
			}
		}

		public int Mes_actual{
			get{
				return mes_actual;
			}
			set{
				mes_actual = value;
			}
		}
		public int Dia_actual{
			get{
				return dia_actual;
			}
			set{
				dia_actual = value;
			}
		}


	}

}
