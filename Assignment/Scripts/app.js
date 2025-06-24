function loadOrders() {
    fetch("orders.xml")
        .then(res => res.text())
        .then(str => {
            const parser = new DOMParser();
            const xml = parser.parseFromString(str, "text/xml");
            const orders = xml.getElementsByTagName("order");
            const list = document.getElementById("orderList");
            list.innerHTML = "";

            for (let i = 0; i < orders.length; i++) {
                const id = orders[i].getElementsByTagName("id")[0].textContent;
                const status = orders[i].getElementsByTagName("status")[0].textContent;
                const customer = orders[i].getElementsByTagName("customer")[0].textContent;
                const date = orders[i].getElementsByTagName("date")[0].textContent;
                const total = orders[i].getElementsByTagName("total")[0].textContent;

                list.innerHTML += `
                    <li>
                        <strong>Order #${id}</strong> - ${status}<br/>
                        Customer: ${customer}<br/>
                        Date: ${date}<br/>
                        Total: RM ${total}
                    </li>`;
            }
        })
        .catch(error => {
            document.getElementById("orderList").innerHTML = `<li>Error loading orders: ${error.message}</li>`;
        });
}
function searchProducts() {
    const keyword = document.getElementById("productSearch").value.trim().toLowerCase();
    const list = document.getElementById("productList");
    list.innerHTML = "<li>Loading...</li>";

    fetch("items.xml")
        .then(res => {
            if (!res.ok) throw new Error("items.xml not found");
            return res.text();
        })
        .then(str => {
            const parser = new DOMParser();
            const xml = parser.parseFromString(str, "text/xml");
            const items = xml.getElementsByTagName("item");
            list.innerHTML = "";

            let found = false;

            for (let i = 0; i < items.length; i++) {
                const name = items[i].getElementsByTagName("name")[0].textContent;
                const category = items[i].getElementsByTagName("category")[0].textContent;
                const price = items[i].getElementsByTagName("price")[0].textContent;

                if (name.toLowerCase().includes(keyword)) {
                    found = true;
                    list.innerHTML += `
                        <li>
                            <strong>${name}</strong><br/>
                            Category: ${category}<br/>
                            Price: RM ${price}
                        </li>`;
                }
            }

            if (!found) {
                list.innerHTML = "<li>No matching products found.</li>";
            }
        })
        .catch(err => {
            list.innerHTML = `<li>Error loading products: ${err.message}</li>`;
        });
}
function loadTickets() {
    fetch("tickets.xml")
        .then(res => res.text())
        .then(str => {
            const parser = new DOMParser();
            const xml = parser.parseFromString(str, "text/xml");
            const tickets = xml.getElementsByTagName("ticket");
            const list = document.getElementById("ticketList");
            list.innerHTML = "";

            for (let i = 0; i < tickets.length; i++) {
                const id = tickets[i].getElementsByTagName("id")[0].textContent;
                const subject = tickets[i].getElementsByTagName("subject")[0].textContent;
                const status = tickets[i].getElementsByTagName("status")[0].textContent;
                const priority = tickets[i].getElementsByTagName("priority")[0].textContent;
                const date = tickets[i].getElementsByTagName("date")[0].textContent;

                list.innerHTML += `
                    <li>
                        <strong>Ticket #${id}</strong><br/>
                        Subject: ${subject}<br/>
                        Status: ${status} | Priority: ${priority}<br/>
                        Date: ${date}
                    </li>`;
            }
        })
        .catch(err => {
            document.getElementById("ticketList").innerHTML = `<li>Error loading tickets: ${err.message}</li>`;
        });
}
function loadProfiles() {
    const role = localStorage.getItem("role");
    const currentUser = localStorage.getItem("username");

    if (!currentUser) {
        alert("You must be logged in to view profiles.");
        window.location.href = "login.html";
        return;
    }

    fetch("users.json")
        .then(res => {
            if (!res.ok) throw new Error("users.json not found");
            return res.json();
        })
        .then(users => {
            const list = document.getElementById("profileList");
            list.innerHTML = "";

            if (role === "admin") {
                const userOnlyList = users.filter(u => u.role === "user");
                if (userOnlyList.length === 0) {
                    list.textContent = "No user profiles found.";
                } else {
                    userOnlyList.forEach(user => {
                        const li = document.createElement("li");
                        li.textContent = `Username: ${user.username} | Email: ${user.email}`;
                        list.appendChild(li);
                    });
                }
            } else {
                const user = users.find(u => u.username === currentUser);
                if (user) {
                    const li = document.createElement("li");
                    li.textContent = `Username: ${user.username} | Email: ${user.email}`;
                    list.appendChild(li);
                } else {
                    list.textContent = "Profile not found.";
                }
            }
        })
        .catch(err => {
            console.error("Failed to load profiles:", err);
            document.getElementById("profileList").textContent = "Error loading profile.";
        });
}
function loadProductsFromSOAP() {
    fetch("http://localhost/soapproxy.php")
        .then(response => response.json())
        .then(data => {
            const list = document.getElementById("productList");
            list.innerHTML = "";
            data.forEach(product => {
                const li = document.createElement("li");
                li.textContent = product;
                list.appendChild(li);
            });
        })
        .catch(error => {
            console.error("SOAP Error:", error);
            alert("Failed to load products from SOAP service.");
        });
}
