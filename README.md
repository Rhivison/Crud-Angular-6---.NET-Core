# Crud-Angular 6 e.NET Core-2.2
Crud Utilizando Angular 6 e .NET Core 2.2

A solução está contida em duas pastas.
 -Backend: Contém o backend desenvolvido utilizando .NET Core 2.2
 -Frontend: Contém o frontend desenvolvido utilizando Angular 6
 
 Para cumprir o desafio, foram implementados:
   - 3 Controllers: PersonController, PhoneNumberTypeController e PersonPhoneController. Os dois primeiros auxiliam na visualização de dados pelo usuário, enquanto o último                           implementa as funcionalidades solicitadas.
   - As Facades, Services, Repositorys, DTOs, Responses e Requests de forma a se respeitar a arquitetura já fornecida.
   - Services do Frontend para as os controllers mencionados acima, sendo que a service de interesse para o CRUD é a person-phone.service.ts
   - A execeção do método PUT, todos os métodos estão implementados e funcionais tanto no Backend quanto no Frontend. Este mencionado está com todos os metodos implementados, entretanto sua tela ainda não está funcional.

Instruções para execução:
  - O Backend continua utilizando o projeto em Docker e os containers orquestrados pelo docker-compose, deve-se apenas verificar a liberação da porta 1433 ou outra de sua escolha para a instância do MSSQL.
  - Para executar o Frontend recomenda-se a utilização do Visual Studio Code. Em um primeiro momento é necessário a execução do comando npm install. Este comando irá baixar todas as dependências do projeto.
    Após a execução do npm install, deve-se alterar o arquivo enviroment.ts com o correto endereço da API do backend. Exemplo:"http//localhost:65179/api". Uma vez alterado o endereço, basta rodar o comando ng serve.    
