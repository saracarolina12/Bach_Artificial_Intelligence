const urls = [
  "https://pokeapi.co/api/v2/pokemon/1/",
  "https://pokeapi.co/api/v2/pokemon/2/",
  "https://pokeapi.co/api/v2/pokemon/3/",
  "https://pokeapi.co/api/v2/pokemon/4/",
  "https://pokeapi.co/api/v2/pokemon/5/",
  "https://pokeapi.co/api/v2/pokemon/6/",
  "https://pokeapi.co/api/v2/pokemon/7/",
  "https://pokeapi.co/api/v2/pokemon/8/",
  "https://pokeapi.co/api/v2/pokemon/9/",
  "https://pokeapi.co/api/v2/pokemon/10/",
  "https://pokeapi.co/api/v2/pokemon/11/",
  "https://pokeapi.co/api/v2/pokemon/12/",
  "https://pokeapi.co/api/v2/pokemon/13/",
  "https://pokeapi.co/api/v2/pokemon/14/",
  "https://pokeapi.co/api/v2/pokemon/15/",
  "https://pokeapi.co/api/v2/pokemon/16/",
  "https://pokeapi.co/api/v2/pokemon/17/",
  "https://pokeapi.co/api/v2/pokemon/18/",
  "https://pokeapi.co/api/v2/pokemon/19/",
  "https://pokeapi.co/api/v2/pokemon/20/",
];


// function showimage(num_id){
//   let requests = urls.map(url => fetch(url));

//   Promise.all(requests)
//     .then(responses => Promise.all(responses.map(r => r.json())))
//     .then(poke => poke.forEach(
//       user => alert(user.name),
//       Swal.fire({
//         //title: URLSearchParams.name,
//         imageUrl: `https://github.com/saracarolina12/School/blob/main/Semestres/Quinto/Desarrollo%20Web/Proyectos/Catologo_Pokemones/${num_id}.png?raw=true`,
//       })
//     ));
// }

function showimage(num_id){
 
  let url = `https://pokeapi.co/api/v2/pokemon/${num_id}/`;
  fetch(url).then(data => data.json()).then(data => {
    var a = "", e="";
    for (let index = 0; index < data.abilities.length; index++) {
        a+='-'+data.abilities[index].ability.name+'<br>';
    }
    for (let index = 0; index <data.types.length; index++) {
        e+='-'+data.types[index].type.name+'<br>';
    }

    Swal.fire({
      // title: '<b><u>'+data.name+'</u></b>',
      title: '<b><u>'+data.name[0].toUpperCase() + data.name.substring(1)+'</u></b>',
      html: '<b><i style="font-size:110%">~Habilidades<br></i></b>' + a + '<br> <b><i style="font-size:110%">~Types<br></i></b>' + e + `<br><b><i style="font-size:110%;">~Experiencia: ${data.base_experience}<br></i></b><div class="progress" style="margin-top:2%;"><div class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" aria-valuenow="75" aria-valuemin="0" aria-valuemax="255" style="width: ${100*data.base_experience/255}%"></div></div>`,
      imageUrl: `${num_id}.png`,
      imageWidth:200,
      imageHeight:200,
      backdrop: `
        rgba(166,7,8,0.4)
      `

    }) 

   
  })
}