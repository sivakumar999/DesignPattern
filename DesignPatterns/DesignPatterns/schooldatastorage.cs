using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class SchoolDataStorage
    {
        private static SchoolDataStorage _instance;
        public List<Student> Students { get; private set; }
        public List<Teacher> Teachers { get; private set; }
        public List<Subject> Subjects { get; private set; }

        private SchoolDataStorage()
        {
            Students = new List<Student>();
            Teachers = new List<Teacher>();
            Subjects = new List<Subject>();
        }

        public static SchoolDataStorage GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SchoolDataStorage();
            }
            return _instance;
        }
    }
}
