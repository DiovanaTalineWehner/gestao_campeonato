function cadastrarCampeonato() {
  debugger
  var nomeCampeonato = document.getElementById('championship-name').value;

  if (!nomeCampeonato) {
    alert('Informe o nome do Campeonato!');
    return;
  }
  
  var campeonatoData = {
    nome_campeonato: nomeCampeonato
    }
  
  
  fetch('http://localhost:5000/api/campeonato/cadastrarcampeonato', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + getCookie("Token")
    },
    body: JSON.stringify(campeonatoData)
  })
  .then(response=>response.json())
  .then(function(response) {
    debugger
    if (typeof response.messages !== 'undefined') {
      alert(response.messages[0]);
      return;
    }

    if (typeof response.success !== 'undefined' && response.success) {
      alert('Campeonato cadastrado com sucesso!');
      return;
    }

    alert('Erro ao cadastrar Campeonato!');
  })
  .catch(function(error) {
    console.log('Erro de conexão com o backend:', error);
  });
}
function getCookie(name) {
  var value = "; " + document.cookie;
  var parts = value.split("; " + name + "=");
  if (parts.length >= 2) return parts.pop().split(";").shift();
}
var campeonatoForm = document.getElementById('championship-form');

campeonatoForm.addEventListener('submit', function(event) {
  event.preventDefault();
  cadastrarCampeonato();
});
