﻿using PrAnalyzer.Contracts.Enum;

namespace PrAnalyzer.Contracts.Interface
{
    public interface IProduct
    {
        string Name { get; }
        ProductType Type { get; }
    }
}
