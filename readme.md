
Notes:

1 - To avoid dependency settings on this project by using a physical relational database instead  of this i used Entity Framework in memory .

2 - This aplication store informations only during execution (in memory).
So once that application are running other chat users can see messagens already sent during execution bafore that user
be logged in or real time receive messagens from others users but messages aren't stored after execution stops.

3 - I used  the follow command to run RabbitMq on a Dcoker container. It's necessaire navigate to docker folder placed in this repo
and run comand on command pront or powershell - (running on docker for windows 10)

- docker comand to up and run RabbitMq:

docker compose up