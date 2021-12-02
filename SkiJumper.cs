using System;
using System.Collections.Generic;
using System.Text;

namespace ZawodnicyCRUD
{
    public class SkiJumper
    {
        public virtual int IdSkijumper { get; set; }
        public virtual int IdCoach { get; set; } //klasa
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Country { get; set; } //klasa
        public virtual DateTime DateOfBirth { get; set; }
        public virtual double Height { get; set; }
        public virtual double Weight { get; set; }
    }
}
