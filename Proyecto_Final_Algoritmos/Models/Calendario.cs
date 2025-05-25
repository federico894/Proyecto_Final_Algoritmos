using System;
using System.Collections;


namespace Proyecto_Final_Algoritmos
{
	public class Calendario
	{
		// Arraylist meses el cual almacena atraves de un for 12 meses
		private ArrayList mes;
		private ArrayList listaDeEventos;
 
		public Calendario() // No pasamos los parametros dia y mes debido a que en el metodo agendarTurno lo pasamos por consola con Console.Readline
		{
			mes = new ArrayList();
			listaDeEventos = new ArrayList();
			inicializarMeses(); // Inicializamos el metodo para que el arraylist ya tenga la cant de meses y no este vacio
		}

		private void inicializarMeses()
		{
			for (int i = 0; i < 12; i++) { // Bucle en cual en cada recorrido el valor de i aumenta y
				// Ejecuta el case correspondiente el cual almacena la cant de dias que tiene ese mes
				switch (i) {
					case 0:
						mes.Add(31);
						break; // Por ejemplo aca case 0 seria mes 1 entonces Add(31) dias a enero
					case 1:
						mes.Add(28);
						break; // Ojo agrega solo el numero pero no es que agrega esa cant de objetos
					case 2:
						mes.Add(31);
						break;
					case 3:
						mes.Add(30);
						break;
					case 4:
						mes.Add(31);
						break;
					case 5:
						mes.Add(30);
						break;
					case 6:
						mes.Add(31);
						break;
					case 7:
						mes.Add(31);
						break;
					case 8:
						mes.Add(30);
						break;
					case 9:
						mes.Add(31);
						break;
					case 10:
						mes.Add(30);
						break;
					case 11:
						mes.Add(31);
						break;

				}
			}
		}

		public void agendar_turno(Evento nuevoEvento)//Pasamos los datos del evento el cual tambien contiene los servicios
		{ //ahora accedemos al atributo del mes sin tener que usar parametro en este metodo y sin console.readline
			if (nuevoEvento.Mes_reserva < 1 || nuevoEvento.Mes_reserva > 12) {//Condicional por si ponemos un numero invalido
				Console.WriteLine("Mes invalido");
				return;
			}
			//ACA DEBERIA AGREGAR ALGO QUE FINALIZE EL METODO SI EL MES ES INVALIDO*
        
			int diaMaximos = (int)mes[nuevoEvento.Mes_reserva - 1]; //Aca casteamos el mes, ya que es un arraylist lo pasamos a int
			//y entre [] agregamos el dato que entramos con Console.readline, el cual va a hacer que nos posicionemos
			//en el indice correcto al cual le pertenece ese mes (-1 ya que el mes que introducimos es 1 numero mas alto que el indice que empieza de 0)
			
			//aca tambien accedemos al atributo dia 
			if (nuevoEvento.Dia_reserva < 1 || nuevoEvento.Dia_reserva > diaMaximos) {//Aca utilizamos el mes que casteamos a int,
				//para verificar si el dia que elegimos es mayor a la de ese mes entonces es un dato ingresado invalido
				Console.WriteLine("Dia invalido");
				return;
			}
			//ACA DEBERIA HACER ALGO QUE FRENE LA EJECUCION NUEVAMENTE SI DA INVALIDO;

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


		public void buscar_eventos_disponibles()
		{
			ArrayList mesPorNum = new ArrayList();//lista para guardar el mes por su numero y no por la cant de dias
			for (int i = 0; i < mes.Count; i++) {//Bucle para llenar la lista con numeros del 1 al 12//es decir, los numeros de los meses
				mesPorNum.Add(i + 1);
			}
			foreach (int nroMes in mesPorNum) {//foreach para recorrer la lista creada con la cant de meses
				int cantDias = (int)mes[nroMes - 1]; //casteo de el item que esta en el indice de mes a tipo int
				//aca recorremos el arraylist de mes nroMes (-1 porque los indice comienzan desde 0)
				//y obtenemos el valor el cual seria el total de dias el cual tiene ese nroMes (por ejemplo nroMes 2 nos paramos en el indice 1 el cual tiene 28 dias)

				for (int dia = 1; dia <= cantDias; dia++) {//realizamos un for para recorrer los dias que contiene totales de ese mes, por eso < cantDias
					bool YaReservado = false;//variable tipo bool para cambiar su valor dentro del if
					foreach (Evento e in listaDeEventos) {
						if (e.Mes_reserva == nroMes && e.Dia_reserva == dia) { //Si el mes reservado es igual al numero del mes y el diareservado es igual
							//a dia entonces cambiamos el valor de YaReservado a verdadero y frenamos el if
							YaReservado = true;
							break;
						}
					}
					if (!YaReservado) {//En caso de que la condicion anterior no se cumpla entonces
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


	}

}