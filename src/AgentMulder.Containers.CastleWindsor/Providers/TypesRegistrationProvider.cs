using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using AgentMulder.Containers.CastleWindsor.Patterns.FromTypes;
using AgentMulder.ReSharper.Domain.Registrations;
using AgentMulder.ReSharper.Domain.Search;

namespace AgentMulder.Containers.CastleWindsor.Providers
{
    [Export]
    [Export(typeof(IRegistrationPatternsProvider))]
    public class TypesRegistrationProvider : IRegistrationPatternsProvider
    {
        private const string TypesFullTypeName = "Castle.MicroKernel.Registration.Types";

        private readonly BasedOnRegistrationProvider basedOnProvider;

        [ImportingConstructor]
        public TypesRegistrationProvider(BasedOnRegistrationProvider basedOnProvider)
        {
            this.basedOnProvider = basedOnProvider;
        }

        public IEnumerable<RegistrationBasePattern> GetRegistrationPatterns()
        {
            var basedOnPatterns = basedOnProvider.GetRegistrationPatterns().ToArray();

            return new FromTypesBasePattern[]
            {
                new From(TypesFullTypeName, basedOnPatterns),
                new FromAssembly(TypesFullTypeName, basedOnPatterns),
                new FromThisAssembly(TypesFullTypeName, basedOnPatterns),
                new FromAssemblyNamed(TypesFullTypeName, basedOnPatterns), 
                new FromAssemblyContainingGeneric(TypesFullTypeName, basedOnPatterns),
                new FromAssemblyContainingNonGeneric(TypesFullTypeName, basedOnPatterns)
            };
        }
    }
}