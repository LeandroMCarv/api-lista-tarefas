# ApiTarefas

API REST simples para gerenciamento de tarefas, desenvolvida em **ASP.NET Core** com **Entity Framework Core** e **SQL Server**. O projeto permite criar, listar, atualizar e excluir tarefas (CRUD), além de disponibilizar uma interface de documentação interativa utilizando **Scalar**.

---

## 🚀 Tecnologias Utilizadas

- ASP.NET Core
- Entity Framework Core
- SQL Server
- Scalar (documentação da API)
- C#

---

## 📂 Estrutura do Projeto

A organização das pastas do projeto segue o padrão abaixo:

```
ApiTarefas
│
├── Controllers
│   └── TarefaController.cs
│
├── Data
│   └── AppDbContext.cs
│
├── Migrations
│   ├── CriarBancoDeDados.cs
│   ├── CriarTarefas.cs
│   ├── CriarTarefas.Designer.cs
│   ├── CriarBancoDeDados.Designer.cs
│   └── AppDbContextModelSnapshot.cs
│
├── Properties
│   └── launchSettings.json
│
├── Tarefas
│   └── Tarefa.cs
│
├── ApiTarefas.cs
├── ApiTarefas.http
├── appsettings.json
├── appsettings.Development.json
└── Program.cs
```

---

## 📝 Modelo de Dados – Tarefa

A entidade `Tarefa` possui os seguintes campos:

- `Id` (int)
- `Descricao` (string)
- `Status` (string)
- `DataCriacao` (DateTime)
- `Prazo` (DateTime?)
- `Prioridade` (string)
- `Responsavel` (string)
- `Finalizado` (bool)

---

## 🔗 Endpoints da API

Base URL:
```
/api/tarefa
```

### ➕ Criar uma tarefa
**POST** `/api/tarefa`

Body (JSON):
```json
{
  "descricao": "Exemplo de tarefa",
  "status": "Pendente",
  "dataCriacao": "2025-01-01T00:00:00",
  "prazo": "2025-01-10T00:00:00",
  "prioridade": "Alta",
  "responsavel": "João",
  "finalizado": false
}
```

---

### 📋 Listar todas as tarefas
**GET** `/api/tarefa`

---

### 🔍 Buscar tarefa por ID
**GET** `/api/tarefa/id?id={id}`

---

### ✏️ Atualizar uma tarefa
**PUT** `/api/tarefa/id`

Body (JSON):
```json
{
  "id": 1,
  "descricao": "Tarefa atualizada",
  "status": "Em andamento",
  "prazo": "2025-01-15T00:00:00",
  "prioridade": "Média",
  "responsavel": "Maria",
  "finalizado": false
}
```

---

### 🗑️ Remover uma tarefa
**DELETE** `/api/tarefa/id?id={id}`

---

## 🧪 Documentação da API

Em ambiente de desenvolvimento, a documentação interativa está disponível via **Scalar**:

```
https://localhost:7261/scalar
```

ou

```
http://localhost:5021/scalar
```

---

## ⚙️ Configuração e Execução

### Pré-requisitos

- .NET SDK instalado
- SQL Server

### Passos

1. Configure a string de conexão `DefaultConnection` no `appsettings.json`.
2. Execute as migrations para criar o banco de dados:
   ```bash
   dotnet ef database update
   ```
3. Inicie a aplicação:
   ```bash
   dotnet run
   ```

---

## 📌 Observações

- O projeto utiliza **Entity Framework Core** com migrations.
- O ambiente de desenvolvimento já está configurado para HTTPS e HTTP.
- O Scalar substitui o Swagger para documentação e testes dos endpoints.

---

## 👨‍💻 Autor

- [@LeandroMCarv](https://www.github.com/LeandroMCarv)

