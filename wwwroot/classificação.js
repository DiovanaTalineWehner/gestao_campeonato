// Função para enviar os dados do formulário para o backend
function adicionarClassificacao() {
  // Obtém os valores dos campos do formulário
  var posicaoSelecionada = document.getElementById('position-select').value;
  var tempoClassificacao = document.getElementById('time-input').value;
  var selectEquipe = document.getElementById("equipe-select-classification");
  var idEquipe = selectEquipe.value;
  var nomeEquipe = selectEquipe.options[selectEquipe.selectedIndex].text;
  
  if (!tempoClassificacao){
    alert('Informe o tempo da classificação!')
    return;
  }
  // Cria um objeto com os dados da classificação
  var classificacaoData = {
    classificacao: posicaoSelecionada,
    tempo_classificacao: tempoClassificacao,
    equipe: {
      id_equipe: idEquipe,
      nome_equipe: nomeEquipe
  }};
  
  // Realiza uma requisição POST para a API com os dados da classificação
  fetch('http://localhost:5000/api/classificacao/cadastrarclassificacao', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(classificacaoData)
  })
  .then(response=>response.json())
  .then(function(response) {
    if (typeof response.messages !== 'undefined') {
      alert(response.messages[0]);
      return;
    }

    if (typeof response.success !== 'undefined' && response.success) {
      alert('Classificacao cadastrada com sucesso!');
      return;
    }

    alert('Erro ao cadastrar a Classificacao!');
  })
  .catch(function(error) {
    console.log('Erro de conexão com o backend:', error);
  });
}

var classificacaoForm = document.getElementById('classification-form');

classificacaoForm.addEventListener('submit', function(event) {
  event.preventDefault(); 
  adicionarClassificacao(); 
});
