using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Expansion
    {
		public static string FormatDescription(this string description)
		{
			string formatDescription = string.Empty;
			description = description.ToLower().Trim();
			char[] descArray = description.ToCharArray();
			descArray[0] = char.ToUpper(description[0]);
			formatDescription += descArray[0];
			for (int i = 1; i < description.Length; i++)
			{
				if (description[i] == ' ' || description[i] == '-')
				{
					descArray[i + 1] = char.ToUpper(descArray[i + 1]);
				}
				formatDescription += descArray[i];
			}
			return formatDescription;
		}
	}
}
