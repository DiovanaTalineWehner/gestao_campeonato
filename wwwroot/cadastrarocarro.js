carForm.addEventListener('submit', function(event) {
    event.preventDefault();
  
    var carName = document.getElementById('car-name').value;
  
    // Criar um objeto com os dados do carro
    var carData = {
      name: carName
    };
  
    // Enviar uma requisição POST para a API com os dados do carro
    fetch('http://seu-backend.com/api/carros', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(carData)
    })
      .then(function(response) {
        // Verificar o status da resposta da API
        if (response.ok) {
          // O carro foi cadastrado com sucesso
          console.log('Carro cadastrado com sucesso!');
          // Faça alguma ação adicional, se necessário
        } else {
          // Houve um erro no cadastro do carro
          console.log('Erro ao cadastrar o carro.');
          // Trate o erro de acordo com sua necessidade
        }
      })
      .catch(function(error) {
        // Houve um erro na requisição
        console.log('Erro na requisição:', error);
        // Trate o erro de acordo com sua necessidade
      });
  
    document.getElementById('car-name').value = '';
  });
  