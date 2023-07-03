// Função para enviar os dados do formulário para o backend
function cadastrarEquipe() {
    // Obtém os valores dos campos do formulário
    var equipeNome = document.getElementById('team-name').value;
  
    // Cria um objeto com os dados da equipe
    var equipeData = {
      nome: equipeNome
    };
  
    // Realiza uma requisição POST para a API com os dados da equipe
    fetch('URL_DA_SUA_API/cadastrarEquipe', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(equipeData)
    })
    .then(function(response) {
      // Verifica se a requisição foi bem-sucedida
      if (response.ok) {
        // Equipe cadastrada com sucesso
        console.log('Equipe cadastrada com sucesso!');
      } else {
        // Ocorreu um erro ao cadastrar a equipe
        console.log('Erro ao cadastrar equipe!');
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
  