# 📦 WeSell EAI Integration Project

## 📁 Project Title
**Enterprise Application Integration for WeSell**

## 👤 Author  
**Lee Ken Yu (Student ID: 1221303813)**  
**Section: TC1L**  
**Faculty of Computing and Informatics, Multimedia University**  
**Submission Date: 4 July 2024**

---

## 📌 Overview

This project is part of the CIT6324 – Enterprise Application Integration (EAI) course, replacing the final exam. The system simulates an integrated e-commerce enterprise platform named **WeSell**, built to demonstrate EAI concepts by connecting different modules including:

- Order Management  
- Product Catalog  
- Customer Profiles  
- Customer Support Tickets  
- User Authentication  

---

## 🌐 Technologies Used

- **Frontend:** HTML5, CSS3, JavaScript  
- **Backend/Data Format:** JSON, XML  
- **Platform:** Localhost (XAMPP), Visual Studio (.NET)  
- **Integration Types:** REST API Simulation, File-Based Integration  
- **Middleware (Conceptual):** RabbitMQ, Apache Camel  

---

## 🔧 Modules

### 📊 Dashboard
- Entry page for users after login.
- Displays navigation to Orders, Products, Support, and Profiles.

### 🧾 Orders
- Load and display order data from `orders.xml`.
- Admin-restricted view for order processing and tracking.

### 🛒 Products
- Search functionality to browse products from `items.xml`.
- Supports keyword-based search like "Laptop", "Tablet", etc.

### 👤 Profiles
- Displays customer information fetched from `users.json`.

### 🛠️ Support
- Loads and lists support tickets from `tickets.xml`.
- Covers cases like refund requests, delivery issues, and login problems.

### 🔐 Login
- Basic authentication system using `users.json`.
- Redirects based on role: only "admin" users can access secure modules.

---

## 🧩 Integration Features

- Session-based role control (admin/user)  
- Data exchange using XML & JSON for modular EAI  
- Navigation simulates an integrated portal  
- Real-time filtering and secure session handling with JavaScript  

---

## 📝 Project Guidelines

This project adheres strictly to the **CIT6324 Project Guidelines**, fulfilling all major sections:
1. **Introduction to EAI in the WeSell enterprise**  
2. **EAI Planning and Integration Architecture**  
3. **Development and Technology Stack**  
4. **EAI Challenges and Recommendations**  
5. **Conclusion and Summary of Learnings**  
📖 Ref: CIT6324 Project Guidelines:contentReference[oaicite:0]{index=0}

---

## 📄 How to Run

1. Install XAMPP or run a local server.  
2. Place all project files in the `htdocs/WeSell` directory.  
3. Open `login.html` in the browser.  
4. Use the credentials in `users.json` to log in:  
   - Username: `admin`, Password: `admin123`  
   - Username: `user1`, Password: `pass123`  

---

## 📁 File Structure

├── index.html          → Dashboard  
├── login.html          → Login page  
├── orders.html         → Order Management  
├── products.html       → Product Search  
├── support.html        → Customer Support  
├── profiles.html       → Customer Profiles  
├── styles.css          → Project styling  
├── items.xml           → Product data  
├── orders.xml          → Orders data  
├── tickets.xml         → Support tickets  
├── users.json          → User login data  
└── libman.json         → CDN library manager config (empty)  

---

## 📚 References

All referenced standards, techniques, and examples were derived from class notes, lectures, and external research sources, following proper citation rules as specified in the CIT6324 guideline:contentReference[oaicite:1]{index=1}.

---

## 📥 Additional Notes

This project is meant to simulate enterprise-level integration using lightweight web technologies, with a focus on:
- Modularity  
- Security (role-based access)  
- Reusability  
- XML/JSON interoperability  

---
