using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Mobin.ExpressionJsonSerializer
{
    partial class Serializer
    {
        private bool MemberInitExpression(Expression expr)
        {
            var expression = expr as MemberInitExpression;
            if (expression == null) { return false; }

            //this.Prop("TypeName", "New");
            //this.Prop("Constructor", this.Constructor(expression.Constructor));
            //this.Prop("Arguments", this.Enumerable(expression.Arguments, this.Expression));
            //this.Prop("Members", this.Enumerable(expression.Members, this.Member));


            this.Prop("TypeName", "MemberInit");
            this.Prop("Expression", this.Expression(expression.NewExpression));
            
            this.Prop("Bindings", this.Enumerable(expression.Bindings, this.MemberBinding));
            return true;
        }
    }
}
