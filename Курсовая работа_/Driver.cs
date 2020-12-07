using System;
using System.Collections.Generic;
using System.Text;

namespace Курсовая_работа_
{
    
    public class Driver
    {
        public int Id { get;  set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Patronymic { get; private set; }
        public int Expirience { get; private set; }
        
        public Driver(string name, string surname, string patronymic, int expirience)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Expirience = expirience;
            

        }



    }
}
