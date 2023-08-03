// Função para enviar os dados do formulário para o backend
function cadastrarEquipe(equipeNome) {
  debugger
  // Obtém os valores dos campos do formulário
  var equipeNome = document.getElementById('team-name').value;

  if (!equipeNome) {
    alert('Informe o nome da Equipe!');
    return;
  }

  var equipeData = {
    nome_equipe: equipeNome
  };

  // Realiza uma requisição POST para a API com os dados da equipe
  fetch('http://localhost:5000/api/equipe/cadastrarequipe', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'Authorization':'Bearer ' + getCookie("Token")
    },
    body: JSON.stringify(equipeData)
  })
  .then(response=>response.json())
  .then(function(response) {
    if (typeof response.messages !== 'undefined') {
      alert(response.messages[0]);
      return;
    }

    if (typeof response.success !== 'undefined' && response.success) {
      alert('Equipe cadastrado com sucesso!');
      return;
    }

    alert('Erro ao cadastrar Equipe!');
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
// Obtém o formulário de cadastro de equipe
var equipeForm = document.getElementById('team-form');

// Adiciona um evento de submit ao formulário
equipeForm.addEventListener('submit', function(event) {
  event.preventDefault(); // Evita o comportamento padrão de envio do formulário
  cadastrarEquipe(); // Chama a função para cadastrar a equipe
});
