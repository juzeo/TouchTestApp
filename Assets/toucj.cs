using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toucj : MonoBehaviour
{
    public Touch touch;
    public float time = 0;
    public bool keep;
    // Start is called before the first frame update
    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    // Update is called once per frame
    void Update()
    {
        if(keep==false)
        time += Time.deltaTime;
        /*if (touch.phase == TouchPhase.Began)
        {
            keep = true;
            GameObject.Find("Canvas").GetComponent<control>().updatetime(time);
            Destroy(this);
        }
        */
        
    }
    public void OnMouseDown()
    {
        
        keep = true;
        GameObject.Find("Canvas").GetComponent<control>().updatetime(time);
        Destroy(this.gameObject);
    }
}
