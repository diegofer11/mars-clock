namespace MarsClock.Components.Services;

public class MarsTimeService
{
    public static double GetJulianDateUt(long millis)
    {
        return 2440587.5 + (millis / 8.64e7);
    }
    
    public static double GetJulianDateTt(double julianDateUt, double ttMinusUtc)
    {
        return julianDateUt + (ttMinusUtc / 86400.0);
    }

    public static double DeltaJ2000(double julianDateTt)
    {
        return julianDateTt - 2451545.0;
    }
    
    public static double MarsMeanAnomaly(double deltaJ2000)
    {
        return 19.3871 + (0.52402073 * deltaJ2000);
    }
    
    public static double FictionMeanSun(double deltaJ2000)
    {
        return 270.3871 + (0.524038496 * deltaJ2000);
    }
    
    public static double EquationOfCenter(double M, double deltaJ2000)
    {
        double perturbers = 0;
        return (10.691 + 3.0e-7 * deltaJ2000) * Math.Sin(M * Math.PI / 180)
               + 0.623 * Math.Sin(2 * M * Math.PI / 180)
               + 0.050 * Math.Sin(3 * M * Math.PI / 180)
               + 0.005 * Math.Sin(4 * M * Math.PI / 180)
               + 0.0005 * Math.Sin(5 * M * Math.PI / 180) + perturbers;
    }

    public static double AreocentricSolarLongitude(double alphaFictionMeanSun, double equationOfCenter)
    {
        return alphaFictionMeanSun + equationOfCenter;
    }
    
    public static double EquationOfTime(double solarLongitude, double equationOfCenter)
    {
        return 2.861 * Math.Sin(2 * solarLongitude * Math.PI / 180) - 0.071 * Math.Sin(4 * solarLongitude * Math.PI / 180)
            + 0.002 * Math.Sin(6 * solarLongitude * Math.PI / 180) - equationOfCenter;
    }
    
    public static double LocalMeanSolarTime(double marsSolDate, double longitude)
    {
        return (marsSolDate * 24) % 24 - (longitude / 15);
    }

    public static double LocalTrueSolarTime(double localMeanSolarTime, double eot)
    {
        return localMeanSolarTime + (eot / 15);
    }
}
