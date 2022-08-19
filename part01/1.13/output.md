Dockerfile
```
FROM golang:1.16

WORKDIR /usr/src/app
COPY . .
RUN go build

CMD ["./server"]
```

Terminal (Build):
```
❯❯ pm :: example-backend git(main) ✗ 16.22  docker build . -t backend-project
[+] Building 41.3s (10/10) FINISHED
 => [internal] load build definition from Dockerfile                                                 0.0s
 => => transferring dockerfile: 121B                                                                 0.0s
  ...

Use 'docker scan' to run Snyk tests against images to find vulnerabilities and learn how to fix them
```
Terminal (Running):
```
❯❯ pm :: example-backend git(main) ✗ 16.23  docker run -p 5001:8080 backend-project
[Ex 2.4+] REDIS_HOST env was not passed so redis connection is not initialized
[Ex 2.6+] POSTGRES_HOST env was not passed so postgres connection is not initialized
[GIN-debug] [WARNING] Creating an Engine instance with the Logger and Recovery middleware already attached.

[GIN-debug] [WARNING] Running in "debug" mode. Switch to "release" mode in production.
 - using env:   export GIN_MODE=release
 - using code:  gin.SetMode(gin.ReleaseMode)

[GIN-debug] GET    /ping                     --> server/router.pingpong (4 handlers)
[GIN-debug] GET    /messages                 --> server/controller.GetMessages (4 handlers)
[GIN-debug] POST   /messages                 --> server/controller.CreateMessage (4 handlers)
[GIN-debug] Listening and serving HTTP on :8080
[GIN] 2022/08/19 - 13:24:59 | 404 |       102.4µs |      172.17.0.1 | GET      "/"
[GIN] 2022/08/19 - 13:24:59 | 404 |         7.6µs |      172.17.0.1 | GET      "/favicon.ico"
[GIN] 2022/08/19 - 13:25:06 | 200 |         7.5µs |      172.17.0.1 | GET      "/ping"
