FROM node:16-alpine3.14

RUN mkdir -p /srv/app/website
WORKDIR /srv/app/website

COPY package.json /srv/app/website
COPY package-lock.json /srv/app/website

RUN npm i

COPY . /srv/app/website

CMD ["npm", "start"]