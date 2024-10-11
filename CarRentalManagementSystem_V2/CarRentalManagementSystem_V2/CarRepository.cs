using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagementSystem_V2
{
    internal class CarRepository
    {

        private string connectionString = "Server=(LocalDb)\\MSSQLLocalDB; Database=CarRentalManagement; Trusted_COnnection=True; TrustServerCertificate=True;";

        public void CreateCar(string id, string brand, string model, decimal price)
        {
            try
            {
                string capitalaizeBrand = CapitalizeBrand(brand);

                string insertQuery = @"INSERT INTO Cars (CarID, Brand, Model, RentalPrice)VALUES(@id, @brand, @model, @price);";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@brand", capitalaizeBrand);
                        command.Parameters.AddWithValue("@model", model);
                        command.Parameters.AddWithValue("@price", price);
                        command.ExecuteNonQuery();
                        Console.WriteLine("Car Add Successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void UpdateCar(string id, string brand, string model, decimal price)
        {
            try
            {
                string capitalaizeBrand = CapitalizeBrand(brand);
                string updateQuery = @"UPDATE Cars SET Brand=@brand, Model=@model, RentalPrice=@price WHERE CarId=@id";
                using (SqlConnection conn = new
               SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@brand", capitalaizeBrand);
                        cmd.Parameters.AddWithValue("@model", model);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Car updated successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void DeleteCar(string id)
        {
            try
            {
                string deleteQuery = @"DELETE Cars FROM Cars WHERE CarId=@id";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("car deleted successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public Car GetCarById(int id)
        {
            string getQuery = @"SELECT * FROM Cars WHERE Id = @id";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(getQuery, conn);
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Car(
                                reader.GetString(0),  // Id
                                reader.GetString(1), // Model
                                reader.GetString(2), // Brand
                                reader.GetDecimal(3) // RentalPrice
                            );
                        }
                        else
                        {
                            return null;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public List<Car> GetCars()
        {

            List<Car> cars = new List<Car>();
            string query = @"SELECT * FROM Cars";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Car car = new Car(
                                reader.GetString(0),  // Id
                                reader.GetString(1), // Model
                                reader.GetString(2), // Brand
                                reader.GetDecimal(3) // RentalPrice
                            );
                            cars.Add(car);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }
            return cars;
        }



        public string CapitalizeBrand(string brand)
        {
            string[] words = brand.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                }
            }
            return string.Join(" ", words);
        }
    }
}
