# Challenge Odontoprev API

## Descrição
A **Challenge Odontoprev API** é uma API REST desenvolvida em **ASP.NET Core 8.0** para gerenciar consultas odontológicas, dentistas, pacientes e histórico de atendimentos. Ela utiliza o **Entity Framework Core** com **Oracle** como banco de dados e implementa o **AutoMapper** para conversão de objetos.

## Tecnologias Utilizadas
- **.NET 8.0**
- **ASP.NET Core**
- **Entity Framework Core** (com suporte a Oracle)
- **AutoMapper**
- **Swashbuckle/Swagger** (para documentação da API)
- **Newtonsoft.Json**

## Estrutura do Projeto
```
Challenge_Odontoprev_API/
├── Controllers/           # Controladores da API
├── DTOs/                 # Data Transfer Objects (DTOs)
├── Infraestructure/      # Configuração do banco de dados e Unit of Work
├── Mappings/             # Perfis do AutoMapper
├── Models/               # Modelos de dados
├── Repositories/         # Repositórios para manipulação dos dados
├── Services/             # Serviços auxiliares
├── Program.cs            # Configuração da aplicação
├── appsettings.json      # Configuração da aplicação
└── README.md             # Documentação do projeto
```

## Configuração e Instalação
### 1. Clonar o repositório
```sh
git clone https://github.com/seu-usuario/Challenge_Odontoprev_API.git
cd Challenge_Odontoprev_API
```

### 2. Configurar a string de conexão
Edite o arquivo `appsettings.json` e substitua `[HOST]`, `[PORT]`, `[SERVICE_NAME]`, `[USUARIO]` e `[SENHA]` com as informações do seu banco de dados Oracle:
```json
"ConnectionStrings": {
    "OracleConnection": "Data Source=//[HOST]:[PORT]/[SERVICE_NAME];User Id=[USUARIO];Password=[SENHA];"
}
```

### 3. Restaurar dependências
```sh
dotnet restore
```

### 4. Rodar a API
```sh
dotnet run
```
A API estará disponível em `http://localhost:5062`

## Endpoints Disponíveis
A documentação completa dos endpoints pode ser acessada via **Swagger**:
```
http://localhost:5062/swagger
```

### Exemplo de Endpoints
- **GET** `/api/paciente` - Lista todos os pacientes
- **POST** `/api/paciente` - Cria um novo paciente
- **GET** `/api/consulta/{id}` - Obtém uma consulta por ID
- **PUT** `/api/consulta/{id}` - Atualiza uma consulta existente
- **DELETE** `/api/dentista/{id}` - Remove um dentista

## Contribuição
1. Fork este repositório
2. Crie uma branch (`feature/nova-funcionalidade`)
3. Commit suas alterações
4. Push para a branch
5. Abra um Pull Request

## Licença
Este projeto está licenciado sob a **MIT License**.

## Integrates

**Turma 2TDSPS**
- Vitor Onofre Ramos | RM553241
- Pedro Henrique | RM553801
- Beatriz Silva | RM552600
