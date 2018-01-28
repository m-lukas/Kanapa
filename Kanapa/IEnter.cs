using System;

namespace Kanapa
{
	public interface IEnter
	{
		bool Enter(string name, DateTime dateStart, DateTime dateEnd, string description, string location);
	}
}

