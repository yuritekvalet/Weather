using System.Collections.Generic;

namespace OpenweathermapDLL
{
    public class List
    {
        public Temp Temp { get; set; }
        public int Humidity { get; set; }

        public string Pressure { get; set; }
        public List<Weather> Weather { get; set; }
    }
}
