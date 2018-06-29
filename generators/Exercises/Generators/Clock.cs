﻿using System.Collections.Generic;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Clock : GeneratorExercise
    {
        private const string ParamClock1 = "clock1";
        private const string ParamClock2 = "clock2";
        private const string ParamHour = "hour";
        private const string ParamMinute = "minute";

        private const string PropertyCreate = "create";
        private const string PropertyEqual = "equal";

        protected override void UpdateTestData(TestData data)
        {
            if (data.Property != PropertyEqual)
            {
                data.SetConstructorInputParameters(ParamHour, ParamMinute);
            }
            else
            {
                data.SetConstructorInputParameters(ParamClock2);

                var result = (Dictionary<string, object>)data.Input[ParamClock1];
                data.Input[ParamClock1] = new UnescapedValue($"new Clock({result[ParamHour]}, {result[ParamMinute]})");
            }

            if (data.Property == PropertyCreate)
            {
                data.TestedMethod = "ToString";
            }
            else if (data.Property == PropertyEqual)
            {
                data.TestedMethod = "Equals";
            }
        }

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert(method);
        }

        private static string RenderAssert(TestMethod method)
        {
            if (method.Data.Property == PropertyEqual)
            {
                return RenderEqualToAssert(method);
            }

            return method.Data.Property != PropertyCreate
                ? RenderConsistencyToAssert(method)
                : method.Assert;
        }

        private static string RenderConsistencyToAssert(TestMethod method) 
            => Assertion.Equal(method.ExpectedParameter, $"{method.TestedValue}.ToString()");

        private static string RenderEqualToAssert(TestMethod method)
        {
            var expected = method.Data.Input[ParamClock1].ToString();

            return method.Data.Expected 
                ? Assertion.Equal(expected, "sut")
                : Assertion.NotEqual(expected, "sut");
        }
    }
}