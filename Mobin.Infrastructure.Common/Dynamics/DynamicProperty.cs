using System;
using System.Collections.Generic;
using System.Text;

namespace Mobin.Common.Dynamics
{
    internal class DynamicProperty
    {
        /// <exclude/>
        /// <excludeToc/>
        public DynamicProperty(string name, Type type)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (type == null) throw new ArgumentNullException("type");
            Name = name;
            Type = type;
        }

        /// <exclude/>
        /// <excludeToc/>
        public string Name
        {
            get;
        }

        /// <exclude/>
        /// <excludeToc/>
        public Type Type
        {
            get;
        }
    }
}