using System.Collections;

public class Coordinate2D
{
	
	/// <summary>
	/// convert coordinate string value to uint index.
	/// </summary>
	/// <returns>
	/// uint index value
	/// </returns>
	/// <param name='pCoor'>
	/// coordinate in string, like "0,1".
	/// </param>
	/// <param name='plength'>
	/// the length of the 2D coordinate in column.
	/// </param>
	public static uint CoordinateToIndex(string pCoor, uint plength)
	{
		string[] splited;
		uint xValue;
		uint yValue;
		
		//simple check if there are ","
		if(!pCoor.Contains(","))
			return 0;
		//split the string into two values
		splited = pCoor.Split(new char[] {','});
		
		xValue = uint.Parse(splited[0]);
		yValue = uint.Parse(splited[1]);
		
		//calculate and return the index value
		return CoordinateToIndex(xValue, yValue, plength);
	}
	
	/// <summary>
	/// Calculation for converting coordinate string to uint index.
	/// </summary>
	/// <returns>
	/// uint index value.
	/// </returns>
	/// <param name='pxCoor'>
	/// x coordinate.
	/// </param>
	/// <param name='pyCoor'>
	/// y coordinate.
	/// </param>
	/// <param name='plength'>
	/// the length of the 2D coordinate in column.
	/// </param>
	public static uint CoordinateToIndex(uint pxCoor, uint pyCoor, uint plength)
	{
		//calculate
		return pyCoor * plength + pxCoor;
	}
}

