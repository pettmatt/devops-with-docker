```
❯❯ pm :: 1.5 :: 18.05  docker images
REPOSITORY                          TAG       IMAGE ID       CREATED         SIZE
ubuntu                              latest    df5de72bdb3b   13 days ago     77.8MB
fav_distro                          bionic    8d5df41c547b   13 days ago     63.1MB
ubuntu                              18.04     8d5df41c547b   13 days ago     63.1MB
devopsdockeruh/simple-web-service   ubuntu    4e3362e907d5   17 months ago   83MB
devopsdockeruh/simple-web-service   alpine    fd312adc88e0   17 months ago   15.7MB
quay.io/nordstrom/hello-world       2.0       c52585b8d1c9   5 years ago     208MB
```

Ubuntu: 83MB,
Alpine: 15.7MB

```
❯❯ pm :: 1.5 :: 18.06  docker run -it alpine
/ #