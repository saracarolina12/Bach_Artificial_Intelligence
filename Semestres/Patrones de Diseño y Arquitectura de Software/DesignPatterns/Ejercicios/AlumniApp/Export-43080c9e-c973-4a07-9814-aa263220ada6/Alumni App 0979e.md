# Alumni App

Esta solución está compuesta por dos patrones de diseño:

- Adapter (estructural)
- Builder (creacional)

### Adapter

![Untitled](Alumni%20App%200979e/Untitled.png)

![Untitled](Alumni%20App%200979e/Untitled%201.png)

En la descripción del problema, observamos que se desea recibir un JSON con la información necesaria para crear la aplicación de calificaciones. Sin embargo, si en lugar del JSON nos dieran la información dentro de un XML, sin la ayuda de un patrón de diseño tendríamos que hacer varios cambios en los archivos.

Esto podría resolverse fácilmente utilizando un adapter. 

Veamoslo de esta forma:

![Untitled](Alumni%20App%200979e/Untitled%202.png)

1. El cliente nos entrega un XML, pero nuestro código está implementado para recibir un JSON
2. Usamos un adapter para convertir XML → JSON.
3. Finalmente recibimos un JSON que será con el que trabajaremos nuestro código.

### Builder

![Untitled](Alumni%20App%200979e/Untitled%203.png)

![Untitled](Alumni%20App%200979e/Untitled%204.png)

Pero... por qué builder?

Tenemos 3 interfaces distintas.

1. Estudiante
2. Profesor
3. Supervisor

Pero si lo pensamos más a detalle, en realidad tenemos sólo un usuario que se compone de varias cosas en común. Aunque no podemos hacer sólo un “tipo” de usuario, pues por ejemplo, el estudiante puede ver y descargar sus calificaciones, pero no puede ver ni descargar las calificaciones de sus compañeros. De igual manera, el supervisor no puede ver ni descargar las calificaciones, y el profesor puede ver las calificaciones de todos, sin embargo, no las puede descargar.

Con esto en mente, creamos un B**uilder para Usuario** para los métodos/atributos que tengan en común *([https://github.com/saracarolina12/IA_School/blob/master/Semestres/Patrones de Diseño y Arquitectura de Software/DesignPatterns/Ejercicios/AlumniApp/UserBuilder.cs](https://github.com/saracarolina12/IA_School/blob/master/Semestres/Patrones%20de%20Dise%C3%B1o%20y%20Arquitectura%20de%20Software/DesignPatterns/Ejercicios/AlumniApp/UserBuilder.cs)*) y 3 **builders* concretos**  *([https://github.com/saracarolina12/IA_School/blob/d74aab039b6335ebe83cb069171e697aabf641e0/Semestres/Patrones de Diseño y Arquitectura de Software/DesignPatterns/Ejercicios/AlumniApp/Form1.cs#L25-L52](https://github.com/saracarolina12/IA_School/blob/d74aab039b6335ebe83cb069171e697aabf641e0/Semestres/Patrones%20de%20Dise%C3%B1o%20y%20Arquitectura%20de%20Software/DesignPatterns/Ejercicios/AlumniApp/Form1.cs#L25-L52))* para aquellas características propias del respectivo usuario (estudiante, profesor, supervisor).

*Importante: sólo se utilizó un builder para este proyecto. La referencia es para su respectivo builder concreto donde se crean las características únicas de cada usuario.