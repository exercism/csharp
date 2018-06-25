﻿using System.Collections.Generic;
using Exercism.CSharp.Output.Templates;

namespace Exercism.CSharp.Output
{
    public class TestClass
    {
        private const string TemplateName = "TestClass";

        public string Exercise { get; set; }
        public string ClassName { get; set; }
        public string CanonicalDataVersion { get; set; }
        public ICollection<string> Methods { get; set; }
        public ISet<string> Namespaces { get; set; }
        public bool IsDisposable { get; set; }

        public string Render() => TemplateRenderer.RenderPartial(TemplateName, new { ClassName, CanonicalDataVersion, Methods, Namespaces, IsDisposable });
    }
}