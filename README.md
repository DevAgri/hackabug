# hackabug

# RADAGRO

RADAGRO UM PROTÓTIPO DE IMPLEMENTO PARA COMBATER PRAGAS EM SOJA E ALGODÃO, SEM UTILIZAR AGROTÓXICOS.
UM SISTEMA PARA GESTAO DE MANEJO ORIENTADO POR VARIÁVEIS CLIMÁTICAS POR MEIO DO USO DE UMA ESTAÇÃO MICROCLIMÁTICA 

# Bug App

/Hackabug.App

Aplicativo para consumir informaçãoes de uma WebApi, e demonstrar de uma forma simples os dados climáticos obtidos através das micros estações. 
O aplicativo é Cross-Mobile desenvolvido em Xamarin com framework Xamarin Forms na linguagem C#. 

/Hackabug.App/hackabug -> Projeto Core Xamarin Forms
/hackabug.Droid -> Camada Android 
/hackabug.IOS   -> Camada IOS 
/hackabug.UWP  -> Camada Universal Windows Plataform

/hackabug.App/hackabug.App.ln -> Mandar abrir com visual studio para carregar todos os packages 

Projeto desenvolvido Visual Studio 2017.

# Hackabug.Api 

/hackabug.Api -> Servidor Rest para todas as 3 plataformas desenvolvida, Web, Mobile e Embarcado, plataforma desenovlvida em .NET 
WebApi.
/Hackabug.Api/hackabug.Api.ln -> Projeto inícial para carregamento de todo o corpo do projeto. 
/HackaBug.Api/HackaBug.Domain -> Domínio do projeto onde ficam todas as Entidadaes.
/HackaBug.Api/HackaBug.Infra.Data -> Camada para Banco foi Usado o ORM Entity Framework para gestão do banco. Já
na pasta Context esta a configuração das tabelas que serão geradas, /Configuration para a tipagem dos respectivos campos. 
/Migration para gerar as tabelas conforme o modelo.
Para iniciar o modelo abra o Nuget Package console e digite Update-Database para acompanhar oque esta sendo gerado coloque -Verbose e para
forçar -Force 
Update-Database -Verbose -Force

# Hackabug.View

Camada de visualização da parte web. Para iniciar a aplicação em modo desenvolvedor abra o terminal navegue até a pasta e digite npm install para baixar
as dependencias assim que baixar execute npm run dev. Para abrir somente a pagina navegue ate a pasta /dist e digite npm start.

Nesta camada foi usado as seguintes tecnologias Vue.Js, Webpack, EsLint, babel. 

# HackaBug.Arduino

Código fonte do projeto da mini Estação, para iniciar o projeto abra o Hackabug.ino com a Ide do arduino. 
A mini estação sera respónsavel por capturar as condições climáticas dos pontos onde ela será implantada 
para a comunicação inícial deste protótipo foi usado um módulo Ethernet. O embarcado diponibiliza um Json para a leitura dos dados 

# Documentos 

Os Esquemáticos de toda a parte elétrica da soluções embarcadas estão dentro dessa pasta.






