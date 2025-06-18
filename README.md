# Administrador de Salón de Fiestas
Proyecto final para la materia Algoritmos y Programación, del segundo año de la carrera Ingeniería en Informática.

## Integrantes
* Fernandez Gonzalo
* Torres Federico
* Agüero Rocío

## UML

<div align="center">

<img src="https://github.com/user-attachments/assets/bfe0639d-0504-4400-b16e-98144a017840"/>

</div>

## Consigna
En un salón de fiestas se tienen registrados los eventos contratados y el conjunto de empleados que
trabaja de forma fija en los eventos. De cada evento se almacena: nombre y dni del cliente, fecha y
hora del evento, tipo de evento (cumpleaños de 15, casamientos, bautismos, etc.. ), encargado, lista
de servicios contratados, costo total (se calcula en base al precio de los servicios contratados y la
cantidad) y monto de la seña. De cada servicio ofrecido se almacena nombre del servicio (catering,
bebida, mozos, DJ, inflables, cama elástica, etc), descripción (detalle de lo que incluye el servicio),
cantidad solicitada, costo unitario del servicio. De cada empleado se registra su nombre y apellido,
dni, nro de legajo, sueldo y tarea que desempeña. El encargado de un evento es un empleado que
organiza y controla el desarrollo del evento y cobra un plus sobre el sueldo.
Se deberá desarrollar una aplicación, utilizando las clases que considere necesarias, utilizando
herencia cuando corresponda. La aplicación debe proveer, mediante un menú, las siguientes
funcionalidades:
- a) Agregar un servicio
- b) Eliminar un servicio.
- c) Dar de alta un empleado/encargado
- d) Dar de baja un empleado/encargado
- e) Reservar el salón para un evento. El cliente puede incluir en su pedido un solo servicio o
varios. El salón toma una sola reserva para la misma fecha. En caso de que ya tenga una
reserva previa se levanta una excepción indicando lo ocurrido. Al confirmar la reserva se le
asigna un encargado al evento.
- f) Cancelar un evento. En caso que el cliente solicite la cancelación con más de un mes de
anticipación a la fecha del servicio, no se le reintegra la seña. En otro caso, el cliente debe
abonar el servicio completo.
- g) Submenú de impresión: listado de eventos, de clientes, de empleados, listado de eventos de
un mes determinado

### Pautas generales
Pautas generales:
1. Pueden conformar grupos de hasta 3 integrantes.
2. Cuando el proyecto se encuentra finalizado, es decir compila y ejecuta, se entrega en clase
presencial (de ser posible) para mostrarle al docente su ejecución. Luego se debe enviar por
mail o compartir por Drive, cada uno de los archivos que contienen la definición de una
clase, y la aplicación, más un archivo Word con el diagrama de clases UML.
3. Podrán entregar el proyecto hasta 3 veces: es decir pueden hacer correcciones 2 veces. La
tercer entrega ya lleva la nota definitiva (aprobado o desaprobado).
4. En caso de estar aprobado, el docente pautará la fecha del coloquio grupal oral. El mismo
podrá ser presencial o virtual.
5. Si el proyecto NO compila o no ejecuta, no se acepta la entrega. Las consultas son previas a
la entrega. Cada entrega que hacen (presencial o virtual) se contabiliza.

### Desarrollo
En cada proyecto se espera que:
- Se haga el diagrama de clases UML
- Se diseñe e implemente cada una de las clases completas: variables de instancia,
constructores, propiedades y métodos de instancia básicos (es decir, con los métodos
completos aún cuando en la aplicación no se los utilice)
- Se haga la aplicación donde se crean y cargan los objetos intervinientes (se puede usar carga
desde archivo de texto, NO es obligatorio). Por ejemplo: si el proyecto es sobre un
supermercado que tiene productos y proveedores, deberán crear el supermercado, cargarle
algunos productos y algunos proveedores para luego poder dar respuesta a las opciones del
menú solicitado. Si el enunciado no lo solicita, no deben simular atención de clientes y
proveedores, ni ventas, ni reposiciones, etc.. (para acotar la longitud del desarrollo)
- Se presenta el menú de opciones solicitado en el problema y se implementan las funciones
que dan respuesta a esos ítems. En la mayoría de los casos, deben desarrollar funciones del
Main que invocan a los métodos de las clases diseñadas. En menor escala, se invocan desde
el menú los métodos ya implementados en las clases. La idea es que NO pongan adentro de
las clases como métodos todos los requerimientos del menú porque simplifican la solución y
personalizan las clases en base al enunciado (y conceptualmente es erróneo!). La aplicación
debe plantear la lógica de resolución del problema haciendo uso de las clases intervinientes.
- Deben usar herencia que se verá reflejado en el código y en el diagrama UML.
- Es obligación que implementen al menos un manejador de excepciones, que se pide en
forma explícita en cada proyecto. Si desean agregar otros, no hay problema.
