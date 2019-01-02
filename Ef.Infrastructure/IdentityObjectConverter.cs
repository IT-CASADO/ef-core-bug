using Ef.Model;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ef.Infrastructure
{
	public class IdentityObjectConverter<TModel, TProvider> : ValueConverter<TModel, TProvider>
		where TModel : IdentityObject<TProvider>
		where TProvider : IComparable
	{
		public IdentityObjectConverter()
			: base(
				  id => id.Value,
				  v => (TModel)Activator.CreateInstance(typeof(TModel), v))
		{ }
	}
}
