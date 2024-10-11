using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagementSystem_V2
{
    internal class Car
    {
        public string CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public decimal RentalPrice { get; set; }

        public Car(string id, string model, string brand, decimal rentalPrice)
        {
            CarId = id;
            Brand = brand;
            Model = model;
            RentalPrice = rentalPrice;
        }

        public virtual string DisplayCarInfo()
        {
            return $"Car ID: {CarId}, Brand: {Brand}, Model: {Model}, Rental Price: {RentalPrice:C}";
        }

        public override string ToString()
        {
            return DisplayCarInfo();
        }
    }
  
}
