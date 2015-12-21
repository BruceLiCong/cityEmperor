using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour {

    private bool _levelEditor = true;
    public float movementFactor = 1.0f;
	// Use this for initialization
	void Start () {
        centerCamera();
	}
	// Update is called once per frame
	void Update () {
        //Camera Movement
        if (Input.GetKeyDown("a"))
        {
            gameObject.transform.Translate(Vector3.left * movementFactor);
        }
        if (Input.GetKeyDown("s"))
        {
            gameObject.transform.Translate(Vector3.down * movementFactor);
        }
        if (Input.GetKeyDown("d"))
        {
            gameObject.transform.Translate(Vector3.right * movementFactor);
        }
        if (Input.GetKeyDown("w"))
        {
            gameObject.transform.Translate(Vector3.up * movementFactor);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Grid.grid.turnLevelIntoFile();
        }
        //Level Editor Mode
        if (Input.GetKeyDown("l"))
        {
            _levelEditor = !_levelEditor;
        }
        if (_levelEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                checkCollision();
            } 
        }
	}
    private void centerCamera()
    {
        float xposition = (float)(Grid.grid.getSizeX() * Grid.grid.getSizeOfTerrain()) / 2 - (float)(Grid.grid.getSizeOfTerrain())/2;
        float yposition = (float)(Grid.grid.getSizeY() * Grid.grid.getSizeOfTerrain()) / 2 - (float)(Grid.grid.getSizeOfTerrain())/2;
        transform.position = new Vector3(xposition, yposition);
    }
    private void checkCollision()
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
        if (hit)
        {
            Debug.Log("Hit " + hitInfo.transform.gameObject.name);
            if (hitInfo.transform.gameObject.tag == "Terrain")
            {
                //Debug.Log("It's working!");
                hitInfo.transform.gameObject.GetComponent<terrainControl>().turnIntoWater();
            }
        }
    }
}
