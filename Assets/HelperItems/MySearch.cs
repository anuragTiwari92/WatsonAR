using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MySearch : MonoBehaviour {
    public MyImage _imagestore;
    public Text _buttonText;
    private const string API_Key = "*******************************";
	/*
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}*/

    public void getImage(){
        StartCoroutine(URLtoUnity());
    }

    IEnumerator URLtoUnity(){
        _buttonText.transform.parent.gameObject.SetActive(false);
        string _mysearch = _buttonText.text;
        _mysearch = WWW.EscapeURL(_mysearch + " hd images");
        _imagestore.removeOldImages();
        Vector3 _cameraFor = Camera.main.transform.forward;

        int rowNum = 1;
        for (int i = 1; i <= 60; i+=10){
            string _url = "https://www.googleapis.com/customsearch/v1?q=" + _mysearch +
                          "&cx=014907212873801323989%3Ajagdujrekw0&filter=1&num=10&searchType=image&start=" + i + 
                          "&fields=items%2Flink&key=" + API_Key;
            WWW www = new WWW(_url);
            yield return www;
            _imagestore.getImagesList(ParseJsonResponse(www.text),rowNum,_cameraFor);
            rowNum++;
        }
        yield return new WaitForSeconds(5f);
        _buttonText.transform.parent.gameObject.SetActive(true);
    }

    List<string> ParseJsonResponse(string text){
        List<string> jasonList = new List<string>();
        string[] urls = text.Split('\n');
        foreach(string line in urls){
            if(line.Contains("link")){
                string url = line.Substring(12, line.Length-13);
                if(url.Contains(".jpg")||url.Contains(".png")){
                    jasonList.Add(url);
                }
            }
        }
        return jasonList;
    }

}
