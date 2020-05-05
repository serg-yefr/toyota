using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toyota_beta
{
    public class Models
    {

        public string Model { get; set; }
        public string Year { get; set; } 
        public string Type { get; set; }
        public string Price { get; set; }
       
        public List<Cars> Cars { get; set; }

        public int Count
        {
            get
            {
                if (Cars == null)
                    return 0;
                else return Cars.Count;
            }
        }


        public Models(string model, string type, string year, 
        string price, List<Cars> cars)
        {
            Model = model; Year = year; Type = type;
            Price = price; Cars = cars;
        }
        public Models()
        {
            
            Cars = new List<Cars>();
        }
    }
}

