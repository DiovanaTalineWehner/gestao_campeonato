// Função para enviar os dados do formulário para o backend
function cadastrarEquipe(equipeNome) {
  // Obtém os valores dos campos do formulário
  var equipeNome = document.getElementById('equipeNome').value;

  // Cria um objeto com os dados da equipe
  var equipeData = {
    nome_equipe: equipeNome
  };

  // Realiza uma requisição POST para a API com os dados da equipe
  fetch('http://localhost:5000/api/equipe/cadastrarequipe', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(equipeData)
  })
  .then(response=>response.json())
  .then(function(response) {
    // Verifica se a requisição foi bem-sucedida
    if (response.success) {
      // Equipe cadastrada com sucesso
      alert('Equipe cadastrada com sucesso!');
    } else {
      // Ocorreu um erro ao cadastrar a equipe
      alert('Erro ao cadastrar equipe!');
    }
  })
  .catch(function(error) {
    // Ocorreu um erro de conexão com o backend
    console.log('Erro de conexão com o backend:', error);
    // Aqui você pode adicionar lógica adicional para lidar com erros de conexão
  });
}

// Obtém o formulário de cadastro de equipe
var equipeForm = document.getElementById('team-form');

// Adiciona um evento de submit ao formulário
equipeForm.addEventListener('submit', function(event) {
  event.preventDefault(); // Evita o comportamento padrão de envio do formulário
  cadastrarEquipe(); // Chama a função para cadastrar a equipe
});
