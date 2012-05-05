using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.DocumentModel;

namespace AgentMulder.ReSharper.Domain.Registrations
{
    public abstract class BasedOnRegistrationBase : ComponentRegistrationBase
    {
        protected readonly IEnumerable<WithServiceRegistration> withServices;

        public IModule Module { get; set; }

        protected BasedOnRegistrationBase(ITreeNode registrationRootElement, IEnumerable<WithServiceRegistration> withServices)
            : base(registrationRootElement)
        {
            this.withServices = withServices.ToArray();
        }
    }
}