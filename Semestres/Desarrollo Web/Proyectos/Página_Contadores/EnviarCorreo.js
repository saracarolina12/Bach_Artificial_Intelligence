em = document.getElementById("email").value;
nom = document.getElementById("nombre").value;
ap = document.getElementById("apellido").value;
us = document.getElementById("usuario").value;
pw = document.getElementById("pass").value;
env = document.getElementById("enviar").value;

function validar(){
    if( em == null || em.length == 0 ) {
        return false;  
        alert('Lo sentimos, no es un correo válido');
    }
    if(nom == null || nom.length == 0){
        return false
    }
    if(ap == null || ap.length == 0){
        return false
    }
    if(us == null || us.length == 0){
        return false
    }
    if(pw == null || pw.length == 0){
        return false
    }

    return true;
}

/*
if(env.onsubmit ="!validar()"){
    alert('Falta rellenar algunos campos y/o los datos introducidos son incorrectos. Verifique de nuevo, por favor');
}else{
    alert('¡Perfecto!');
}
*/