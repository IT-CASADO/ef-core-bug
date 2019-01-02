using System;
using System.Collections.Generic;

namespace Ef.Model
{
	public class FormulaVariableAttribute : ValueObject
	{
		private Guid TenantId { get; set; }
		public Guid AttributeId { get; private set; }
		public Guid VariableAttributeId { get; private set; }

		public FormulaVariableAttribute(Guid tenantId, Guid attributeId, Guid variableAttributeId)
		{
			TenantId = tenantId;
			AttributeId = attributeId;
			VariableAttributeId = variableAttributeId;
		}

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return TenantId;
			yield return AttributeId;
			yield return VariableAttributeId;
		}
	}
}
