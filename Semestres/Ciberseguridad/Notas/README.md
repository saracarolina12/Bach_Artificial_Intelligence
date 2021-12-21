##Autenticación HTTP:
<pre>
	Control de acceso y autenticación.
	*Más común: "Basic Auth"
  -Funcionamiento:
	1. El servidor responde con un estado de 401 (unauthorized)
	2. Devuelve información sobre cómo autorizarse con un header de "WWW.Authenticate" con al menos una revisión.
	3. Si el cliente quiere autenticarse con un servidor, lo hará incluyendo un header de solicitud "Authorizaton" con sus credenciales.
	//Normalmente un cliente hará una solicitud de contraseña al usuario y luego enviará la solicitud incluyendo el header "Authorization" correcto al servidor.

	->En el caso de una Basic Auth, el intercambio debe ser sobre una conexión HTTPS (TLS) para que sea seguro
-----------------------------------------------------------------------------------------------------
</pre>
### Basic Auth
<pre>
	Está definido por "RFC 7617" (quien transmite credenciales como un par de usuario/contraseña codificado usando base64)
</pre>
######Seguridad de la autenticación básica
<pre>
	base64 también puede ser decodificado, por lo tanto, es necesario usar HTTPS/TLS junto a la Basic Auth. (sin esto, es recomendable no usar Basic Auth para información valiosa o sensible)
</pre>
######Restringiendo acceso con Apache y Basic Auth
<pre>
	Para proteger por contraseña un directorio con un servidor Apache, necesitamos usar los ficheros .htaccess y .htpasswd

	.htaccess normalmente tiene esta forma:
		AuthType Basic
		AuthName "Access to the staging site"
		AuthUserFile /path/to/.htpasswd
		Require valid-user
	.htpasswd tiene en cada línea forma de 
		username:$contraseña (sin espacios)
</pre>

















