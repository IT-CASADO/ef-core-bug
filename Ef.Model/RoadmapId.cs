using System;
using System.Collections.Generic;
using System.Text;

namespace Ef.Model
{
	public class RoadmapId : IdentityObject<Guid>
	{
		public RoadmapId(Guid value)
			: base(value)
		{ }

		public static implicit operator Guid(RoadmapId roadmapId) => roadmapId.Value;
	}
}
