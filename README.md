# 🌍 Klima Kosovë - Vizualizimi i Ndryshimeve Klimatike

Aplikacion i plotë në ueb për vizualizimin grafik të të dhënave mbi ndryshimet klimatike për Kosovën dhe të gjitha qytetet e saj.

## 📋 Përmbajtja

- [Teknologjitë](#teknologjitë)
- [Veçoritë](#veçoritë)
- [Si të filloni](#si-të-filloni)
- [Struktura e Projektit](#struktura-e-projektit)
- [API Endpoints](#api-endpoints)
- [Screenshots](#screenshots)

## 🛠 Teknologjitë

### Backend
- **.NET 8 Web API** - API RESTful
- **C#** - Gjuha e programimit

### Frontend
- **Angular 19** - Framework i frontendidg
- **Chart.js** - Libraria për grafikët
- **SCSS** - Stilizimi

## ✨ Veçoritë

- 📊 **6 lloje grafikësh** të ndryshëm për vizualizimin e të dhënave
- 🏙️ **26 qytete** të Kosovës me të dhëna klimatike
- 📅 **Të dhëna historike** nga 2000 deri 2025
- 🎨 **Dizajn modern** me dark theme
- 📱 **Responsive** - Punon në të gjitha pajisjet
- 🌡️ **Statistika** të detajuara klimatike
- ⚠️ **Ngjarje ekstreme** të motit

## 🚀 Si të filloni

### Parakushtet

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) (versioni 18+)
- [Angular CLI](https://angular.io/cli) (`npm install -g @angular/cli`)

### Hapi 1: Startoni Backend-in

```powershell
cd ClimateAPI
dotnet run
```

Backend-i do të startojë në: `http://localhost:5223`

Swagger UI: `http://localhost:5223/swagger`

### Hapi 2: Startoni Frontend-in

Hapni një terminal të ri:

```powershell
cd climate-app
npm install
ng serve
```

Frontend-i do të startojë në: `http://localhost:4200`

## 📁 Struktura e Projektit

```
Testimi/
├── ClimateAPI/                 # .NET Web API
│   ├── Controllers/
│   │   └── ClimateController.cs
│   ├── Models/
│   │   ├── City.cs
│   │   └── ClimateData.cs
│   ├── Services/
│   │   └── ClimateDataService.cs
│   └── Program.cs
│
├── climate-app/               # Angular Frontend
│   └── src/
│       └── app/
│           ├── components/
│           │   └── dashboard/
│           ├── models/
│           └── services/
│
└── README.md
```

## 🔗 API Endpoints

| Metoda | Endpoint | Përshkrimi |
|--------|----------|------------|
| GET | `/api/climate/cities` | Lista e qyteteve |
| GET | `/api/climate/cities/{id}` | Detajet e një qyteti |
| GET | `/api/climate/data` | Të dhënat klimatike me filtra |
| GET | `/api/climate/yearly` | Të dhënat vjetore |
| GET | `/api/climate/temperature-trend/{cityId}` | Trendi i temperaturës |
| GET | `/api/climate/seasonal/{cityId}` | Të dhënat sezonale |
| GET | `/api/climate/comparison/{year}` | Krahasimi i qyteteve |
| GET | `/api/climate/extreme-events` | Ngjarjet ekstreme |
| GET | `/api/climate/statistics/{cityId}` | Statistikat klimatike |

## 📊 Grafikët

1. **Trendi i Temperaturës** - Line chart me trendin 25-vjeçar
2. **Reshjet Vjetore** - Bar chart me reshjet totale
3. **Të Dhënat Sezonale** - Polar area chart
4. **Niveli i CO₂** - Area chart me trendin
5. **Krahasimi i Qyteteve** - Radar chart
6. **Lagështia** - Doughnut chart

## 🏙️ Qytetet e Kosovës

Aplikacioni përfshin të dhëna për:
- Prishtinë (Kryeqyteti)
- Prizren
- Pejë
- Gjakovë
- Ferizaj
- Mitrovicë
- Gjilan
- Podujevë
- Vushtrri
- Suharekë
- Dhe 15 qytete të tjera...

## 📈 Të Dhënat

Të dhënat klimatike përfshijnë:
- 🌡️ Temperatura mesatare, maksimale dhe minimale
- 🌧️ Sasia e reshjeve
- 💨 Lagështia
- ☁️ Nivelet e CO₂
- ☀️ Ditët me diell dhe shi
- 🌬️ Shpejtësia e erës

---

**Zhvilluar për Kosovën 🇽🇰**

