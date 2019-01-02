using System;
using System.Collections.Generic;
using System.Linq;

namespace Ef.Model
{
	public abstract class ValueObject : IEquatable<ValueObject>
	{
		protected abstract IEnumerable<object> GetEqualityComponents();

		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(this, obj))
			{
				return true;
			}

			if (object.ReferenceEquals(null, obj))
			{
				return false;
			}

			if (this.GetType() != obj.GetType())
			{
				return false;
			}

			return GetEqualityComponents().SequenceEqual((obj as ValueObject).GetEqualityComponents());
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hash = 13;

				foreach (var obj in GetEqualityComponents())
				{
					hash = hash * 23 + (obj != null ? obj.GetHashCode() : 0);
				}

				return hash;
			}
		}

		public bool Equals(ValueObject other)
		{
			if (object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (object.ReferenceEquals(null, other))
			{
				return false;
			}

			return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
		}

		public static bool operator ==(ValueObject left, ValueObject right)
		{
			if (left is null)
			{
				return right is null;
			}

			return left.Equals(right);
		}

		public static bool operator !=(ValueObject left, ValueObject right) => !(left == right);
	}
}
