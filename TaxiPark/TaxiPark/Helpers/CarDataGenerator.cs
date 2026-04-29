using TaxiPark.Models;

namespace TaxiPark.Helpers
{
    public static class CarDataGenerator
    {
        private static readonly string[] Brands =
            { "Toyota", "Ford", "BMW", "Mercedes", "Hyundai", "Kia", "Nissan", "Volkswagen" };

        private static readonly string[] Conditions =
            { "Отличное", "Хорошее", "Удовлетворительное", "Требует ремонта" };

        public static Car GenerateCar(int index)
        {
            return new Car(
                number: index + 1,
                brand: Brands[index % Brands.Length],
                year: 2015 + (index % 10),
                condition: Conditions[index % Conditions.Length],
                driver: $"Водитель {index + 1}"
            );
        }

        public static Car GenerateCustomCar(int number, string brand, string driver)
        {
            return new Car(
                number: number,
                brand: brand,
                year: 2024,
                condition: "Отличное",
                driver: driver
            );
        }
    }
}