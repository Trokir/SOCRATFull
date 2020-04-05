using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Socrat.Lib
{
    public interface IEntity: IDisposable
    {
        Guid Id { get; set; }
        IEntity ParentEntity { get; set; }
      
        bool Changed { get; set; }
        string Title { get; }
        void SetChangedSilent(bool state);
        void DependedDelete(IEntity entity);
        List<IEntity> DeletedEntities { get; set; }
    }
}
