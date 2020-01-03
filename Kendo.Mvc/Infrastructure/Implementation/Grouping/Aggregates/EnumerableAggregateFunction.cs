namespace Kendo.Mvc
{
    using Infrastructure.Implementation;
    using Infrastructure.Implementation.Expressions;
    using System.Linq.Expressions;

    public abstract class EnumerableAggregateFunction : EnumerableAggregateFunctionBase
    {
        /// <summary>
        /// Creates the aggregate expression using <see cref="EnumerableAggregateFunctionExpressionBuilder"/>.
        /// </summary>
        /// <param name="enumerableExpression">The grouping expression.</param>
        /// <param name="liftMemberAccessToNull"></param>
        /// <returns></returns>
        public override Expression CreateAggregateExpression(Expression enumerableExpression, bool liftMemberAccessToNull)
        {
            var builder = new EnumerableAggregateFunctionExpressionBuilder(enumerableExpression, this);
            builder.Options.LiftMemberAccessToNull = liftMemberAccessToNull;
            return builder.CreateAggregateExpression();
        }
    }
}