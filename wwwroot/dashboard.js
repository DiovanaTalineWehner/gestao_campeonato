
function loadDashboard() {
    const equipeValue = document.getElementById("equipe-select").value;
    const carroValue = document.getElementById("car-name").value;
    const campeonatoValue = document.getElementById("championship-name").value;
    const classificacaoValue = document.getElementById("position-select").value;
  
    const dadosPreenchidos = {
      equipe: equipeValue,
      carro: carroValue,
      campeonato: campeonatoValue,
      classificacao: classificacaoValue
    };
  
    renderDashboard(dadosPreenchidos);
  }
  
  
  function renderDashboard(data) {
    const dashboardTableBody = document.getElementById("dashboard-table-body");
  
   
    const newRow = document.createElement("tr");
  
  
    const equipeCell = document.createElement("td");
    equipeCell.textContent = data.equipe;
    newRow.appendChild(equipeCell);
  
    const carroCell = document.createElement("td");
    carroCell.textContent = data.carro;
    newRow.appendChild(carroCell);
  
    const campeonatoCell = document.createElement("td");
    campeonatoCell.textContent = data.campeonato;
    newRow.appendChild(campeonatoCell);
  
    const classificacaoCell = document.createElement("td");
    classificacaoCell.textContent = data.classificacao;
    newRow.appendChild(classificacaoCell);
  
    
    dashboardTableBody.appendChild(newRow);
  }
  
  
  document.getElementById("car-form").addEventListener("submit", function(event) {
    event.preventDefault();
    loadDashboard();
  });
  
  document.getElementById("team-form").addEventListener("submit", function(event) {
    event.preventDefault();
    loadDashboard();
  });
  
  document.getElementById("championship-form").addEventListener("submit", function(event) {
    event.preventDefault();
    loadDashboard();
  });
  
  
  document.getElementById("classification-form").addEventListener("submit", function(event) {
    event.preventDefault();
    loadDashboard();
  });
  