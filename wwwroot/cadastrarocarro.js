function cadastrarCarro() {
  var carroNome = document.getElementById('car-name').value;

  var selectEquipe = document.getElementById("equipe-select");
  var idEquipe = selectEquipe.value;
  var nomeEquipe = selectEquipe.options[selectEquipe.selectedIndex].text;

  if (!carroNome) {
    alert('Informe o nome do Carro!');
    return;
  }
  
  var carroData = {
    nome_carro: carroNome,
    equipe: {
      id_equipe: idEquipe,
      nome_equipe: nomeEquipe
    }
  };
  
  fetch('http://localhost:5000/api/carro/cadastrarcarro', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'Authorization':'Bearer ' + getCookie("Token")
    },
    body: JSON.stringify(carroData)
  })
  .then(response=>response.json())
  .then(function(response) {
    if (typeof response.messages !== 'undefined') {
      alert(response.messages[0]);
      return;
    }

    if (typeof response.success !== 'undefined' && response.success) {
      alert('Carro cadastrado com sucesso!');
      return;
    }

    alert('Erro ao cadastrar Carro!');
  })
  .catch(function(error) {
    console.log('Erro de conexão com o backend:', error);
  });
}
function getCookie(name){
  var value = "; " + document.cookie;
  var parts = value.split("; " + name + "=");
  if (parts.length >=2) return parts.pop().split(";");shift();
}

var carroForm = document.getElementById('car-form');

carroForm.addEventListener('submit', function(event) {
  event.preventDefault();
  cadastrarCarro();
});
