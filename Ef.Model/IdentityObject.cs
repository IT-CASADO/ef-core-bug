using System;
using System.Collections.Generic;

namespace Ef.Model
{
	public class IdentityObject<TValue> : ValueObject, IComparable, IComparable<IdentityObject<TValue>>
		where TValue : IComparable
	{
		public TValue Value { get; private set; }

		protected IdentityObject(TValue value)
		{
			Value = value;
		}

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}

		public override string ToString()
		{
			return Value.ToString();
		}

		public int CompareTo(IdentityObject<TValue> other)
		{
			if (other == null)
			{
				return -1;
			}

			return Value.CompareTo(other.Value);
		}

		public int CompareTo(object obj)
		{
			return CompareTo(obj as IdentityObject<TValue>);
		}

		public static implicit operator TValue(IdentityObject<TValue> identityObject) => identityObject.Value;
	}
}
