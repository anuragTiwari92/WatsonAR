using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frameBehavior : MonoBehaviour {
    public Renderer imageRenderer;
    private Vector3 framePosition;
	// Use this for initialization
	void Start () {
        //turn the images only in y direction towards the caera
        transform.LookAt(Camera.main.transform);
        Vector3 desiredAngle = new Vector3(0, transform.localEulerAngles.y, 0);
        transform.rotation = Quaternion.Euler(desiredAngle);

        //force the images into the air
        transform.localPosition += new Vector3(0, 20, 0);


	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = Vector3.Lerp(transform.localPosition, framePosition, Time.deltaTime * 4f);

	}

    public void getImage(string url){
        StartCoroutine(LoadImg(url));
    }
    IEnumerator LoadImg(string url){
        WWW wWW = new WWW(url);
        yield return wWW;
        imageRenderer.material.mainTexture = wWW.texture;
    }
}
