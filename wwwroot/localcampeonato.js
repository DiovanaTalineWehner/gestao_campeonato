// Submissão do formulário de local do campeonato
var championshipForm = document.getElementById('championship-form');
championshipForm.addEventListener('submit', function(event) {
  event.preventDefault(); // Evite o comportamento padrão de envio do formulário

  // Obtenha os valores selecionados
  var citySelect = document.getElementById('city-select');
  var selectedCity = citySelect.value;
  var championshipNameInput = document.getElementById('championship-name');
  var championshipName = championshipNameInput.value;

  // Realize o envio dos dados para o backend
  // Aqui você pode adicionar a lógica de envio para o backend utilizando AJAX ou outra abordagem
  // Exemplo de envio utilizando fetch:
  fetch('/cadastrar-campeonato', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify({ city: selectedCity, championshipName: championshipName })
  })
  .then(response => {
    if (response.ok) {
      // Sucesso no envio dos dados
      alert('Informações do campeonato enviadas para o backend:\nCidade: ' + selectedCity + '\nNome do Campeonato: ' + championshipName);
    } else {
      // Erro no envio dos dados
      alert('Erro ao enviar os dados para o backend.');
    }
  })
  .catch(error => {
    console.error('Ocorreu um erro:', error);
    alert('Erro ao enviar os dados para o backend.');
  });
});
