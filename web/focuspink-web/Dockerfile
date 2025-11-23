# Build stage
FROM node:22 AS build
WORKDIR /app

COPY package*.json ./
RUN npm ci

COPY . .

RUN npm run build -- --configuration production

# Runtime stage
FROM nginx:1.27 AS final
WORKDIR /usr/share/nginx/html

RUN rm -rf ./*

COPY --from=build /app/dist/focuspink-web/browser ./

COPY nginx/default.conf /etc/nginx/conf.d/default.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
