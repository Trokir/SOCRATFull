using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.DirectX.Common.Direct2D;
using DevExpress.XtraEditors;
using Socrat.Common.UI;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.Lib.Commands;
using Socrat.Log;
using Socrat.References;
using Socrat.References.Processings;

namespace Socrat.Module.Order.Processings
{
    public partial class CxMailCorrespondence : CxGenericListTable<EMail> //XXXX own
    {
        public CxMailCorrespondence()
        {
            InitializeComponent();
            Load += CxProcessings_Load;
            Disposed += CxProcessings_Disposed;
        }
        
        protected override IEntity GetOwner()
        {
            return FormulaItem;
        }

        private void CxProcessings_Load(object sender, EventArgs e)
        {        //    FormulaItem.FormulaItemProcessings.CollectionChanged -= FormulaItemProcessingsOnCollectionChanged;
                 //    FormulaItem.FormulaItemProcessings.CollectionChanged += FormulaItemProcessingsOnCollectionChanged;
            var allMails = DataHelper.GetAll<EMail>();
        }

        private void CxProcessings_Disposed(object sender, EventArgs e)
        {
            //if (FormulaItem != null)
            //{
            //    FormulaItem.FormulaItemProcessings.CollectionChanged -= FormulaItemProcessingsOnCollectionChanged;
            //}
        }

        //private void FormulaItemProcessingsOnCollectionChanged(object sender, CollectionChangedEventArgs<FormulaItemProcessing> e)
        //{
        //    foreach (FormulaItemProcessing addedItems in e.Added)
        //    {
        //        RefrashSequence(addedItems);
        //    }

        //    foreach (FormulaItemProcessing deletedItems in e.Removed)
        //    {
        //        SecuenceList = FormulaItem.FormulaItemProcessings.OrderBy(x => x.Sequence).ToList();
        //    }
        //    for (var i = 0; i < SecuenceList.Count; i++)
        //        SecuenceList[i].Sequence = (short)(i + 1);
        //}

        public event EventHandler NeedViewUpdate;

        public FormulaItem FormulaItem { get; set; }
        public OrderRow OrderRow { get; set; }

        public List<FormulaItemProcessing> SecuenceList = new List<FormulaItemProcessing>();

        protected override void InitColumns()
        {
            AddColumn("Последовательность", "Sequence", 40, 0);
            AddColumn("Операции", "Title", 120, 1);
            AddColumn("Комплектующие", "ComponentsStr", 200, 2);
            SortByColumn("Sequence");
        }

        protected override IEntityEditor GetEditor(OpenMode openMode = OpenMode.Default)
        { 
            return new FxMail();
        }

