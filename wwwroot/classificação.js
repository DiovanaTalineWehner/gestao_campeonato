var addClassificationBtn = document.getElementById('add-classification-btn');

  // Adicione um ouvinte de evento de clique ao botão
  addClassificationBtn.addEventListener('click', function(event) {
    event.preventDefault(); // Impede o envio do formulário mais de uma vez

    // Obtenha os valores dos campos de entrada
    var positionSelect = document.getElementById('position-select');
    var timeInput = document.getElementById('time-input');

    var position = positionSelect.value;
    var time = timeInput.value;

    // Crie um objeto de dados para enviar ao back-end
    var data = {
      position: position,
      time: time
    };  

    // Crie uma nova solicitação XMLHttpRequest
    var xhr = new XMLHttpRequest();
    var url = 'URL_DO_BACKEND'; // Substitua pela URL do seu back-end

    // Defina o método e a URL da solicitação
    xhr.open('POST', url, true);

    // Defina o cabeçalho da solicitação (se necessário)
    xhr.setRequestHeader('Content-Type', 'application/json');

    // Converta o objeto de dados em uma string JSON
    var jsonData = JSON.stringify(data);

    // Defina a função de callback para tratar a resposta do back-end
    xhr.onload = function() {
      if (xhr.status === 200) {
        // Requisição bem-sucedida, faça algo aqui se necessário
        console.log('Dados enviados com sucesso!');
      } else {
        // A requisição falhou, trate o erro aqui
        console.error('Erro ao enviar os dados: ' + xhr.status);
      }
    };

    // Envie a solicitação com os dados JSON
    xhr.send(jsonData);
  });
  