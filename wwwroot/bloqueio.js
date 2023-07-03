
//Responsável por fazer o bloqueio ao painel de sistemas, para o usuário poder acessar somente se ele tiver uma conta criada


$(document).ready(function() {
    // Requisição AJAX para verificar o status de autenticação
    $.ajax({
      url: 'sua_api_url/verificar_autenticacao',
      type: 'GET',
      success: function(response) {
        // Verificar a resposta da API
        if (response.autenticado) {
          // Se o usuário está autenticado, habilitar as opções do sistema
          habilitarOpcoesSistema();
        } else {
          // Se o usuário não está autenticado, desabilitar as opções do sistema
          desabilitarOpcoesSistema();
        }
      },
      error: function() {
        // Tratar  os possíveis erros de requisição
        console.log('Erro ao verificar autenticação.');
      }
    });
  
    // Função para habilitar as opções do sistema
    function habilitarOpcoesSistema() {
      $('.bloqueado').removeClass('bloqueado');
    }
  
    // Função para desabilitar as opções do sistema
    function desabilitarOpcoesSistema() {
      $('.dropdown .bloqueado').addClass('bloqueado');
    }
  });
  