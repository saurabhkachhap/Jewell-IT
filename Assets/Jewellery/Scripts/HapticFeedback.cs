using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticFeedback : MonoBehaviour
{
    private AndroidJavaObject _javaClass;

	public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
	public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
	public static AndroidJavaObject vibrator =currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
	public static AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");


    private void Start()
    {
        //_javaClass = new AndroidJavaObject("com.example.hapticfeadbacklibrary.AndroidHapticFeedback");

        //_javaClass.Call("LogNativeAndroidLogCatMessage");
        //_javaClass.Call("LogNumberSentFromUnity", 5);
        

    }

    private void OnEnable()
    {
        Vibrate(500);
    }

    private static void Vibrate(long millisecond)
    {
        //_javaClass.Call("Haptic", 500L);
		vibrator.Call("vibrate", millisecond);
    }
}
