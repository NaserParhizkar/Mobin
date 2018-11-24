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
        private readonly Dictionary<ParameterExpression, string>
            _parameterExpressions = new Dictionary<ParameterExpression, string>();

        private bool ParameterExpression(Expression expr)
        {
            var expression = expr as ParameterExpression;
            if (expression == null) { return false; }

            string name;
            if (!this._parameterExpressions.TryGetValue(expression, out name))
            {
                name = expression.Name ?? "p_" + Guid.NewGuid().ToString("N");
                this._parameterExpressions[expression] = name;
            }

            this.Prop("TypeName", "Parameter");
            this.Prop("Name", name);

            return true;
        }
    }
}
