using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp.Tree;

namespace AgentMulder.ReSharper.Domain.Modules
{
    public interface IModuleExtractor
    {
        IPsiModule GetTargetModule(ICSharpExpression expression);
    }
}