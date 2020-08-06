using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController1 : MonoBehaviour {
	public List<GameObject> Objects = new List<GameObject>();
	public List<GameObject> IgnoreObjects = new List<GameObject>();

	public List<Material> ActiveMaterials = new List<Material>();
	public List<Material> IgnoreMaterials = new List<Material>();


	public bool ToggleFade = false,Visable = false,fading=false;
	public bool StartFaded = false;

	public float fadeAmount;

	public CanvasGroup cGroup;
	public bool getVisable(){return this.Visable;}
	// Use this for initialization

	void Start () {
		foreach(GameObject obj in IgnoreObjects){
			foreach(MeshRenderer mesh in obj.GetComponentsInChildren<MeshRenderer>()){
				foreach(Material m in mesh.materials)
					IgnoreMaterials.Add(m);
			}
			foreach(SkinnedMeshRenderer mesh in obj.GetComponentsInChildren<SkinnedMeshRenderer>()){
				foreach(Material m in mesh.materials)
					IgnoreMaterials.Add(m);
			}
		}
		foreach(GameObject obj in Objects){
			foreach(MeshRenderer mesh in obj.GetComponentsInChildren<MeshRenderer>()){
				foreach(Material m in mesh.materials)
					if(!IgnoreMaterials.Contains(m))
						ActiveMaterials.Add(m);
			}
			foreach(SkinnedMeshRenderer mesh in obj.GetComponentsInChildren<SkinnedMeshRenderer>()){
				foreach(Material m in mesh.materials)
					if(!IgnoreMaterials.Contains(m))
						ActiveMaterials.Add(m);
			}
		}

		if(StartFaded)
			StartFade(.1f);
	}

	void Update(){
		if(ToggleFade){
			ToggleFade = false;
			if(Visable){
				StartFade(1f);
			}else{
				StartUnfade(1f);
			}
			Visable = !Visable;
		}
	}
	public void SetFade(float amount){
		foreach(Material m in ActiveMaterials){
			m.SetFloat("_Fade",amount);
		}
	}

	public void StartFadeAfterDelay(float delay,float duration){
		fading=true;
		StartCoroutine(StartFadeAfterDelayRoutine(delay,duration));
	}
	IEnumerator StartFadeAfterDelayRoutine(float delay,float duration){
		yield return new WaitForSeconds(delay);
		StartCoroutine(StartFadeRoutine(duration));
	}
	public void StartUnfadeAfterDelay(float delay,float duration){
		fading=true;
		StartCoroutine(StartUnfadeAfterDelayRoutine(delay,duration));

	}
	IEnumerator StartUnfadeAfterDelayRoutine(float delay,float duration){
		yield return new WaitForSeconds(delay);
		StartCoroutine(StartUnfadeRoutine(duration));
	}



	Coroutine Unfade;
	Coroutine Fade;



	public void StartFade(float duration){
		if(Unfade!=null)
		StopCoroutine(Unfade);
		fading=true;
		Fade = StartCoroutine(StartFadeRoutine(duration));
	}
	public void StartUnfade(float duration){
		if(Fade!=null)
		StopCoroutine(Fade);
		fading=true;
		Unfade =StartCoroutine(StartUnfadeRoutine(duration));
	}

	IEnumerator StartUnfadeRoutine(float duration){
		float time = 0;
		while(time < duration){
			time += Time.fixedDeltaTime;
			foreach(Material m in ActiveMaterials){
				float f = m.GetFloat("_Fade");
				float max = m.GetFloat("_MaxTransparacy");

				if((time/duration) > f)
					m.SetFloat("_Fade", Mathf.Clamp((time/duration),0,max));
			}
			if(cGroup !=null)
				cGroup.alpha = (time/duration);
			yield return new WaitForSeconds(.0001f);
		}
		foreach(Material m in ActiveMaterials)
			m.SetFloat("_Fade",  m.GetFloat("_MaxTransparacy"));
		
			if(cGroup !=null){
				cGroup.interactable =true;
				cGroup.blocksRaycasts =true;
				cGroup.alpha = 1;
		}
			Visable = true;
		fading=false;
	}
	IEnumerator StartFadeRoutine(float duration){
		float time = duration;
		while(time > 0){
			time -= Time.fixedDeltaTime;
//			Debug.Log("Fade " );
			foreach(Material m in ActiveMaterials){
				float f = m.GetFloat("_Fade");
				float max = m.GetFloat("_MaxTransparacy");

				if((time/duration) < f)
					m.SetFloat("_Fade",  Mathf.Clamp((time/duration),0,max)); // m.SetFloat("_Fade",  Mathf.Clamp((time/duration),.8f,max)); 
			}
			if(cGroup !=null)
				cGroup.alpha = (time/duration);
			yield return new WaitForSeconds(.0001f);
		}
		foreach(Material m in ActiveMaterials)
			m.SetFloat("_Fade",0); //m.SetFloat("_Fade", 0);
		if(cGroup !=null){
				cGroup.interactable =false;
				cGroup.blocksRaycasts =false;
			cGroup.alpha = 0; //cGroup.alpha = 0;
		}
		Visable = false;
		fading=false;
		
	}
}
