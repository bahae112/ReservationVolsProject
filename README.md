# ✈️ ReservationVolsProject

Bienvenue dans **ReservationVolsProject** – une plateforme intuitive et sécurisée pour la réservation de vols en ligne. 🛫🌍  

## 📌 Description  

**ReservationVolsProject** est une application web développée avec **ASP.NET Core MVC** qui permet aux utilisateurs de **chercher, réserver et gérer** leurs billets d’avion facilement.  
L’application intègre un **système d’authentification et de gestion des rôles** pour différencier les **Clients et Administrateurs (Gestionnaires)** afin d'assurer une gestion optimale des réservations.  

---

## 🚀 Fonctionnalités  

### 👤 **Client**  
✅ Recherche et réservation de vols avec filtres avancés (dates, prix, compagnies aériennes, escales…)  
✅ Paiement sécurisé via Stripe ou PayPal 💳   ( non encore implemente )
✅ Accès à l’historique des réservations 📜  
✅ Annulation ou modification de réservation 🔄  
✅ Réception de notifications et emails 📩  

### 🔑 **Administrateur (Gestionnaire)**  
✅ Gestion des vols (ajout, modification et suppression) ✈️  
✅ Gestion des réservations ( implemente ) et validation des paiements ✅   ( non encore implemente )
✅ Accès aux statistiques des vols et des réservations 📊  
✅ Gestion des utilisateurs (ajout/suppression de clients) 👥  
✅ Surveillance et sécurité de l’application 🔐  

---

## 🛠️ Technologies utilisées  

### 🎯 **Backend**  
- **ASP.NET Core MVC** (.NET 7 ou 8) 🚀  
- **Entity Framework Core** pour l’accès aux données  
- **ASP.NET Identity** pour la gestion des utilisateurs et des rôles  

### 🌐 **Frontend**  
- **Bootstrap 5** pour un design moderne et responsive 🎨  
- **Razor Pages** et **Tag Helpers** pour les vues  

### 🗄️ **Base de données**  
- **SQL Server** avec **Entity Framework Core**  

### 🔑 **Sécurité & Authentification**  
- **ASP.NET Core Identity**  
- **Gestion des rôles (Client / Administrateur)**  
- **Protection CSRF & XSS**  

### 💳 **Paiement**  
- **Intégration Stripe ou PayPal** pour la réservation  

---

## 📦 Installation & Lancement  

### 1️⃣ Cloner le repo  
```bash
git clone https://github.com/bahae112/ReservationVolsProject.git
cd ReservationVolsProject
