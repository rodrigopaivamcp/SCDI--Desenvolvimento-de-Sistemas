#  SCDI — Sistema de Controle de Disponibilidade de Insumos

O **SCDI** é uma Web API robusta desenvolvida em **.NET 8** utilizando os princípios da **Clean Architecture** (Arquitetura Limpa). O objetivo do ecossistema é o gerenciamento de estoque, precificação e auditoria de insumos industriais ou comerciais de forma isolada, escalável e segura.

---

##  Tecnologias e Ferramentas Utilizadas

* **Linguagem / Framework:** C# no ecossistema .NET 8.0
* **Banco de Dados:** PostgreSQL (Relacional)
* **Ambiente Isolado:** Docker & Docker Compose
* **ORM / Mapeamento:** Entity Framework Core (EF Core) com Npgsql
* **Documentação Interativa:** OpenAPI / Swagger UI
* **Testes Automatizados:** xUnit para testes unitários de domínio

---

##  Estrutura de Arquitetura do Projeto

O projeto foi segmentado em camadas para garantir a separação de conceitos (*Separation of Concerns*):

1. **`SCDI.Domain`:** O coração do sistema. Contém as entidades de negócio (`Insumo.cs`) e as regras estritas de domínio (validações contra valores negativos).
2. **`SCDI.Infrastructure`:** Responsável pelo acesso ao banco de dados, Fluent API, contexto do EF (`ScdiDbContext.cs`) e controle de Migrations.
3. **`SCDI.API`:** Porta de entrada do sistema. Gerencia os controladores HTTP, tratamento de login e expõe o Swagger UI.
4. **`SCDI.UnitTests`:** Suíte automatizada encarregada de testar a estabilidade das regras de negócio.

---

##  Como Executar o Projeto Localmente

Siga o passo a passo abaixo para rodar a aplicação e o banco de dados na sua máquina:

### 1. Pré-requisitos
Certifique-se de possuir instalado:
* **.NET 8 SDK**
* **Docker / Docker Desktop**

### 2. Subir o Banco de Dados (PostgreSQL)
Navegue até a raiz do projeto (onde está o arquivo `docker-compose.yml`) e inicie o container isolado:
```bash
docker-compose up -d

### 3. incronizar as Tabelas (EF Migrations)
Para aplicar as migrações estruturais e criar as tabelas dentro do banco PostgreSQL conteinerizado, execute:
```bash
dotnet ef database update --project src/SCDI.Infrastructure --startup-project src/SCDI.API

### 4. Ligar a Web API Backend
Para iniciar o servidor HTTP da aplicação backend e expor os endpoints, execute:
```bash
dotnet run --project src/SCDI.API
