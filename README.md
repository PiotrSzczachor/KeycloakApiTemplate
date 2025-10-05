# KeycloakApiTemplate

## Migracje

### Dodanie migracji
```dotnet ef migrations add OptionalNavigationEntites -p Data/Data.csproj -s KeycloakApiTemplate/KeycloakApiTemplate.csproj --output-dir Migrations```

### Aktualizacja bazy
```dotnet ef database update -p Data/Data.csproj -s KeycloakApiTemplate/KeycloakApiTemplate.csproj```






---
---
---

# 🏙️ Krakowskie Cyfrowe Centrum Wolontariatu (Krakow Digital Volunteer Center)

## 📚 Spis treści

1. Opis projektu
2. Architektura systemu
3. Backend (.NET)
4. Frontend (Angular)
5. Baza danych / model danych
6. API (OpenAPI / Swagger)
7. Uruchomienie lokalne
8. Bezpieczeństwo i prywatność
10. Testowanie
12. Contributing / Onboarding


# 1. Opis projektu

## 🎯 Cel projektu

Celem projektu jest stworzenie nowoczesnej, przyjaznej użytkownikowi platformy, która łączy młodych wolontariuszy, szkolnych koordynatorów oraz organizacje i instytucje działające na terenie Krakowa.  
System ma ułatwić rekrutację, komunikację oraz zarządzanie inicjatywami społecznymi, zapewniając łatwy dostęp do wolontariatu dla młodzieży i wspierając współpracę z organizacjami pozarządowymi.

---

## 💡 Dlaczego to ważne

- **Wolontariat rozwija młodzież**, buduje lokalną społeczność i wspiera aktywne uczestnictwo w życiu miasta.  
- **Obecnie wiele inicjatyw nie dociera do potencjalnych wolontariuszy**, a organizacje mają trudności z rekrutacją i komunikacją.  
- **Brakuje jednego, spójnego miejsca online**, które łączyłoby potrzeby organizacji z energią młodych ludzi.  

Aplikacja eliminuje te problemy, oferując **centralną platformę wolontariatu miejskiego**.

---

# 🌟 Platforma Wolontariatu „Młody Kraków”

Nowoczesna aplikacja wspierająca wolontariat młodzieżowy w Krakowie.  
Łączy uczniów, szkoły oraz organizacje społeczne, ułatwiając współpracę, komunikację i rozwój inicjatyw społecznych.

---

## 👥 Grupy użytkowników

**Wolontariusz** - Uczeń lub młoda osoba mieszkająca w Krakowie. Może przeglądać oferty, zapisywać się na wydarzenia i kontaktować z organizacjami. 

**Organizacja / Instytucja** - NGO, szkoła, uczelnia lub jednostka miejska. Może publikować oferty, zarządzać zgłoszeniami i generować zaświadczenia. 

**Szkolny koordynator wolontariatu** - Nauczyciel lub opiekun odpowiedzialny za koordynację działań wolontariackich w danej szkole oraz kontakt z organizacjami. Może zgłaszać uczniów do wydarzeń zakładanych przez organizacje.

**Admin** - Koordynator całego sytemiu, zarządza rolami, akceptuje prośby o założenie konta i nadzoruje przebieg spotkań.

---

## 🧭 Kluczowe założenia

- **Brak rywalizacji** – aplikacja promuje współpracę i wspólne działanie, nie konkurencję.  
- **Intagracja** - celem jest stworzenie wspólnoty młodzieży dbającej o miastop Kraków.
- **Zgodność z RODO** – pełna dbałość o bezpieczeństwo i prywatność danych użytkowników.  
- **Prostota** - interfejs użytkownika jest jak najprostszy umożliwiając płynne i przyjazne korzystanie z aplikacji.
- **Mobilność i responsywność** – aplikacja działa na smartfonach, tabletach i komputerach.  

---

## ⚙️ Główne funkcjonalności

### 👤 Dla wolontariuszy
- Przeglądanie i wyszukiwanie ofert według tematyki, lokalizacji i wymagań.  
- Tworzenie konta (z rozróżnieniem na osoby pełnoletnie i niepełnoletnie).  
- Zgłaszanie się do projektów jednym kliknięciem.  
- Wbudowany chat.  
- Terminarz wydarzeń z przypomnieniami.  
- Generowanie zaświadczeń o wolontariacie po zatwierdzeniu przez organizację.  

---

### 🏢 Dla organizacji
- Publikacja ofert wolontariatu i zarządzanie zgłoszeniami.  
- Komunikacja z uczestnikami (chat, powiadomienia).  
- Przypisywanie wolontariuszy do zadań i projektów.  
- Raportowanie godzin pracy i statystyk.  
- Generowanie i zatwierdzanie zaświadczeń.  
- Wystawianie opinii i rekomendacji wolontariuszom.  

