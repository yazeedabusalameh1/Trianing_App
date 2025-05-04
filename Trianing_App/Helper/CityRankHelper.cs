namespace Trianing_App.Helper
{
    public class CityRankHelper
    {
        public static int CalculateRank(int? population)
        {
            

            if (population > 2000)
                return 3;
            else if (population > 1000)
                return 2;
            else if(population <1000)
                return 1;
            else
                return 0;
        }
    }
}

