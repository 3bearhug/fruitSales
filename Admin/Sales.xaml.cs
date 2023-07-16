using Org.BouncyCastle.Asn1.Mozilla;
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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace farmersMarket 
{
    public partial class Sales : Window
    {
        public class Product
        {
            public string ProductName { get; set; }
            public int ProductID { get; set; }
            public double AmountKG { get; set; }
            public decimal PricePerKG { get; set; }
        }

        public Sales()
        {
            InitializeComponent();
            LoadProducts(); 
        }

        private void showme_Click(object sender, RoutedEventArgs e)
        {
            string productName = Name.Text;
            double requestedAmount = double.Parse(amountTextBox.Text);

            Product product = GetProductByNameFromDB(productName);

            if (product == null || product.AmountKG < requestedAmount)
            {
                MessageBox.Show("Invalid product or insufficient inventory.");
                return;
            }

            decimal salesAmount = (decimal)requestedAmount * product.PricePerKG;

            salesTextBox.Text = salesAmount.ToString();

            product.AmountKG -= requestedAmount;

            UpdateProductInDB(product);
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {

            Name.Text = "";
            amountTextBox.Text = "";
            salesTextBox.Text = "";
        }

        private Product GetProductByNameFromDB(string productName)
        {

            string connectionString = "server=localhost;database=farmersMarket;user=root;password=root12345!";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Products WHERE ProductName = @ProductName";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", productName);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Product
                            {
                                ProductName = reader.GetString("ProductName"),
                                ProductID = reader.GetInt32("ProductID"),
                                AmountKG = reader.GetDouble("AmountKG"),
                                PricePerKG = reader.GetDecimal("PricePerKG")
                            };
                        }
                    }
                }
            }

            return null;
        }

        private void UpdateProductInDB(Product product)
        {
            string connectionString = "server=localhost;database=farmersMarket;user=root;password=root12345!";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Products SET AmountKG = @AmountKG WHERE ProductName = @ProductName";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", product.ProductName);
                    command.Parameters.AddWithValue("@AmountKG", product.AmountKG);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("MySQL error: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("General error: " + ex.Message);
                    }
                }
            }
        }
        private void LoadProducts()
        {
            string connectionString = "server=localhost;database=farmersMarket;user=root;password=root12345!";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand("SELECT * FROM Products", connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        List<Product> products = new List<Product>();
                        while (reader.Read())
                        {
                            products.Add(new Product()
                            {
                                ProductName = reader.GetString("ProductName"),
                                ProductID = reader.GetInt32("ProductID"),
                                AmountKG = reader.GetDouble("AmountKG"),
                                PricePerKG = reader.GetDecimal("PricePerKG")
                            });
                        }

                        ProductList.ItemsSource = products;
                    }
                }
            }
        }
    }
}
