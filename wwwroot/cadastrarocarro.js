// Função para enviar os dados do formulário para o backend
function cadastrarCarro() {
  // Obtém os valores dos campos do formulário
  var carroNome = document.getElementById('car-name').value;
  var equipeSelecionada = document.getElementById('equipe-select').value;
  
  // Cria um objeto com os dados do carro
  var carroData = {
    nome: carroNome,
    equipe: equipeSelecionada
  };
  
  // Realiza uma requisição POST para a API com os dados do carro
  fetch('/api/cadastrarcarro', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(carroData)
  })
  .then(function(response) {
    // Verifica se a requisição foi bem-sucedida
    if (response.ok) {
      console.log('Carro cadastrado com sucesso!');
    } else {
      console.log('Erro ao cadastrar carro!');
    }
  })
  .catch(function(error) {
    console.log('Erro de conexão com o backend:', error);
    // Aqui você pode adicionar lógica adicional para lidar com erros de conexão
  });
}

var carroForm = document.getElementById('car-form');

// Adiciona um evento de submit ao formulário
carroForm.addEventListener('submit', function(event) {
  event.preventDefault(); // Evita o comportamento padrão de envio do formulário
  cadastrarCarro(); // Chama a função para cadastrar o carro
});
