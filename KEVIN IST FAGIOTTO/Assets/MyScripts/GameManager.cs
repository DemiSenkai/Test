using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    
    Renderer renderer = null;

    GameObject selection = null;

    Material originalMarerial;
    GameObject originalSelection;

    public Material highlightMaterial;

    // Use this for initialization
    void Start () {
    }
	

    void SelectGameObject(GameObject currentSelection)
    {
        if(!currentSelection.Equals(selection))
        {
            if (selection != null)
            {
                //Altes Material wiederherstellen
                selection.GetComponent<Renderer>().sharedMaterial = originalMarerial;

            }

            //Material zwischenspeichern(für deselection)
            originalMarerial = currentSelection.GetComponent<Renderer>().sharedMaterial;

            //GameObject selecten
            selection = currentSelection;

            //GameObject als selected markieren
            selection.GetComponent<Renderer>().sharedMaterial = highlightMaterial;
        }
    }

    void DeselectGameObject()
    {
        if(selection != null)
        {
            //Ursprüngliches Material wiederherstellen
            selection.GetComponent<Renderer>().sharedMaterial = originalMarerial;

            //GameObject deselecten
            selection = null;
        }

    }


	// Update is called once per frame
	void Update () {

        if(selection != null)
        {
            Debug.Log(selection.transform.name);
        }
        
        //Wenn linksclick
		if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse left-klick.");

            Ray mousePoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit;
            if(Physics.Raycast((mousePoint), out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "Selectable")
                {

                    Debug.DrawRay(mousePoint.origin, mousePoint.direction * hit.distance, Color.green);
                    Debug.Log("Hit Object: " + hit.transform.gameObject.name);

                    SelectGameObject(hit.transform.gameObject);
                }
                else
                {
                    DeselectGameObject();
                    Debug.DrawRay(mousePoint.origin, mousePoint.direction * hit.distance, Color.red);
                }
            }
            else
            {
                DeselectGameObject();
                Debug.DrawRay(mousePoint.origin, mousePoint.direction * 1000, Color.white);
            }
        }
	}
}
