Heroku link: https://mighty-savannah-30334.herokuapp.com/

```
docker pull devopsdockeruh/coursepage

heroku login
heroku container:login

heroku apps:create --region eu
   Creating app... done, ⬢ mighty-savannah-30334, region is eu
   https://mighty-savannah-30334.herokuapp.com/ | https://git.heroku.com/mighty-savannah-30334.git

docker tag devopsdockeruh/coursepage registry.heroku.com/mighty-savannah-30334/web
docker push registry.heroku.com/mighty-savannah-30334/web

heroku container:release web --app mighty-savannah-30334