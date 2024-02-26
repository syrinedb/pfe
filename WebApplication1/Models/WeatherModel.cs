namespace WebApplication1.Models
{
    public class WeatherModel
    {
        public Meteo meteo { get; set; }
        public Hourly_Units hourly_Units { get; set; }

        public Hourly hourly{ get; set; }
        public Modele modele { get; set; }

    }
        public class Meteo
        {
            public float latitude { get; set; }
            public float longitude { get; set; }
            public int forecast_days { get; set; }
            public int past_days { get; set; }

            public float generationtime_ms { get; set; }
            public int utc_offset_seconds { get; set; }
            public string timezone { get; set; }
            public string timezone_abbreviation { get; set; }
            public float elevation { get; set; }
            public Hourly_Units hourly_units { get; set; }
            public Hourly hourly { get; set; }
        }
        public class Hourly_Units
        {
            public string time { get; set; }
            public string temperature_2m { get; set; }
        }

        public class Hourly
        {
            public string[] time { get; set; }
            public float[] temperature_2m { get; set; }
        }
    public class Modele
    {
        public string cardmod { get; set; }
        public void GetMode(string cardmod)
        {
            switch (cardmod)
            {
                case "standard":
                    this.cardmod = "forecast";
                    break;
                case "Germany":
                    this.cardmod = "dwd-icon";
                    break;
                case "NOAA U.S":
                    this.cardmod = "gfs";
                    break;
                case "meteofrance":
                    this.cardmod = "meteofrance";
                    break;
                case "ECMWF":
                    this.cardmod = "ecmwf";
                    break;
                case "JMA Japan":
                    this.cardmod = "jma";
                    break;
                case "MET Norway":
                    this.cardmod = "metno";
                    break;
                case "GEM Canada":
                    this.cardmod = "gem";
                    break;
                case "BOM Australia":
                    this.cardmod = "bom";
                    break;
                case "CMA china":
                    this.cardmod = "cma";
                    break;




            };
        }
    }

}
