using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

using System;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;


namespace farmersMarket
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string server = "localhost";
        private string database = "farmersmarket";
        private string uid = "root";
        private string password = "root12345!";
        private string connectionString;

        public MainWindow()
        {
            InitializeComponent();
            connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            LoadData();
        }

        private void LoadData()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM products", connection);

                try
                {
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());

                    ProductList.ItemsSource = dt.DefaultView;  // Bind the retrieved data to your 'ProductList' control
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("General Error: " + ex.Message);
                }
            }
        }

        //3. mySQ command generation and execution 
        private void insert_Click(object sender, RoutedEventArgs e)
        {
            string productName = Name.Text;
            string id = idTextBox.Text;
            string amountKg = amountTextBox.Text;
            string pricePerKg = Name_Copy1.Text;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO products (ProductName, ProductID, AmountKG, PricePerKG) VALUES (@productName, @id, @amountKg, @pricePerKg)";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@productName", productName);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@amountKg", amountKg);
                    cmd.Parameters.AddWithValue("@pricePerKg", pricePerKg);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record inserted successfully");
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Database error: " + ex.Message);
                    }
                }

                LoadData();
            }
        }
        private void select_Click_1(object sender, RoutedEventArgs e)
        {
            string id = idTextBox.Text;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM products WHERE ProductID = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    try
                    {
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());

                        ProductList.ItemsSource = dt.DefaultView;
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Database error: " + ex.Message);
                    }
                }
            }
        }

        private void update_Click_1(object sender, RoutedEventArgs e)
        {
            string productName = Name.Text;
            string id = idTextBox.Text;
            string amountKg = amountTextBox.Text;
            string pricePerKg = Name_Copy1.Text;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE products SET ProductName = @productName, AmountKG = @amountKg, PricePerKG = @pricePerKg WHERE ProductID = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@productName", productName);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@amountKg", amountKg);
                    cmd.Parameters.AddWithValue("@pricePerKg", pricePerKg);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record updated successfully");
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Database error: " + ex.Message);
                    }
                }

                LoadData();
            }
        }

        private void delete_Click_1(object sender, RoutedEventArgs e)
        {
            string id = idTextBox.Text;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM products WHERE ProductID = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record deleted successfully");
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Database error: " + ex.Message);
                    }
                }

                LoadData();
            }
        }

        private void salesButton_Click(object sender, RoutedEventArgs e)
        {
            Sales sl = new Sales();

            this.Hide();

            sl.ShowDialog();

            LoadData();
            this.Show();
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            Name.Text = "";
            idTextBox.Text = "";
            amountTextBox.Text = "";
            Name_Copy1.Text = "";
            LoadData();
        }
    }
}


