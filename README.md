  <h3 align="center">ReadingIs(so)Good</h3>

  <p align="center">
    Macro service based web api for book sales.
    <br />
    <a href="https://ercin-readingisgood.herokuapp.com/swagger/index.html"><strong>Live Demo »</strong> (REVERSE PROXY)</a>
    <br />
    <a href="https://ercin-readingisgood-log.herokuapp.com/swagger/index.html"><strong>Log Demo »</strong> (Logging Service)</a>
    <br />
    <a href="https://ercin-readingisgood-customer.herokuapp.com/swagger/index.html"><strong>Customer Demo »</strong> (Customer Service)</a>
    <br />
    <a href="https://ercin-readingisgood-order.herokuapp.com/swagger/index.html"><strong>Order Demo »</strong> (Order Service)</a>
    <br />
    <a href="https://ercin-readingisgood-auth.herokuapp.com/swagger/index.html"><strong>Authorization Demo »</strong> (Auth Service)</a>  
  </p>

### Built With

* [.NET Core 5](https://en.wikipedia.org/wiki/.NET_Core)
* [PostgreSQL](https://www.postgresql.org/)
* [Entity Framework Core](https://en.wikipedia.org/wiki/Entity_Framework)
* [Ocelot](https://github.com/ThreeMammals/Ocelot)
* [NUnit](https://nunit.org/)
* [Docker](https://www.docker.com/)
* [Heroku](https://www.heroku.com/)
* [Swagger](https://swagger.io/)
* [ElephantSQL](https://www.elephantsql.com/)

## Architectural Concept

![](https://github.com/ErcinDedeoglu/ReadingIsGood/raw/main/assets/Network%20Tapology.png)

Incoming restful requests are directly met by the Gateway (Reverse Proxy) and directed to the running container. The application is designed as a 3 layer architecture. Repository Design Pattern was preferred for database communication in the project. The Unit Of Work design pattern is preferred for processing incoming web service requests and minimizing code repetition. Entity Framework Core and Code First are used on the ORM side. PostgreSQL is preferred for database. The project has been implemented as stateless in microservice architecture. In this way, it can be run on Docker.

**ReadingIsGood.Gateway.API:** Reverse proxy. Responsible for receiving incoming requests and initial verification.

**ReadingIsGood.Authorization.API:** Identification service. Allows users to login.

**ReadingIsGood.Customer.API**: Service responsible for customer-related work.

**ReadingIsGood.Log.API:** It serves changes made to the database. It is used for audit log.

**ReadingIsGood.Order.API:** Used to manage orders.

## Getting Started

First of all, the application is deployed using Heroku and ElephantSQL. Access to the Swagger OpenAPI is enabled at https://ercin-readingisgood.herokuapp.com/swagger/index.html.

NET Core 5 SDK is required to compile the application. If you want to migrate to a different database than I use, you can get a free PostgreSQL database from ElephantSQL or use your own instance.

# Here we go

When you reach https://ercin-readingisgood.herokuapp.com/swagger/index.html, you will see Reverse Proxy's OpenAPI page.

![](https://github.com/ErcinDedeoglu/ReadingIsGood/raw/main/assets/OpenAPI%20Service%20Selection.png)

We continue by choosing Authorization API - v1 service.

We expand the "/api/authorization/Users/authenticate" method from the opened service swagger.

![](https://github.com/ErcinDedeoglu/ReadingIsGood/raw/main/assets/OpenAPI%20Auth-1.png)

**Username: test**
**Password: test**
We fill it as and press the "Execute" button.

![](https://github.com/ErcinDedeoglu/ReadingIsGood/raw/main/assets/OpenAPI%20Auth-2.png)

There is Bearer token in the returned json request. We take it to the **clipboard** (copy it).

![](https://github.com/ErcinDedeoglu/ReadingIsGood/raw/main/assets/OpenAPI%20Auth-3.png)

There is an "Authorize" button on each page in Swagger. We scroll up and find the button and click it.

![](https://github.com/ErcinDedeoglu/ReadingIsGood/raw/main/assets/OpenAPI%20Auth-4.png)

We paste the token we copied into the Bearer token field and press the "Authorize" button.

Now we can consume all api's without any other settings.

Happy coding.
