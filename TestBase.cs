using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using ZawodnicyCRUD;

namespace ZawodnicyCRUDTest
{
    public class TestBase
    {
        public TestContext TestContext { get; set; }
        protected MockedSkiJumpers SkiJumpersDB;
        protected SkiJumper SkiJumper_1_Poland;
        protected SkiJumper SkiJumper_5_Germany;
        protected SkiJumper SkiJumper_10_Poland;
        protected SkiJumper SkiJumper_1_Germany;
        protected SkiJumperService SkiJumperService;

    }
}
