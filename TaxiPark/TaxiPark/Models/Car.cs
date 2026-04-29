namespace TaxiPark.Models
{
    public class Car
    {
        public int Number { get; set; }           
        public string Brand { get; set; }        
        public int Year { get; set; }            
        public string Condition { get; set; }     
        public string Driver { get; set; }        

        public Car(int number, string brand, int year, string condition, string driver)
        {
            Number = number;
            Brand = brand;
            Year = year;
            Condition = condition;
            Driver = driver;
        }

        public override string ToString()
        {
            return $"№{Number} | {Brand} | {Year} г. | {Condition} | Водитель: {Driver}";
        }
    }
}