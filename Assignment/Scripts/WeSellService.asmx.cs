using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Xml;

namespace Assignment.Scripts
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WeSellService : WebService
    {
        // CUSTOMER METHODS
        [WebMethod]
        public string RegisterCustomer(string name, string email, string password)
        {
            // Store user in DB (dummy response for now)
            return "Registration successful for " + name;
        }

        [WebMethod]
        public bool CustomerLogin(string email, string password)
        {
            return email == "test@customer.com" && password == "1234";
        }

        [WebMethod]
        public string PlaceOrder(string customerId, string productId, int quantity)
        {
            return $"Order placed: {productId} x{quantity} for customer {customerId}";
        }

        [WebMethod]
        public string TrackOrder(string orderId)
        {
            return $"Order {orderId} is in transit.";
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
            return email == "admin@wesell.com" && password == "admin123";
        }

        [WebMethod]
        public string AdminLogout()
        {
            return "Admin logged out successfully.";
        }

        [WebMethod]
        public List<string> GetAllOrders()
        {
            return new List<string> { "Order #001", "Order #002" };
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
            return $"Response sent for ticket {ticketId}: {response}";
        }
    }

}
