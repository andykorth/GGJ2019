/*           
**  SingletonScript.cs
**      
**  Copyright (c) 2010-2013 Andy Korth and Howling Moon Software
**    
**  Source may be used under for whatever by whoever
**  
** This was based on an idea by Neil Carter's lovely Script.cs, details at http://nether.homeip.net:8080/unity/
* 
*/

using UnityEngine;

// Makes crappy unity warnings go away.
public class SingletonScript {};

public class SingletonScript <T> : Script where T:Object  {

	protected static T instance;

	public static T i {
		get {
			if (instance == null) {
				throw new System.Exception ("Missing instance on singleton type: " + typeof (T).FullName );
			}
			return instance;
		}
	}

	protected void Awake(){
		instance = this as T;
	}

	public static bool Existed(){
		return instance != null;
	}
	public static bool Exists(){
		return instance != null;
	}


}
