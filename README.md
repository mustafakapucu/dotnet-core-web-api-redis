# dotnet-core-web-api-redis_on_docker

# Redis on Docker
docker run --rm -p 1453:6379 --name rediscontainer -d redis
docker exec -it 2e92(container uniq id) redis-cli
config get databases

# Dotnet Core Project
dotnet new webapi --name simple_redis_api_on_docker
dotnet add package StackExchange.Redis ( for Redis connection)
dotnet add package Faker.Net (to create fake datas)
dotnet add package Newtonsoft.Json (to convert to object)
dotnet watch run


