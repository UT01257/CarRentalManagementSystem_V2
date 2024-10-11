using Microsoft.Data.SqlClient;

namespace CarRentalManagementSystem_V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager manager = new CarManager();
            CarRepository repository = new CarRepository();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();

                Console.WriteLine("\n Car Rental Management");
                Console.WriteLine("1. Add a new car");
                Console.WriteLine("2. view All car");
                Console.WriteLine("3. Update a car");
                Console.WriteLine("4. Delete a car");
                Console.WriteLine("5. view car by id");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        CreateCar(manager, repository);
                        break;
                    case "2":
                        Console.Clear();
                        GetCars(repository);
                        break;
                    case "3":
                        Console.Clear();
                        UpdateCar(manager, repository);
                        break;
                    case "4":
                        Console.Clear();
                        DeleteCar(manager, repository);
                        break;
                    case "5":
                        Console.Clear();
                        GetCarById(repository);
                        break;
                    case "6":
                        Console.Clear();
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please Choose Valid Actions");
                        break;

                }
                if (!exit)
                {
                    Console.WriteLine("Press enter to continue.......");
                    break;
                }


            }
        }

        static void CreateCar(CarManager manager, CarRepository repository)
        {
            Console.WriteLine("Enter Car ID: ");
            string CarID = Console.ReadLine();
            Console.WriteLine("Enter Car Brand: ");
            string Brand = Console.ReadLine();
            Console.WriteLine("Enter Car Model: ");
            string Model = Console.ReadLine();

            decimal RentalPrice = manager.ValidateCarRentalPrice();

            repository.CreateCar(CarID, Brand, Model, RentalPrice);
        }

        static void UpdateCar(CarManager manager, CarRepository repository)
        {
            Console.WriteLine("Enter Car Id to find car");
            string CarId = Console.ReadLine();
            Console.WriteLine("Enter New Brand");
            string Brand = Console.ReadLine();
            Console.WriteLine("Enter New model");
            string Model = Console.ReadLine();
            decimal RentalPrice = manager.ValidateCarRentalPrice();


            repository.UpdateCar(CarId, Brand, Model, RentalPrice);

        }

        static void DeleteCar(CarManager manager, CarRepository repository)
        {
            Console.WriteLine("Enter Car Id to delete Car: ");
            string id = Console.ReadLine();
            //manager.DeleteCar(id);
            repository.DeleteCar(id);

        }

        static void GetCarById(CarRepository repository)
        {
            Console.WriteLine("Enter Car ID to View:");
            int id = int.Parse(Console.ReadLine());
            // manager.DeleteFitnessProgram(id);
            var car = repository.GetCarById(id);
            Console.WriteLine(car.ToString());

        }

        static void GetCars(CarRepository repository)
        {
            var cars = repository.GetCars();
            // manager.DeleteFitnessProgram(id)
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }

        }
        //static void SetConnection()
        //{

        //    string masterDbConnectionString = "Server=(LocalDb)\\MSSQLLocalDB; Database=master; Trusted_Connection=True; TrustServerCertificate=True;";

     
        //    string connectionString = "Server=(LocalDb)\\MSSQLLocalDB; Database=CarRentalManagement; Trusted_Connection=True; TrustServerCertificate=True;";

        //    string dbQuery = @"IF NOT EXISTS (SELECT * FROM sys.databases WHERE name='CarRentalManagement') 
        //                   CREATE DATABASE CarRentalManagement;";

        //    string tableQuery = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Cars' AND xtype='U') 
        //                    CREATE TABLE Cars(
        //                        CarId NVARCHAR(50) PRIMARY KEY, 
        //                        Brand NVARCHAR(50) NOT NULL,
        //                        Model NVARCHAR(50) NOT NULL,
        //                        RentalPrice DECIMAL(10,2) NOT NULL
        //                    );";

          
        //    string insertQuery = @"
        //             INSERT INTO Cars (CarId, Brand, Model, RentalPrice)
        //             VALUES ('CAR_001','Honda', 'Vessel', 10.00);";

       
        //    using (SqlConnection connection = new SqlConnection(masterDbConnectionString))
        //    {
        //        try
        //        {
        //            connection.Open();
        //            using (SqlCommand command = new SqlCommand(dbQuery, connection))
        //            {
        //                command.ExecuteNonQuery();
        //                Console.WriteLine("Database created successfully (or already exists).");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"Error creating database: {ex.Message}");
        //        }
        //    }

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            conn.Open();

   
        //            using (SqlCommand cmd = new SqlCommand(tableQuery, conn))
        //            {
        //                cmd.ExecuteNonQuery();
        //                Console.WriteLine("Table created successfully (or already exists).");
        //            }

        //            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
        //            {
        //                cmd.ExecuteNonQuery();
        //                Console.WriteLine("Sample data inserted successfully.");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"Error executing queries: {ex.Message}");
        //        }
        //    }

        //    Console.ReadLine();
        //}



    }
}

