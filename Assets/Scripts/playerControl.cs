using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour {

    private bool _levelEditor = true;
	// Use this for initialization
	void Start () {
        centerCamera();
	}
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("i"))
        {
            _levelEditor = !_levelEditor;
        }
        if (_levelEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("Mouse is down");

                RaycastHit hitInfo = new RaycastHit();
                bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
                if (hit)
                {
                    Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                    if (hitInfo.transform.gameObject.tag == "Terrain")
                    {
                        //Debug.Log("It's working!");
                    }
                }
            } 
        }
	}
    private void centerCamera()
    {
        float xposition = (float)(Grid.grid.getSizeX() * Grid.grid.getSizeOfTerrain()) / 2 - (float)(Grid.grid.getSizeOfTerrain())/2;
        float yposition = (float)(Grid.grid.getSizeY() * Grid.grid.getSizeOfTerrain()) / 2 - (float)(Grid.grid.getSizeOfTerrain())/2;
        transform.position = new Vector3(xposition, yposition);
    }
}
