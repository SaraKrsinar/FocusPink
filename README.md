# 🎀 FocusPink

A minimalist full-stack **to-do web app** built with **Angular**, **.NET 8**, and **PostgreSQL**

---

## Tech Stack

frontend: Angular 17,
backend: ASP.NET 8,
database: PostgreSQL,
containerization: Docker

---


## Setup Instructions

### 1) Clone the repository
```bash
git clone https://github.com/SaraKrsinar/FocusPink.git
cd FocusPink
```

### 2) Configure environment variables
Copy the example file:
```bash
cp .env.example .env
```

Then edit `.env` (locally) to match your preferred credentials:
```bash
POSTGRES_USER=focuspink
POSTGRES_PASSWORD=example123
POSTGRES_DB=focuspinkdb
```
> These values are only used locally when running the project with Docker. 
> You can choose any username, password, and database name you prefer.

> **Note:** `.env` is **not** committed, only `.env.example` is included for demonstration purposes.

---

### 3) Run with docker compose
### First build:
```bash
docker compose up --build
```
### Next time:
```bash
docker compose up
```

This command will start the database, API, and web app containers together.

### If you want to stop all containers:
```bash
docker compose down
```
---

## About environment configuration

The `.env.example` file is provided for **learning purposes only**:

```bash
# Example environment file
# Not for production use
# This file is only for learning purposes, used to demonstrate Docker and environment configuration.
# Replace values locally before running `docker compose up`

POSTGRES_USER=focuspink
POSTGRES_PASSWORD=example123
POSTGRES_DB=focuspinkdb

API_CONNECTION=Host=db;Port=5432;Database=focuspinkdb;Username=focuspink;Password=example123
API_PORT=8080
DB_PORT=5432
```

> Each developer creates their own local `.env` based on this example.


---

## Development notes

- The API uses **Entity Framework Core (EF Core)** with automatic migrations. 
- The frontend communicates with the backend via a **proxy (`proxy.conf.json`)** pointing to `localhost:8080`. 

---

## Future Improvements

- Edit task titles
- Task filtering / sorting
- Dark mode theme
- Switch to SQLite for lightweight local builds
- Add user authentication (JWT)

---
