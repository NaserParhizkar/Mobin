﻿using Kendo.Mvc.Resources;
using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    public class GridFilterableMessages : JsonObject
    {
        public GridFilterableMessages()
        {
            Info = Messages.Filter_Info;
            IsTrue = Messages.Filter_IsTrue;
            IsFalse = Messages.Filter_IsFalse;
            Filter = Messages.Filter_Filter;
            Clear = Messages.Filter_Clear;
            And = Messages.Filter_And;
            Or = Messages.Filter_Or;
            SelectValue = Messages.Filter_SelectValue;
            Operator = Messages.Filter_Operator;
            Value = Messages.Filter_Value;
            Cancel = Messages.Filter_Cancel;
            Search = Messages.Filter_Search;
            SelectedItemsFormat = Messages.Filter_SelectedItemsFormat;
        }

        public string Info { get; set; }
        public string IsTrue { get; set; }
        public string IsFalse { get; set; }
        public string Filter { get; set; }
        public string Clear { get; set; }
        public string And { get; set; }
        public string Or { get; set; }
        public string SelectValue { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }
        public string Cancel { get; set; }
        public string Search { get; set; }
        public string SelectedItemsFormat { get; set; }

        private const string DefaultInfo = "Show items with value that:";
        private const string DefaultIsTrue = "is true";
        private const string DefaultIsFalse = "is false";
        private const string DefaultFilter = "Filter";
        private const string DefaultClear = "Clear";
        private const string DefaultAnd = "And";
        private const string DefaultOr = "Or";
        private const string DefaultSelectValue = "-Select value-";
        private const string DefaultOperator = "Operator";
        private const string DefaultValue = "Value";
        private const string DefaultCancel = "Cancel";
        private const string DefaultSearch = "Search";
        private const string DefaultSelectedItemsFormat = "{0} items selected";

        protected override void Serialize(IDictionary<string, object> json)
        {
            if (Info != DefaultInfo)
            {
                json["info"] = Info;
            }

            if (IsTrue != DefaultIsTrue)
            {
                json["isTrue"] = IsTrue;
            }

            if (IsFalse != DefaultIsFalse)
            {
                json["isFalse"] = IsFalse;
            }

            if (Filter != DefaultFilter)
            {
                json["filter"] = Filter;
            }

            if (Clear != DefaultClear)
            {
                json["clear"] = Clear;
            }

            if (And != DefaultAnd)
            {
                json["and"] = And;
            }

            if (Or != DefaultOr)
            {
                json["or"] = Or;
            }

            if (SelectValue != DefaultSelectValue)
            {
                json["selectValue"] = SelectValue;
            }

            if (Operator != DefaultOperator)
            {
                json["operator"] = Operator;
            }

            if (Value != DefaultValue)
            {
                json["value"] = Value;
            }

            if (Cancel != DefaultCancel)
            {
                json["cancel"] = Cancel;
            }
            if (Search != DefaultSearch)
            {
                json["search"] = Search;
            }
            if (SelectedItemsFormat != DefaultSelectedItemsFormat)
            {
                json["selectedItemsFormat"] = SelectedItemsFormat;
            }
        }
    }
}
