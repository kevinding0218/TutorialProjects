# Client App
# FROM johnpapa/angular-cli as client-app
FROM node:10.13-alpine as client-app
LABEL authors="John Papa"
WORKDIR /usr/src/app
COPY ["package.json", "npm-shrinkwrap.json*", "./"]
RUN npm install --silent
COPY . .
RUN npx ng build --prod

# Node server
FROM node:10.13-alpine as node-server
WORKDIR /usr/src/app
COPY ["package.json", "npm-shrinkwrap.json*", "./"]
RUN npm install --production --silent && mv node_modules ../
COPY server.js .
COPY /server /usr/src/app/server

# Final image
FROM node:10.13-alpine
WORKDIR /usr/src/app
COPY --from=node-server /usr/src /usr/src
COPY --from=client-app /usr/src/app/dist ./
EXPOSE 8626
# CMD ["node", "server.js"]
CMD ["npm", "start"]
