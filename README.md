# Movie API

 RESTful API pro správu filmů, rezervací, recenzí, promítání, sálů, sedadel a uživatelů. API je vytvořeno v .NET a poskytuje různé endpointy pro manipulaci s daty.

## Endpointy

### Movie

- **GET** `/api/Movie` - Získá seznam všech filmů.
- **POST** `/api/Movie` - Vytvoří nový film.
- **GET** `/api/Movie/{id}` - Získá detail filmu podle ID.
- **PUT** `/api/Movie/{id}` - Aktualizuje film podle ID.
- **DELETE** `/api/Movie/{id}` - Smaže film podle ID.
- **GET** `/api/Movie/Search/{title}` - Vyhledá film podle názvu.
- **GET** `/api/Movie/Filter` - Filtruje filmy podle různých kritérií.
- **GET** `/api/Movie/Upcoming` - Získá seznam nadcházejících filmů.
- **GET** `/api/Movie/NowShowing` - Získá seznam filmů, které jsou právě v kině.

### Reservation

- **GET** `/api/Reservation` - Získá seznam všech rezervací.
- **POST` `/api/Reservation` - Vytvoří novou rezervaci.
- **GET** `/api/Reservation/{id}` - Získá detail rezervace podle ID.
- **DELETE** `/api/Reservation/{id}` - Smaže rezervaci podle ID.
- **PUT** `/api/Reservation/{id}` - Aktualizuje rezervaci podle ID.
- **GET** `/api/Reservation/Search/{search}` - Vyhledá rezervace podle zadaného kritéria.
- **GET** `/api/Reservation/ScreeningRoom/{screeningRoomId}` - Získá rezervace pro daný sál.

### Review

- **GET** `/api/Review` - Získá seznam všech recenzí.
- **POST` `/api/Review` - Vytvoří novou recenzi.
- **GET** `/api/Review/{id}` - Získá detail recenze podle ID.
- **PUT** `/api/Review/{id}` - Aktualizuje recenzi podle ID.
- **GET** `/api/Review/Movie/{movieId}` - Získá recenze pro daný film.
- **GET** `/api/Review/Rating/{rating}` - Získá recenze podle hodnocení.
- **GET** `/api/Review/User/{userId}` - Získá recenze od daného uživatele.

### Screening

- **GET** `/api/Screening` - Získá seznam všech promítání.
- **POST` `/api/Screening` - Vytvoří nové promítání.
- **GET** `/api/Screening/Available` - Získá seznam dostupných promítání.
- **GET** `/api/Screening/Upcoming` - Získá seznam nadcházejících promítání.
- **GET** `/api/Screening/Today` - Získá seznam promítání pro dnešní den.
- **GET** `/api/Screening/Movie/{movieId}` - Získá promítání pro daný film.
- **GET** `/api/Screening/{id}/Seats` - Získá sedadla pro dané promítání.
- **GET** `/api/Screening/{id}/Reservations` - Získá rezervace pro dané promítání.
- **GET** `/api/Screening/search` - Vyhledá promítání podle zadaného kritéria.
- **GET** `/api/Screening/{id}` - Získá detail promítání podle ID.
- **PUT** `/api/Screening/{id}` - Aktualizuje promítání podle ID.
- **DELETE** `/api/Screening/{id}` - Smaže promítání podle ID.

### ScreeningRoom

- **GET** `/api/ScreeningRoom` - Získá seznam všech sálů.
- **POST` `/api/ScreeningRoom` - Vytvoří nový sál.
- **GET** `/api/ScreeningRoom/{id}` - Získá detail sálu podle ID.
- **DELETE** `/api/ScreeningRoom/{id}` - Smaže sál podle ID.
- **PUT** `/api/ScreeningRoom/{id}` - Aktualizuje sál podle ID.
- **GET** `/api/ScreeningRoom/GetScreeningRoomsByCapacity` - Získá sály podle kapacity.
- **GET** `/api/ScreeningRoom/SearchScreeningRooms` - Vyhledá sály podle zadaného kritéria.

### Seat

- **GET** `/api/Seat` - Získá seznam všech sedadel.
- **POST` `/api/Seat` - Vytvoří nové sedadlo.
- **GET** `/api/Seat/{id}` - Získá detail sedadla podle ID.
- **PUT** `/api/Seat/{id}` - Aktualizuje sedadlo podle ID.
- **DELETE** `/api/Seat/{id}` - Smaže sedadlo podle ID.
- **GET** `/api/Seat/available/{screeningId}` - Získá dostupná sedadla pro dané promítání.
- **PUT** `/api/Seat/availability/{id}` - Aktualizuje dostupnost sedadla.

### User

- **POST** `/api/User/register` - Registruje nového uživatele.
- **POST** `/api/User/login` - Přihlásí uživatele.

---

## Data Transfer Objects (DTOs)

API používá DTOs pro přenos dat mezi klientem a serverem. Zde jsou příklady DTOs pro některé entity:

### Movie DTO
```json
{
    "id": "6abe99c4-de53-11ef-a389-4a981ec9989b",
    "title": "Název filmu",
    "description": "Popis filmu",
    "releaseDate": "2025-01-29T00:00:00",
    "genre": "Žánr",
    "durationMinutes": 90,
    "posterUrl": "url_k_obrazku.jpg"
}
```

### POST/PUT Movie DTO
```json
{
  "title": "string",
  "description": "string",
  "releaseDate": "2025-01-29T17:54:09.529Z",
  "genre": "string",
  "durationMinutes": 500,
  "posterUrl": "string"
}
```

### Příklady odpovědí API
GET /api/Screening/Today
```json
{
    "id": "a54717d6-6841-49a2-a7a8-463665cac233",
    "startTime": "2025-01-29T15:53:02.169082",
    "movieTitle": "The Godfather",
    "screeningRoomName": "Sál 2"
}
```
GET /api/Seat/available/{screeningId}
```json

{
    "id": "15133da9-aabb-449a-9f8e-44d38f171e94",
    "row": 1,
    "number": 6,
    "isAvailable": true,
    "screenName": "The Shawshank Redemption"
}
```

### Instalace
Naklonujte si tento repozitář:
```code
git clone https://github.com/vas-username/vas-projekt.git
```
Přejděte do MovieR.API
```code
cd MovieR.API/
```
Spusťte projekt:
```code
dotnet run
```
