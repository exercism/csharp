using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Generators.Input
{
    public class CanonicalDataCase
    {
        public IDictionary<string, dynamic> Properties { get; set; }
        public IDictionary<string, dynamic> Input { get; set; }
        public dynamic Expected { get; set; }

        public string Property { get; set; }
        public string Description { get; set; }
        public string[] DescriptionPath { get; set; }

        public bool UseVariablesForInput { get; set; }
        public bool UseVariableForExpected { get; set; }
        public bool UseVariablesForConstructorParameters { get; set; }
        public bool UseVariableForTested { get; set; }
        public bool UseFullDescriptionPath { get; set; }

        public TestedMethodType TestedMethodType { get; set; }
        public Type ExceptionThrown { get; set; }

        public HashSet<string> InputParameters { get; } = new HashSet<string>();
        public HashSet<string> ConstructorInputParameters { get; } = new HashSet<string>();

        public void SetInputParameters(params string[] properties)
        {
            InputParameters.Clear();
            InputParameters.UnionWith(properties);

            ConstructorInputParameters.ExceptWith(properties);
        }

        public void SetConstructorInputParameters(params string[] properties)
        {
            ConstructorInputParameters.Clear();
            ConstructorInputParameters.UnionWith(properties);

            InputParameters.ExceptWith(properties);

            TestedMethodType = TestedMethodType.Instance;
        }
    }
}