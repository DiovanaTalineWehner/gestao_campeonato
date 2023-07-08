// Função para enviar os dados do formulário para o backend
function adicionarClassificacao() {
  // Obtém os valores dos campos do formulário
  var posicaoSelecionada = document.getElementById('position-select').value;
  var tempoClassificacao = document.getElementById('time-input').value;
  var equipeSelecionada = document.getElementById('equipe-select-classification').value;
  
  // Cria um objeto com os dados da classificação
  var classificacaoData = {
    posicao: posicaoSelecionada,
    tempo: tempoClassificacao,
    equipe: equipeSelecionada
  };
  
  // Realiza uma requisição POST para a API com os dados da classificação
  fetch('/api/Classificação', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(classificacaoData)
  })
  .then(function(response) {
    // Verifica se a requisição foi bem-sucedida
    if (response.ok) {
      // Classificação adicionada com sucesso
      console.log('Classificação adicionada com sucesso!');
    } else {
      // Ocorreu um erro ao adicionar a classificação
      console.log('Erro ao adicionar classificação!');
    }
  })
  .catch(function(error) {
    // Ocorreu um erro de conexão com o backend
    console.log('Erro de conexão com o backend:', error);
    // Aqui você pode adicionar lógica adicional para lidar com erros de conexão
  });
}

// Obtém o formulário de adição de classificação
var classificacaoForm = document.getElementById('classification-form');

// Adiciona um evento de submit ao formulário
classificacaoForm.addEventListener('submit', function(event) {
  event.preventDefault(); // Evita o comportamento padrão de envio do formulário
  adicionarClassificacao(); // Chama a função para adicionar a classificação
});