---

### 🏫 Dla szkolnych koordynatorów
- Zarządzanie kontem szkoły i uczniami.  
- Kontakt z organizacjami.  
- Kalendarz wydarzeń i system powiadomień.  
- Zatwierdzanie i generowanie zaświadczeń dla uczniów.  
- Raporty z aktywności uczniów i statystyki.  

---

## 🌍 Funkcjonalności wspólne

- 🗺️ **Interaktywna mapa inicjatyw wolontariackich w Krakowie.**  
- 🔐 **Bezpieczne logowanie** z wykorzystaniem **Keycloak** i obsługa autoryzacji **JWT**.  
- 💻 **Responsywny, nowoczesny interfejs** zgodny z identyfikacją wizualną programu **„Młody Kraków”**.  

---

## 🚀 Efekt końcowy

Stworzenie **prototypu nowoczesnej platformy wolontariatu**, która:

- Łączy **młodzież, szkoły i organizacje** w jednym miejscu.  
- Ułatwia **komunikację i zarządzanie inicjatywami społecznymi**.  
- Zachęca do aktywności społecznej poprzez **intuicyjny design, prostotę obsługi i interaktywne rozwiązania**.  


---
## 2. 🏗️ Architektura systemu

System został zaprojektowany w oparciu o zasadę **Clean Architecture** i **SOLID**, co zapewnia przejrzystość, łatwość utrzymania oraz możliwość dalszego rozwoju aplikacji.  
Warstwy zostały jasno rozdzielone na:

- **Application** – logika biznesowa, obsługa przypadków użycia oraz integracja z infrastrukturą.  
- **Domain / Models** – definicje encji i obiektów domenowych, niezależnych od technologii.  
- **Infrastructure / Data** – implementacje dostępu do danych, ApplicationDbContext, konfiguracje bazy danych i integracje z zewnętrznymi systemami.  

Aplikacja jest typu **SPA (Single Page Application)** – całość interfejsu użytkownika jest ładowana po stronie przeglądarki, a komunikacja z backendem odbywa się poprzez API REST z użyciem tokenów **JWT** generowanych przez **Keycloak**.

---

## 3. ⚙️ Backend (.NET 8.0)

Warstwa backendowa została opracowana w technologii **.NET 8.0** z wykorzystaniem architektury **Clean SOLID**, co pozwala na wysoką separację logiki biznesowej od warstwy danych i interfejsu API.

### 🔐 Autoryzacja i bezpieczeństwo
Szczególny nacisk położono na bezpieczeństwo i zarządzanie tożsamością użytkowników.  
Do **logowania, rejestracji oraz autoryzacji** zastosowano **Keycloak**, który:

- generuje i weryfikuje **tokeny JWT**,  
- umożliwia integrację z różnymi rolami użytkowników (Wolontariusz, Organizacja, Koordynator szkolny),  
- zapewnia pełną zgodność z wymogami **RODO**.

Dzięki Keycloak backend może w sposób bezpieczny zarządzać autoryzacją i kontrolą dostępu w oparciu o role i uprawnienia użytkowników.

### 🧩 Struktura backendu


Projekt backendu został zaprojektowany w architekturze warstwowej, opartej na zasadach **czystego podziału odpowiedzialności (Separation of Concerns)**.  
Każda warstwa ma jasno określoną rolę i odpowiada za inny etap przetwarzania danych.

#### **Api**
Warstwa odpowiedzialna za komunikację z frontendem.  
Zawiera **kontrolery**, które udostępniają **REST API** do obsługi operacji CRUD oraz innych żądań biznesowych.  
Tutaj odbywa się mapowanie żądań HTTP na odpowiednie metody serwisowe z warstwy `Application`.

**Przykład:**  
- `UsersController`  
- `AddressesController` 
- `EventController`


#### **Application**
Zawiera **logikę biznesową** aplikacji.  
To tutaj umieszczone są **serwisy (services)**, które przetwarzają dane, wykonują operacje biznesowe i komunikują się z warstwą `Data`.  
Warstwa `Application` nie ma bezpośredniego dostępu do bazy danych — korzysta wyłącznie z repozytoriów.

**Przykład:**  
- `AddressesService`  
- `EventService`
---
### **Data**
Odpowiada za **dostęp do danych** i komunikację z bazą PostgreSQL.  
Zawiera ApplicationDbContext, które implementują operacje na obsługuje zestawy danych oraz migracje.  

### **Models**
Zawiera definicje **encji (models / entities)** odwzorowujących tabele w bazie danych PostgreSQL.  
Każdy model odpowiada konkretnej tabeli i zawiera właściwości opisujące jej kolumny oraz relacje między encjami.  
Modele są używane przez Entity Framework Core do generowania i utrzymania schematu bazy danych.

