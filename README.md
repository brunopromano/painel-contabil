# Painel Contabil

## Stack Utilizada
* [.Net Core 3.1](#Backend)
* [Angular 11](#Frontend)
* SQL Server 15
* Postman 8
* [Entity Framework Core 3.11](#Migrations)
<br>
<br>


## Migrations

Primeiramente é necessário realizar as migrations para criar as tabelas:
~~~bash
$ cd PainelContabil.Repository
$ dotnet ef --startup-project ../ProAgil.API database update 
~~~

<b>ATENÇÃO:</b> Após as tabelas criadas é necessário criar um trigger. Para isso, execute o 
código que está no arquivo `PainelContabil.Repository/BalancoDia_Trigger.sql` no SQL Management Studio.
<br>
<br>


## Backend

Para restaurar as dependências, deve-se estar na raiz do projeto `PainelContabil` e então o seguite comando irá restaurar todas as dependências do backend:
```cmd
$ dotnet restore
```

Para iniciar a API:
```
$ dotnet run --project PainelContabil.API
```

## Frontend

Para instalar as dependências (é necessário ter o <b>`NodeJs`</b> instalado e o <b>`npm`</b>) deve-se apontar para a pasta `PainelContabilClient` e então:
```cmd
$ npm i
```
Após as dependências instaladas, para iniciar o cliente:
```cmd
$ ng serve
```
