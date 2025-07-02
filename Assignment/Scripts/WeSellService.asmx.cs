using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Web;
using System.Web.Services;
using System.Xml.Linq;

namespace Assignment.Scripts
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WeSellService : WebService
    {
        // Define User class for JSON
        public class User
        {
            public string username { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public string role { get; set; }
        }

        private List<User> LoadUsers()
        {
            string path = HttpContext.Current.Server.MapPath("~/users.json");
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<User>>(json);
        }

        private void SaveUsers(List<User> users)
        {
            string path = HttpContext.Current.Server.MapPath("~/users.json");
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        // CUSTOMER METHODS
        [WebMethod]
        public bool CustomerLogin(string email, string password)
        {
            var users = LoadUsers();
            return users.Any(u => u.email == email && u.password == password && u.role == "user");
        }

        [WebMethod]
        public string PlaceOrder(string customerId, string productId, int quantity)
        {
            string path = HttpContext.Current.Server.MapPath("~/orders.xml");
            XDocument doc = XDocument.Load(path);

            XElement newOrder = new XElement("order",
                new XElement("id", Guid.NewGuid().ToString().Substring(0, 8)),
                new XElement("status", "Pending"),
                new XElement("customer", customerId),
                new XElement("date", DateTime.Now.ToString("yyyy-MM-dd")),
                new XElement("total", (quantity * 100).ToString("0.00"))
            );

            doc.Root.Add(newOrder);
            doc.Save(path);

            return $"Order placed: {productId} x{quantity} for customer {customerId}";
        }

        [WebMethod]
        public string TrackOrder(string orderId)
        {
            string path = HttpContext.Current.Server.MapPath("~/orders.xml");
            XDocument doc = XDocument.Load(path);

            var order = doc.Descendants("order")
                .FirstOrDefault(o => (string)o.Element("id") == orderId);

            if (order == null)
                return $"Order {orderId} not found.";

            return $"Order {orderId} status: {order.Element("status")?.Value}";
        }

        [WebMethod]
        public string CustomerLogout()
        {
            return "Customer logged out successfully.";
        }

        // ADMIN METHODS
        [WebMethod]
        public bool AdminLogin(string email, string password)
        {
            var users = LoadUsers();
            return users.Any(u => u.email == email && u.password == password && u.role == "admin");
        }

        [WebMethod]
        public string AdminLogout()
        {
            return "Admin logged out successfully.";
        }

        [WebMethod]
        public List<string> GetAllOrders()
        {
            string path = HttpContext.Current.Server.MapPath("~/orders.xml");
            XDocument doc = XDocument.Load(path);

            return doc.Descendants("order")
                .Select(o => $"Order ID: {o.Element("id")?.Value} | Status: {o.Element("status")?.Value}")
                .ToList();
        }

        [WebMethod]
        public string UpdateInventory(string productId, int newQuantity)
        {
            return $"Inventory updated for {productId}: {newQuantity} in stock.";
        }

        [WebMethod]
        public string MonitorSystemStatus()
        {
            return "System is online. All services operational.";
        }

        [WebMethod]
        public string RespondToTicket(string ticketId, string response)
        {
            string path = HttpContext.Current.Server.MapPath("~/tickets.xml");
            XDocument doc = XDocument.Load(path);

            var ticket = doc.Descendants("ticket")
                .FirstOrDefault(t => (string)t.Element("id") == ticketId);

            if (ticket == null)
                return $"Ticket {ticketId} not found.";

            ticket.SetElementValue("status", "Resolved");
            ticket.Add(new XElement("response", response));
            doc.Save(path);

            return $"Response sent for ticket {ticketId}.";
        }
    }
}
