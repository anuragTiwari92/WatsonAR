using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyImage : MonoBehaviour {
    public GameObject framePrefab;
    public MySearch _myGoogleSearch;
	/*
	 * // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}*/
    public void removeOldImages(){
        if(transform.childCount>0){
            foreach(Transform child in this.transform){
                Destroy(child.gameObject);
            }
        }  
    }
    public void getImagesList(List<string>urlList, int resultNum, Vector3 _camFor){
        int frameNum = 1;
        Vector3 centre = Camera.main.transform.position;
        foreach (string url in urlList)
        {
            Vector3 _framePosition = NewPosition(frameNum, resultNum, _camFor);
            GameObject frame = Instantiate(framePrefab,_framePosition, Quaternion.identity, this.transform);
            frame.GetComponent<frameBehavior>().getImage(url);
            frameNum++;
        }
    }

    Vector3 NewPosition(int frameNum, int rowNum, Vector3 _camForwards){
        Vector3 _framePosition = Vector3.zero;
        if(frameNum<=5){
            _framePosition = _camForwards + new Vector3(frameNum * -3, 0, rowNum * 3.5f);
        }
        else{
            _framePosition = _camForwards + new Vector3((frameNum % 5) * 3, 0, rowNum * 3.5f);
        }
        return _framePosition;
    }
}
