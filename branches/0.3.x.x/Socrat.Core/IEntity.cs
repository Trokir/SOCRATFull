using System;
using System.Collections.Generic;

namespace Socrat.Core
{
    public interface IEntity: IDisposable
    {
        Guid Id { get; set; }

        List<IEntity> ParentEntities { get; set; }
        void SetParentsChanged(bool state);


        bool Changed { get; set; }
        string Title { get; }
        void SetChangedSilent(bool state);
    }
}
