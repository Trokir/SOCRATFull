using DevExpress.XtraEditors;
using Socrat.Common;
using Socrat.Log;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Socrat.Core.Helpers
{
    public class ValidationHelper
    {
        public static bool Validate<T>(
            ValidationStage stage, 
            IEntity entity, 
            object listObject /*, Action action*/, 
            ReportType reportType = ReportType.MessageBox)
        {
            //if (!(listObject is List<T> list))
               // throw new Exception($"Невозможно валидировать сущность {entity} поскольку родительский список отсутствует или не является типом List<IEntity>");

            ValidationResult result = entity.Validate(stage, listObject);

            if (result == ValidationResult.Success)
                return true;

            if (reportType == ReportType.Exception)
                throw new Exception(result.Message);

            if (reportType == ReportType.MessageBox)
                XtraMessageBox.Show(result.Message, "Ошибка валидации!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            else if (reportType == ReportType.Log)
                Logger.AddError(result.Message);
            return false;
            }
    }
}
