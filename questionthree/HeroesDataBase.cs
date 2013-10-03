using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;

public static class HeroesDataBase
{
	//encoded alphabet values on number
	public static Dictionary<char, string> encodedValues = new Dictionary<char, string>()
	{
		{'0', "YZ"},
		{'1', "AB"},
		{'2', "CD"},
		{'3', "EF"},
		{'4', "GHI"},
		{'5', "JKL"},
		{'6', "MNO"},
		{'7', "PQR"},
		{'8', "STU"},
		{'9', "VWX"},
	};
	
	//list of heroes' name
	public static List<string> heroesName = new List<string>(7)
	{
		"Hulk", "Superman", "Batman", "Thing", "Iceman", "Antman", "Daredevil"
	};
	
	/// <summary>
	/// Searchs the name of hero by entering code numbers
	/// </summary>
	/// <returns>
	/// hero with the matching numbers
	/// </returns>
	/// <param name='pinput'>
	/// numbers input from users
	/// </param>
	public static string SearchName(string pinput)
	{
		//cur alphabet on pinput
		string curAlphabet;
		//cur alphabet set base on curAlphabet
		string alphabetSet;
		//clone on heroesName
		List<string> filterList = (List<string>)Clone<string>(heroesName);
		//filtered Heroes name
		List<string> filteredHeroes = new List<string>();
		
		filterList = filterLength(filterList, pinput.Length);
		for(int i = 0; i < pinput.Length; ++i)
		{
			curAlphabet = pinput.Substring(i, 1);
			alphabetSet = encodedValues[curAlphabet.ToCharArray()[0]];
			filteredHeroes.Clear();
			for(int j = 0; j < alphabetSet.Length; ++j)
			{
				filteredHeroes.AddRange(filterChar(filterList, alphabetSet.Substring(j, 1), i));
			}
			filterList = (List<string>)Clone<string>(filteredHeroes);
		}
		if(filteredHeroes.Count != 0)
			return  filteredHeroes[0];
		
		return "None";
	}
	
	/// <summary>
	/// Filters the length.
	/// </summary>
	/// <returns>
	/// the same string length with the comparing length
	/// </returns>
	/// <param name='plist'>
	/// List of string
	/// </param>
	/// <param name='length'>
	/// length to be filtered
	/// </param>
	public static List<string> filterLength(List<string> plist, int length)
	{
		//new List for result
		List<string> newList = new List<string>();
		
		for(int i = 0; i < plist.Count; ++i)
		{
			if(plist[i].Length == length)
			{
				newList.Add(plist[i]);
			}
		}
		return newList;
	}
	
	/// <summary>
	/// Filters the char on specific index.
	/// </summary>
	/// <returns>
	/// the string value with the same character code on the specified index, regardless of lower or upper letter difference.
	/// </returns>
	/// <param name='plist'>
	/// List of string
	/// </param>
	/// <param name='pcmpValue'>
	/// single alphabet string value
	/// </param>
	/// <param name='pindex'>
	/// the index of the position
	/// </param>
	public static List<string> filterChar(List<string> plist, string pcmpValue, int pindex)
	{
		//new List for result
		List<string> newList = new List<string>();
		//char ascii code holders
		byte[] asciicodeHeroes;
		byte[] asciicodeSets;
		
		for(int i = 0; i < plist.Count; ++i)
		{
			asciicodeHeroes = Encoding.ASCII.GetBytes(plist[i].Substring(pindex, 1));
			asciicodeSets = Encoding.ASCII.GetBytes(pcmpValue.Substring(0, 1));
			
			if(asciicodeHeroes[0] == asciicodeSets[0] || asciicodeHeroes[0] == asciicodeSets[0] + 32)
				newList.Add(plist[i]);
		}
		return newList;
	}
	
	//Entension method: To Clone ICloneable Data Type
    public static IList<T> Clone<T>(this IList<T> listToClone) where T: ICloneable
    {
        return listToClone.Select(item => (T)item.Clone()).ToList();
    }
	
}

