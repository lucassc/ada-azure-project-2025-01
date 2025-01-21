# Desafio: Deploy de Infraestrutura para Aplicação em Kubernetes com Terraform

## Contexto

O time de desenvolvimento finalizou a construção de uma nova aplicação que precisa ser implantada em um ambiente em nuvem. Essa aplicação está conteinerizada e sua principal responsabilidade é conectar-se ao Azure Key Vault para recuperar a string de conexão do banco de dados. Uma vez conectada, a aplicação irá executar migrações automaticamente e popular as tabelas necessárias.


## Objetivo

O objetivo deste desafio é provisionar a infraestrutura necessária para rodar a aplicação utilizando **Terraform**.

A equipe de Cloud recebeu a responsabilidade de provisionar a infraestrutura necessária para que a aplicação funcione corretamente. O desafio está em criar um ambiente Kubernetes adequado, garantindo a segurança, escalabilidade e confiabilidade da solução.

## Requisitos

### Infraestrutura

1. **Ambiente**
   - O cluster deve ser provisionado utilizando Terraform.
   - Deve incluir um **namespace** dedicado para a aplicação.

2. **Azure Key Vault**
   - Deve ser criado no Terraform e conter a string de conexão do banco de dados.
   - A aplicação deve ter permissão para ler os segredos.

3. **Banco de Dados**
   - Um banco de dados deve ser provisionado.
   - A string de conexão deve ser armazenada no Key Vault.

### Deployment da Aplicação

- A variavel de ambiente SPD_KEY_VAULT_URI deve conter a Uri do key vault. Ex: `https://mykeyvault.vault.azure.net/`
- Container image: `schwendler/embarque-ti-spd-project`
- A secret com a connection string deve ser definida com o nome: `db-connection-string`
- O pod da aplicação deve recuperar automaticamente a string de conexão do Key Vault.
- Aplicação irá rodar na porta 8080

## Entrega

O projeto deve ser entregue em um repositório Git contendo:

1. **Códigos Terraform** para provisionamento da infraestrutura.
3. **Documentação** contendo:
   - Como executar o Terraform para criar a infraestrutura.
   - Como fazer deploy da aplicação.
   - Como validar que a aplicação está funcionando corretamente.

## Avaliação

Os seguintes critérios serão utilizados para avaliação do desafio:

- **Infraestrutura provisionada corretamente** e funcionando conforme esperado.
- **Uso adequado de Terraform**
- **Documentação clara e objetiva** sobre como utilizar a infraestrutura.

## Desafio Extra

Para aqueles que desejam um desafio adicional, implemente:
- **Monitoramento e Logging**
- **Pipeline CI/CD** para automação do deploy da infraestrutura e da aplicação.

Boa sorte! 🚀

