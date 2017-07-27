namespace Endgame
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Reflection;

	static class HelperFunctions
	{
		public static void Repeat(int count, Action action)
		{
			for (int i = 0; i < count; i++)
			{
				action();
			}
		}
	}
}
