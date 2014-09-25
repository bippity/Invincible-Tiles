using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TShockAPI;
using TShockAPI.DB;

namespace InvincibleTiles
{
	public static class Extensions
	{
		public static bool ContainsKey(this List<KeyValuePair<int, string>> pairs, int wall)
		{
			foreach (var pair in pairs)
			{
				if (pair.Key == wall)
					return true;
			}
			return false;
		}

		public static List<int> ToIDList(this string str)
		{
			List<int> ids = new List<int>();
			foreach (var s in str.Split(','))
			{
				ids.Add(Convert.ToInt32(s));
			}
			return ids;
		}

		public static string IDToDBString(this List<int> ids)
		{
			List<string> strList = new List<string>();
			foreach (var id in ids)
			{
				strList.Add(id.ToString());
			}
			return String.Join(",", strList);
		}

		public static bool IsBanned(this Dictionary<string, List<int>> list, int x, int y, int id)
		{
			List<string> regions = TShock.Regions.InAreaRegionName(x, y);
			if (regions.Count < 1)
			{
				regions.Add("");
			}

			foreach (string region in regions)
			{
				if (list.ContainsKey(region) && list[region].Contains(id))
				{
					return true;
				}
			}
			return false;
		}
	}
}
