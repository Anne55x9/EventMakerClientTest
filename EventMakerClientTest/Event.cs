﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMakerClientTest
{
    public class Event
    {
        public int Id { get; set; }

       
        public string Name { get; set; }

 
        public string Description { get; set; }

      
        public string Place { get; set; }


        public DateTime Date { get; set; }


        public override string ToString()
        {
            return "navn: " + Name + "Beskrivelse: " + Description;
        }
    }
}
