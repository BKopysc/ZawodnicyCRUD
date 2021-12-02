using System;
using System.Collections.Generic;
using System.Text;

namespace ZawodnicyCRUD
{
    public class SkiJumperService : ISkiJumperService
    {
        private Dictionary<int, SkiJumper> _skiJumpersDict = new Dictionary<int, SkiJumper>();
        public string Create(SkiJumper s)
        {
            if(s == null)
            {
                throw new ArgumentNullException("null");
            }

            if(_skiJumpersDict.ContainsKey(s.IdSkijumper))
            {
                return "IdExists";
            }
            else
            {
                _skiJumpersDict.Add(s.IdSkijumper, s);
                return "Created";
            }


        }

        public string Delete(int id)
        {
            if (_skiJumpersDict.ContainsKey(id))
            {
                _skiJumpersDict.Remove(id);
                return "Removed";
            }
            else
            {
                throw new ArgumentOutOfRangeException("IdIsNotInRange");
            }

        }

        public SkiJumper Read(int id)
        {
            SkiJumper ski;
            if (_skiJumpersDict.TryGetValue(id, out ski))
            {
                return ski;
            }
            else
            {
                throw new ArgumentOutOfRangeException("IdIsNotInRange");
            }
        }

        public string Update(SkiJumper s)
        {

            if (s == null)
            {
                throw new ArgumentNullException("null");
            }

            if (_skiJumpersDict.ContainsKey(s.IdSkijumper))
            {
                _skiJumpersDict[s.IdSkijumper] = s;
                return "Updated";
            }
            else
            {
                throw new ArgumentOutOfRangeException("SkiJumper does not exist");
            }
        }

        public List<SkiJumper> FiletrByCountry(string Country)
        {
            List<SkiJumper> SkiJumpersList = new List<SkiJumper>();
            foreach(KeyValuePair<int, SkiJumper> entry in _skiJumpersDict)
            {
                if(entry.Value.Country == Country)
                {
                    SkiJumpersList.Add(entry.Value);
                }
            }

            if(SkiJumpersList.Count == 0)
            {
                throw new ArgumentOutOfRangeException("Country does not exist");
            }
            else
            {
                return SkiJumpersList;
            }
        }
        

    }
}
