# Challenge Odontoprev API

## Objetivo Geral
Desenvolver uma API utilizando ASP.NET Core Web API, aplicando princípios de arquitetura de software, design patterns, técnicas de documentação, testes e integração com banco de dados.

## Requisitos
- Definir a arquitetura da API, explicando a escolha entre uma abordagem monolítica ou microservices e justificando a decisão.
- Implementar a API seguindo a arquitetura escolhida e explicar as diferenças.
- Endpoints CRUD (ORACLE) para os recursos de escolha (ex: produtos, usuários).
- Implementar pelo menos um padrão de criação na API (ex: Singleton para o gerenciador de configurações).
- Configurar a documentação da API utilizando Swagger/OpenAPI, com descrições claras dos endpoints e modelos de dados.

## Arquitetura
A API foi desenvolvida utilizando uma abordagem monolítica. Optamos por essa abordagem devido à simplicidade na gestão e deploy inicial do projeto, além de facilitar a integração e comunicação entre os componentes internos da aplicação.

## Design Patterns Utilizados
- **Singleton**: Utilizado para o gerenciador de configurações da aplicação para garantir que uma única instância seja utilizada durante o ciclo de vida da aplicação.

## Endpoints CRUD
A seguir estão os endpoints CRUD implementados para os recursos Paciente, Dentista, Consulta e Histórico de Consulta. Todos os dados são armazenados em um banco de dados Oracle.

### Tabelas no Banco de Dados Oracle
```sql
CREATE TABLE Paciente (
    ID_Paciente NUMBER(12) PRIMARY KEY,
    Nome VARCHAR2(30) NOT NULL,
    Data_Nascimento DATE NOT NULL,
    CPF VARCHAR2(14) UNIQUE NOT NULL,
    Endereco VARCHAR2(200) NOT NULL,
    Telefone VARCHAR2(20) NOT NULL,
    Carteirinha NUMBER(12) UNIQUE NOT NULL
);

CREATE TABLE Dentista (
    ID_Dentista NUMBER(12) PRIMARY KEY,
    Nome VARCHAR2(100) NOT NULL,
    CRO VARCHAR2(20) UNIQUE NOT NULL,
    Especialidade VARCHAR2(50) NOT NULL,
    Telefone VARCHAR2(20) NOT NULL
);

CREATE TABLE Consulta (
    ID_Consulta NUMBER(12) PRIMARY KEY,
    Data_Consulta TIMESTAMP NOT NULL,
    ID_Paciente NUMBER(12) NOT NULL,
    ID_Dentista NUMBER(12) NOT NULL,
    Status VARCHAR2(50) NOT NULL,
    FOREIGN KEY (ID_Paciente) REFERENCES Paciente(ID_Paciente),
    FOREIGN KEY (ID_Dentista) REFERENCES Dentista(ID_Dentista)
);

CREATE TABLE Historico_Consulta (
    ID_Historico NUMBER(12) PRIMARY KEY,
    ID_Consulta NUMBER(12) NOT NULL,
    Data_Atendimento TIMESTAMP NOT NULL,
    Motivo_Consulta VARCHAR2(300) NOT NULL,
    Observacoes VARCHAR2(300),
    FOREIGN KEY (ID_Consulta) REFERENCES Consulta(ID_Consulta)
);
```

## Documentação da API
A documentação da API foi configurada utilizando Swagger/OpenAPI. Para acessar a documentação, execute a aplicação e navegue até `http://localhost:<porta>/swagger`.

## Introdução para Rodar a API
1. Clone o repositório:
```bash
git clone https://github.com/VitorOnofreRamos/Challenge_Odontoprev_API.git
```

2. Navegue até o diretório do projeto:
```bash
cd Challenge_Odontoprev_API
```

3. Configure a conexão com o banco de dados Oracle no arquivo `appsettings.json`.
   
4. Execute a aplicação:
```bash
dotnet run
```

## Integrantes do grupo:
- Vitor Onofre Ramos
  - RM553241
- Pedro Henrique Soares Araujo:
  - RM553801
- Beatriz Silva:
  - RM552600
