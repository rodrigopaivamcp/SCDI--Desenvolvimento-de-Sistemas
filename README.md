# SCDI — Sistema de Controle de Disponibilidade de Insumos

O SCDI é uma Web API backend de nível corporativo desenvolvida sobre a plataforma .NET 8. O sistema foi projetado especificamente para gerenciar o inventário, catalogação, precificação e auditoria automatizada de insumos industriais e comerciais. 

A aplicação foi construída seguindo os padrões da Clean Architecture (Arquitetura Limpa) e os princípios do DDD (Domain-Driven Design), garantindo uma separação estrita de responsabilidades, alta testabilidade e independência de ferramentas externas.

---

## Tecnologias e Ecossistema

* Ambiente de Execução / Linguagem: .NET 8.0 (SDK) / C# 12
* Banco de Dados Relacional: PostgreSQL 15 (Conteinerizado via Docker)
* ORM (Mapeamento Objeto-Relacional): Entity Framework Core 8.0
* Driver de Conexão: Npgsql.EntityFrameworkCore.PostgreSQL
* Documentação Interativa: OpenAPI 3.0 / Swagger UI
* Framework de Testes Automatizados: xUnit

---

## Guia de Avaliação Direta pelo GitHub

Caso a avaliação da estrutura seja feita diretamente por este repositório do GitHub (sem a necessidade de baixar ou rodar o código localmente), a arquitetura e os componentes estão organizados de forma transparente abaixo:

### 1. Onde encontrar cada componente da Arquitetura:
* Regras de Negócio e Validações: Acesse a pasta src/SCDI.Domain/Entities/Insumo.cs para checar as travas de domínio (que impedem nomes vazios e preços negativos).
* Mapeamento do Banco de Dados: Acesse src/SCDI.Infrastructure/Configurations/InsumoConfiguration.cs para visualizar a configuração da Fluent API (chaves GUID, limites de caracteres e precisão monetária).
* Exposição dos Endpoints (API): Acesse src/SCDI.API/Controllers/InsumosController.cs para validar os métodos REST (GET, POST, PUT, DELETE).
* Garantia de Qualidade: Acesse src/SCDI.UnitTests/Domain/InsumoTests.cs para ver a suíte com os 4 testes automatizados xUnit que validam o comportamento do sistema.

### Como o Banco de Dados subiria no Docker:
O arquivo docker-compose.yml na raiz está parametrizado para baixar uma imagem limpa do PostgreSQL 15 e expô-la na porta isolada 5433 (evitando conflitos locais), criando automaticamente a base de dados scdi_management_db.

### Evidências de Execução Local:
Os testes automatizados foram validados via CLI (dotnet test) apresentando 100% de sucesso (4 Passed, 0 Failed).

---

## Guia de Uso e Instruções de Inicialização (Execução Local)

Para rodar este ecossistema localmente e acessar a interface do Swagger com o ambiente configurado corretamente, siga as instruções abaixo. 

### Pré-requisito Obrigatório:
Abra o terminal (Prompt de Comando, PowerShell ou Terminal do VS Code) exatamente na raiz da pasta do projeto (onde reside o arquivo docker-compose.yml e a pasta src/).

---

### Passo a Passo para Execução:

#### Passo 1: Inicializar a Infraestrutura de Banco de Dados (Docker)
Para baixar a imagem oficial do PostgreSQL e iniciar o banco de dados rodando de forma isolada em segundo plano, execute:
docker-compose up -d

> O banco de dados estará ativo e ouvindo localmente através da porta configurada 5433.

#### Passo 2: Sincronizar a Estrutura do Banco (EF Migrations)
Para transmitir e aplicar os scripts de criação de tabelas do Entity Framework para dentro do container Docker instalado no Passo 1, execute o comando:
dotnet ef database update --project src/SCDI.Infrastructure --startup-project src/SCDI.API

> Aguarde o terminal compilar e exibir a palavra de sucesso Done. no final.

#### Passo 3: Ligar a Web API Backend
Para iniciar o servidor HTTP local da aplicação e expor os endpoints de negócio,
