// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Query.Sql;
using Microsoft.EntityFrameworkCore.Utilities;

namespace Microsoft.EntityFrameworkCore.Query.Expressions
{
    /// <summary>
    ///     <para>
    ///         Service dependencies parameter class for <see cref="SelectExpression" />
    ///     </para>
    ///     <para>
    ///         This type is typically used by database providers (and other extensions). It is generally
    ///         not used in application code.
    ///     </para>
    /// </summary>
    public sealed class SelectExpressionDependencies
    {
        /// <summary>
        ///     <para>
        ///         Creates the service dependencies parameter object for a <see cref="SelectExpression" />.
        ///     </para>
        ///     <para>
        ///         Do not call this constructor directly from provider or application code as it may change
        ///         as new dependencies are added. Use the 'With...' methods instead.
        ///     </para>
        /// </summary>
        /// <param name="querySqlGeneratorFactory"> The query SQL generator factory. </param>
        public SelectExpressionDependencies([NotNull] IQuerySqlGeneratorFactory querySqlGeneratorFactory)
        {
            Check.NotNull(querySqlGeneratorFactory, nameof(querySqlGeneratorFactory));

            QuerySqlGeneratorFactory = querySqlGeneratorFactory;
        }

        /// <summary>
        ///     The query SQL generator factory.
        /// </summary>
        public IQuerySqlGeneratorFactory QuerySqlGeneratorFactory { get; }

        /// <summary>
        ///     Clones this dependency parameter object with one service replaced.
        /// </summary>
        /// <param name="querySqlGeneratorFactory">
        ///     A replacement for the current dependency of this type.
        /// </param>
        /// <returns> A new parameter object with the given service replaced. </returns>
        public SelectExpressionDependencies With([NotNull] IQuerySqlGeneratorFactory querySqlGeneratorFactory)
            => new SelectExpressionDependencies(Check.NotNull(querySqlGeneratorFactory, nameof(querySqlGeneratorFactory)));
    }
}
