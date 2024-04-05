using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class Route : IRoute
    {
        private string _startingPoint;
        private string _endPoint;
        private double _length;
        private int _routeId;
        private bool _isLocked;

        public Route(string startPoint, string endPoint, double length, int routeId)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Length = length;
            RouteId = routeId;
            _isLocked = false;
        }

        public string StartPoint
        {
            get => _startingPoint;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.StartPointNull);
                }
                _startingPoint = value;
            }
        }

        public string EndPoint
        {
            get => _endPoint;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EndPointNull);
                }
                _endPoint = value;
            }
        }

        public double Length 
        {
            get => _length;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.RouteLengthLessThanOne);
                }
                _length = value;
            }
        }

        public int RouteId 
        {
            get => _routeId;
            private set
            {
                _routeId = value;
            }
        }

        public bool IsLocked => _isLocked;

        public void LockRoute()
        {
            _isLocked = true;
        }
    }
}
