using System;

namespace Mobin.Common.Attributes
{
    /// <summary>
    /// Manage all menus for show dynamically without add them to layout
    /// </summary>
    public class MenuAttribute : Attribute
    {
        /// <summary>
        /// Menu name which should be show anywhere 
        /// </summary>
        public string MenuName { get; set; }
    }
}
