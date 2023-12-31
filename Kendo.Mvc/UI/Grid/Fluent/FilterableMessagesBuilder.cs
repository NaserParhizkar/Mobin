﻿namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent interface for configuring the Filter menu options.
    /// </summary>
    public class FilterableMessagesBuilder : IHideObjectMembers
    {
        private readonly GridFilterableMessages messages;

        public FilterableMessagesBuilder(GridFilterableMessages messages)
        {
            this.messages = messages;
        }

        /// <summary>
        /// Sets the info part of the filter menu
        /// </summary>
        /// <param name="message">The message</param>        
        public FilterableMessagesBuilder Info(string message)
        {
            messages.Info = message;

            return this;
        }

        /// <summary>
        /// Sets the text for And option.
        /// </summary>
        /// <param name="message">The text</param>
        public FilterableMessagesBuilder And(string message)
        {
            messages.And = message;

            return this;
        }

        /// <summary>
        /// Sets the text for Or option.
        /// </summary>
        /// <param name="message">The text</param>
        public FilterableMessagesBuilder Or(string message)
        {
            messages.Or = message;

            return this;
        }

        /// <summary>
        /// Sets the text for Boolean IsTrue option value.
        /// </summary>
        /// <param name="message">The message</param>        
        public FilterableMessagesBuilder IsTrue(string message)
        {
            messages.IsTrue = message;

            return this;
        }

        /// <summary>
        /// Sets the text for Boolean IsFalse option value.
        /// </summary>
        /// <param name="message">The message</param>        
        public FilterableMessagesBuilder IsFalse(string message)
        {
            messages.IsFalse = message;

            return this;
        }

        /// <summary>
        /// Sets the text for Filter button.
        /// </summary>
        /// <param name="message">The message</param>        
        public FilterableMessagesBuilder Filter(string message)
        {
            messages.Filter = message;

            return this;
        }

        /// <summary>
        /// Sets the text for SelectValue option.
        /// </summary>
        /// <param name="message">The message</param>        
        public FilterableMessagesBuilder SelectValue(string message)
        {
            messages.SelectValue = message;

            return this;
        }

        /// <summary>
        /// Sets the text for Clear button.
        /// </summary>
        /// <param name="message">The message</param> 
        public FilterableMessagesBuilder Clear(string message)
        {
            messages.Clear = message;

            return this;
        }

        /// <summary>
        /// Sets the text for Operator label.
        /// </summary>
        /// <param name="message">The message</param> 
        public FilterableMessagesBuilder Operator(string message)
        {
            messages.Operator = message;

            return this;
        }

        /// <summary>
        /// Sets the text for Value label.
        /// </summary>
        /// <param name="message">The message</param> 
        public FilterableMessagesBuilder Value(string message)
        {
            messages.Value = message;

            return this;
        }

        /// <summary>
        /// Sets the text for Cancel button.
        /// </summary>
        /// <param name="message">The message</param> 
        public FilterableMessagesBuilder Cancel(string message)
        {
            messages.Cancel = message;

            return this;
        }
        /// <summary>
        /// Sets the text for Search placeholder.
        /// </summary>
        /// <param name="message">The message</param> 
        public FilterableMessagesBuilder Search(string message)
        {
            messages.Search = message;

            return this;
        }

        /// <summary>
        /// Sets the format for the selected items count message.
        /// </summary>
        /// <param name="message">The message</param> 
        public FilterableMessagesBuilder SelectedItemsFormat(string message)
        {
            messages.SelectedItemsFormat = message;

            return this;
        }
    }
}