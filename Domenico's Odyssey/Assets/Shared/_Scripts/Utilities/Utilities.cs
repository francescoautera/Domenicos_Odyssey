using System.Collections.Generic;

namespace Domenico.Shared.Utilities
{

	public static class Utilities
	{

		public static void Swap<T>(this IList<T> list, int indexA, int indexB) => (list[indexA], list[indexB]) = (list[indexB], list[indexA]);

		public static void RemoveNulls<T>(this List<T> list)
		{
			for (int i = list.Count - 1; i >= 0; i--)
			{
				if (list[i] == null)
				{
					list.Remove(list[i]);
				}
			}
		}
	}

}