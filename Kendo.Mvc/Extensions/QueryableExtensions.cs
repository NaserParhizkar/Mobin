namespace Kendo.Mvc.Extensions
{
    using Infrastructure.Implementation.Expressions;
    using Kendo.Mvc;
    using Kendo.Mvc.Infrastructure;
    using Kendo.Mvc.Infrastructure.Implementation;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides extension methods to process DataSourceRequest.
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// Applies paging, sorting, filtering and grouping using the information from the DataSourceRequest object.
        /// If the collection is already paged, the method returns an empty result.
        /// </summary>
        /// <param name="enumerable">An instance of <see cref="IEnumerable" />.</param>
        /// <param name="request">An instance of <see cref="DataSourceRequest" />.</param>
        /// <returns>
        /// A <see cref="DataSourceResult" /> object, which contains the processed data after
        /// paging, sorting, filtering and grouping are applied.
        /// </returns>
        public static DataSourceResult ToDataSourceResult(this IEnumerable enumerable, DataSourceRequest request)
        {
            return enumerable.AsQueryable().ToDataSourceResult(request);
        }

        /// <summary>
        /// Applies paging, sorting, filtering and grouping using the information from the DataSourceRequest object.
        /// If the collection is already paged, the method returns an empty result.
        /// </summary>
        /// <param name="enumerable">An instance of <see cref="IEnumerable" />.</param>
        /// <param name="request">An instance of <see cref="DataSourceRequest" />.</param>
        /// <returns>
        /// A Task of <see cref="DataSourceResult" /> object, which contains the processed data
        /// after paging, sorting, filtering and grouping are applied.
        /// It can be called with the "await" keyword for asynchronous operation.
        /// </returns>
        public static Task<DataSourceResult> ToDataSourceResultAsync(this IEnumerable enumerable, DataSourceRequest request)
        {
            return CreateDataSourceResultAsync(() => QueryableExtensions.ToDataSourceResult(enumerable, request));
        }

        public static DataSourceResult ToDataSourceResult(this IEnumerable enumerable, DataSourceRequest request, ModelStateDictionary modelState)
        {
            return enumerable.AsQueryable().ToDataSourceResult(request, modelState);
        }

        public static Task<DataSourceResult> ToDataSourceResultAsync(
            this IEnumerable enumerable, DataSourceRequest request, ModelStateDictionary modelState)
        {
            return CreateDataSourceResultAsync(() => QueryableExtensions.ToDataSourceResult(enumerable, request, modelState));
        }

        /// <summary>
        /// Applies paging, sorting, filtering and grouping using the information from the DataSourceRequest object.
        /// If the collection is already paged, the method returns an empty result.
        /// </summary>
        /// <param name="queryable">An instance of <see cref="IQueryable" />.</param>
        /// <param name="request">An instance of <see cref="DataSourceRequest" />.</param>
        /// <returns>
        /// A <see cref="DataSourceResult" /> object, which contains the processed data after paging, sorting, filtering and grouping are applied.
        /// </returns>
        public static DataSourceResult ToDataSourceResult(this IQueryable queryable, DataSourceRequest request)
        {
            return queryable.ToDataSourceResult(request, null);
        }

        /// <summary>
        /// Applies paging, sorting, filtering and grouping using the information from the DataSourceRequest object.
        /// If the collection is already paged, the method returns an empty result.
        /// </summary>
        /// <param name="queryable">An instance of <see cref="IQueryable" />.</param>
        /// <param name="request">An instance of <see cref="DataSourceRequest" />.</param>
        /// <returns>
        /// A Task of <see cref="DataSourceResult" /> object, which contains the processed data
        /// after paging, sorting, filtering and grouping are applied.
        /// It can be called with the "await" keyword for asynchronous operation.
        /// </returns>
        public static Task<DataSourceResult> ToDataSourceResultAsync(this IQueryable queryable, DataSourceRequest request)
        {
            return CreateDataSourceResultAsync(() => QueryableExtensions.ToDataSourceResult(queryable, request));
        }

        public static DataSourceResult ToDataSourceResult<TModel, TResult>(this IEnumerable<TModel> enumerable, DataSourceRequest request, Func<TModel, TResult> selector)
        {
            return enumerable.AsQueryable().CreateDataSourceResult(request, null, selector);
        }

        public static Task<DataSourceResult> ToDataSourceResultAsync<TModel, TResult>(
            this IEnumerable<TModel> enumerable, DataSourceRequest request, Func<TModel, TResult> selector)
        {
            return CreateDataSourceResultAsync(() => QueryableExtensions.ToDataSourceResult(enumerable, request, selector));
        }

        public static DataSourceResult ToDataSourceResult<TModel, TResult>(this IEnumerable<TModel> enumerable, DataSourceRequest request, ModelStateDictionary modelState, Func<TModel, TResult> selector)
        {
            return enumerable.AsQueryable().CreateDataSourceResult(request, modelState, selector);
        }

        public static Task<DataSourceResult> ToDataSourceResultAsync<TModel, TResult>(
            this IEnumerable<TModel> enumerable, DataSourceRequest request, ModelStateDictionary modelState, Func<TModel, TResult> selector)
        {
            return CreateDataSourceResultAsync(() => QueryableExtensions.ToDataSourceResult(enumerable, request, modelState, selector));
        }

        public static DataSourceResult ToDataSourceResult<TModel, TResult>(this IQueryable<TModel> enumerable, DataSourceRequest request, Func<TModel, TResult> selector)
        {
            return enumerable.CreateDataSourceResult(request, null, selector);
        }

        public static Task<DataSourceResult> ToDataSourceResultAsync<TModel, TResult>
            (this IQueryable<TModel> queryable, DataSourceRequest request, Func<TModel, TResult> selector)
        {
            return CreateDataSourceResultAsync(() => QueryableExtensions.ToDataSourceResult(queryable, request, selector));
        }

        public static DataSourceResult ToDataSourceResult<TModel, TResult>(this IQueryable<TModel> enumerable, DataSourceRequest request, ModelStateDictionary modelState, Func<TModel, TResult> selector)
        {
            return enumerable.CreateDataSourceResult(request, modelState, selector);
        }

        public static Task<DataSourceResult> ToDataSourceResultAsync<TModel, TResult>(
            this IQueryable<TModel> queryable, DataSourceRequest request, ModelStateDictionary modelState, Func<TModel, TResult> selector)
        {
            return CreateDataSourceResultAsync(() => QueryableExtensions.ToDataSourceResult(queryable, request, modelState, selector)); ;
        }

        public static DataSourceResult ToDataSourceResult(this IQueryable queryable, DataSourceRequest request, ModelStateDictionary modelState)
        {
            return queryable.CreateDataSourceResult<object, object>(request, modelState, null);
        }

        public static Task<DataSourceResult> ToDataSourceResultAsync(this IQueryable queryable, DataSourceRequest request, ModelStateDictionary modelState)
        {
            return CreateDataSourceResultAsync(() => QueryableExtensions.ToDataSourceResult(queryable, request, modelState));
        }

        private static DataSourceResult CreateDataSourceResult<TModel, TResult>(this IQueryable queryable, DataSourceRequest request, ModelStateDictionary modelState, Func<TModel, TResult> selector)
        {
            var result = new DataSourceResult();

            var data = queryable;

            var filters = new List<IFilterDescriptor>();

            if (request.Filters != null)
            {
                filters.AddRange(request.Filters);
            }

            if (filters.Any())
            {
                data = data.Where(filters);
            }

            var sort = new List<SortDescriptor>();

            if (request.Sorts != null)
            {
                sort.AddRange(request.Sorts);
            }

            var temporarySortDescriptors = new List<SortDescriptor>();

            IList<GroupDescriptor> groups = new List<GroupDescriptor>();

            if (request.Groups != null)
            {
                groups.AddRange(request.Groups);
            }

            var aggregates = new List<AggregateDescriptor>();

            if (request.Aggregates != null)
            {
                aggregates.AddRange(request.Aggregates);
            }

            if (aggregates.Any())
            {
                var dataSource = data.AsQueryable();

                var source = dataSource;
                if (filters.Any())
                {
                    source = dataSource.Where(filters);
                }

                result.AggregateResults = source.Aggregate(aggregates.SelectMany(a => a.Aggregates));

                if (groups.Any() && aggregates.Any())
                {
                    groups.Each(g => g.AggregateFunctions.AddRange(aggregates.SelectMany(a => a.Aggregates)));
                }
            }

            result.Total = data.Count();

            if (!sort.Any() && queryable.Provider.IsEntityFrameworkProvider())
            {
                // The Entity Framework provider demands OrderBy before calling Skip.
                SortDescriptor sortDescriptor = new SortDescriptor
                {
                    Member = queryable.ElementType.FirstSortableProperty()
                };
                sort.Add(sortDescriptor);
                temporarySortDescriptors.Add(sortDescriptor);
            }

            if (groups.Any())
            {
                groups.Reverse().Each(groupDescriptor =>
                {
                    var sortDescriptor = new SortDescriptor
                    {
                        Member = groupDescriptor.Member,
                        SortDirection = groupDescriptor.SortDirection
                    };

                    sort.Insert(0, sortDescriptor);
                    temporarySortDescriptors.Add(sortDescriptor);
                });
            }

            if (sort.Any())
            {
                data = data.Sort(sort);
            }

            var notPagedData = data;

            data = data.Page(request.Page - 1, request.PageSize);

            if (groups.Any())
            {
                data = data.GroupBy(notPagedData, groups);
            }

            result.Data = data.Execute(selector);

            if (modelState != null && !modelState.IsValid)
            {
                result.Errors = modelState.SerializeErrors();
            }

            temporarySortDescriptors.Each(sortDescriptor => sort.Remove(sortDescriptor));

            return result;
        }

        private static Task<DataSourceResult> CreateDataSourceResultAsync(Func<DataSourceResult> expression)
        {
            return Task.Run(expression);
        }

        private static IQueryable CallQueryableMethod(this IQueryable source, string methodName, LambdaExpression selector)
        {
            IQueryable query = source.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable),
                    methodName,
                    new[] { source.ElementType, selector.Body.Type },
                    source.Expression,
                    Expression.Quote(selector)));

            return query;
        }

        /// <summary>
        /// Sorts the elements of a sequence using the specified sort descriptors.
        /// </summary>
        /// <param name="source">A sequence of values to sort.</param>
        /// <param name="sortDescriptors">The sort descriptors used for sorting.</param>
        /// <returns>
        /// An <see cref="IQueryable" /> whose elements are sorted according to a <paramref name="sortDescriptors"/>.
        /// </returns>
        public static IQueryable Sort(this IQueryable source, IEnumerable<SortDescriptor> sortDescriptors)
        {
            var builder = new SortDescriptorCollectionExpressionBuilder(source, sortDescriptors);
            return builder.Sort();
        }

        /// <summary>
        /// Pages through the elements of a sequence until the specified
        /// <paramref name="pageIndex"/> using <paramref name="pageSize"/>.
        /// </summary>
        /// <param name="source">A sequence of values to page.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// An <see cref="IQueryable" /> whose elements are at the specified <paramref name="pageIndex"/>.
        /// </returns>
        public static IQueryable Page(this IQueryable source, int pageIndex, int pageSize)
        {
            IQueryable query = source;

            query = query.Skip(pageIndex * pageSize);

            if (pageSize > 0)
            {
                query = query.Take(pageSize);
            }

            return query;
        }

        /// <summary>
        /// Projects each element of a sequence into a new form.
        /// </summary>
        /// <returns>
        /// An <see cref="IQueryable" /> whose elements are the result of invoking a
        /// projection selector on each element of <paramref name="source" />.
        /// </returns>
        /// <param name="source"> A sequence of values to project. </param>
        /// <param name="selector"> A projection function to apply to each element. </param>
        public static IQueryable Select(this IQueryable source, LambdaExpression selector)
        {
            return source.CallQueryableMethod("Select", selector);
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function.
        /// </summary>
        /// <param name="source"> An <see cref="IQueryable" /> whose elements to group.</param>
        /// <param name="keySelector"> A function to extract the key for each element.</param>
        /// <returns>
        /// An <see cref="IQueryable"/> with <see cref="IGrouping{TKey,TElement}"/> items,
        /// whose elements contains a sequence of objects and a key.
        /// </returns>
        public static IQueryable GroupBy(this IQueryable source, LambdaExpression keySelector)
        {
            return source.CallQueryableMethod("GroupBy", keySelector);
        }

        /// <summary>
        /// Sorts the elements of a sequence in ascending order according to a key.
        /// </summary>
        /// <returns>
        /// An <see cref="IQueryable" /> whose elements are sorted according to a key.
        /// </returns>
        /// <param name="source">
        /// A sequence of values to order.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from an element.
        /// </param>
        public static IQueryable OrderBy(this IQueryable source, LambdaExpression keySelector)
        {
            return source.CallQueryableMethod("OrderBy", keySelector);
        }

        /// <summary>
        /// Sorts the elements of a sequence in descending order according to a key.
        /// </summary>
        /// <returns>
        /// An <see cref="IQueryable" /> whose elements are sorted in descending order according to a key.
        /// </returns>
        /// <param name="source">
        /// A sequence of values to order.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from an element.
        /// </param>
        public static IQueryable OrderByDescending(this IQueryable source, LambdaExpression keySelector)
        {
            return source.CallQueryableMethod("OrderByDescending", keySelector);
        }

        /// <summary>
        /// Calls <see cref="OrderBy(System.Linq.IQueryable,System.Linq.Expressions.LambdaExpression)"/>
        /// or <see cref="OrderByDescending"/> depending on the <paramref name="sortDirection"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <returns>
        /// An <see cref="IQueryable" /> whose elements are sorted according to a key.
        /// </returns>
        public static IQueryable OrderBy(this IQueryable source, LambdaExpression keySelector, ListSortDirection? sortDirection)
        {
            if (sortDirection.HasValue)
            {
                if (sortDirection.Value == ListSortDirection.Ascending)
                {
                    return source.OrderBy(keySelector);
                }

                return source.OrderByDescending(keySelector);
            }

            return source;
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified <paramref name="groupDescriptors"/>.
        /// </summary>
        /// <param name="source"> An <see cref="IQueryable" /> whose elements to group. </param>
        /// <param name="groupDescriptors">The group descriptors used for grouping.</param>
        /// <returns>
        /// An <see cref="IQueryable"/> with <see cref="IGroup"/> items,
        /// whose elements contains a sequence of objects and a key.
        /// </returns>
        public static IQueryable GroupBy(this IQueryable source, IEnumerable<GroupDescriptor> groupDescriptors)
        {
            return source.GroupBy(source, groupDescriptors);
        }

        public static IQueryable GroupBy(this IQueryable source, IQueryable notPagedData, IEnumerable<GroupDescriptor> groupDescriptors)
        {
            var builder = new GroupDescriptorCollectionExpressionBuilder(source, groupDescriptors, notPagedData);
            builder.Options.LiftMemberAccessToNull = source.Provider.IsLinqToObjectsProvider();
            return builder.CreateQuery();
        }

        /// <summary>
        /// Calculates the results of given aggregates functions on a sequence of elements.
        /// </summary>
        /// <param name="source"> An <see cref="IQueryable" /> whose elements will
        /// be used for aggregate calculation.</param>
        /// <param name="aggregateFunctions">The aggregate functions.</param>
        /// <returns>Collection of <see cref="AggregateResult"/>s calculated for each function.</returns>
        public static AggregateResultCollection Aggregate(this IQueryable source, IEnumerable<AggregateFunction> aggregateFunctions)
        {
            var functions = aggregateFunctions.ToList();

            if (functions.Count > 0)
            {
                var builder = new QueryableAggregatesExpressionBuilder(source, functions);
                builder.Options.LiftMemberAccessToNull = source.Provider.IsLinqToObjectsProvider();
                var groups = builder.CreateQuery();

                foreach (AggregateFunctionsGroup group in groups)
                {
                    return group.GetAggregateResults(functions);
                }
            }

            return new AggregateResultCollection();
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <returns>
        /// An <see cref="IQueryable" /> that contains elements from the input sequence
        /// that satisfy the condition specified by <paramref name="predicate" />.
        /// </returns>
        /// <param name="source"> An <see cref="IQueryable" /> to filter.</param>
        /// <param name="predicate"> A function to test each element for a condition.</param>
        public static IQueryable Where(this IQueryable source, Expression predicate)
        {
            return source.Provider.CreateQuery(
               Expression.Call(
                   typeof(Queryable),
                   "Where",
                   new[] { source.ElementType },
                   source.Expression,
                   Expression.Quote(predicate)));
        }

        /// <summary>
        /// Filters a sequence of values based on a collection of <see cref="IFilterDescriptor"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="filterDescriptors">The filter descriptors.</param>
        /// <returns>
        /// An <see cref="IQueryable" /> that contains elements from the input sequence
        /// that satisfy the conditions specified by each filter descriptor in <paramref name="filterDescriptors" />.
        /// </returns>
        public static IQueryable Where(this IQueryable source, IEnumerable<IFilterDescriptor> filterDescriptors)
        {
            if (filterDescriptors.Any())
            {
                var parameterExpression = Expression.Parameter(source.ElementType, "item");

                var expressionBuilder = new FilterDescriptorCollectionExpressionBuilder(parameterExpression, filterDescriptors);
                expressionBuilder.Options.LiftMemberAccessToNull = source.Provider.IsLinqToObjectsProvider();
                var predicate = expressionBuilder.CreateFilterExpression();
                return source.Where(predicate);
            }

            return source;
        }

        /// <summary>
        /// Returns a specified number of contiguous elements from the start of a sequence.
        /// </summary>
        /// <returns>
        /// An <see cref="IQueryable" /> that contains the specified number
        /// of elements from the start of <paramref name="source" />.
        /// </returns>
        /// <param name="source"> The sequence to return elements from.</param>
        /// <param name="count"> The number of elements to return. </param>
        /// <exception cref="ArgumentNullException"><paramref name="source" /> is null. </exception>
        public static IQueryable Take(this IQueryable source, int count)
        {
            if (source == null) throw new ArgumentNullException("source");
            return source.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable), "Take",
                    new Type[] { source.ElementType },
                    source.Expression, Expression.Constant(count)));
        }

        /// <summary>
        /// Bypasses a specified number of elements in a sequence
        /// and then returns the remaining elements.
        /// </summary>
        /// <returns>
        /// An <see cref="IQueryable" /> that contains elements that occur
        /// after the specified index in the input sequence.
        /// </returns>
        /// <param name="source">
        /// An <see cref="IQueryable" /> to return elements from.
        /// </param>
        /// <param name="count">
        /// The number of elements to skip before returning the remaining elements.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="source" /> is null.</exception>
        public static IQueryable Skip(this IQueryable source, int count)
        {
            if (source == null) throw new ArgumentNullException("source");
            return source.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable), "Skip",
                    new Type[] { source.ElementType },
                    source.Expression, Expression.Constant(count)));
        }

        /// <summary> Returns the number of elements in a sequence.</summary>
        /// <returns> The number of elements in the input sequence.</returns>
        /// <param name="source">
        /// The <see cref="IQueryable" /> that contains the elements to be counted.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="source" /> is null.</exception>
        public static int Count(this IQueryable source)
        {
            if (source == null) throw new ArgumentNullException("source");
            return source.Provider.Execute<int>(
                Expression.Call(
                    typeof(Queryable), "Count",
                    new Type[] { source.ElementType }, source.Expression));
        }

        /// <summary> Returns the element at a specified index in a sequence.</summary>
        /// <returns> The element at the specified position in <paramref name="source" />.</returns>
        /// <param name="source"> An <see cref="IQueryable" /> to return an element from.</param>
        /// <param name="index"> The zero-based index of the element to retrieve.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="source" /> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"> <paramref name="index" /> is less than zero.</exception>
        public static object ElementAt(this IQueryable source, int index)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (index < 0) throw new ArgumentOutOfRangeException("index");

            return source.Provider.Execute(
                Expression.Call(
                    typeof(Queryable),
                    "ElementAt",
                    new Type[] { source.ElementType },
                    source.Expression,
                    Expression.Constant(index)));
        }

        /// <summary>
        /// Produces the set union of two sequences by using the default equality comparer.
        /// </summary>
        /// <returns>
        /// An <see cref="IQueryable" /> that contains the elements from both input sequences, excluding duplicates.
        /// </returns>
        /// <param name="source">
        /// An <see cref="IQueryable" /> whose distinct elements form the first set for the union.
        /// </param>
        /// <param name="second">
        /// An <see cref="IQueryable" /> whose distinct elements form the first set for the union.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="source" /> is null.</exception>
        public static IQueryable Union(this IQueryable source, IQueryable second)
        {
            IQueryable query = source.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable),
                    "Union",
                    new[] { source.ElementType },
                    source.Expression,
                    second.Expression));

            return query;
        }

        private static IEnumerable Execute<TModel, TResult>(this IQueryable source, Func<TModel, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException("source");

            var type = source.ElementType;


            if (selector != null)
            {
                var groups = new List<AggregateFunctionsGroup>();

                if (type == typeof(AggregateFunctionsGroup))
                {
                    foreach (AggregateFunctionsGroup group in source)
                    {
                        group.Items = group.Items.AsQueryable().Execute(selector);
                        groups.Add(group);
                    }

                    return groups;
                }
                else
                {
                    var list = new List<TResult>();

                    foreach (TModel item in source)
                    {
                        list.Add(selector(item));
                    }

                    return list;
                }
            }
            else
            {
                var list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(type));

                foreach (var item in source)
                {
                    list.Add(item);
                }

                return list;
            }
        }

        /// <summary>
        /// Applies sorting, filtering and grouping using the information from the DataSourceRequest object.
        /// If the collection is already paged, the method returns an empty result.
        /// </summary>
        /// <param name="enumerable">An instance of <see cref="IEnumerable" />.</param>
        /// <param name="request">An instance of <see cref="DataSourceRequest" />.</param>
        /// <returns>
        /// A <see cref="TreeDataSourceResult" /> object, which contains the processed data after sorting, filtering and grouping are applied.
        /// </returns>
        public static TreeDataSourceResult ToTreeDataSourceResult(this IEnumerable enumerable, DataSourceRequest request)
        {
            return enumerable.AsQueryable().ToTreeDataSourceResult(request, null);
        }

        /// <summary>
        /// Applies sorting, filtering and grouping using the information from the DataSourceRequest object.
        /// If the collection is already paged, the method returns an empty result.
        /// </summary>
        /// <param name="enumerable">An instance of <see cref="IEnumerable" />.</param>
        /// <param name="request">An instance of <see cref="DataSourceRequest" />.</param>
        /// <returns>
        /// A Task of <see cref="TreeDataSourceResult" /> object, which contains the processed data
        /// after sorting, filtering and grouping are applied.
        /// It can be called with the "await" keyword for asynchronous operation.
        /// </returns>
        public static Task<TreeDataSourceResult> ToTreeDataSourceResultAsync(this IEnumerable enumerable, DataSourceRequest request)
        {
            return CreateTreeDataSourceResultAsync(() => QueryableExtensions.ToTreeDataSourceResult(enumerable, request));
        }

        public static TreeDataSourceResult ToTreeDataSourceResult(this IEnumerable enumerable, DataSourceRequest request, ModelStateDictionary modelState)
        {
            return enumerable.AsQueryable().CreateTreeDataSourceResult<object, object, object, object>(request, null, null, modelState, null, null);
        }

        public static Task<TreeDataSourceResult> ToTreeDataSourceResultAsync(this IEnumerable enumerable,
            DataSourceRequest request, ModelStateDictionary modelState)
        {
            return CreateTreeDataSourceResultAsync(() => QueryableExtensions.ToTreeDataSourceResult(enumerable, request, modelState));
        }

        public static TreeDataSourceResult ToTreeDataSourceResult<TModel, TResult>(this IQueryable<TModel> enumerable,
            DataSourceRequest request,
            Func<TModel, TResult> selector)
        {
            return enumerable.ToTreeDataSourceResult<TModel, object, object, TResult>(request, null, null, selector);
        }

        public static Task<TreeDataSourceResult> ToTreeDataSourceResultAsync<TModel, TResult>(this IQueryable<TModel> queryable,
            DataSourceRequest request, Func<TModel, TResult> selector)
        {
            return CreateTreeDataSourceResultAsync(() => QueryableExtensions.ToTreeDataSourceResult(queryable, request, selector));
        }

        public static TreeDataSourceResult ToTreeDataSourceResult<TModel, TResult>(this IEnumerable<TModel> enumerable,
            DataSourceRequest request,
            Func<TModel, TResult> selector)
        {
            return enumerable.ToTreeDataSourceResult<TModel, object, object, TResult>(request, null, null, selector);
        }

        public static Task<TreeDataSourceResult> ToTreeDataSourceResultAsync<TModel, TResult>(this IEnumerable<TModel> enumerable,
            DataSourceRequest request, Func<TModel, TResult> selector)
        {
            return CreateTreeDataSourceResultAsync(() => QueryableExtensions.ToTreeDataSourceResult(enumerable, request, selector));
        }

        public static TreeDataSourceResult ToTreeDataSourceResult<TModel, T1, T2>(this IQueryable<TModel> enumerable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector)
        {
            return enumerable.CreateTreeDataSourceResult<TModel, T1, T2, TModel>(request, idSelector, parentIDSelector, null, null, null);
        }

        public static Task<TreeDataSourceResult> ToTreeDataSourceResultAsync<TModel, T1, T2>(this IQueryable<TModel> queryable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector)
        {
            return CreateTreeDataSourceResultAsync(() =>
                QueryableExtensions.ToTreeDataSourceResult(queryable, request, idSelector, parentIDSelector));
        }

        public static TreeDataSourceResult ToTreeDataSourceResult<TModel, T1, T2>(this IQueryable<TModel> enumerable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            Expression<Func<TModel, bool>> rootSelector)
        {
            return enumerable.CreateTreeDataSourceResult<TModel, T1, T2, TModel>(request, idSelector, parentIDSelector, null, null, rootSelector);
        }

        public static Task<TreeDataSourceResult> ToTreeDataSourceResultAsync<TModel, T1, T2>(this IQueryable<TModel> queryable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            Expression<Func<TModel, bool>> rootSelector)
        {
            return CreateTreeDataSourceResultAsync(() =>
                QueryableExtensions.ToTreeDataSourceResult(queryable, request, idSelector, parentIDSelector, rootSelector));
        }

        public static TreeDataSourceResult ToTreeDataSourceResult<TModel, T1, T2, TResult>(this IQueryable<TModel> queryable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            Expression<Func<TModel, bool>> rootSelector,
            Func<TModel, TResult> selector)
        {
            return queryable.CreateTreeDataSourceResult(request, idSelector, parentIDSelector, null, selector, rootSelector);
        }

        public static Task<TreeDataSourceResult> ToTreeDataSourceResultAsync<TModel, T1, T2, TResult>(this IQueryable<TModel> queryable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            Expression<Func<TModel, bool>> rootSelector,
            Func<TModel, TResult> selector)
        {
            return CreateTreeDataSourceResultAsync(() =>
                QueryableExtensions.ToTreeDataSourceResult(queryable, request, idSelector, parentIDSelector, rootSelector, selector));
        }

        public static TreeDataSourceResult ToTreeDataSourceResult<TModel, T1, T2>(this IQueryable<TModel> queryable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            ModelStateDictionary modelState)
        {
            return queryable.ToTreeDataSourceResult<TModel, T1, T2, TModel>(request, idSelector, parentIDSelector, modelState, null);
        }

        public static Task<TreeDataSourceResult> ToTreeDataSourceResultAsync<TModel, T1, T2>(this IQueryable<TModel> queryable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            ModelStateDictionary modelState)
        {
            return CreateTreeDataSourceResultAsync(() =>
                QueryableExtensions.ToTreeDataSourceResult(queryable, request, idSelector, parentIDSelector, modelState));
        }

        public static TreeDataSourceResult ToTreeDataSourceResult<TModel, T1, T2>(this IQueryable<TModel> enumerable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            Expression<Func<TModel, bool>> rootSelector,
            ModelStateDictionary modelState)
        {
            return enumerable.CreateTreeDataSourceResult<TModel, T1, T2, TModel>(request, idSelector, parentIDSelector, modelState, null, rootSelector);
        }

        public static Task<TreeDataSourceResult> ToTreeDataSourceResultAsync<TModel, T1, T2>(this IQueryable<TModel> queryable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            Expression<Func<TModel, bool>> rootSelector,
            ModelStateDictionary modelState)
        {
            return CreateTreeDataSourceResultAsync(() =>
                QueryableExtensions.ToTreeDataSourceResult(queryable, request, idSelector, parentIDSelector, rootSelector, modelState));
        }

        public static TreeDataSourceResult ToTreeDataSourceResult<TModel, T1, T2, TResult>(this IQueryable<TModel> queryable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            Func<TModel, TResult> selector)
        {
            return queryable.CreateTreeDataSourceResult(request, idSelector, parentIDSelector, null, selector, null);
        }

        public static Task<TreeDataSourceResult> ToTreeDataSourceResultAsync<TModel, T1, T2, TResult>(this IQueryable<TModel> queryable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            Func<TModel, TResult> selector)
        {
            return CreateTreeDataSourceResultAsync(() =>
                QueryableExtensions.ToTreeDataSourceResult(queryable, request, idSelector, parentIDSelector, selector));
        }

        public static TreeDataSourceResult ToTreeDataSourceResult<TModel, T1, T2, TResult>(this IQueryable<TModel> queryable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            ModelStateDictionary modelState,
            Func<TModel, TResult> selector)
        {
            return queryable.CreateTreeDataSourceResult(request, idSelector, parentIDSelector, modelState, selector, null);
        }

        public static Task<TreeDataSourceResult> ToTreeDataSourceResultAsync<TModel, T1, T2, TResult>(this IQueryable<TModel> queryable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            ModelStateDictionary modelState,
            Func<TModel, TResult> selector)
        {
            return CreateTreeDataSourceResultAsync(() =>
                QueryableExtensions.ToTreeDataSourceResult(queryable, request, idSelector, parentIDSelector, modelState, selector));
        }

        public static TreeDataSourceResult ToTreeDataSourceResult<TModel, T1, T2, TResult>(this IQueryable<TModel> queryable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            Expression<Func<TModel, bool>> rootSelector,
            ModelStateDictionary modelState,
            Func<TModel, TResult> selector)
        {
            return queryable.CreateTreeDataSourceResult(request, idSelector, parentIDSelector, modelState, selector, rootSelector);
        }

        public static Task<TreeDataSourceResult> ToTreeDataSourceResultAsync<TModel, T1, T2, TResult>(this IQueryable<TModel> queryable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            Expression<Func<TModel, bool>> rootSelector,
            ModelStateDictionary modelState,
            Func<TModel, TResult> selector)
        {
            return CreateTreeDataSourceResultAsync(() =>
                QueryableExtensions.ToTreeDataSourceResult(queryable, request, idSelector, parentIDSelector, rootSelector, modelState, selector));
        }

        public static TreeDataSourceResult ToTreeDataSourceResult<TModel, T1, T2>(this IEnumerable<TModel> enumerable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector)
        {
            return enumerable.AsQueryable().CreateTreeDataSourceResult<TModel, T1, T2, TModel>(request, idSelector, parentIDSelector, null, null, null);
        }

        public static Task<TreeDataSourceResult> ToTreeDataSourceResultAsync<TModel, T1, T2>(this IEnumerable<TModel> enumerable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector)
        {
            return CreateTreeDataSourceResultAsync(() =>
                QueryableExtensions.ToTreeDataSourceResult(enumerable, request, idSelector, parentIDSelector));
        }

        public static TreeDataSourceResult ToTreeDataSourceResult<TModel, T1, T2>(this IEnumerable<TModel> enumerable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            Expression<Func<TModel, bool>> rootSelector)
        {
            return enumerable.AsQueryable().CreateTreeDataSourceResult<TModel, T1, T2, TModel>(request, idSelector, parentIDSelector, null, null, rootSelector);
        }

        public static Task<TreeDataSourceResult> ToTreeDataSourceResultAsync<TModel, T1, T2>(this IEnumerable<TModel> enumerable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            Expression<Func<TModel, bool>> rootSelector)
        {
            return CreateTreeDataSourceResultAsync(() =>
                QueryableExtensions.ToTreeDataSourceResult(enumerable, request, idSelector, parentIDSelector, rootSelector));
        }

        public static TreeDataSourceResult ToTreeDataSourceResult<TModel, T1, T2, TResult>(this IEnumerable<TModel> queryable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            Expression<Func<TModel, bool>> rootSelector,
            Func<TModel, TResult> selector)
        {
            return queryable.AsQueryable().CreateTreeDataSourceResult(request, idSelector, parentIDSelector, null, selector, rootSelector);
        }

        public static Task<TreeDataSourceResult> ToTreeDataSourceResultAsync<TModel, T1, T2, TResult>(this IEnumerable<TModel> enumerable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            Expression<Func<TModel, bool>> rootSelector,
            Func<TModel, TResult> selector)
        {
            return CreateTreeDataSourceResultAsync(() =>
                QueryableExtensions.ToTreeDataSourceResult(enumerable, request, idSelector, parentIDSelector, rootSelector));
        }

        public static TreeDataSourceResult ToTreeDataSourceResult<TModel, T1, T2>(this IEnumerable<TModel> queryable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            ModelStateDictionary modelState)
        {
            return queryable.AsQueryable().ToTreeDataSourceResult<TModel, T1, T2, TModel>(request, idSelector, parentIDSelector, modelState, null);
        }

        public static Task<TreeDataSourceResult> ToTreeDataSourceResultAsync<TModel, T1, T2>(this IEnumerable<TModel> enumerable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            ModelStateDictionary modelState)
        {
            return CreateTreeDataSourceResultAsync(() =>
                QueryableExtensions.ToTreeDataSourceResult(enumerable, request, idSelector, parentIDSelector, modelState));
        }

        public static TreeDataSourceResult ToTreeDataSourceResult<TModel, T1, T2>(this IEnumerable<TModel> enumerable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            Expression<Func<TModel, bool>> rootSelector,
            ModelStateDictionary modelState)
        {
            return enumerable.AsQueryable().CreateTreeDataSourceResult<TModel, T1, T2, TModel>(request, idSelector, parentIDSelector, modelState, null, rootSelector);
        }

        public static Task<TreeDataSourceResult> ToTreeDataSourceResultAsync<TModel, T1, T2>(this IEnumerable<TModel> enumerable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            Expression<Func<TModel, bool>> rootSelector,
            ModelStateDictionary modelState)
        {
            return CreateTreeDataSourceResultAsync(() =>
                QueryableExtensions.ToTreeDataSourceResult(enumerable, request, idSelector, parentIDSelector, rootSelector, modelState));
        }

        public static TreeDataSourceResult ToTreeDataSourceResult<TModel, T1, T2, TResult>(this IEnumerable<TModel> queryable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            Func<TModel, TResult> selector)
        {
            return queryable.AsQueryable().CreateTreeDataSourceResult(request, idSelector, parentIDSelector, null, selector, null);
        }

        public static Task<TreeDataSourceResult> ToTreeDataSourceResultAsync<TModel, T1, T2, TResult>(this IEnumerable<TModel> enumerable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            Func<TModel, TResult> selector)
        {
            return CreateTreeDataSourceResultAsync(() =>
                QueryableExtensions.ToTreeDataSourceResult(enumerable, request, idSelector, parentIDSelector, selector));
        }

        public static TreeDataSourceResult ToTreeDataSourceResult<TModel, T1, T2, TResult>(this IEnumerable<TModel> queryable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            ModelStateDictionary modelState,
            Func<TModel, TResult> selector)
        {
            return queryable.AsQueryable().CreateTreeDataSourceResult(request, idSelector, parentIDSelector, modelState, selector, null);
        }

        public static Task<TreeDataSourceResult> ToTreeDataSourceResultAsync<TModel, T1, T2, TResult>(this IEnumerable<TModel> enumerable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            ModelStateDictionary modelState,
            Func<TModel, TResult> selector)
        {
            return CreateTreeDataSourceResultAsync(() =>
                QueryableExtensions.ToTreeDataSourceResult(enumerable, request, idSelector, parentIDSelector, modelState, selector));
        }

        public static TreeDataSourceResult ToTreeDataSourceResult<TModel, T1, T2, TResult>(this IEnumerable<TModel> queryable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            Expression<Func<TModel, bool>> rootSelector,
            ModelStateDictionary modelState,
            Func<TModel, TResult> selector)
        {
            return queryable.AsQueryable().CreateTreeDataSourceResult(request, idSelector, parentIDSelector, modelState, selector, rootSelector);
        }

        public static Task<TreeDataSourceResult> ToTreeDataSourceResultAsync<TModel, T1, T2, TResult>(this IEnumerable<TModel> enumerable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            Expression<Func<TModel, bool>> rootSelector,
            ModelStateDictionary modelState,
            Func<TModel, TResult> selector)
        {
            return CreateTreeDataSourceResultAsync(() =>
                QueryableExtensions.ToTreeDataSourceResult(enumerable, request, idSelector, parentIDSelector, rootSelector, modelState, selector));
        }

        private static Task<TreeDataSourceResult> CreateTreeDataSourceResultAsync(Func<TreeDataSourceResult> expression)
        {
            return Task.Run(expression);
        }

        private static TreeDataSourceResult CreateTreeDataSourceResult<TModel, T1, T2, TResult>(this IQueryable queryable,
            DataSourceRequest request,
            Expression<Func<TModel, T1>> idSelector,
            Expression<Func<TModel, T2>> parentIDSelector,
            ModelStateDictionary modelState,
            Func<TModel, TResult> selector,
            Expression<Func<TModel, bool>> rootSelector)
        {
            var result = new TreeDataSourceResult();

            var data = queryable;

            var filters = new List<IFilterDescriptor>();

            if (request.Filters != null)
            {
                filters.AddRange(request.Filters);
            }

            if (filters.Any())
            {
                data = data.Where(filters);

                data = data.ParentsRecursive<TModel>(queryable, idSelector, parentIDSelector);
            }

            var filteredData = data;

            if (rootSelector != null)
            {
                data = data.Where(rootSelector);
            }

            var sort = new List<SortDescriptor>();

            if (request.Sorts != null)
            {
                sort.AddRange(request.Sorts);
            }

            var aggregates = new List<AggregateDescriptor>();

            if (request.Aggregates != null)
            {
                aggregates.AddRange(request.Aggregates);
            }

            if (aggregates.Any())
            {
                var dataSource = data;
                var groups = dataSource.GroupBy(parentIDSelector);

                foreach (IGrouping<T2, TModel> group in groups)
                {
                    result.AggregateResults.Add(Convert.ToString(group.Key), group.AggregateForLevel(filteredData, aggregates, idSelector, parentIDSelector));
                }
            }

            if (sort.Any())
            {
                data = data.Sort(sort);
            }

            result.Data = data.Execute(selector);

            if (modelState != null && !modelState.IsValid)
            {
                result.Errors = modelState.SerializeErrors();
            }

            return result;
        }
    }
}
