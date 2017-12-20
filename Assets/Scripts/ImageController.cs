using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageController : MonoBehaviour {

	public float FadeRate;

	private Image image;
	private float targetAlpha;
	private	float alphaDiff;
	private Color curColor;
	private LevelManager levelManager;
	private bool isReady;

	// Use this for initialization
	void Start () {

		//Initial Definitions
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		image = this.GetComponent<Image>();
		targetAlpha = this.image.color.a;
		curColor = this.image.color;

		if(this.image==null)
		{
			Debug.LogError("Error: No image on "+this.name);
		}

		//Image initialization
		FadeIn ();
	}
	
	// Update is called once per frame
	void Update () {

		alphaDiff = Mathf.Abs (curColor.a - this.targetAlpha);

		if (alphaDiff>0.0001f)
		{
			curColor.a = Mathf.Lerp(curColor.a,targetAlpha,FadeRate*Time.deltaTime);
			this.image.color = curColor;
		}

		if (curColor.a >= 0.8f) {
			FadeOut();
		} 

		if (isReady == true && curColor.a <= 0.05f) {
			levelManager.LoadNextLevel();
		}
	}
	
	public void FadeOut()
	{
		this.targetAlpha = 0.0f;
		isReady = true;
	}
	
	public void FadeIn()
	{
		this.targetAlpha = 1.0f;
		isReady = false;
	}
}
