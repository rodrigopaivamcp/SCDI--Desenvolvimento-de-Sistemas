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
Para iniciar o servidor HTTP local da aplicação e expor os endpoints de negócio, execute:
dotnet run --project src/SCDI.API

> Nota de Execução: Este terminal ficará ativamente "travado" segurando o servidor da API ligado. Não feche esta janela.

---

### Acessando a Interface do Swagger UI

Com o terminal do Passo 3 ativo, abra o navegador de internet e acesse a interface interativa de testes através do endereço oficial abaixo:

Endereço do Swagger: http://localhost:5096/swagger

*(Adicione obrigatoriamente o sufixo /swagger ao final do link para renderizar a página corretamente).*

---

### Manual de Homologação e Teste dos Endpoints

Dentro da interface do Swagger UI, os testes de requisições seguem o seguinte fluxo lógico:

1. Autenticação: Realize uma chamada POST no endpoint /api/Auth/login o utilizando as credenciais padrão de homologação para receber o token simulado:
   * Username: admin
   * Password: admin123
2. Operações de Insumos: Com o acesso validado, utilize os endpoints do InsumosController enviando payloads estruturados para inclusão, listagem, alteração e exclusão de itens de estoque no banco de dados.
3. Validação de Domínio (DDD): Caso envie um payload com PrecoUnitario negativo (menor que zero) ou Nome vazio, a camada de domínio rejeitará a operação imediatamente, retornando um status 400 Bad Request com a mensagem de erro da exceção, provando a consistência das entidades de negócio.

---

### Executando os Testes Unitários de Forma Independente

Caso deseje rodar a suíte de testes automatizados, abra um segundo terminal na raiz do projeto (mantendo a API ligada no terminal anterior) e execute:
dotnet test

---

## Troubleshooting (Solução de Comportamentos do Ambiente)

1. Divergência de Caminhos no Terminal: Caso ocorra o erro Unable to retrieve project metadata, certifique-se de que os comandos estão sendo digitados exatamente na raiz do repositório, mantendo os prefixos src/ indicados nos passos acima.
2. Erro 404 ao Abrir a URL: A rota padrão raiz da API está protegida. É obrigatório adicionar o sufixo /swagger ao final do endereço no navegador para renderizar a interface visual.
3. Persistência de Cache no Swagger UI: Em alguns navegadores, o formulário do Swagger pode reter valores digitados anteriormente na memória gráfica. Ao atualizar valores monetários, certifique-se de clicar em uma área vazia fora da caixa de texto antes de acionar o botão Execute para forçar a atualização do JSON bruto de envio.

---
