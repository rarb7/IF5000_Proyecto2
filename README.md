# IF5000_Proyecto2
Este programa se realizo en el lenguaje de programacion C#,editor de texto Visual Studio 2019 y SQL Managment Studio 18 <br>

<pre>Para la ejecución de este programa se requiere:<br>
    &nbsp;&nbsp;1-Tener libros en formato .txt y posteriormente guardar estos libros dentro de ControllerNode/Enviar/
<br> &nbsp;&nbsp;&nbsp;&nbsp; 2-Instalar NuGet Package System.Data.SqlClient 
<br> &nbsp;&nbsp;&nbsp;&nbsp; 3-Revisar que los puertos numero 2999,3000,3001,3002,3003,3004 y 3005 no esten siendo ocupados por otro programa  
<br> &nbsp;&nbsp;&nbsp;&nbsp; 4-Se debe tener una instancia local de la Base de datos llamada ProyectoRedes2
</pre>

Lo primero que debemos de hacer es encender nuestros nodos para que esten esperando cualquier nuevo documento que queramos enviarle.
Una vez encendidos los nodos tendremos se nos habilita la opcion de poder apagarlos si asi se desea y el botón enviar, que se encarga de enviar los archivos divididos para los distintos nodos, y el botón enviar a SA, el cual lo que realiza es de enviar el archivo comprimido con el algoritmo de huffman hacia el usuario con el libro solicitado.

Dentro de la aplicacion de saSEARCH tenemos la opcion de solicitar nuestro libro ingresando palabras claves relacionadas con el mismo, una vez que demos click al boton consultar se desplegaran los diferentes titulos de los libros almacenados en los RAID y tambien de solicitar libro.

Dentro de la aplicacion de ControllerNode, el usuario escoja su libro a recuperar, esperamos a que esta solicitud llegue al ControllerNode, damos click al botón Enviar al SA, este mismo muestra en pantalla el nombre del archivo que se enviará comprimido con el algorimo de huffman hacia el cliente. Cuando el nombre del Libro se muestre encima del botón de envio, significará que el envio ha sido exitoso.

Devuelta al saSEARCH se nos habilita el boton abrir una vez que se reciba el libro recuperado del COntrollerNode y los RAID, podremos darle click al botón abrir, lo que mostrará el archivo solicitado previamente.
