using System;
using System.Collections.Generic;
using Kendo.Mvc.Extensions;

namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent API for configuring DialogMessagesSettings
    /// </summary>
    public partial class DialogMessagesSettingsBuilder
        
    {
        /// <summary>
        /// The title of the close button.
        /// </summary>
        /// <param name="value">The value for Close</param>
        public DialogMessagesSettingsBuilder Close(string value)
        {
            Container.Close = value;
            return this;
        }

        /// <summary>
        /// The title of the prompt input.
        /// </summary>
        /// <param name="value">The value for PromptInput</param>
        public DialogMessagesSettingsBuilder PromptInput(string value)
        {
            Container.PromptInput = value;
            return this;
        }

    }
}
