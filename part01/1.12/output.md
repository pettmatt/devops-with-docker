Dockerfile:
```
FROM node:16

EXPOSE 5000
WORKDIR /usr/src/app

COPY . .
RUN npm i

RUN npm run build 
RUN npm i -g serve

CMD ["serve", "-s", "-l", "5000", "build"]
```

Console:
```
❯❯ pm :: example-frontend git(main) ✗ 16.07  docker build . -t frontend-project
[+] Building 71.4s (12/12) FINISHED
 => [internal] load build definition from Dockerfile                                                 0.0s
 => => transferring dockerfile: 199B                                                                 0.0s
 => [internal] load .dockerignore                                                                    0.0s
 => => transferring context: 34B                                                                     0.0s
 => [internal] load metadata for docker.io/library/node:16                                           1.3s
 => [auth] library/node:pull token for registry-1.docker.io                                          0.0s
 => [1/6] FROM docker.io/library/node:16@sha256:bf1609ac718dda03940e2be4deae1704fb77cd6de2bed8bf91d  0.0s
 => [internal] load build context                                                                    0.0s
 => => transferring context: 1.42kB                                                                  0.0s
 => CACHED [2/6] WORKDIR /usr/src/app                                                                0.0s
 => [3/6] COPY . .                                                                                   0.1s
 => [4/6] RUN npm i                                                                                 44.7s
 => [5/6] RUN npm run build                                                                         15.0s
 => [6/6] RUN npm i -g serve                                                                         3.6s
 => exporting to image                                                                               6.7s
 => => exporting layers                                                                              6.6s
 => => writing image sha256:d9f3537137b62e19b5df626f98e531ee65ccf28c2d4aacf4d6c9d4d0127f1576         0.0s
 => => naming to docker.io/library/frontend-project                                                  0.0s

Use 'docker scan' to run Snyk tests against images to find vulnerabilities and learn how to fix them
❯❯ pm :: example-frontend git(main) ✗ 16.08  docker run -p 5000:5000 frontend-project
INFO: Accepting connections at http://localhost:5000.