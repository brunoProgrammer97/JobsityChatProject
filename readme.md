Notes:

1 - To avoid dependency settings on this project by using a physical relational database instead  of this i used Entity Framework in memory .

2 - This aplication store informations only during execution (in memory).
So once that application are running other chat users can see messagens already sent during execution bafore that user
be logged in or real time receive messagens from others users/bot but messages aren't stored after application stops

3 - I used  the follow command to run RabbitMq on a Dcoker container. It's necessaire navigate to docker folder placed in this repo
and run command on command pront or powershell - (running on docker installed for windows 10)

- docker comand to up and run RabbitMq:

docker compose up

4 - I Implemented a simple register and authentication using cookies

5 - I followed a multi-layered architecture to decouple and keep modules moore separate according to each
responsbility. I used inversion of control to implement Repositories in Infrastructure layer
and dependency injection. And used too a design that keep Core layer independent to others.