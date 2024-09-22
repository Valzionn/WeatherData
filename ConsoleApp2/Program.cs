using System;

public class WeatherData
{
    private double temperature;
    private int humidity;
    private char scale;

    public double Temperature
    {
        get { return temperature; }
        set
        {
            if (scale == 'C' && (value < -60 || value > 60))
            {
                Console.WriteLine("Reading mistake: Temperature seems unrealistic.");
            }
            else if (scale == 'F' && (value < -76 || value > 140))
            {
                Console.WriteLine("Reading mistake: Temperature seems unrealistic.");
            }
            else
            {
                temperature = value;
            }
        }
    }

    public int Humidity
    {
        get { return humidity; }
        set
        {
            if (value < 0 || value > 100)
            {
                Console.WriteLine("Reading mistake: Humidity should be between 0% and 100%.");
            }
            else
            {
                humidity = value;
            }
        }
    }

    public char Scale
    {
        get { return scale; }
        set
        {
            if (value == 'C' || value == 'F')
            {
                scale = value;
            }
            else
            {
                Console.WriteLine("Scale must be 'C' or 'F'.");
            }
        }
    }

    public void Convert()
    {
        if (scale == 'C')
        {
            temperature = (temperature * 9 / 5) + 32;
            scale = 'F';
        }
        else if (scale == 'F')
        {
            temperature = (temperature - 32) * 5 / 9;
            scale = 'C';
        }
    }
}

class Program
{
    static void Main()
    {
        WeatherData weather = new WeatherData();

        weather.Scale = 'C';
        weather.Temperature = 25;
        weather.Humidity = 50;

        Console.WriteLine($"Temperature: {weather.Temperature}°{weather.Scale}");
        Console.WriteLine($"Humidity: {weather.Humidity}%");

        weather.Convert();

        Console.WriteLine($"Converted Temperature: {weather.Temperature}°{weather.Scale}");
    }
}
