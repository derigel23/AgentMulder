﻿using System.Collections.Generic;
using AgentMulder.ReSharper.Domain.Search;

namespace AgentMulder.ReSharper.Domain.Containers
{
    public interface IContainerInfo
    {
        string ContainerDisplayName { get; }
        IEnumerable<IRegistrationPattern> RegistrationPatterns { get; }
    }
}