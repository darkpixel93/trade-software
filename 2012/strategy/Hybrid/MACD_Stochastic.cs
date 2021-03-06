﻿//Copyright by NHQ, HCM city, 2011 
using application.Strategy;
using commonClass;
using commonTypes;

namespace Strategy
{
    public class MACD_Stochastic_Helper : baseHelper
    {
        public MACD_Stochastic_Helper() : base(typeof(MACD_Stochastic)) { }
    }    

    public class MACD_Stochastic : GenericStrategy
    {
        protected override void StrategyExecute()
        {
            DataSeries sma20 = Indicators.SMA.Series(data.Close, parameters[0], "");

            Indicators.MACD macd = Indicators.MACD.Series(data.Close, parameters[1], parameters[2],
                parameters[3], "");

            Indicators.Stoch stoch = Indicators.Stoch.Series(data.Bars, parameters[4], parameters[5],
                parameters[6], "");

            DataSeries line1 = stoch.SlowKSeries;
            DataSeries line2 = stoch.SlowDSeries;

            double delta = 0, lastDelta = 0;
            bool upTrend = false;

            AppTypes.MarketTrend stochasticTrend = AppTypes.MarketTrend.Unspecified;

            for (int idx = 1; idx < macd.Values.Length; idx++)
            {
                delta = (macd.HistSeries[idx] - macd.HistSeries[idx - 1]);
                stochasticTrend = ((line1[idx] > line2[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                upTrend = (data.Close[idx] > sma20[idx] ? true : false);
                if (upTrend && delta > 0 && lastDelta < 0 && stochasticTrend == AppTypes.MarketTrend.Upward)
                    BuyAtClose(idx);

                if (is_bought && stochasticTrend == AppTypes.MarketTrend.Downward)
                    SellAtClose(idx);
                lastDelta = delta;
            }
        }
    }

    
}
