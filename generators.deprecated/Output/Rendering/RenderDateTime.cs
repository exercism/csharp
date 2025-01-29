﻿using System;

namespace Exercism.CSharp.Output.Rendering;

internal partial class Render
{
    public string DateTime(DateTime dateTime) =>
        dateTime.Hour == 0 && dateTime.Minute == 0 && dateTime.Second == 0
            ? $"new DateTime({dateTime.Year}, {dateTime.Month}, {dateTime.Day})"
            : $"new DateTime({dateTime.Year}, {dateTime.Month}, {dateTime.Day}, {dateTime.Hour}, {dateTime.Minute}, {dateTime.Second})";
}