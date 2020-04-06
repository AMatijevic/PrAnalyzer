using PrAnalyzer.Contracts.Enum;
using PrAnalyzer.Contracts.Interface;
using System;

namespace PrAnalyzer.Core.Services
{
    public class CostCalculator : ICostCalculator
    {
        //Config file or DB storage 
        private const decimal BaseCostPerMonth = 5; // eur
        private const decimal ConsumptionCost = 22; // cent/kWh  
        private const int MonthsInYear = 12;
        private const decimal Limit = 4000; // kWh/year
        private const decimal BasePackageCost = 800; // eur
        private const decimal PackageConsumptionCost = 30; // cent/kWh  ;

        public decimal Calculate(IProduct product, decimal consumption)
        {
            return product.Type switch
            {
                ProductType.Basic => BasicCalculation(consumption),
                ProductType.Package => PackageCalculation(consumption),
                ProductType.None => throw new ArgumentException()
            };
        }

        private decimal BasicCalculation(decimal consumption)
        {
            var baseCost = MonthsInYear * BaseCostPerMonth;
            return baseCost + consumption * (ConsumptionCost / 100);
        }

        private decimal PackageCalculation(decimal consumption)
        {
            return consumption switch
            {
                _ when consumption <= Limit => BasePackageCost,
                _ when consumption > Limit => BasePackageCost + (consumption - Limit) * (PackageConsumptionCost / 100),
            };
        }
    }
}
