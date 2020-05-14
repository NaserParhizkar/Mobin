using System.Linq.Expressions;

namespace Mobin.ExpressionJsonSerializer
{
    partial class Serializer
    {
        private bool LambdaExpression(Expression expr)
        {
            var expression = expr as LambdaExpression;
            if (expression == null) { return false; }

            this.Prop("TypeName", "Lambda");
            this.Prop("Name", expression.Name);
            this.Prop("Parameters", this.Enumerable(expression.Parameters, this.Expression));
            this.Prop("Body", this.Expression(expression.Body));
            this.Prop("TailCall", expression.TailCall);

            return true;
        }
    }
}
