﻿using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
	private static T _instance;
	private static object _lock = new object();
	private static bool _quit = false;

	public static T Instance {
		
		get {

			if (_quit) {
				return null;
			}

			lock (_lock) 
			{
				if (_instance == null) {
					_instance = (T) FindObjectOfType(typeof(T));

					if (_instance == null) {
						GameObject singleton = new GameObject ();
						_instance = singleton.AddComponent<T> ();
						singleton.name = "(singleton) " + typeof(T).ToString ();

						DontDestroyOnLoad (singleton);
					} 
				}
				return _instance;
			}
		}
			
	}

	public void OnDestroy() {
		_quit = true;
	}
}