using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Common;

namespace Socrat.Core.Entities.Transformations
{
    [EntityFormConfiguration("Преобразования", "Преобразование: {Title}")]
    [PropertyVisualisation("Название", "Name", 100, 0)]
    [PropertyVisualisation("Подстановка", "Value", 100, 40)]
    [PropertyVisualisation("Примечание", "Comments", 300, 50)]
    public class MaterialNomTransformationRule : Entity
    {
        #region Locals

        private MaterialNom _MaterialNom;
        private TransformationRule _TransformationRule;
        private string _Value;
        private string _Comments;
        #endregion

        #region Properties

        /// <summary>
        /// Правило преобразования
        /// </summary>
        [ParentItem]
        public virtual TransformationRule TransformationRule
        {
            get => _TransformationRule;
            set => SetField(ref _TransformationRule, value, () => TransformationRule);
        }
        /// <summary>
        /// Номенклатура материала
        /// </summary>
        [ParentItem]
        public virtual MaterialNom MaterialNom
        {
            get => _MaterialNom;
            set => SetField(ref _MaterialNom, value, () => MaterialNom);
        }
        /// <summary>
        /// Значение подстановки
        /// </summary>
        public string Value
        {
            get => _Value;
            set => SetField(ref _Value, value, () => Value);
        }
        /// <summary>
        /// Примечание
        /// </summary>
        public string Comments
        {
            get => _Comments;
            set => SetField(ref _Comments, value, () => Comments);
        }
        #endregion

        #region Foreign keys
        public Guid MaterialNomId {get; set;}

        public Guid TransformationRuleId { get; set; }
        #endregion

        #region ViewModel props
        [NotMapped]
        public string Name
        {
            get => 
                TransformationRule == null 
                ? "Ошибка. Нет ссылки на правило преобразования" 
                : $"{TransformationRule}";
        }

        #endregion

        #region Overrides
        public override string ToString()
        {
            return TransformationRule == null ? "Новое" : $"{TransformationRule}";
        }

        protected override string GetTitle()
        {
            return ToString();
        }

        public override ValidationResult Validate(ValidationStage stage, object ownedList)
        {
            if (!(ownedList is List<MaterialNomTransformationRule> list))
                throw new Exception("Предоставленный родительский список пуст или не является типом List<Bank>");


            if (stage == ValidationStage.OnAdd || stage == ValidationStage.OnEdit)
            {

                if (list.Exists(x => x.Id != this.Id 
                                     && x.MaterialNom.Id == MaterialNom.Id 
                                     && x.TransformationRule.Id == TransformationRule.Id))
                    return new ValidationResult(
                        ValidationState.Failed,
                        ReportType.MessageBox,
                        "Добавление отменено. Для данного материала уже существует правило трансформации этого типа");
            }

            return new ValidationResult(ValidationResult.Success);
        }

        #endregion

        #region DB context config

        public class Configuration : EntityTypeConfiguration<MaterialNomTransformationRule>
        {
            public Configuration()
            {
                ToTable("MaterialNomTransformationRule");
                HasKey(p => p.Id);
                Property(p => p.MaterialNomId).HasColumnName("MaterialNomId").IsRequired();
                Property(p => p.TransformationRuleId).HasColumnName("TransformationRuleId").IsRequired();
                Property(p => p.Value).HasColumnName("Value").HasMaxLength(50).IsRequired();
                Property(p => p.Comments).HasColumnName("Comments").HasMaxLength(1024).IsOptional();
            }
        }

        #endregion
    }
}
