# Supabase .NET Minimal API

A simple .NET 9 Minimal API that connects to [Supabase](https://supabase.com/) (free tier), with Swagger and basic `GET` and `POST` support for sensor readings.

---

## Features

- Connects to Supabase via REST API using environment variables
- Two endpoints:
  - `GET /readings` – fetch all readings
  - `POST /readings` – add a new reading
- Swagger UI for testing

---

## Setup

1. Clone and navigate:

   ```bash
   git clone https://github.com/diehlpedro/supabase-dotnet.git
   cd supabase-dotnet
   ```

2. Add a `.env` file:

   ```env
   SUPABASE_URL=https://your-project.supabase.co
   SUPABASE_ANON_KEY=your-anon-key
   ```

3. Create the table on Supabase:

   ```sql
   create table readings (
       id serial primary key,
       sensorid text not null,
       value numeric not null,
       unit text not null
   );
   ```

4. Run the app:

   ```bash
   dotnet run
   ```

5. Visit Swagger:  
   `http://localhost:<port>/swagger`

---

## ⚠️ Notes

- This project is for **testing/demo purposes**.
- Avoid exposing your anon key publicly.
- Use [Row Level Security](https://supabase.com/docs/learn/auth-deep-dive/auth-row-level-security) in production.

---

MIT License