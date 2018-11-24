using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mobin.ExpressionJsonSerializer
{
    partial class Serializer
    {
        private bool NewExpression(Expression expr)
        {
            var expression = expr as NewExpression;

            if (expression == null)
                return false;

            this.Prop("TypeName", "New");
            this.Prop("Constructor", this.Constructor(expression.Constructor));
            this.Prop("Arguments", this.Enumerable(expression.Arguments,this.Expression));
            this.Prop("Members", this.Enumerable(expression.Members,this.Member));

            return true;
        }
    }
}
