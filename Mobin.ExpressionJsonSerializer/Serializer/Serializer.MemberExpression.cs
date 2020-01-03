using System.Linq.Expressions;

namespace Mobin.ExpressionJsonSerializer
{
    partial class Serializer
    {
        private bool MemberExpression(Expression expr)
        {
            var expression = expr as MemberExpression;

            if (expression == null)
                return false;

            this.Prop("TypeName", "Member");
            this.Prop("Expression", this.Expression(expression.Expression));
            this.Prop("Member", this.Member(expression.Member));

            return true;
        }
    }
}
