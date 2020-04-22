using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetSupplies : MonoBehaviour
{
    public GameObject GoHomePanel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Supplies")
        {
            //GoHomePanel.SetActive(true);
            //this.gameObject.GetComponent<WaypointMaker>().enabled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (col.gameObject.tag == "Finish" )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Supplies")
        {
            GoHomePanel.SetActive(false);
            col.gameObject.SetActive(false);

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //Destroy(col.gameObject);


            //this.gameObject.GetComponent<WaypointMaker2>().enabled = true;
        }
    }
}
