Frontend commands:
```
docker build . -t frontend-project
docker run --rm -p 5000:5000 frontend-project
```

Backend commands:
```
docker build . -t backend-project
docker run --rm -p 5001:5001 backend-project
```