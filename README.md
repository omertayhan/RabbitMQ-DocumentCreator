For more information [RabbitMQ](https://www.cloudamqp.com/blog/part4-rabbitmq-for-beginners-exchanges-routing-keys-bindings.html)

## RabbitMQ Docker Setup

Download [Docker Desktop](https://www.docker.com/products/docker-desktop/).

Download and run RabbitMQ on Developer PowerShell:

```powershell
docker run --hostname=rmq -p 8080:15672 -p 5672:5672 -d rabbitmq:3-management
