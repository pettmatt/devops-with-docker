I was unable to come up with a command that could do the task with ONE command.

Start simple-web-service
```
docker run -d --name ex1_4 devopsdockeruh/simple-web-service:ubuntu
```
Enter to the container
```
docker exec -it ex1_4 bash
```
Install curl
```
apt-get update; apt-get install curl
```
Curl-command
```
sh -c 'echo "Input website:"; read website; echo "Searching.."; sleep 1; curl http://$website;'
```

FINAL OUTPUT:
```
root@14ae6e0ac33b:/usr/src/app# sh -c 'echo "Input website:"; read website; echo "Searching.."; sleep 1; curl http://$website;'
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
root@14ae6e0ac33b:/usr/src/app#
```