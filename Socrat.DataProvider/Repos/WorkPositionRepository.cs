using Socrat.Core.Entities;

namespace Socrat.DataProvider.Repos
{
    internal class WorkPositionRepository : UniversalRepository<WorkPosition>
    {
    }

    /*
    internal class WorkPositionRepository : BaseRepository<Socrat.Model.WorkPosition>
    {
        public override void Save(Model.WorkPosition entity)
        {
            DataProvider.WorkPosition _item;
            Mapper.Initialize(MapperConfig.CfgDesc);
            if (entity.Id < 1)
            {
                _item = Mapper.Map<Model.WorkPosition, DataProvider.WorkPosition>(entity);
                _socratEntities.WorkPositions.Add(_item);
            }
            else
            {
                _item = _socratEntities.WorkPositions.FirstOrDefault(x => x.Id == entity.Id);
                Mapper.Map<Model.WorkPosition, DataProvider.WorkPosition>(entity, _item);
            }
            _socratEntities.SafetySaveChanges();

            entity.Id = _item.Id;
            entity.Changed = false;
        }

        public override Model.WorkPosition Revert(Model.WorkPosition entity)
        {
            Model.WorkPosition _res = GetItem(entity.Id);
            return _res;
        }

        public override void Delete(long id)
        {
            DataProvider.WorkPosition _item =
                _socratEntities.WorkPositions.FirstOrDefault(x => x.Id == id);
            if (_item != null)
            {
                _socratEntities.WorkPositions.Remove(_item);
                _socratEntities.SafetySaveChanges();
            }
        }

        public override Model.WorkPosition GetItem(long id)
        {
            Model.WorkPosition _item;
            Mapper.Initialize(MapperConfig.Cfg);
            _item = Mapper.Map<DataProvider.WorkPosition, Model.WorkPosition>(
                _socratEntities.WorkPositions.FirstOrDefault(x => x.Id == id));
            _item.Changed = false;
            return _item;
        }

        public override IEnumerable<Model.WorkPosition> GetAll()
        {
            Mapper.Initialize(MapperConfig.Cfg);
            List<Model.WorkPosition> _list =
                Mapper.Map<DbSet<DataProvider.WorkPosition>, List<Model.WorkPosition>>(_socratEntities.WorkPositions);
            _list.ForEach(x => x.Changed = false);
            return _list;
        }
    }
    */
}