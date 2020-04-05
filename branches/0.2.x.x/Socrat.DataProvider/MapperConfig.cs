using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using AutoMapper;
using AutoMapper.Configuration;
using DevExpress.XtraEditors;
using Socrat.Lib;
using Socrat.Model;
using Socrat.Model.Params;

namespace Socrat.DataProvider
{
    public static class MapperConfig
    {
        /// <summary>
        /// Настройка прямого преобразования из ДТО в ViewModel
        /// </summary>
        /// <param name="mapperCfg"></param>
        public static void Cfg(IMapperConfigurationExpression mapperCfg)
        {
            mapperCfg.CreateMap<DataProvider.OPF, Model.OPF>();
            mapperCfg.CreateMap<DataProvider.Country, Model.Country>();
            mapperCfg.CreateMap<DataProvider.Currency, Model.Currency>();
            mapperCfg.CreateMap<DataProvider.Gender, Model.Gender>();
            mapperCfg.CreateMap<DataProvider.CustomerType, Model.CustomerType>();
            mapperCfg.CreateMap<DataProvider.CustomerPropType, Model.CustomerPropType>();
            mapperCfg.CreateMap<DataProvider.CustomerProp, Model.CustomerProp>();
            mapperCfg.CreateMap<DataProvider.Account, Model.Account>()
                .ForMember(x => x.Bank, x => x.MapFrom(m => m.Bank)).MaxDepth(3);
            mapperCfg.CreateMap<DataProvider.Bank, Model.Bank>()
                .ForMember(x => x.Accounts,
                    x => x.MapFrom(m => m.Accounts))
                .ForMember(x => x.Bik, x => x.MapFrom(m => m.Bik)).MaxDepth(3);
            mapperCfg.CreateMap<DataProvider.Customer, Model.Customer>().MaxDepth(4);

            mapperCfg.CreateMap<DataProvider.DocumentType, Model.DocumentType>();
            mapperCfg.CreateMap<DataProvider.DepartmentType, Model.DepartmentType>();
            mapperCfg.CreateMap<DataProvider.ContactType, Model.ContactType>();
            mapperCfg.CreateMap<DataProvider.CoworkerContact, Model.CoworkerContact>().MaxDepth(3);
            mapperCfg.CreateMap<DataProvider.Coworker, Model.Coworker>()
                .ForMember(x => x.Contacts, x => x.MapFrom(m => m.CoworkerContacts));
            mapperCfg.CreateMap<DataProvider.WorkPosition, Model.WorkPosition>();
            mapperCfg.CreateMap<DataProvider.DocumentSignatureType, Model.DocumentSignatureType>();
            mapperCfg.CreateMap<DataProvider.DocumentSignature, Model.DocumentSignature>();
            mapperCfg.CreateMap<DataProvider.DivisionCustomer, Model.DivisionCustomer>();
            mapperCfg.CreateMap<DataProvider.CoworkerPosition, Model.CoworkerPosition>().MaxDepth(2);
            mapperCfg.CreateMap<DataProvider.DivisionContact, Model.DivisionContact>().MaxDepth(2);
            mapperCfg.CreateMap<DataProvider.DivisionSignature, Model.DivisionSignature>().MaxDepth(2);
            mapperCfg.CreateMap<DataProvider.Division, Model.Division>().MaxDepth(3);

            mapperCfg.CreateMap<DataProvider.SlozType, Model.SlozType>();
            mapperCfg.CreateMap<DataProvider.PaymentType, Model.PaymentType>();
            mapperCfg.CreateMap<DataProvider.OrderRowSloz, Model.OrderRowSloz>();
            mapperCfg.CreateMap<DataProvider.OrderRow, Model.OrderRow>().MaxDepth(4);
            mapperCfg.CreateMap<DataProvider.Order, Model.Order>().MaxDepth(2);

            mapperCfg.CreateMap<DataProvider.AppParam, Model.Params.AppParam>()
                .ForMember(x => x.Alias, op => op.ResolveUsing(o => MapToAppParam(o.Alias)));

            mapperCfg.CreateMap<DataProvider.Role, Model.Users.Role>();
            mapperCfg.CreateMap<DataProvider.User, Model.Users.User>();
            mapperCfg.CreateMap<DataProvider.Module, Model.Users.Module>();
            mapperCfg.CreateMap<DataProvider.TreeItemType, Model.Users.TreeItemType>();
            mapperCfg.CreateMap<DataProvider.TreeItem, Model.Users.TreeItem>().MaxDepth(2);

            mapperCfg.CreateMap<DataProvider.RoleTreeItem, Model.Users.RoleTreeItem>().MaxDepth(5);

            mapperCfg.CreateMap<DataProvider.ContractType, Model.ContractType>();
            mapperCfg.CreateMap<DataProvider.Contract, Model.Contract>().MaxDepth(4);

            mapperCfg.CreateMap<DataProvider.ContractShippingSquare, Model.ContractShippingSquare>().MaxDepth(2);
            mapperCfg.CreateMap<DataProvider.ContractTenderFormula, Model.ContractTenderFormula>().MaxDepth(2);

            mapperCfg.CreateMap<DataProvider.AddressContact, Model.AddressContact>().MaxDepth(2);
            mapperCfg.CreateMap<DataProvider.AddressElementType, Model.AddressElementType>();
            mapperCfg.CreateMap<DataProvider.AddressElement, Model.AddressElement>();
            mapperCfg.CreateMap<DataProvider.AddressItem, Model.AddressItem>();
            mapperCfg.CreateMap<DataProvider.Address, Model.Address>()
                .ForMember(x => x.AddressItems, s => s.MapFrom(m => m.AddressItems));
            mapperCfg.CreateMap<DataProvider.ContractAddress, Model.ContractAddress>().MaxDepth(2);
            mapperCfg.CreateMap<DataProvider.CustomerAddress, Model.CustomerAddress>().MaxDepth(2);

            mapperCfg.CreateMap<DataProvider.Measure, Model.Measure>().MaxDepth(1);
            mapperCfg.CreateMap<DataProvider.MaterialType, Model.MaterialType>().MaxDepth(1);
            mapperCfg.CreateMap<DataProvider.Material, Model.Material>().MaxDepth(3);
            mapperCfg.CreateMap<DataProvider.Vendor, Model.Vendor>().MaxDepth(1);
            mapperCfg.CreateMap<DataProvider.Brand, Model.Brand>().MaxDepth(1);
            mapperCfg.CreateMap<DataProvider.TradeMark, Model.TradeMark>().MaxDepth(1);
            mapperCfg.CreateMap<DataProvider.VendorMaterial, Model.VendorMaterial>().MaxDepth(2);
            mapperCfg.CreateMap<DataProvider.VendorMaterialNom, Model.VendorMaterialNom>().MaxDepth(2);
            mapperCfg.CreateMap<DataProvider.MaterialMarkType, Model.MaterialMarkType>().MaxDepth(4);
            mapperCfg.CreateMap<DataProvider.MaterialSizeType, Model.MaterialSizeType>()
                .ForMember(x => x.DefaultMaterialNom, a => a.MapFrom(s => s.MaterialNom))
                .MaxDepth(2);
            mapperCfg.CreateMap<DataProvider.MaterialNom, Model.MaterialNom>().MaxDepth(2);
            mapperCfg.CreateMap<DataProvider.Processing, Model.Processing>().MaxDepth(2);
            mapperCfg.CreateMap<DataProvider.FormulaItem, Model.FormulaItem>()
                .ConstructUsing(FormulaItemCtor)
                .ForMember(x => x.Formula, a => a.Ignore())
                .AfterMap(FormulaItemAfterMap)
                .MaxDepth(4);
            mapperCfg.CreateMap<DataProvider.FormulaItemGlassProperty, Model.FormulaItemGlassProperty>()
                .ForMember(x => x.FormulaItem, a => a.Ignore())
                .MaxDepth(2);
            mapperCfg.CreateMap<DataProvider.FormulaItemFrameProperty, Model.FormulaItemFrameProperty>()
                .ForMember(x => x.FormulaItem, a => a.Ignore())
                .MaxDepth(2);
            mapperCfg.CreateMap<DataProvider.FormulaItemTriplexProperty, Model.FormulaItemTriplexProperty>()
                .ForMember(x => x.FormulaItem, a => a.Ignore())
                .MaxDepth(2);
            mapperCfg.CreateMap<DataProvider.Formula, Model.Formula>().MaxDepth(6);
            mapperCfg.CreateMap<DataProvider.Shape, Model.Shapes.Shape>().MaxDepth(6);
            mapperCfg.CreateMap<DataProvider.ShapePoint, Model.Shapes.CustomPoint>().MaxDepth(6);


        }

