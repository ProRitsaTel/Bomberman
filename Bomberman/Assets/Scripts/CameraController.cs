using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CameraController : MonoBehaviour
{
	public Field field;
    // Start is called before the first frame update
    void Start()
    {
        var ListOfStone = GameObject.FindGameObjectsWithTag("Stone").ToArray();
        field = new Field()
        {
        	MinX = ListOfStone.Min(x => x.transform.position.x) - 0.5f,
        	MinY = ListOfStone.Min(x => x.transform.position.y) - 0.5f,
        	MaxX = ListOfStone.Max(x => x.transform.position.x) + 0.5f,
        	MaxY = ListOfStone.Max(x => x.transform.position.y) + 0.5f,
        };
    }

    // Update is called once per frame
    void Update()
    {
          float cameraHalfHeigth = GetComponent<Camera>().orthographicSize;
          float cameraHalfWidth = cameraHalfHeigth * ((float)Screen.width/ Screen.height);

          var Bomberman = FindObjectOfType<Bomberman>().transform.position;
          var x = Bomberman.x;
          var y = Bomberman.y;

          x = Mathf.Clamp(x, field.MinX + cameraHalfWidth, field.MaxX - cameraHalfWidth);
          y = Mathf.Clamp(y, field.MinY + cameraHalfHeigth, field.MaxY - cameraHalfHeigth);
          transform.position = new Vector3(x, y, transform.position.z);
    }
    void OnDrawGizmos()
    {
    	Gizmos.color = Color.red;
    	Gizmos.DrawLine(new Vector2(field.MinX,field.MinY),new Vector2(field.MaxX,field.MinY));
    	Gizmos.DrawLine(new Vector2(field.MinX,field.MaxY),new Vector2(field.MaxX,field.MaxY));
    	Gizmos.DrawLine(new Vector2(field.MinX,field.MinY),new Vector2(field.MinX,field.MaxY));
    	Gizmos.DrawLine(new Vector2(field.MaxX,field.MinY),new Vector2(field.MaxX,field.MaxY));
    }
    public struct Field
    {
    	public float MinX;
    	public float MinY;
    	public float MaxX;
    	public float MaxY;
    }
}
