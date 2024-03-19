using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab_ef
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    internal class Pizzeria
    { 
        public int ClientID;
        public int PersonalID;
        public int PizzaID;
        public int OrdersID;

        public string ClientName {  get; private set; }
        public string PersonalName { get; private set; }
        public string PizzaName { get; private set;  }
        public decimal Price { get; private set; }
        public Pizzeria(Order orders)
        {
            ClientID = orders.Client.ID_Client;
            ClientName = orders.Client.FirstName;

            PersonalID = orders.Personal.ID_Personal;
            PersonalName = orders.Personal.FirstName;

            PizzaID = orders.Pizza.ID_Pizza;
            PizzaName = orders.Pizza.PizzaName;

            OrdersID = orders.ID_Orders;
            Price = orders.Price;
        }
    }
    public partial class MainWindow : Window
    {
        private PizzeriaEntities context = new PizzeriaEntities();
        List<Pizzeria> pizzerias = new List<Pizzeria>();
        public MainWindow()
        {
            InitializeComponent();
            foreach (var item in context.Orders.ToList())
            {
                pizzerias.Add(new Pizzeria(item));
            }
            PizzeriaDataGrid.ItemsSource = pizzerias;

        }
    }
}
