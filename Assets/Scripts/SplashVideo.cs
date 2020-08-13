using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SplashVideo : MonoBehaviour {

    private string movie = "powers.mp4";
//public VideoClip clip;
    void Start () 
    {
        StartCoroutine(streamVideo(movie));
    }

    private IEnumerator streamVideo(string video)
    {
    	//#if UNITY_IOS
		//Handheld.PlayFullScreenMovie("file://" + Application.persistentDataPath + "/StreamingAssets/"+video);
		//#else
       // Handheld.PlayFullScreenMovie(video, Color.black, FullScreenMovieControlMode.Hidden, FullScreenMovieScalingMode.Fill);

		//#endif
        yield return new WaitForEndOfFrame ();
       // SceneManager.LoadScene ("Intro");
    }

   public void Launch(){
    	SceneManager.LoadScene ("Horizontal");
    }
}
