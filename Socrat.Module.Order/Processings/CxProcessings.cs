using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.Lib.Commands;
using Socrat.References;
using Socrat.References.Processings;

namespace Socrat.Module.Order.Processings
{
    public partial class CxProcessings : CxGenericListTable<FormulaItemProcessing>
    {
        public CxProcessings()
        {
            InitializeComponent();
        }

        public event EventHandler NeedViewUpdate;

        public FormulaItem FormulaItem { get; set; }
        public OrderRow OrderRow { get; set; }

        protected override void InitColumns()
        {
            AddColumn("Операции", "Title", 200, 0);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxProcessingEdit();
        }

        protected override FormulaItemProcessing GetNewInstance()
        {
            return new FormulaItemProcessing();
        }

        protected override void InitCommands()
        {
            _commands = new List<ReferenceCommand>
            {
                new ReferenceCommand(MenuCommandType.Item, "Просмотр", OpenItemExecute, null)
                    {Image = Properties.Resources.preview_16x16},
                new ReferenceCommand(MenuCommandType.Item, "Добавить", AddItemExecute, null)
                    {Image = Properties.Resources.addfile_16x16, IsWriteCommand = true},
                new ReferenceCommand(MenuCommandType.Item, "Удалить", DeleteItemExecute, null)
                    {Image = Properties.Resources.deletelist_16x16, IsWriteCommand = true},
            };
        }

        protected override ObservableCollection<FormulaItemProcessing> GetItems()
        {
            return FormulaItem.FormulaItemProcessings;
        }

        protected override void AddItem()
        {
            FxMaterialProcessings _fx = new FxMaterialProcessings();
            _fx.SetSingleSelectMode(null);
            _fx.MaterialEnum = FormulaItem.MaterialEnum;
            _fx.ItemSelected += (sender, args) =>
            {
                var processing = _fx.SelectedItem as Processing;
                FormulaItemProcessing _itemProcessing =
                    FormulaItemProcessingBuilder.CreateByProcessing(processing, this.FormulaItem);
                if (!Items.Contains(_itemProcessing))
                    Items.Add(_itemProcessing);
                RefreshData();
                OnNeedViewUpdate();
            };
            _fx.ItemMultiSelected += (sender, args) =>
            {
                foreach (var processing in _fx.SelectedItems)
                {
                    FormulaItemProcessing _itemProcessing =
                        FormulaItemProcessingBuilder.CreateByProcessing(processing, this.FormulaItem);
                    if (!Items.Contains(_itemProcessing))
                    {
                        Items.Add(_itemProcessing);
                    }

                    RefreshData();
                }
                OnNeedViewUpdate();
            };
            OnDialogOutput(_fx, DialogOutputType.Dialog);

        }

        protected override void OpenItem()
        {
            FormulaItemProcessing _itemProcessing = Items.FirstOrDefault(x => x.Id == GetCurrentRowId()) as FormulaItemProcessing;
            switch (_itemProcessing.Enumerator)
            {
                case FormulaItemProcessingEnum.SurfaseProcessing:
                    FxSurfaceCoverProtectionEdit _fxs = new FxSurfaceCoverProtectionEdit();
                    _fxs.SurfaseProcessing = _itemProcessing as SurfaseProcessing;
                    _fxs.OrderRow = OrderRow;
                    _fxs.DialogOutput += _fx_DialogOutput; ;
                    OnDialogOutput(_fxs, DialogOutputType.Dialog);
                    break;
                case FormulaItemProcessingEnum.СomponentsProcessing:
                    FxFormulaItemProcessingComponents _fxc = new FxFormulaItemProcessingComponents();
                    _fxc.FormulaItemProcessing = _itemProcessing;
                    _fxc.DialogOutput += _fx_DialogOutput;
                    OnDialogOutput(_fxc, DialogOutputType.Dialog);
                    break;
                case FormulaItemProcessingEnum.SideProcessing:
                    FxSideProcessing _fxSide = new FxSideProcessing();
                    _fxSide.OrderRow = OrderRow;
                    _fxSide.SideProcessing = _itemProcessing as SideProcessing;
                    _fxSide.DialogOutput += _fx_DialogOutput;
                    OnDialogOutput(_fxSide, DialogOutputType.Dialog);
                    break;
                case FormulaItemProcessingEnum.EdgeProcessing:
                    FxEdgeProcessingEdit _fxEdge = new FxEdgeProcessingEdit();
                    _fxEdge.OrderRow = OrderRow;
                    _fxEdge.FormulaItemProcessing = _itemProcessing as EdgeProcessing;
                    _fxEdge.DialogOutput += _fx_DialogOutput;
                    OnDialogOutput(_fxEdge, DialogOutputType.Dialog);
                    break;
            }
        }

        private void _fx_DialogOutput(object sender, WindowOutputEventArgs e)
        {
            OnDialogOutput(e);
        }

        private void OnNeedViewUpdate()
        {
            NeedViewUpdate?.Invoke(this, EventArgs.Empty);
        }

        protected override void CustomKeyDown(Keys keys)
        {
        }
    }
}
