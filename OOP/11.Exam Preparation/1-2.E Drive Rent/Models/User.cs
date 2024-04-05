using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;

namespace EDriveRent.Models
{
    public class User : IUser
    {
        private string _firstName;
        private string _lastName;
        private string _drivingLicenseNumber;
        private double _rating;
        private bool _isBlocked;

        public User(string firstName, string lastName, string drivingLicenseNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DrivingLicenseNumber = drivingLicenseNumber;
            _rating = 0;
            _isBlocked = false;
        }

        public string FirstName 
        {
            get => _firstName;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.FirstNameNull);
                }
                _firstName = value;
            }
        }

        public string LastName 
        {
            get => _lastName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LastNameNull);
                }
                _lastName = value;
            }
        }

        public double Rating 
        {
            get => _rating;
            private set
            {
                _rating = value;
            }
        }

        public string DrivingLicenseNumber
        {
            get => _drivingLicenseNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }
                _drivingLicenseNumber = value;
            }
        }

        public bool IsBlocked 
        {
            get => _isBlocked;
            private set
            {
                _isBlocked = value;
            }
        }

        public void DecreaseRating()
        {
            Rating -= 2;
            if (Rating < 0)
            {
                Rating = 0;
            }
            IsBlocked = true;
        }

        public void IncreaseRating()
        {
            Rating += 0.5;
            if (Rating > 10.0)
            {
                Rating = 10;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} Driving license: {DrivingLicenseNumber} Rating: {Rating}";
        }
    }
}
