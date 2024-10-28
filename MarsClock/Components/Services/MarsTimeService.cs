namespace MarsClock.Components.Services;

public class MarsTimeService
{
    public double GetJulianDateUt(long millis)
    {
        return 2440587.5 + (millis / 8.64e7);
    }
    
    public double GetJulianDateTt(double julianDateUt, double ttMinusUtc)
    {
        return julianDateUt + (ttMinusUtc / 86400.0);
    }

    public double DeltaJ2000(double julianDateTt)
    {
        return julianDateTt - 2451545.0;
    }
    
    public double MarsMeanAnomaly(double deltaJ2000)
    {
        return 19.3871 + (0.52402073 * deltaJ2000);
    }
    
    public double FictionMeanSun(double deltaJ2000)
    {
        return 270.3871 + (0.524038496 * deltaJ2000);
    }
    
    public double EquationOfCenter(double marsMeanAnomaly, double deltaJ2000)
    {
        double perturbers = 0;
        return (10.691 + 3.0e-7 * deltaJ2000) * Math.Sin(marsMeanAnomaly * Math.PI / 180)
               + 0.623 * Math.Sin(2 * marsMeanAnomaly * Math.PI / 180)
               + 0.050 * Math.Sin(3 * marsMeanAnomaly * Math.PI / 180)
               + 0.005 * Math.Sin(4 * marsMeanAnomaly * Math.PI / 180)
               + 0.0005 * Math.Sin(5 * marsMeanAnomaly * Math.PI / 180) + perturbers;
    }

    public double AreocentricSolarLongitude(double alphaFictionMeanSun, double equationOfCenter)
    {
        return alphaFictionMeanSun + equationOfCenter;
    }
    
    public double EquationOfTime(double solarLongitude, double equationOfCenter)
    {
        return 2.861 * Math.Sin(2 * solarLongitude * Math.PI / 180) - 0.071 * Math.Sin(4 * solarLongitude * Math.PI / 180)
            + 0.002 * Math.Sin(6 * solarLongitude * Math.PI / 180) - equationOfCenter;
    }
    
    public double LocalMeanSolarTime(double marsSolDate, double longitude)
    {
        return (marsSolDate * 24) % 24 - (longitude / 15);
    }
    
    public string GetCoordinatedMarsTime(double marsSolDate)
    {
        var marsHours = (marsSolDate * 24) % 24;
        var hours = (int)marsHours;
        var minutes = (int)((marsHours - hours) * 60);
        var seconds = (int)(((marsHours - hours) * 60 - minutes) * 60);

        return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
    }

    public double LocalTrueSolarTime(double localMeanSolarTime, double eot)
    {
        return localMeanSolarTime + (eot / 15);
    }
}
