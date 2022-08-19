After modifying mvnw-file to use LF line ending format the dockerfile runs as intended.

Dockerfile:
```
FROM openjdk:8

EXPOSE 8080
WORKDIR /usr/src/app
COPY . .
RUN ./mvnw package

CMD ["java", "-jar", "./target/docker-example-1.1.3.jar"]
```
Terminal (Build):
```
docker build . -t spring-project
```
Terminal (Running):
```
docker run -p 3005:8080 spring-project