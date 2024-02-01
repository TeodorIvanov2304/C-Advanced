using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;

        private int capacity;
        public Parking(int capacity)
        {   
            //Директно инициализираме нов лист,с големина = на подаденото capacity
            cars = new List<Car>(capacity);
            this.capacity = capacity;
        }

        public int Count
        {
            get => cars.Count;

        }

        public string AddCar(Car car)
        {   
            //Правим проекция от стринг-масив, в която ще пазим регистрациите на всички коли
            string[] registrations = cars.Select(c=>c.RegistrationNumber).ToArray();

            //Номера вече съществува
            if (registrations.Contains(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (cars.Count >= capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber) 
        {
            //Car car = cars.FirstOrDefault(x=>x.RegistrationNumber == registrationNumber);
            Car car = GetCar(registrationNumber);
            if (car != null) 
            {   
                cars.Remove(car);
                return $"Successfully removed {registrationNumber}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return  cars.FirstOrDefault(c=>c.RegistrationNumber == registrationNumber);

        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (string number in registrationNumbers)
            {
                cars.RemoveAll(r => r.RegistrationNumber == number);
            }
        }
    }
}
