using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Socrat.Lib;

namespace Socrat.Model
{
    /// <summary>
    /// Базовый класс реализации INotifyPropertyChanged
    /// </summary>
    public abstract class PropertyChangedBase : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool _Changed;
        [Browsable(false)]
        public bool Changed
        {
            get { return GetChanged(); }
            set { SetChanged(value); }
        }

        private void SetChanged(bool value)
        {
            _Changed = value;
            //если value = false
            //устанавливаем Changed = false всем дочерним объектам и коллекциям 
            if (!value)
                SetHostedEntitiesChangeValue(value);
            OnPropertyChanged("Changed");
        }

        /// <summary>
        /// Устанавливаем всем Changed по-тихому не отправляя обратные уведомления
        /// </summary>
        /// <param name="value"></param>
        public void SetChangedSilent(bool value)
        {
            _Changed = value; 
            if (!value)
                SetHostedEntitiesChangeValue(value);
        }

        protected virtual bool GetChanged()
        {
            return _Changed;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
            //System.Diagnostics.Debug.Print("Изменено поле: " + propertyName);
        }

        protected void OnPropertyChanged<T>(Expression<Func<T>> selectorExpression)
        {
            if (selectorExpression == null)
                throw new ArgumentNullException("selectorExpression");
            var me = selectorExpression.Body as MemberExpression;

            // Nullable properties can be nested inside of a convert function
            if (me == null)
            {
                var ue = selectorExpression.Body as UnaryExpression;
                if (ue != null)
                    me = ue.Operand as MemberExpression;
            }

            if (me == null)
                throw new ArgumentException("The body must be a member expression");

            OnPropertyChanged(me.Member.Name);
        }

        protected void SetField<T>(ref T field, T value, Expression<Func<T>> selectorExpression, params Expression<Func<object>>[] additonal)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return;
            Entity _entity = value as Entity;
            if (null != _entity)
            {
                Entity _field= field as Entity;
                if (_field != null && _field.Id == _entity.Id)
                {
                    field = value;
                    return;
                }
            }

            //System.Diagnostics.Debug.Print(String.Format("Значение: {0}", value));
            field = value;
            OnPropertyChanged(selectorExpression);
            _Changed = true;
            OnPropertyChanged(() => Changed);
            foreach (var item in additonal)
                OnPropertyChanged(item);
        }

        private void SetHostedEntitiesChangeValue(bool state)
        {
            //проход по полям типа IEntity
            IEnumerable<FieldInfo> _fields =
                this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .ToList().Where(x => x.FieldType.GetInterfaces().Contains(typeof(IEntity)));
            IEntity _entity;
            foreach (FieldInfo field in _fields)
            {
                _entity = field.GetValue(this) as IEntity;
                if (null == _entity)
                    break;
                if (_entity.Changed != state)
                    _entity.SetChangedSilent(state);
            }

            //проход по коллекциям IEntity
            _fields =
                this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .ToList().Where(x => x.FieldType.GetInterfaces().Contains(typeof(IList)));
            IEnumerable<IEntity> _entityCollection;
            foreach (FieldInfo field in _fields)
            {
                _entityCollection = field.GetValue(this) as IEnumerable<IEntity>;
                if (null == _entityCollection)
                    continue;
                foreach (IEntity entity in _entityCollection)
                {
                    if (null != entity)
                        entity.SetChangedSilent(state);
                }
            }
        }
    }
}
