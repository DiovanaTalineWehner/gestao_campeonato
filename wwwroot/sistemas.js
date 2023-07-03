//Esse script é responsável por retornar toda a informação que o usuário preencheu para a página de sistemas. 
//Onde ele vai ter um dashboard dessas informações.

//  Solicitação HTTP para obter os dados do backend
fetch('/dados-dashboard')
  .then(response => response.json())
  .then(data => {
    // Manipulação  dos dados recebido para preencher os dados do dashboard

    const dashboardTableBody = document.getElementById('dashboard-table-body');

    // Limpe os dados anteriores da tabela
    dashboardTableBody.innerHTML = '';

    // Itere sobre os dados recebidos e crie as linhas da tabela
    data.forEach(item => {
      const row = document.createElement('tr');

      // Crie as células da linha com os valores dos dados
      const equipeCell = document.createElement('td');
      equipeCell.textContent = item.equipe;
      row.appendChild(equipeCell);

      const carroCell = document.createElement('td');
      carroCell.textContent = item.carro;
      row.appendChild(carroCell);

      const campeonatoCell = document.createElement('td');
      campeonatoCell.textContent = item.campeonato;
      row.appendChild(campeonatoCell);

      const classificacaoCell = document.createElement('td');
      classificacaoCell.textContent = item.classificacao;
      row.appendChild(classificacaoCell);

      // Adicione a linha à tabela
      dashboardTableBody.appendChild(row);
    });
  })
  .catch(error => {
    console.error('Erro ao obter os dados do backend:', error);
  });
