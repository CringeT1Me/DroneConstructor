using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DronesConstructor.Classes
{
    public class DroneComponentsClass
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public DroneType droneType {  get; set; }
        public int droneTypeID {  get; set; }
        public BitmapImage image { get; set; }
        public Characteristics characteristics { get; set; }
        public Battery battery { get; set; }
        public ESC esc { get; set; }
        public Board board { get; set; }
        public MotorCharacteristics motorCharacteristics { get; set; }
        public List<Module> modules { get; set; }

        public DroneComponentsClass()
        {
            ModuleType moduleType = new ModuleType();
            characteristics = new Characteristics();
            battery = new Battery();
            esc = new ESC();
            board = new Board();
            droneType = new DroneType();
            motorCharacteristics = new MotorCharacteristics();
            modules = new List<Module>();
        }

        public class Characteristics
        {
            public int ID { get; set; }
            public double requiedThrust {  get; set; }
            public double fullWeight { get; set; }
            public double fullValtage {  get; set; }
            public double thrust {  get; set; }
            public int gas {  get; set; }
            public int countOfProp {  get; set; }
            public int thrustRatio {  get; set; }
            public double flightTime {  get; set; }
            public double realFlightTime {  get; set; }
            public double frameWeight {  get; set; }
            public double RPM {  get; set; }
            public double positiveLoad {  get; set; }
            public double fullCurrent { get; set; }
            public double KV { get; set; }
            public int minCells {  get; set; }
            public int maxCells { get; set; }
            public double minValtage {  get; set; }
            public double maxValtage {  get; set; }
            public int IDDroneType {  get; set; }
            public List<int> modules { get; set; }
            public string propName {  get; set; }
        }
        
        public class Motor
        {
            public int ID { get; set; }
            public string name {  get; set; }
            public double KV { get; set; }
            public double voltage { get; set; }
            public double weight { get; set; }
            public double temperature { get; set; }
        }

        public class MotorCharacteristics
        {
            public MotorCharacteristics()
            {
                motor = new Motor();
                propeller = new Propeller();
            }
            public int ID { get; set; }
            public Motor motor { get; set; }
            public Propeller propeller { get; set; }
            public double current { get; set; }
            public int gas { get; set; }
            public double maxCurrent { get; set; }
            public double thrust { get; set; }
        }

        public class Propeller
        {
            public int ID { get; set; }
            public string name { get; set; }
            public double weight { get; set; }
        }

        public class Battery
        {
            public int ID { get; set; }
            public string name { get; set; }
            public int cellCount {  get; set; }
            public double dischargeRating { get; set; }
            public double capacity { get; set; }
            public double weight { get; set; }
        }

        public class Module
        {
            public int ID { get; set; }
            public string name { get; set; }
            public double weight { get; set;}

        }

        public class ConstructionModule
        {
            public int ID { get; set; }
            public int IDConstruction { get; set; }
            public int IDModule { get; set; }

        }

        public class ModuleType
        {
            public int ID { get; set; }
            public string name { get; set; }
            public bool active { get; set; }
            public double weight { get; set; }
        }

        public class Board
        {
            public int ID { get; set; }
            public string name { get; set; }
            public int minCellsCount { get; set; }
            public int maxCellsCount { get; set; }
            public string specification { get; set; }
            public double weight { get; set; }
        }

        public class ESC
        {
            public int ID { get; set; }
            public string name { get; set; }
            public double maxCurrent { get; set; }
            public int minCellsCount { get; set; }
            public int maxCellsCount { get; set; }
            public double weight { get; set; }
        }

        public class Objective
        {
            public Objective()
            {
                requiedModuleTypes = new List<int>();
            }
            public int ID { get; set; }
            public string name { get; set; }
            public int IDSector { get; set; }
            public List<int> requiedModuleTypes {  get; set; }
            public bool active { get; set; }
        }

        public class DroneType
        {
            public int ID { get; set; }
            public string name { get; set; }
            public byte[] imageByteArray {  get; set; }
        }

        public void CalculateRequiedThrust()
        {
            this.characteristics.requiedThrust = (characteristics.fullWeight) * characteristics.thrustRatio / characteristics.countOfProp;
        }

        public double CalculateRequiedThrust(double droneWeight, int ratio, double modulesWeight, int motorsNumber)
        {
            return (droneWeight + modulesWeight) * ratio / motorsNumber;
        }

        public void FlightTime()
        {
            characteristics.realFlightTime = (battery.capacity / 1000) / characteristics.fullCurrent * 60;
        }

        public double FlightTime (double batteryCapacity, double fullCurrent)
        {
            return (batteryCapacity / 1000) / fullCurrent * 60;
        }


        


    }
}
