﻿using DotLiquid;

namespace Exercism.CSharp.Output.Rendering;

internal class UnescapedValue : ILiquidizable
{
    private readonly string _value;

    public UnescapedValue(string value) => _value = value;

    public override string ToString() => _value;

    public object ToLiquid() => _value;
}