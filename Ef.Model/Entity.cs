using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ef.Model
{
	public abstract class Entity
	{
		protected abstract IEnumerable<object> GetIdentityComponents();

		public override bool Equals(object obj)
		{
			return this.ComponentEquals(obj, () =>
			{
				var vo = obj as Entity;
				return GetIdentityComponents().SequenceEqual(vo.GetIdentityComponents());
			});
		}

		public override int GetHashCode()
		{
			return this.CombineHashCodes(GetIdentityComponents());
		}
	}
}
