# 📄 Documentação Técnica do Projeto

## 🖥️ Requisitos Funcionais

- O sistema deve permitir a inclusão de contas, exigindo os seguintes campos: Nome, Valor Original, Data de Vencimento e Data de Pagamento.
- O sistema deve permitir a listagem das contas cadastradas, mostrando os seguintes detalhes de cada conta: Nome, Valor Original, Valor Corrigido, Quantidade de dias de atraso e Data de Pagamento.

## ⚙️ Requisitos Não Funcionais

- As informações devem ser persistidas em um banco de dados relacional.
- Utilização da linguagem C#.
- Utilização de injeção de dependência.
- Utilização do .NET Core 8.0 e Entity Framework Core.

## 💼 Regras de Negócio

- Todos os campos da inclusão de contas são obrigatórios.
- Não pode existir mais de uma conta por data de pagamento.
- Ao cadastrar uma conta, o sistema deve verificar se a conta está em atraso e, caso esteja, calcular o valor corrigido com base nas seguintes regras:
  - **Até 3 dias de atraso:** Multa de 2% e Juros de 0,1% ao dia.
  - **Mais de 3 dias de atraso:** Multa de 3% e Juros de 0,2% ao dia.
  - **Mais de 10 dias de atraso:** Multa de 5% e Juros de 0,3% ao dia.

## 👨🏼‍💻 Casos de Uso

### UC01 - Inclusão de Conta

**Ator Principal:** Usuário

**Fluxo Principal:**
- 1. O Usuário insere os dados da conta e submete-os.
- 2. O Sistema verifica se todos os campos obrigatórios foram preenchidos.
- 3. O Sistema verifica se já existe uma conta cadastrada com a mesma data de pagamento.
- 4. O Sistema calcula a quantidade de dias em atraso e aplica as regras de cálculo, se necessário.
- 5. A conta é persistida no banco de dados.

**Fluxo Alternativo:**
- Se algum dos campos obrigatórios não for preenchido, o sistema exibe uma mensagem de erro.
- Se já existir uma conta cadastrada com a mesma data de pagamento, o sistema exibe uma mensagem de erro.

### UC02 - Listagem das Contas Cadastradas

**Ator Principal:** Usuário

**Fluxo Principal:**
- 1. O Usuário solicita a listagem das contas cadastradas.
- 2. O Sistema retorna a lista de contas com os dados solicitados.

**Fluxo Alternativo:**
- Se não houver nenhuma conta cadastrada, o sistema retorna uma lista vazia.

## 💾 Modelo Lógico de Dados

### Conta
- Id (PK)
- Nome
- ValorOriginal
- DataVencimento
- DataPagamento
- DiasAtraso
- ValorCorrigido

### RegraNegocio
- Id (PK)
- DiasEmAtraso
- Multa
- JurosPorDia
