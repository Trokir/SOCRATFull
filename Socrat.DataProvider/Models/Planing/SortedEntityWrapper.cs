using System;
using System.Collections;
using System.Collections.Generic;
using Socrat.Common.Enums;
using Socrat.Core.Added;
using Socrat.Core.BL.Planning;

namespace Socrat.Data.Model.Planing
{
    public class SortedEntityWrapper : Entity
    {
        public IEnumerable<SortedEntityWrapper> SubGroups;
        public ICollection<SortedEntityWrapper> TempPropertiesList = new HashSet<SortedEntityWrapper>();
        public static int PiramideCellCount { get; set; }
        public static int A { get; set; }
        public static int A1 { get; set; }
        public static int A2 { get; set; }
        public static int A3 { get; set; }
        public static int A4 { get; set; }
        public static int A5 { get; set; }
        public static int A5ins { get; set; }
        public static int A6 { get; set; }
        public static int B { get; set; }
        public static int B1 { get; set; }
        public static int B2 { get; set; }
        public static int H { get; set; }
        public static int H1 { get; set; }
        public static int H2 { get; set; }
        public static int H3 { get; set; }
        public static int SidesCount { get; set; }


        public object Key { get; set; }
        public int Count { get; set; }
        public IEnumerable Items { get; set; }


        public List<GridSort> GridSorts { get; set; }


        public ICollection<SortedEntityWrapper> CurrentPropertiesList { get; set; }
        public PiramideType PiramideType { get; set; }


        public ProductionTypes ProdType { get; set; }


        public double? Thickness { get; set; }


        public string CustomerAddress { get; set; }
        public int StateCounter { get; set; }
        public string GroupMark { get; set; }
        public int CurrentCounter { get; set; }


        public string Habarites { get; set; }


        public double? Width { get; set; }


        public double? Height { get; set; }


        public double? TrueWidth { get; set; }


        public double? TrueHeight { get; set; }


        public string OrderNum { get; set; }


        public double? Weight { get; set; }


        public string CustomerName { get; set; }
        public string FirstCustType { get; set; }
        public string SecondCustType { get; set; }
        public string ThirdCustType { get; set; }
        public bool? FirstTrash { get; set; }
        public bool? SecondTrash { get; set; }
        public bool? ThirdTrash { get; set; }
        public string FirstNumber { get; set; }
        public string SecondNumber { get; set; }
        public string ThirdNumber { get; set; }
        public BarCodeTypes? BarCodeType { get; set; }
        public double FirstThickness { get; set; }
        public double SecondThickness { get; set; }
        public double ThirdThickness { get; set; }
        public int MainStr { get; set; }
        public int ThingsCount { get; set; }


        public string Formula { get; set; }


        public string Sloz { get; set; }


        public string Pull { get; set; }
        public PoolStartEnum PoolStartState { get; set; }
        public DateTime? PullDate { get; set; }

        public string Pir { get; set; }
        public int Side { get; set; }
        public float Box { get; set; }
        public int Floor { get; set; }
        public bool IsGas { get; set; }
        public string Classification { get; set; }


        public GazState GazState { get; set; }


        public bool IsFilm { get; set; }


        public bool IsShprosses { get; set; }
        public int GasPackages { get; set; }
        public string AllFramesThickness { get; set; }

        public int MaxFrameThickness { get; set; }
        public int LastFrameThickness { get; set; }

        public Guid? OrdRowFormulaId { get; set; }
        public Guid IdentityId { get; set; }

        public string DefGroup { get; set; }

        public OrderRow OrderRow { get; set; }
        public string ModifiedWord { get; set; }
        public string OurBarCode { get; set; }
        public string CustomerBarCode { get; set; }
        public string NumCustomer { get; set; }
        public string Mark { get; set; }
        public string Comment { get; set; }
        public int QueueNum { get; set; }
        public List<OrderRowItem> OrderRowItemsList { get; set; }
        public Pool CurrentPool { get; set; }
        public string FullQueueNumber { get; set; }
    }
}