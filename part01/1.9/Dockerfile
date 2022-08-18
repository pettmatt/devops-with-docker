FROM ubuntu:20.04
#Install curl. Needed to add --yes flag in order to get pass a prompt
RUN apt-get update; apt-get install --yes curl
#Set working directory
WORKDIR /usr/src/app
#Copy file
COPY c.sh .
#Run copied file
CMD "./c.sh"