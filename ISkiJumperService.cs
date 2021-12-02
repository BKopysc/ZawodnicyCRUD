using System;
using System.Collections.Generic;
using System.Text;

namespace ZawodnicyCRUD
{
    interface ISkiJumperService
    {
        public string Create(SkiJumper s);
        public SkiJumper Read(int id);

        public string Update(SkiJumper s);
        public string Delete(int id);

    }
}
