### Description on how I went by solving the project.
I started by reading the project description and splitting it up into tasks, after that I created a few undertasks for some of the tasks from the description. 
- Creating a .Net Core Web ApI project
    - Creating project with minimal functionality
    - Structure the project adding layers
        - Presentation(Controller)
        - Serivce
        - Data Access
- 3 Functionalites for the API
    - 2 GET and 1PATCH methods
    - Create Routes
- Starting the given postgres database from Salt/Borgun
- Write tests
- Setup Swagger
- Use Docker to start the web service

I started the database and took a look at it. After that I created the Web API project with minimal functionality to test the API connection to the database. After that I started structuring the project, setting it up into 3 Layers, Presentation(Controller), Service and Data Access. When that was finished and all was functions where tested, I started writing unit tests. Swagger was added and information on how to use the functions in the SwaggerUI. Lastly I tried setting the Web Api in Docker, I had no problems with building images or creating containers. When running thee image for project it starts up And you are able to enter the SwaggerUI, but there is some connection problem to the database
```shell
An error occurred using the connection to database 'test' on server 'tcp://localhost:5432'.
```
Using the docker compose file did also have a problem
```shell
Cannot assign requested address [::1]:5432
```
I tested adding the postgres database to the project and to the docker compose file but that did not help fixing it.
In conclusion I was not able to fix the docker problem but you can run the code and everything works the. That is maybe something we could talk about in our next meeting if you can see the problem that I had and have maybe a fix for it.

### Description on how to run the code and tests.
For running the tests you should navigate into the `Salt.Tests/` folder and type:
```shell
dotnet test
```

For running the code and starting up the Web API you should navigate into the `Salt.WebApi/` folder and type:
```shell
dotnet build
dotnet run
```

### Description on how to use the service f.ex. in text or in Swagger
When the Web API is up and running you can navigate to [SwaggerUI](http://localhost:5000/swagger). The API runs on port 5000.

There are 3 functions for the API, links and endpoints are below with info on parameters and examples.

_________________

#### Get Merchant Transactions By Date
`http://localhost:5000/api/merchants/{merchantId}/transactions`
Using a GET method, merchantId and query with date parameter after transactions is required. e.g.
```shell
http://localhost:5000/api/merchants/9876501/transactions?date=2020-07-01
```
Status should return OK and List of all tranasctions by date.

_________________

#### Get Merchant Payment By Date
`http://localhost:5000/api/merchants/{merchantId}/payments`
Using a GET method, merchantId and query with date parameter after payments is required. e.g.
```shell
http://localhost:5000/api/merchants/9876501/payments?date=2020-07-01
```
Status should return OK and Object with total merhcant id, date, total amount and currency.

_________________

#### Patch Merchant Void Transaction By Id
`http://localhost:5000/api/merchants/{merchantId}/transactions/{transactionId}`
Using a PATCH method, merchantId and transactionId is required. e.g.
```shell
http://localhost:5000/api/merchants/9876501/transactions/a18603ad-e3f3-48c2-bc1e-0ef929c593c5
```
Status should return OK and with the transaction object showing that voided is true.