        private static void FormulaItemAfterMap(FormulaItem source, Model.FormulaItem target)
        {
            MaterialEnum _material = EnumHelper<MaterialEnum>.Parse(source?.Material.EnumCode);
            switch (_material)
            {
                case MaterialEnum.Glass:
                    Model.GlassItem _glassItem = target as Model.GlassItem;
                    if (_glassItem != null)
                    {
                        Mapper.Initialize(MapperConfig.Cfg);
                        _glassItem.FormulaItemGlassProperties =
                            Mapper
                                .Map<ICollection<DataProvider.FormulaItemGlassProperty>,
                                    IEnumerable<Model.FormulaItemGlassProperty>>(source.FormulaItemGlassProperties);
                        if (_glassItem.FormulaItemGlassProperty != null)
                            _glassItem.FormulaItemGlassProperty.FormulaItem = _glassItem;
                    }
                    break;
                case MaterialEnum.Frame:
                    Model.FrameItem _frameItem = target as Model.FrameItem;
                    if (_frameItem != null)
                    {
                        Mapper.Initialize(MapperConfig.Cfg);
                        _frameItem.FormulaItemFrameProperties =
                            Mapper
                                .Map<ICollection<DataProvider.FormulaItemFrameProperty>,
                                    IEnumerable<Model.FormulaItemFrameProperty>>(source.FormulaItemFrameProperties);
                        if (_frameItem.FormulaItemFrameProperty != null)
                            _frameItem.FormulaItemFrameProperty.FormulaItem = _frameItem;
                    }
                    break;
                case MaterialEnum.Film:
                    break;
                case MaterialEnum.Triplex:
                    Model.TriplexItem _triplexItem = target as Model.TriplexItem;
                    if (_triplexItem != null)
                    {
                        Mapper.Initialize(MapperConfig.Cfg);
                        _triplexItem.FormulaItemTriplexProperties =
                            Mapper
                                .Map<ICollection<DataProvider.FormulaItemTriplexProperty>,
                                    IEnumerable<Model.FormulaItemTriplexProperty>>(source.FormulaItemTriplexProperties);
                        if (_triplexItem.FormulaItemTriplexProperty != null)
                            _triplexItem.FormulaItemTriplexProperty.FormulaItem = _triplexItem;
                    }
                    break;
                case MaterialEnum.TriplexFilm:
                    break;
            }
            //Mapper.Initialize(MapperConfig.Cfg);
            //target.Material = Mapper.Map<DataProvider.Material, Model.Material>(source.Material);
        }

