using DevExpress.XtraEditors.DXErrorProvider;
using Socrat.Core;

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Socrat.Shape.Factory
{
    public class ShapeCurrentState : Entity
    {  
        private int _CatalogNumber;


        [DisplayName("Номер в каталоге")]
        [Description("Технологические особенности")]
        [ReadOnly(false)]
        [Category("Kаталог")]
        [Required(AllowEmptyStrings = false)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Номер может быть только числом"), Range(0, 1000)]
        public int CatalogNumber
        {
            get { return _CatalogNumber; }
            set
            {
                
                SetField(ref _CatalogNumber, value, () => CatalogNumber);
            }
        }


       
       
    }
}
