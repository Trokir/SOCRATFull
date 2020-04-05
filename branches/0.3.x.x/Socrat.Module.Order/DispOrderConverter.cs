using System;
using System.Collections.Generic;
using System.Xml;
using Socrat.Core.Entities;
using Socrat.Log;
using Socrat.References.Formula;

namespace Socrat.Module.Order
{
    public class OrderConverter: BaseConverter
    {
        private Dictionary<string, Formula> _FormulaBuffer = new Dictionary<string, Formula>();

        public Core.Entities.Order[] ConvertFromDispXml(string xml)
        {
            List<Core.Entities.Order> _orders = new List<Core.Entities.Order>();

            XmlDocument _doc = new XmlDocument();
            _doc.InnerXml = xml;
            XmlElement _root = _doc.DocumentElement;

            Core.Entities.Order _order;
            foreach (XmlNode node in _root.ChildNodes)
            {
                if (node.Name == "ORDER")
                {
                    _order = ConvertOrderFromDispXml(node);
                    if (_order != null)
                        _orders.Add(_order);
                }
            }

            return _orders.ToArray();
        }

        public Core.Entities.Order ConvertOrderFromDispXml(XmlNode orderNode)
        {
            Core.Entities.Order _order = null;
            try
            {

                if (orderNode != null)
                {
                    _order = new Core.Entities.Order();
                    foreach (XmlAttribute nodeAttribute in orderNode.Attributes)
                    {
                        switch (nodeAttribute.Name)
                        {
                            case "CUSTOMER_DATE":
                                DateTime _date = ValueParse(nodeAttribute.Value, DateTime.Today.AddDays(3));
                                if (_date <= DateTime.Today)
                                {
                                    _order.Comment = $"Дата изготовления {_date} в заказе указана меньше текущей. " 
                                                     + "Исправлена на значение по-умолчанию.";
                                    _date = DateTime.Today.AddDays(3);
                                }
                                _order.DateCustomer = _date;
                                break;
                            case "CUSTOMER_NUM":
                                _order.NumCustomer = ValueParse(nodeAttribute.Value, "1");
                                break;
                        }
                    }

                    OrderRow _row;
                    foreach (XmlNode _node in orderNode.ChildNodes)
                    {
                        if (_node.Name == "ORDER_ROW")
                        {
                            _row = ConvertRowFromDispXml(_node);
                            _row.Num = _order.GetNextRowNum();
                            if (_row != null)
                            {
                                _order.OrderRows.Add(_row);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddErrorMsgEx("OrderConverter.ConvertFromDispXml", ex);
            }

            return _order;
        }

        public OrderRow ConvertRowFromDispXml(XmlNode node)
        {
            OrderRow _row = new OrderRow();

            foreach (XmlAttribute attribute in node.Attributes)
            {
                switch (attribute.Name)
                {
                    case "H":
                        _row.OverallH = ValueParse(attribute.Value, 0);
                        break;
                    case "W":
                        _row.OverallW = ValueParse(attribute.Value, 0);
                        break;
                    case "FORMULA":
                        _row.FormulaStr = attribute.Value;
                        if (_FormulaBuffer.ContainsKey(_row.FormulaStr))
                        {
                            _row.Formula = _FormulaBuffer[_row.FormulaStr];
                        }
                        else
                        {
                            _row.Formula = FormulaParser.Parse(_row.FormulaStr);
                            _row.Formula.Valid = true;
                            if (_row.Formula != null)
                                _FormulaBuffer.Add(_row.FormulaStr, _row.Formula);
                        }
                        break;
                    case "MARK":
                        _row.Mark = attribute.Value;
                        break;
                    case "COUNT":
                        _row.Qty = ValueParse(attribute.Value, 0);
                        break;
                    case "KOMENT":
                        _row.Comment = attribute.Value;
                        break;
                    case "BARCODE":
                        _row.Barcode = attribute.Value;
                        break;
                }
            }

            return _row;
        }
    }
}
