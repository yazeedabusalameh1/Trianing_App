


using Trianing_App.GlobalConstant;

namespace Trianing_App.Helper

{
    public class CityRankHelper

    {
       

       
        public static  int CalculateRank(int? population)
        {


            if (population > 2000)
                return Constant.rankCon.Gold;
            else if (population > 1000)
                return Constant.rankCon.Silver;
            else if (population < 1000)
                return Constant.rankCon.Bronze;
            else
                return 0;
        }
    }
}