**Przykład:**  
- `User`  
- `School`  
- `Organization`  
- `Event`  
- `Address`





## 4. 💻 Frontend (Angular 20)

Warstwa frontendowa została stworzona w technologii **Angular 20**, co zapewnia nowoczesny, wydajny i responsywny interfejs użytkownika.  
Aplikacja działa jako **SPA**, komunikując się z backendem wyłącznie poprzez REST API.

### 🔧 Kluczowe elementy frontendu

- Zastosowanie **Angular Signals** do zarządzania stanem aplikacji w sposób reaktywny i wydajny.  
- Integracja z **Keycloak** – pełna obsługa logowania, wylogowania i odświeżania tokenów JWT.  
- Zastosowanie standalone komponentow umożliwiających pominięcie obsługi modułów
- Responsywność i zgodność z identyfikacją wizualną programu.  


---

## 5. 🗄️ Baza danych / Model danych

System korzysta z relacyjnej bazy danych **PostgreSQL**, w której zastosowano odpowiednie relacje pomiędzy encjami.  
Model danych został zaprojektowany tak, aby odzwierciedlał rzeczywiste powiązania pomiędzy użytkownikami, szkołami, organizacjami i wydarzeniami.

## 6. API (OpenAPI / Swagger)

Aplikacja backendowa została wyposażona w pełną dokumentację API w standardzie **OpenAPI 3.0**, generowaną automatycznie przy użyciu **Swagger UI**.

Dzięki temu możliwe jest:
- łatwe **testowanie endpointów** bezpośrednio z poziomu przeglądarki,
- szybkie **poznanie struktury dostępnych zasobów**,
- automatyczne **generowanie klienta API** (np. dla Angulara, Reacta lub Postmana),
- pełna **spójność dokumentacji z kodem źródłowym**.
## 7. Uruchomienie lokalne

Projekt można uruchomić lokalnie w środowisku developerskim przy użyciu **.NET 8.0** (backend) oraz **Angular 20** (frontend).  
System został zaprojektowany tak, aby umożliwiać łatwe dostosowanie konfiguracji – zwłaszcza w zakresie autoryzacji przez **Keycloak** i generowania kont testowych.

---

### ⚙️ Wymagania wstępne
Aby uruchomić projekt lokalnie, wymagane są:
- **.NET SDK 8.0**
- **Node.js 20+**
- **Angular CLI 20**
- **PostgreSQL** (lokalna baza danych)
- **Keycloak** (serwer autoryzacji)

---

### 🧩 Konfiguracja Keycloak
Aplikacja wykorzystuje **Keycloak** jako centralny serwer uwierzytelniania i autoryzacji. Za pomocą plików konfiguracyjnych mamy możliwość skonfigurowania działania systemu autorayzacji dla użytkowników.

## 8. Bezpieczeństwo i prywatność

System Krakowskiego Cyfrowego Centrum Wolontariatu został zaprojektowany z myślą o **maksymalnym bezpieczeństwie danych użytkowników** oraz pełnej **zgodności z RODO**.  
Priorytetem projektu jest ochrona informacji osobistych młodzieży, szkół i organizacji.

---

### 🔐 Autoryzacja i zarządzanie tożsamością – **Keycloak**

Aplikacja wykorzystuje **Keycloak** jako centralny komponent uwierzytelniania i autoryzacji (IAM – *Identity and Access Management*).

#### Główne funkcje integracji:
- **OpenID Connect / OAuth2.0** – nowoczesne i bezpieczne protokoły autoryzacji.  
- **Tokeny JWT (JSON Web Token)** – wszystkie żądania do API są weryfikowane przy użyciu podpisanych tokenów JWT.  
- **Role i grupy** – dostęp do zasobów systemu jest kontrolowany na podstawie roli użytkownika:  
  - `Volunteer` – wolontariusz  
  - `Organization` – przedstawiciel organizacji  
  - `Coordinator` – szkolny koordynator wolontariatu  
  - `Admin` – administrator systemu  
- **Single Sign-On (SSO)** – jedno logowanie daje dostęp do całej platformy (frontend + backend).  
- **Bezpieczne wylogowanie** – zakończenie sesji w Keycloak automatycznie unieważnia tokeny JWT.  
- **Obsługa polityk haseł** – wymuszenie silnych haseł, rotacji i wymiany tymczasowych haseł przy pierwszym logowaniu.

#### 🔄 Odświeżanie tokenów
Frontend (Angular 20) automatycznie odświeża token JWT przed jego wygaśnięciem, co zapewnia bezpieczeństwo sesji bez konieczności ponownego logowania użytkownika.

#### 🔏 Przechowywanie tokenów
Tokeny JWT są przechowywane wyłącznie w **pamięci sesji przeglądarki (sessionStorage)**, dzięki czemu nie są dostępne dla innych aplikacji ani skryptów.





