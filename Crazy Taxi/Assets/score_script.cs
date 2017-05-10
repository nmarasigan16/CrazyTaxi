using UnityEngine;
using System.Collections;
using TMPro;

public class score_script : MonoBehaviour {
    private TextMeshPro text;
    int score;

	// Use this for initialization
	void Start () {
        text = transform.Find("Score").gameObject.GetComponent<TextMeshPro>();
        score = 0;
        text.SetText("Score: \r\n" + score.ToString());
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void update_score(int added)
    {
        score += added;
        text.SetText("Score: \r\n" + score.ToString());
    }
}
