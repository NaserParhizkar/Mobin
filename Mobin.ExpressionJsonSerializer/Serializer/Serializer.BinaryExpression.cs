﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mobin.ExpressionJsonSerializer
{
    partial class Serializer
    {
        private bool BinaryExpression(Expression expr)
        {
            var expression = expr as BinaryExpression;
            if (expression == null) { return false; }

            this.Prop("typeName", "binary");
            this.Prop("left", this.Expression(expression.Left));
            this.Prop("right", this.Expression(expression.Right));
            this.Prop("method", this.Method(expression.Method));
            this.Prop("conversion", this.Expression(expression.Conversion));
            this.Prop("liftToNull", expression.IsLiftedToNull);

            return true;
        }
    }
}
