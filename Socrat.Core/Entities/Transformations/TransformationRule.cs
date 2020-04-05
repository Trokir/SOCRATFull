using Socrat.Common;
using Socrat.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;

namespace Socrat.Core.Entities.Transformations
{
    [EntityFormConfiguration("Правила преобразования", "Правило преобразования: {Title}")]
    [PropertyVisualisation("Название", "TransformationName", 100, 0)]
    [PropertyVisualisation("Длина", "Length", 30, 10, false, DevExpress.Utils.HorzAlignment.Center)]
    [PropertyVisualisation("Caps", "CapsMode", 100, 20, false, DevExpress.Utils.HorzAlignment.Center)]
    [PropertyVisualisation("Язык", "CharSet", 100, 30, false, DevExpress.Utils.HorzAlignment.Center)]
    [PropertyVisualisation("Символы", "ContType", 100, 40, false, DevExpress.Utils.HorzAlignment.Center)]
    [PropertyVisualisation("Примечание", "Comments", 300, 50)]
    public class TransformationRule : Entity
    {
        public TransformationRule()
        {
            Transformations = new AttachedList<MaterialNomTransformationRule>(this);
        }

        #region Locals
        private TransformationRules _Transformation = TransformationRules.Unknown;
        private int _Length;
        private CapitalizationModes _CapitalizationMode = CapitalizationModes.AnyCase;
        private CharacterSets _CharacterSet = CharacterSets.LatinOnly;
        private StringCharacterTypes _CharacterType = StringCharacterTypes.Any;
        private string _Comments;
        #endregion

        #region Properties

        /// <summary>
        /// Название правила
        /// </summary>
        public TransformationRules Transformation
        {
            get => _Transformation;
            set => SetField(ref _Transformation, value, () => Transformation);
        }
        /// <summary>
        /// Максимальная длина результата трансформации
        /// </summary>
        public int Length
        {
            get => _Length;
            set => SetField(ref _Length, value, () => Length);
        }
        /// <summary>
        /// Режим ввода прописные/строчные 
        /// </summary>
        public CapitalizationModes CapitalizationMode
        {
            get => _CapitalizationMode;
            set => SetField(ref _CapitalizationMode, value, () => CapitalizationMode);
        }
        /// <summary>
        /// Язык ввода 
        /// </summary>
        public CharacterSets CharacterSet
        {
            get => _CharacterSet;
            set => SetField(ref _CharacterSet, value, () => CharacterSet);
        }
        /// <summary>
        /// Режим ввода цифры/буквы/все
        /// </summary>
        public StringCharacterTypes CharacterType
        {
            get => _CharacterType;
            set => SetField(ref _CharacterType, value, () => CharacterType);
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

        #region Collections
        public virtual AttachedList<MaterialNomTransformationRule> Transformations { get; }

        #endregion

        #region ViewModel fields

        public string CapsMode
        {
            get
            {
                return
                    _CapitalizationMode == CapitalizationModes.LowerCaseOnly ?
                        "Строчные" :
                    _CapitalizationMode == CapitalizationModes.UpperCaseOnly ?
                        "Прописные" :
                        "Любые";
            }
        }

        public string CharSet
        {
            get
            {
                return
                    _CharacterSet == CharacterSets.LatinOnly ?
                        "Только латинские" :
                        "Любые";
            }
        }

        public string ContType
        {
            get
            {
                return
                    _CharacterType == StringCharacterTypes.Letters ?
                        "Только буквы" :
                     _CharacterType == StringCharacterTypes.Digits ?
                        "Только цифры" :
                    _CharacterType == StringCharacterTypes.DigitsOrLetters ?
                        "Только цифры и буквы" :
                        "Любые";
            }
        }

        public string TransformationName
        {
            get => EnumHelper.GetTransformationRules().FirstOrDefault(x => x.Value == Transformation).Key;
        }

        #endregion

        #region Overrides

        protected override string GetTitle()
        {
            return ToString();
        }

        public override string ToString()
        {
            return TransformationName;
        }

        public override ValidationResult Validate(ValidationStage stage, object ownedList)
        {
            if (!(ownedList is List<TransformationRule> list))
                throw new Exception("Предоставленный родительскийсписок пуст или не является типом List<TransformationRule>");

            if (stage == ValidationStage.OnAdd)
            {
                if (list.Any(x =>
                    x.Transformation == Transformation))
                    return new ValidationResult(
                        ValidationState.Failed,
                        ReportType.MessageBox,
                        "Правило с таким типом трансформации уже содержится в базе данных!");
            }

            if (stage == ValidationStage.OnEdit)
            {
                if (list.Any(x =>
                    x.Id != Id &&
                        x.Transformation == Transformation))
                    return new ValidationResult(
                        ValidationState.Failed,
                        ReportType.MessageBox,
                        "Правило с таким типом трансформации  уже содержится в базе данных!");
            }

            return new ValidationResult(ValidationResult.Success);
        }


        #endregion

        #region DB context config

        public class Configuration : EntityTypeConfiguration<TransformationRule>
        {
            public Configuration()
            {
                ToTable("TransformationRule");
                HasKey(p => p.Id);

                Property(p => p.Transformation).HasColumnName("Transformation").IsRequired();
                Property(p => p.Length).HasColumnName("Length").IsRequired();
                Property(p => p.CapitalizationMode).HasColumnName("Capitalization").IsRequired();
                Property(p => p.CharacterSet).HasColumnName("CharacterSet").IsRequired();
                Property(p => p.CharacterType).HasColumnName("CharacterType").IsRequired();
                Property(p => p.Comments).HasColumnName("Comments").HasMaxLength(1024).IsOptional();

                HasMany(e => e.Transformations)
                   .WithRequired(e => e.TransformationRule)
                   .HasForeignKey(e => e.TransformationRuleId)
                   .WillCascadeOnDelete(true);
            }
        }

        #endregion
    }
}