        protected override EMail GetNewInstance()
        {
            return new EMail() { Loaded = true };
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

        //protected override AttachedList<EMail> GetItems()
        //{
        //    SecuenceList = FormulaItem.FormulaItemProcessings.OrderBy(x => x.Sequence).ToList();
        //    return FormulaItem.FormulaItemProcessings;
        //}


        private void Revert(EMail item)
        {
            try
            {
                Repository.Revert2(item);
            }
            catch (Exception e)
            {
                Logger.AddErrorEx("CxProcessings.Revert", e);
            }
        }

        protected override void OpenItem()
        {
            EMail _itemProcessing = Items.FirstOrDefault(x => x.Id == GetCurrentRowId()) as EMail;
         
            //switch (_itemProcessing.Enumerator)
            //{
            //    case FormulaItemProcessingEnum.SurfaseProcessing:
            //        FxSurfaceCoverProtectionEdit _fxs = new FxSurfaceCoverProtectionEdit();
            //        _fxs.SurfaseProcessing = _itemProcessing as SurfaseProcessing;
            //        _fxs.OrderRow = OrderRow;
            //        _fxs.SaveButtonClick += (sender, args) =>
            //        {
            //            IEntity owner = _fxs.PreviousEditor?.Entity;
            //            args.Cancel = FixEdit(_itemProcessing, owner, args.FromClosing);
            //            if (args.Cancel)
            //                Revert(_itemProcessing);
            //            _fxs.Close();
            //        };
            //        _fxs.DialogOutput += _fx_DialogOutput; ;
            //        OnDialogOutput(_fxs, DialogOutputType.Dialog);
            //        break;
            //    case FormulaItemProcessingEnum.СomponentsProcessing:
            //        FxFormulaItemProcessingComponents _fxc = new FxFormulaItemProcessingComponents();
            //        _fxc.FormulaItemProcessing = _itemProcessing;
            //        _fxc.DialogOutput += _fx_DialogOutput;
            //        _fxc.SaveButtonClick += (sender, args) =>
            //        {
            //            IEntity owner = _fxc.PreviousEditor?.Entity;
            //            args.Cancel = FixEdit(_itemProcessing, owner, args.FromClosing);
            //            if (args.Cancel)
            //                Revert(_itemProcessing);
            //            _fxc.Close();
            //        };
            //        OnDialogOutput(_fxc, DialogOutputType.Dialog);
            //        break;
            //    case FormulaItemProcessingEnum.SideProcessing:
            //        FxSideProcessing _fxSide = new FxSideProcessing();
            //        _fxSide.Row = OrderRow;
            //        _fxSide.SideProcessing = _itemProcessing as SideProcessing;
            //        _fxSide.DialogOutput += _fx_DialogOutput;
            //        _fxSide.SaveButtonClick += (sender, args) =>
            //        {
            //            IEntity owner = _fxSide.PreviousEditor?.Entity;
            //            args.Cancel = FixEdit(_itemProcessing, owner, args.FromClosing);
            //            if (args.Cancel)
            //                Revert(_itemProcessing);
            //            _fxSide.Close();
            //        };
            //        OnDialogOutput(_fxSide, DialogOutputType.Dialog);
            //        break;
            //    case FormulaItemProcessingEnum.EdgeProcessing:
            //        FxEdgeProcessingEdit _fxEdge = new FxEdgeProcessingEdit();
            //        _fxEdge.Row = OrderRow;
            //        _fxEdge.FormulaItemProcessing = _itemProcessing as EdgeProcessing;
            //        _fxEdge.DialogOutput += _fx_DialogOutput;
            //        _fxEdge.SaveButtonClick += (sender, args) =>
            //        {
            //            IEntity owner = _fxEdge.PreviousEditor?.Entity;
            //            args.Cancel = FixEdit(_itemProcessing, owner, args.FromClosing);
            //            if (args.Cancel)
            //                Revert(_itemProcessing);
            //            _fxEdge.Close();
            //        };
            //        OnDialogOutput(_fxEdge, DialogOutputType.Dialog);
            //        break;
            //}
        }

        //private void RefrashSequence(FormulaItemProcessing item)
        //{
        //    if (Items.Count(x => x.Sequence == item.Sequence) > 1)
        //    {
        //        SecuenceList.Remove(item);
        //        if (item.Sequence - 1 < SecuenceList.Count)
        //        {
        //            int _indx = (int)(item.Sequence - 2);
        //            _indx = Math.Max(_indx, 0);
        //            if (_indx < SecuenceList.Count)
        //                SecuenceList.Insert(_indx, item);
        //            else
        //                SecuenceList.Add(item);
        //        }
        //        else
        //            SecuenceList.Add(item);
        //        for (var i = 0; i < SecuenceList.Count; i++)
        //            SecuenceList[i].Sequence = (short)(i + 1);
        //    }
        //}

        //private bool FixEdit(FormulaItemProcessing item, IEntity owner, bool fromClosing)
        //{
        //    bool res = false;
        //    DialogResult _dialogResult = DialogResult.Yes;
        //    if(fromClosing)
        //        _dialogResult = XtraMessageBox.Show("Сохранить изменения?", "Сохранить", MessageBoxButtons.YesNoCancel,
        //            MessageBoxIcon.Question);
        //    if (_dialogResult == DialogResult.Cancel)
        //        return true;

        //    else if(_dialogResult == DialogResult.Yes)
        //        Repository.Save2(item, owner);
        //    else if(_dialogResult == DialogResult.No)            
        //        Repository.Revert2(item);           

            
        //    RefrashSequence(item);
        //    RefreshData();
        //    return res;
        //}

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
