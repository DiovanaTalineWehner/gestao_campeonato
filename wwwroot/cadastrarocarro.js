carForm.addEventListener('submit', function(event) {
    event.preventDefault();
  
    var carName = document.getElementById('car-name').value;
  
    // Criar um objeto com os dados do carro
    var carData = {
      name: carName
    };
  
    // Envia uma requisição POST para a API com os dados do carro
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
        } else {
          console.log('Erro ao cadastrar o carro.');
         
        }
      })
      .catch(function(error) {
        // Caso ocorre algum problema  
        console.log('Erro na requisição:', error);

      });
  
    document.getElementById('car-name').value = '';
  });
  