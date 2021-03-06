using System.Collections.Generic;
using System.ComponentModel.Composition;
using AgentMulder.Containers.CastleWindsor.Patterns.FromTypes.WithService;
using AgentMulder.ReSharper.Domain.Registrations;
using AgentMulder.ReSharper.Domain.Search;

namespace AgentMulder.Containers.CastleWindsor.Providers
{
    [Export]
    public class WithServicesRegistrationProvider : IRegistrationPatternsProvider
    {
        public IEnumerable<WithServiceRegistrationBasePattern> GetRegistrationPatterns()
        {
            return new WithServiceRegistrationBasePattern[]
            {

            };
        }

        IEnumerable<RegistrationBasePattern> IRegistrationPatternsProvider.GetRegistrationPatterns()
        {
            return GetRegistrationPatterns();
        }
    }
}