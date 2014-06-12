using System; //Libraries
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMV_GUI 
{
    abstract class MotorVehicle : IComparable<MotorVehicle> //Class MotorVehicle
    {
        string VIN;
        string make;
        string model;
        DateTime dateOfProduction; //Date of production , displays today date
        protected int noOfWheels; //Number of wheels on vehicle
        protected int noOfSeats; //Number of seats in vehicle
        protected char fieldSep = '|'; //Field separator

        public MotorVehicle(string VIN, string make, string model, int noOfWheels, int noOfSeats, DateTime dateOfProduction)
        {
            this.VIN = VIN;
            this.make = make;
            this.model = model;
            this.noOfSeats = noOfSeats;
            this.noOfWheels = noOfWheels;
            this.dateOfProduction = dateOfProduction;
        }

        public virtual string show() //Public string
        {
            return string.Format(" Make: {1} {0} Model: {2} {0} Number of Wheels: {3}", fieldSep, make, model, noOfWheels);
        }

        public int CompareTo(MotorVehicle other) // dateOfProduction
        {
            return this.dateOfProduction.CompareTo(other.dateOfProduction);
        }
    }

    class Truck : MotorVehicle //Class for truck
    {
        private double maxWeight;

        public Truck(string VIN, string make, string model, int noOfWheels, int noOfSeats, DateTime dateOfProduction, double maxWeight)
            : base(VIN, make, model, noOfSeats, noOfWheels, dateOfProduction)
        {
            this.maxWeight = maxWeight;
        }

        public override string show()
        {
            return string.Format("Truck: " + base.show() + " {0} Maximum Weight: {1}", fieldSep, maxWeight);
        }
    }

    //If it has more than eight seats it is bus type of vehicle
    class Bus : MotorVehicle //Bus class
    {
        private string companyName;

        public Bus(string VIN, string make, string model, int noOfWheels, int noOfSeats, DateTime dateOfProduction, string companyName)
            : base(VIN, make, model, noOfSeats, noOfWheels, dateOfProduction)
        {
            this.companyName = companyName;
        }

        public override string show()
        {
            return string.Format("Bus: " + base.show() + " {0} Company Name: {1}", fieldSep, companyName);
        }
    }

    //If it has less than eight seats it is car type
    class Car : MotorVehicle
    {
        private string color;
        private bool AC;
        private int airbags;

        public Car(string VIN, string make, string model, int noOfWheels, int noOfSeats, DateTime dateOfProduction, string color, bool AC, int airbags)
            : base(VIN, make, model, noOfSeats, noOfWheels, dateOfProduction)
        {
            this.color = color;
            this.AC = AC;
            this.airbags = airbags;
        }

        public override string show()
        {
            return string.Format("Car: " + base.show() + " {0} Color: {1} {0} Has AC: {2} {0} Number of Airbags: {3}", fieldSep, color, AC, airbags);
        }
    }

    class Taxi : Car //Just like a car but it is in Taxi class,because it leads different licence
    {
        private bool licence;

        public Taxi(string VIN, string make, string model, int noOfWheels, int noOfSeats, DateTime dateOfProduction, string color, bool AC, int airbags, bool licence)
            : base(VIN, make, model, noOfWheels, noOfSeats, dateOfProduction, color, AC, airbags)
        {
            new Car(VIN, make, model, noOfSeats, noOfWheels, dateOfProduction, color, AC, airbags);
            this.licence = licence;
        }

        public override string show()
        {
            return string.Format("Taxi: " + base.show() + "{0} Driver has licence: {1}", fieldSep, licence);
        }
    }
    // It has to have less than tree seats
    class Motorcycle : MotorVehicle
    {
        private double ccm;

        public Motorcycle(string VIN, string make, string model, int noOfWheels, int noOfSeats, DateTime dateOfProduction, double ccm)
            : base(VIN, make, model, noOfSeats, noOfWheels, dateOfProduction)
        {
            this.ccm = ccm;
        }

        public override string show()
        {
            return string.Format("Motorcycle: " + base.show() + " {0} CCM: {1} ", fieldSep, ccm);
        }
    }
}
