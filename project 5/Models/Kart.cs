using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_5.Models
{
    public class Kart
    {
        public int Id {get;set;}
        public string Name{get;set;}
        public string Size{get;set;}
        
        // public string Type{get;set;}
        public bool IsAvailable{get;set;}
    }
}