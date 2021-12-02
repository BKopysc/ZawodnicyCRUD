using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZawodnicyCRUD;

namespace ZawodnicyCRUDTest
{
    public class MockedSkiJumpers
    {
        private static Random rand = new Random();
        private static string RandomString(int len)
        {
            string FirstChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string OtherChar = "abcdefghijklmnopqrstuwxyz";

            string FirstLetter = new string(Enumerable.Repeat(FirstChar, 1)
                .Select(s => s[rand.Next(s.Length)]).ToArray());
            string OtherLetters = new string(Enumerable.Repeat(OtherChar, len-1)
                .Select(s => s[rand.Next(s.Length)]).ToArray());

            return (FirstLetter + OtherLetters);
        }

        private double RandomDouble(double min, double max)
        {
            return Math.Round((rand.NextDouble() * (max - min) + min),2);

        }

        private DateTime RandomDate()
        {
            DateTime min = new DateTime(1970, 1, 1);
            DateTime max = new DateTime(2014, 1, 1);
            int range = (max - min).Days;
            return min.AddDays(rand.Next(range));
        }
        public SkiJumper GetSkiJumper(int id, string Country)
        {
            Mock<SkiJumper> SkiJumper = new Mock<SkiJumper>();
            SkiJumper.SetupGet(s => s.Name).Returns(RandomString(5));
            SkiJumper.SetupGet(s => s.Surname).Returns(RandomString(8));
            SkiJumper.SetupGet(s => s.IdSkijumper).Returns(id);
            SkiJumper.SetupGet(s => s.IdCoach).Returns(rand.Next(1, 20));
            SkiJumper.SetupGet(s => s.Height).Returns(RandomDouble(140.0, 200.0));
            SkiJumper.SetupGet(s => s.Weight).Returns(RandomDouble(40.0, 80.0));
            SkiJumper.SetupGet(s => s.DateOfBirth).Returns(RandomDate());
            SkiJumper.SetupGet(s => s.Country).Returns(Country);

            return SkiJumper.Object;
        }
    }


}
