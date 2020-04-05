using System;
using System.Collections.Generic;
using System.Xml;
using Socrat.Log;
using Socrat.Model;
using Socrat.Model.Convertion;

namespace Socrat.Module.Order
{
    public class OrderConverter: BaseConverter
    {
        private Dictionary<string, Model.Formula> _FormulaBuffer = new Dictionary<string, Formula>();

        public Model.Order[] ConvertFromDispXml(string xml)
        {
            List<Model.Order> _orders = new List<Model.Order>();

            XmlDocument _doc = new XmlDocument();
            _doc.InnerXml = xml;
            XmlElement _root = _doc.DocumentElement;

            Model.Order _order;
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

        public Model.Order ConvertOrderFromDispXml(XmlNode orderNode)
        {
            Model.Order _order = null;
            try
            {

                if (orderNode != null)
                {
                    _order = new Model.Order();
                    foreach (XmlAttribute nodeAttribute in orderNode.Attributes)
                    {
                        switch (nodeAttribute.Name)
                        {
                            case "CUSTOMER_DATE":
                                _order.DateCustomer = ValueParse(nodeAttribute.Value, DateTime.Today.AddDays(3));
                                break;
                            case "CUSTOMER_NUM":
                                _order.NumCustomer = ValueParse(nodeAttribute.Value, "1");
                                break;
                        }
                    }

                    Model.OrderRow _row;
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

        public Model.OrderRow ConvertRowFromDispXml(XmlNode node)
        {
            Model.OrderRow _row = new OrderRow();

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
