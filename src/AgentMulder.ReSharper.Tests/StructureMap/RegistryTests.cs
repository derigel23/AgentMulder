using System.Linq;
using AgentMulder.Containers.StructureMap;
using AgentMulder.ReSharper.Domain.Containers;
using AgentMulder.ReSharper.Tests.StructureMap.Helpers;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;
using NUnit.Framework;

namespace AgentMulder.ReSharper.Tests.StructureMap
{
    [TestStructureMap]
    public class RegistryTests : ComponentRegistrationsTestBase
    {
        protected override string RelativeTestDataPath
        {
            get { return @"StructureMap\RegistryTests"; }
        }

        protected override string RelativeTypesPath
        {
            get { return @"..\..\Types"; }
        }

        protected override IContainerInfo ContainerInfo
        {
            get { return new StructureMapContainerInfo(); }
        }

        [TestCase("RegistryInstanceConfigure", new[] { "Foo.cs" })]
        [TestCase("ForGenericUseGeneric", new[] { "Foo.cs" })]
        [TestCase("ForGenericUseGenericMultipleStatements", new[] { "Foo.cs", "Bar.cs" })]
        [TestCase("ForGenericUseGenericWithAdditionalParams", new[] { "Foo.cs" })]
        [TestCase("ForNonGenericUseNonGenericType", new[] { "Foo.cs" })]
        public void DoTest(string testName, string[] fileNames)
        {
            RunTest(testName, registrations =>
            {
                ICSharpFile[] codeFiles = fileNames.Select(GetCodeFile).ToArray();

                Assert.AreEqual(codeFiles.Length, registrations.Count());
                foreach (var codeFile in codeFiles)
                {
                    codeFile.ProcessChildren<ITypeDeclaration>(declaration =>
                        Assert.That(registrations.Any((r => r.Registration.IsSatisfiedBy(declaration.DeclaredElement)))));
                }
            });
        }

        [TestCase("RegistryInstanceConfigure", new[] { "Bar.cs" })]
        [TestCase("ForGenericUseGeneric", new[] { "Bar.cs" })]
        [TestCase("ForGenericUseGenericMultipleStatements", new[] { "Baz.cs" })]
        [TestCase("ForGenericUseGenericWithAdditionalParams", new[] { "Bar.cs" })]
        [TestCase("ForNonGenericUseNonGenericType", new[] { "Bar.cs" })]
        public void ExcludeTest(string testName, string[] fileNamesToExclude)
        {
            RunTest(testName, registrations =>
            {
                ICSharpFile[] codeFiles = fileNamesToExclude.Select(GetCodeFile).ToArray();

                CollectionAssert.IsNotEmpty(registrations);
                foreach (var codeFile in codeFiles)
                {
                    codeFile.ProcessChildren<ITypeDeclaration>(declaration =>
                        Assert.That(registrations.All((r => !r.Registration.IsSatisfiedBy(declaration.DeclaredElement)))));
                }
            });
        }
    }
}