        private static Model.FormulaItem FormulaItemCtor(FormulaItem sourceItem)
        {
            Model.FormulaItem resultItem = null;
            MaterialEnum _material = EnumHelper<MaterialEnum>.Parse(sourceItem?.Material.EnumCode);
            switch (_material)
            {
                case MaterialEnum.Glass:
                    resultItem = new GlassItem();
                    break;
                case MaterialEnum.Frame:
                    resultItem = new FrameItem();
                    break;
                case MaterialEnum.Film:
                    resultItem = new FilmItem();
                    break;
                case MaterialEnum.Triplex:
                    resultItem = new TriplexItem();
                    break;
                case MaterialEnum.TriplexFilm:
                    resultItem = new TriplexFilmItem();
                    break;
            }
            return resultItem;
        }

        public static ParamAlias MapToAppParam(string alias)
        {
            return EnumHelper<ParamAlias>.Parse(alias);
        }

        /// <summary>
        /// Настройка обратного преобразования из ViewModel в ДТО
        /// </summary>
        /// <param name="mapperCfg"></param>
        public static void CfgDesc(IMapperConfigurationExpression mapperCfg)
        {
            mapperCfg.CreateMap<Model.OPF, DataProvider.OPF>();
            mapperCfg.CreateMap<Model.Country, DataProvider.Country>();
            mapperCfg.CreateMap<Model.Currency, DataProvider.Currency>();
            mapperCfg.CreateMap<Model.Gender, DataProvider.Gender>();
            mapperCfg.CreateMap<Model.CustomerType, DataProvider.CustomerType>();
            mapperCfg.CreateMap<Model.CustomerPropType, DataProvider.CustomerPropType>();
            mapperCfg.CreateMap<Model.CustomerProp, DataProvider.CustomerProp>();
            mapperCfg.CreateMap<Model.Account, DataProvider.Account>()
                .ForMember(x => x.Bank, x => x.Ignore())
                .ForMember(x => x.Customer, x => x.Ignore())
                .ForMember(x => x.Currency, x => x.Ignore());
            mapperCfg.CreateMap<Model.Bank, DataProvider.Bank>()
                .ForMember(x => x.Accounts,
                    x => x.Ignore()).MaxDepth(2);
            mapperCfg.CreateMap<Model.Customer, DataProvider.Customer>()
                .ForMember(x => x.Country, x => x.Ignore())
                .ForMember(x => x.Currency, x => x.Ignore())
                .ForMember(x => x.OPF, x => x.Ignore())
                .ForMember(x => x.Accounts, x => x.Ignore())
                .MaxDepth(2);

            mapperCfg.CreateMap<Model.DocumentType, DataProvider.DocumentType>();
            mapperCfg.CreateMap<Model.DepartmentType, DataProvider.DepartmentType>();
            mapperCfg.CreateMap<Model.WorkPosition, DataProvider.WorkPosition>();
            mapperCfg.CreateMap<Model.DocumentSignatureType, DataProvider.DocumentSignatureType>();
            mapperCfg.CreateMap<Model.ContactType, DataProvider.ContactType>();
            mapperCfg.CreateMap<Model.CoworkerContact, DataProvider.CoworkerContact>()
                .ForMember(x => x.Coworker, x => x.Ignore())
                .ForMember(x => x.ContactType, x => x.Ignore());
            mapperCfg.CreateMap<Model.CoworkerPosition, DataProvider.CoworkerPosition>()
                .ForMember(x => x.Division, x => x.Ignore())
                .ForMember(x => x.Coworker, x => x.Ignore())
                .ForMember(x => x.WorkPosition, x => x.Ignore());
            mapperCfg.CreateMap<Model.CoworkerPosition, DataProvider.CoworkerPosition>()
                .ForMember(x => x.Coworker, x => x.Ignore())
                .ForMember(x => x.Division, x => x.Ignore())
                .ForMember(x => x.WorkPosition, x => x.Ignore());
            mapperCfg.CreateMap<Model.DivisionSignature, DataProvider.DivisionSignature>()
                .ForMember(x => x.Coworker, x => x.Ignore())
                .ForMember(x => x.Division, x => x.Ignore())
                .ForMember(x => x.DocumentSignatureType, x => x.Ignore())
                .ForMember(x => x.Customer, a => a.Ignore())
                .ForMember(x => x.DocumentType, a => a.Ignore());
            mapperCfg.CreateMap<Model.Coworker, DataProvider.Coworker>()
                .ForMember(x => x.Gender, a => a.Ignore())
                .ForMember(x => x.CoworkerContacts, x => x.MapFrom(m => m.Contacts));
            mapperCfg.CreateMap<Model.DivisionCustomer, DataProvider.DivisionCustomer>()
                .ForMember(x => x.Division, x => x.Ignore())
                .ForMember(x => x.Customer, x => x.Ignore());
            mapperCfg.CreateMap<Model.DivisionContact, DataProvider.DivisionContact>()
                .ForMember(x => x.Division, x => x.Ignore())
                .ForMember(x => x.ContactType, x => x.Ignore())
                .ForMember(x => x.DepartmentType, x => x.Ignore());
            mapperCfg.CreateMap<Model.Division, DataProvider.Division>();

            mapperCfg.CreateMap<Model.PaymentType, DataProvider.PaymentType>();
            mapperCfg.CreateMap<Model.SlozType, DataProvider.SlozType>();
            mapperCfg.CreateMap<Model.OrderRowSloz, DataProvider.OrderRowSloz>();
            mapperCfg.CreateMap<Model.OrderRow, DataProvider.OrderRow>()
                .ForMember(x => x.Order, a => a.Ignore())
                .ForMember(x => x.Formula, a => a.Ignore());
            mapperCfg.CreateMap<Model.Order, DataProvider.Order>()
                .ForMember(x => x.Division, x => x.Ignore())
                .ForMember(x => x.Customer, x => x.Ignore())
                .ForMember(x => x.Account, a => a.Ignore())
                .ForMember(x => x.OrderRows, a => a.Ignore());


            mapperCfg.CreateMap<Model.Params.AppParam, DataProvider.AppParam>()
                .ForMember(x => x.Alias, op => op.ResolveUsing(o => MaoFromParamAlias(o.Alias)));

            mapperCfg.CreateMap<Model.Users.Role, DataProvider.Role>();
            mapperCfg.CreateMap<Model.Users.User, DataProvider.User>()
                .ForMember(x => x.Role, x => x.Ignore());
            mapperCfg.CreateMap<Model.Users.Module, DataProvider.Module>();
            mapperCfg.CreateMap<Model.Users.TreeItemType, DataProvider.TreeItemType>();
            mapperCfg.CreateMap<Model.Users.TreeItem, DataProvider.TreeItem>()
                .ForMember(x => x.ParentTreeItem, x => x.Ignore())
                .ForMember(x => x.Module, x => x.Ignore())
                .ForMember(x => x.TreeItemType, x => x.Ignore())
                .ForMember(x => x.RoleTreeItems, x => x.Ignore());
            mapperCfg.CreateMap<Model.Users.RoleTreeItem, DataProvider.RoleTreeItem>()
                .ForMember(x => x.Role, x => x.Ignore())
                .ForMember(x => x.TreeItem, x => x.Ignore());

            mapperCfg.CreateMap<Model.ContractType, DataProvider.ContractType>();
            mapperCfg.CreateMap<Model.Contract, DataProvider.Contract>()
                .ForMember(x => x.ContractType, x => x.Ignore())
                .ForMember(x => x.Division, x => x.Ignore())
                .ForMember(x => x.Customer, x => x.Ignore())
                .ForMember(x => x.Coworker, x => x.Ignore())
                .ForMember(x => x.PaymentType, x => x.Ignore());

            mapperCfg.CreateMap<Model.ContractShippingSquare, DataProvider.ContractShippingSquare>()
                .MaxDepth(1);
            mapperCfg.CreateMap<Model.ContractTenderFormula, DataProvider.ContractTenderFormula>()
                .ForMember(x => x.Contract, x => x.Ignore());

            mapperCfg.CreateMap<Model.AddressContact, DataProvider.AddressContact>()
                .ForMember(x => x.Address, d => d.Ignore())
                .ForMember(x => x.ContactType, d => d.Ignore())
                .ForMember(x => x.WorkPosition, d => d.Ignore());
            mapperCfg.CreateMap<Model.AddressElementType, DataProvider.AddressElementType>();
            mapperCfg.CreateMap<Model.AddressElement, DataProvider.AddressElement>()
                .ForMember(x => x.AddressElementType, x => x.Ignore());
            mapperCfg.CreateMap<Model.AddressItem, DataProvider.AddressItem>()
                .ForMember(x => x.AddressElement, x => x.Ignore());
            mapperCfg.CreateMap<Model.Address, DataProvider.Address>()
                .ForMember(x => x.Country, x => x.Ignore());
            mapperCfg.CreateMap<Model.ContractAddress, DataProvider.ContractAddress>()
                .ForMember(x => x.Contract, x => x.Ignore())
                .ForMember(x => x.Address, x => x.Ignore());
            mapperCfg.CreateMap<Model.CustomerAddress, DataProvider.CustomerAddress>()
                .ForMember(x => x.Address, d => d.Ignore())
                .ForMember(x => x.Customer, d => d.Ignore());

            mapperCfg.CreateMap<Model.Measure, DataProvider.Measure>()
                .ForMember(x => x.MaterialSizeTypes, d => d.Ignore());
            mapperCfg.CreateMap<Model.MaterialType, DataProvider.MaterialType>()
                .ForMember(x => x.Materials, d => d.Ignore());
            mapperCfg.CreateMap<Model.Material, DataProvider.Material>()
                .ForMember(x => x.MaterialType, d => d.Ignore());
            mapperCfg.CreateMap<Model.Vendor, DataProvider.Vendor>()
                .ForMember(x => x.Brands, d => d.Ignore())
                .ForMember(x => x.VendorMaterialNoms, d => d.Ignore())
                .ForMember(x => x.VendorMaterials, d => d.Ignore());
            mapperCfg.CreateMap<Model.Brand, DataProvider.Brand>()
                .ForMember(x => x.Material, d => d.Ignore())
                .ForMember(x => x.Vendor, d => d.Ignore());
            mapperCfg.CreateMap<Model.TradeMark, DataProvider.TradeMark>()
                .ForMember(x => x.Material, d => d.Ignore())
                .ForMember(x => x.Brand, d => d.Ignore());
            mapperCfg.CreateMap<Model.VendorMaterialNom, DataProvider.VendorMaterialNom>()
                .ForMember(x => x.Brand, d => d.Ignore())
                .ForMember(x => x.Material, d => d.Ignore())
                .ForMember(x => x.TradeMark, d => d.Ignore())
                .ForMember(x => x.Vendor, d => d.Ignore());
            mapperCfg.CreateMap<Model.VendorMaterial, DataProvider.VendorMaterial>()
                .ForMember(x => x.Material, d => d.Ignore())
                .ForMember(x => x.Vendor, d => d.Ignore());
            mapperCfg.CreateMap<Model.MaterialMarkType, DataProvider.MaterialMarkType>()
                .ForMember(x => x.Material, d => d.Ignore());
            mapperCfg.CreateMap<Model.MaterialSizeType, DataProvider.MaterialSizeType>()
                .ForMember(x => x.MaterialMarkType, d => d.Ignore())
                .ForMember(x => x.Measure, d => d.Ignore());
            mapperCfg.CreateMap<Model.MaterialNom, DataProvider.MaterialNom>()
                .ForMember(x => x.VendorMaterialNom, d => d.Ignore())
                .ForMember(x => x.MaterialSizeType, d => d.Ignore())
                .ForMember(x => x.MaterialSizeTypes, d => d.Ignore());
            mapperCfg.CreateMap<Model.Processing, DataProvider.Processing>()
                .ForMember(x => x.Material, d => d.Ignore());
            mapperCfg.CreateMap<Model.FormulaItem, DataProvider.FormulaItem>()
                .ForMember(x => x.Material, a => a.Ignore())
                .ForMember(x => x.Formula, a => a.Ignore())
                .ForMember(x => x.MaterialNom, a => a.Ignore())
                .ForMember(x => x.ParentItem, a => a.Ignore())
                .ForMember(x => x.MaterialNom_Id, a => a.Condition(c => c.Material.MaterialEnum != MaterialEnum.Triplex))
                .ForMember(x => x.FormulaItems, a => a.Ignore())
                .MaxDepth(0);
            mapperCfg.CreateMap<Model.GlassItem, DataProvider.FormulaItem>()
                .ForMember(x => x.Material, a => a.Ignore())
                .ForMember(x => x.Formula, a => a.Ignore())
                .ForMember(x => x.MaterialNom, a => a.Ignore())
                .ForMember(x => x.ParentItem, a => a.Ignore())
                .ForMember(x => x.MaterialNom_Id, a => a.Condition(c => c.Material.MaterialEnum != MaterialEnum.Triplex))
                .ForMember(x => x.FormulaItems, a => a.Ignore())
                .ForMember(x => x.FormulaItemGlassProperties, a => a.MapFrom(s => s.FormulaItemGlassProperties))
                .MaxDepth(0);
            mapperCfg.CreateMap<Model.FrameItem, DataProvider.FormulaItem>()
                .ForMember(x => x.Material, a => a.Ignore())
                .ForMember(x => x.Formula, a => a.Ignore())
                .ForMember(x => x.MaterialNom, a => a.Ignore())
                .ForMember(x => x.ParentItem, a => a.Ignore())
                .ForMember(x => x.MaterialNom_Id, a => a.Condition(c => c.Material.MaterialEnum != MaterialEnum.Triplex))
                .ForMember(x => x.FormulaItems, a => a.Ignore())
                .ForMember(x => x.FormulaItemFrameProperties, a => a.MapFrom(s => s.FormulaItemFrameProperties))
                .MaxDepth(0);
            mapperCfg.CreateMap<Model.TriplexItem, DataProvider.FormulaItem>()
                .ForMember(x => x.Material, a => a.Ignore())
                .ForMember(x => x.Formula, a => a.Ignore())
                .ForMember(x => x.MaterialNom, a => a.Ignore())
                .ForMember(x => x.ParentItem, a => a.Ignore())
                .ForMember(x => x.MaterialNom_Id, a => a.Condition(c => c.Material.MaterialEnum != MaterialEnum.Triplex))
                .ForMember(x => x.FormulaItems, a => a.Ignore())
                .ForMember(x => x.FormulaItemTriplexProperties, a => a.MapFrom(s => s.FormulaItemTriplexProperties))
                .MaxDepth(0);
            mapperCfg.CreateMap<Model.Formula, DataProvider.Formula>()
                .ForMember(x => x.OrderRows, a => a.Ignore())
                .ForMember(x => x.FormulaItems, a => a.Ignore());
            mapperCfg.CreateMap<Model.FormulaItemGlassProperty, DataProvider.FormulaItemGlassProperty>()
                .ForMember(x => x.FormulaItem, a => a.Ignore());
            mapperCfg.CreateMap<Model.FormulaItemFrameProperty, DataProvider.FormulaItemFrameProperty>()
                .ForMember(x => x.FormulaItem, a => a.Ignore());
            mapperCfg.CreateMap<Model.FormulaItemTriplexProperty, DataProvider.FormulaItemTriplexProperty>()
                .ForMember(x => x.FormulaItem, a => a.Ignore());
            mapperCfg.CreateMap<Model.Shapes.CustomPoint, DataProvider.ShapePoint>()
                .ForMember(x => x.Shape, a => a.Ignore());
            mapperCfg.CreateMap<Model.Shapes.Shape, DataProvider.Shape>();
        }

        private static string MaoFromParamAlias(ParamAlias alias)
        {
            return Enum.GetName(typeof(ParamAlias), alias);
        }

    }
}