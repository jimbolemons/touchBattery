using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Video;
public class IntroPanelController : MonoBehaviour {
public GameObject Main,Still,Video;
	public VideoPlayer vPlayer;
	bool onvideo = false;
	public RawImage img;
	public RenderTexture rendtext;
	float alpha =0;
	// Use this for initialization
	void Start () {
		vPlayer.Prepare();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(onvideo && alpha<1){
			Color clr = img.color;
			alpha+=Time.fixedDeltaTime;
			clr.a = alpha;
			img.color = clr;
		}
	}
	void removevid(){
		onvideo=false;

		rendtext.Release();

		Color clr = img.color;
		alpha=0;
		clr.a=alpha;
		img.color = clr;

		vPlayer.Stop();
		 vPlayer.frame = 0;
		vPlayer.Prepare();
	}
	public void OpenStill(){
		removevid();
		Still.SetActive(true);
		//Video.SetActive(false);
		Video.transform.localScale = Vector3.zero;

		Main.SetActive(false);

	}
	public void OpenMain(){
		removevid();

		Main.SetActive(true);
		Still.SetActive(false);
		//Video.SetActive(false);
			Video.transform.localScale = Vector3.zero;
	}
	public void OpenApp(){
		removevid();

		Main.SetActive(false);
		Still.SetActive(false);
		//Video.SetActive(false);
			Video.transform.localScale = Vector3.zero;

	}
	public void OpenVideo(){
		onvideo=true;
	Video.transform.localScale = Vector3.one;
		vPlayer.Play();
		//Video.SetActive(true);
		Main.SetActive(false);
		Still.SetActive(false);
	}
}
