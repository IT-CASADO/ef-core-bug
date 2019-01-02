using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Ef.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ef.Infrastructure
{
	public static class EntityTypeBuilderExtensions
	{
		public static PropertyBuilder<TIdentityObject> HasIdentityObjectConverter<TIdentityObject, TKey>(this PropertyBuilder<TIdentityObject> builder)
			where TIdentityObject : IdentityObject<TKey>
			where TKey : IComparable
		{
			builder.HasConversion(new IdentityObjectConverter<TIdentityObject, TKey>());

			return builder;
		}

		public static PropertyBuilder<TIdentityObject> HasIdentityObjectGuidConverter<TIdentityObject>(this PropertyBuilder<TIdentityObject> builder)
			where TIdentityObject : IdentityObject<Guid>
		{
			return HasIdentityObjectConverter<TIdentityObject, Guid>(builder);
		}
	}
}
