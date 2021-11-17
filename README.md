# Trabajo_VentaEntradas

## Objetivos

La creacion de un sistema que permita la creacion y gestion de shows musicales/conciertos, utilizando ASP .NET MVC Core.

## Entidades básicas

- Usuario
- Administrador
- Cliente
- Entrada
- Localidad
- Show

| Entidad | Propiedades |
| ----- | ----- |
| Usuario | Dni, Contrasenia, Nombre, Apellido, Rol |
| Administrador | Rol |
| Cliente | Rol |
| Entrada | Id, Seccion, Precio, Asiento, Fecha, DniUsuario, IdShow|
| Localidad | Id, Nombre, Direccion, Campo, Platea |
| Show | Id, Fecha, Banda, PrecioCampo, PrecioPlatea, AsientosCampo, AsientosPlatea, IdLocalidad |

## Caracteristicas y Funcionalidades

### Usuario

- Dni, Contrasenia, Nombre y Apellido son obligatorios.
- Es la base de la que heredan Administrador y Cliente.

### Administrador

- Cuenta con el rol Administrador, que le permite acceder a la creacion y modificacion de Show y Localidad, asi tambien como al manejo de los Clientes.

### Cliente

- Pueden crearse desde el Register.
- Cuenta con el rol Cliente, que le permite comprar entradas para shows ya cargados y guardarlas.
- Cada cliente puede visualizar todas las entradas que haya comprado para los distintos shows.

### Show

- Solo se muestras aquellos shows que todavia no hayan ocurridos. Todo show con una fecha menor a la actual no es mostrado.
- Se permite comprar hasta 5 entradas por compra. En caso de que la cantidad de asientos disponibles sea menor a 5, actualiza la cantidad al numero de asientos disponibles.

### Entrada

- Las entradas se crean en el momento en que se realiza la compra.
- Cuentan con la informacion del show y la localidad correspondientes.
