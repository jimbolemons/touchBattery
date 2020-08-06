using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


using UnityEngine.Events;



public class VideoTriggerEvents : MonoBehaviour
{
	private VideoPlayer player;
	public UnityEvent m_event;
    // Start is called before the first frame update
    void Start()
    {
    	player = this.GetComponent<VideoPlayer>();
        player.loopPointReached += EndReached;
    }

  
    void EndReached(VideoPlayer vp){
    	if(m_event!=null)
		m_event.Invoke();
    }
}
