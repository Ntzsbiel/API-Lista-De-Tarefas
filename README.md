# 📌 DIO - Trilha .NET - API e Entity Framework  
www.dio.me  

## 🏆 Desafio Concluído  
Este repositório contém a solução para o desafio de projeto do módulo de API e Entity Framework da trilha .NET da DIO. O objetivo foi construir uma **API para gerenciamento de tarefas**, permitindo operações de CRUD (Create, Read, Update e Delete).  

## 📌 Contexto  
Desenvolvi um sistema gerenciador de tarefas para auxiliar na organização da rotina. A API permite criar, visualizar, atualizar e excluir tarefas, seguindo boas práticas de desenvolvimento e utilizando o **Entity Framework** para interação com o banco de dados.  

A aplicação foi implementada no formato **Web API**, garantindo flexibilidade e fácil integração com outras aplicações.  

## 🛠 Estrutura da Classe  
A principal entidade do sistema é a **Tarefa**, modelada conforme o diagrama abaixo:  

![Diagrama da classe Tarefa](imagens/diagrama.png)  

A estrutura foi desenvolvida utilizando **Migrations** para manter o banco de dados atualizado automaticamente.  

## 🚀 Métodos Implementados  

### **Swagger**  
A API conta com uma documentação interativa gerada com **Swagger**, permitindo testes diretos nos endpoints:  

![Métodos Swagger](imagens/swagger.png)  

### **Endpoints Disponíveis**  

| Verbo  | Endpoint                | Parâmetro | Body          |
|--------|-------------------------|-----------|---------------|
| GET    | /Tarefa/{id}            | id        | N/A           |
| PUT    | /Tarefa/{id}            | id        | Schema Tarefa |
| DELETE | /Tarefa/{id}            | id        | N/A           |
| GET    | /Tarefa/ObterTodos      | N/A       | N/A           |
| GET    | /Tarefa/ObterPorTitulo  | titulo    | N/A           |
| GET    | /Tarefa/ObterPorData    | data      | N/A           |
| GET    | /Tarefa/ObterPorStatus  | status    | N/A           |
| POST   | /Tarefa                 | N/A       | Schema Tarefa |

### **Modelo de Tarefa (Schema)**  
Este é o modelo utilizado nos métodos que exigem envio de dados no corpo da requisição:  

```json
{
  "id": 0,
  "titulo": "string",
  "descricao": "string",
  "data": "2022-06-08T01:31:07.056Z",
  "status": "Pendente"
}
