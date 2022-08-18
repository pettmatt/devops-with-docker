❯❯ pm :: 1.8 :: 18.34  docker build . --tag curler
[+] Building 12.3s (9/9) FINISHED
 => [internal] load build definition from Dockerfile                                                                                0.0s
 => => transferring dockerfile: 276B                                                                                                0.0s
 => [internal] load .dockerignore                                                                                                   0.0s
 => => transferring context: 2B                                                                                                     0.0s
 => [internal] load metadata for docker.io/library/ubuntu:20.04                                                                     0.6s
 => [internal] load build context                                                                                                   0.0s
 => => transferring context: 25B                                                                                                    0.0s
 => CACHED [1/4] FROM docker.io/library/ubuntu:20.04@sha256:af5efa9c28de78b754777af9b4d850112cad01899a5d37d2617bb94dc63a49aa        0.0s
 => [2/4] RUN apt-get update; apt-get install --yes curl                                                                           11.1s
 => [3/4] WORKDIR /usr/src/app                                                                                                      0.1s
 => [4/4] COPY c.sh .                                                                                                               0.1s
 => exporting to image                                                                                                              0.3s
 => => exporting layers                                                                                                             0.3s
 => => writing image sha256:48c12526f6f271e316bd0887183bd67183cccdb65f534e591453d13067e83ac3                                        0.0s
 => => naming to docker.io/library/curler                                                                                           0.0s

Use 'docker scan' to run Snyk tests against images to find vulnerabilities and learn how to fix them
❯❯ pm :: 1.8 :: 18.35  docker run -it curler
Input website:
helsinki.fi
Searching..
<!DOCTYPE HTML PUBLIC "-//IETF//DTD HTML 2.0//EN">
<html><head>
<title>301 Moved Permanently</title>
</head><body>
<h1>Moved Permanently</h1>
<p>The document has moved <a href="https://www.helsinki.fi/">here</a>.</p>
</body></html>
❯❯ pm :: 1.8 :: 18.35