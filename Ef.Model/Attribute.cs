using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ef.Model
{

	public class Attribute : Entity
	{
		#region Properties
		public Guid TenantId { get; set; }
		public Guid Id { get; set; }
		public RoadmapId RoadmapId { get; set; }
		public string Name { get; set; }

		// Formular
		public string Formula { get; set; }

		private readonly List<FormulaVariableAttribute> _formulaVariableAttributes = new List<FormulaVariableAttribute>();
		public IEnumerable<FormulaVariableAttribute> FormulaVariableAttributes => _formulaVariableAttributes.AsReadOnly();

		#endregion

		#region Constructor

		public Attribute()
		{
		}
		public Attribute(IEnumerable<FormulaVariableAttribute> formulaVariableAttributes)
		{
			this._formulaVariableAttributes = formulaVariableAttributes.ToList();
		}
		#endregion

		#region Overrides
		protected override IEnumerable<object> GetIdentityComponents()
		{
			yield return this.Id;
		}
		#endregion

	}
}
