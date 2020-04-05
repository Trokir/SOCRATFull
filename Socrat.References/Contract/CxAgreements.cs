using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.DataProvider;

namespace Socrat.References.Contract
{
    public partial class CxAgreements : DevExpress.XtraEditors.XtraUserControl
    {
        public Core.Entities.Contract Contract { get; set; }
        private List<Socrat.Core.Entities.PaymentType> _paymentTypes;

        public CxAgreements()
        {
            InitializeComponent();

            Load += CxAgreements_Load;
        }

        private void CxAgreements_Load(object sender, EventArgs e)
        {
            using (DataFactory _factory = new DataFactory())
            {
                IRepository<PaymentType> _ptRepo = _factory.CreateRepository<IRepository<PaymentType>>();
                _paymentTypes = _ptRepo.GetAll().ToList();
            }

            luePaymentType.Properties.DataSource = _paymentTypes;
            luePaymentType.EditValue = Contract.PaymentTypeId ?? _paymentTypes.FirstOrDefault()?.Id;

            BindData();
        }

        private PaymentType GetPaymentType(PaymentTypeEnum paymentTypeEnum)
        {
            if (_paymentTypes == null || _paymentTypes.Count < 1)
                using (DataFactory _factory = new DataFactory())
                {
                    IRepository<PaymentType> _ptRepo = _factory.CreateRepository<IRepository<PaymentType>>();
                    _paymentTypes = _ptRepo.GetAll().ToList();
                }

            return _paymentTypes.FirstOrDefault(x => x.PaymentTypeEnum == paymentTypeEnum);
        }

        private void BindData()
        {
            BindEditor(teBeforeDay, Contract, x => x.PaymentBeforeDay);
            BindEditor(teBeforePercent, Contract, x => x.PaymentBeforePercent);
            BindEditor(teBeforeAmount, Contract, x => x.PaymentBeforeAmount);
            BindEditor(teReadyPercent, Contract, x => x.PaymentReadyPercent);
            BindEditor(teReadyAmount, Contract, x => x.PaymentReadyAmount);
            BindEditor(teAfterDay, Contract, x => x.PaymentAfterDay);
            BindEditor(teCreditLimit, Contract, x => x.PaymentCreditLimit);
            BindEditor(teBillValidity, Contract, x => x.BillValidityPeriod);
            BindEditor(teChangeDayInfo, Contract, x => x.PriceChangeDayInfo);
            BindEditor(teDaysProduct, Contract, x => x.DaysForProduct);

            teDateTransferTime.Time = DateTime.Today + (Contract.DateTransferTime ?? TimeSpan.Zero);
        }

        /// <summary>
        /// Привязка данных через люмбда-синтаксис
        /// </summary>
        /// <typeparam name="T">тиб обякта данных</typeparam>
        /// <typeparam name="P">тип свойства объекта данных</typeparam>
        /// <param name="editor">редактор</param>
        /// <param name="obj">объект данных</param>
        /// <param name="selectorExpression">лямбда-селестор свойства объекта данных</param>
        public void BindEditor<T, P>(BaseEdit editor, T obj, Expression<Func<T, P>> selectorExpression) where T : class
        {
            if (selectorExpression == null)
                throw new ArgumentNullException("selectorExpression");
            var me = selectorExpression.Body as MemberExpression;

            //внутри функции могут быть вложены свойства равные null
            if (me == null)
            {
                var ue = selectorExpression.Body as UnaryExpression;
                if (ue != null)
                    me = ue.Operand as MemberExpression;
            }

            if (me == null)
                throw new ArgumentException("Тело должно содержать Выражение(Expression)");
            editor.DataBindings.Clear();
            editor.DataBindings.Add("EditValue", obj, me.Member.Name, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void luePaymentType_EditValueChanged(object sender, EventArgs e)
        {
            Guid _id;
            if (luePaymentType.EditValue != null && Guid.TryParse(luePaymentType.EditValue.ToString(), out _id))
            {
                Contract.PaymentType = _paymentTypes.FirstOrDefault(x => x.Id == _id);

                PaymentTypeEnum _paymentType = _paymentTypes.FirstOrDefault(x => x.Id == _id)?.PaymentTypeEnum ?? PaymentTypeEnum.None;

                bool _mixNprepay = _paymentType == PaymentTypeEnum.Mixed || _paymentType == PaymentTypeEnum.Prepay;
                meAgreement.Enabled = _mixNprepay;
                teBeforeDay.Enabled = _mixNprepay;
                teBeforePercent.Enabled = _mixNprepay;
                teBeforeAmount.Enabled = _mixNprepay;

                bool _mixed = _paymentType == PaymentTypeEnum.Mixed;
                meAgreement2.Enabled = _mixed;
                teReadyPercent.Enabled = _mixed;
                teReadyAmount.Enabled = _mixed;

                bool _postNmix = _paymentType == PaymentTypeEnum.PostPay || _paymentType == PaymentTypeEnum.Mixed;
                meAgreement3.Enabled = _postNmix;
                teAfterDay.Enabled = _postNmix;
                teCreditLimit.Enabled = _postNmix;
            }
        }

        private void teDateTransferTime_EditValueChanged(object sender, EventArgs e)
        {
            Contract.DateTransferTime = teDateTransferTime.Time.TimeOfDay;
        }
    }
}
