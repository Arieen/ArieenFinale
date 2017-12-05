using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform Player;
	public bool cambiado;

    public Vector2
        Margin,
        Smoothing;

    public BoxCollider2D BoundsRealWorld;
    public BoxCollider2D BoundsFantasyWorld;

    private Vector3
    _min,
    _max;


    public bool IsFollowing { get; set; }


    public void Start()
    {		
        _min = BoundsRealWorld.bounds.min;
        _max = BoundsRealWorld.bounds.max;
        IsFollowing = true;

    }

    public void Update()
    {
		
        var x = transform.position.x;
        var y = transform.position.y;

		var dimension = GameObject.Find ("Arieen").gameObject.GetComponent<CambiarSprite> ().mundo; 

		if (dimension == "ChangeCameraToRillion") 
        {
	        _min = BoundsRealWorld.bounds.min;
	        _max = BoundsRealWorld.bounds.max;
			y = Mathf.Lerp(y + 50, Player.position.y, Smoothing.y * Time.deltaTime);
			GameObject.Find ("Arieen").gameObject.GetComponent<CambiarSprite> ().mundo = "Rillion";
        }

		else if ( dimension == "ChangeCameraToNormal")
        {
	        _min = BoundsFantasyWorld.bounds.min;
	        _max = BoundsFantasyWorld.bounds.max;
			y = Mathf.Lerp(y - 50 , Player.position.y, Smoothing.y * Time.deltaTime);
			GameObject.Find ("Arieen").gameObject.GetComponent<CambiarSprite> ().mundo = "Normal";
		}
        

        if (IsFollowing)
        {
            if (Mathf.Abs(x - Player.position.x) > Margin.x)
                x = Mathf.Lerp(x, Player.position.x, Smoothing.x * Time.deltaTime);
            if (Mathf.Abs(y - Player.position.y) > Margin.y)
                y = Mathf.Lerp(y, Player.position.y, Smoothing.y * Time.deltaTime);
        }
        var cameraHalfWidth = GetComponent<Camera>().orthographicSize * ((float)Screen.width / Screen.height);
        x = Mathf.Clamp(x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
        y = Mathf.Clamp(y, _min.y + GetComponent<Camera>().orthographicSize, _max.y - GetComponent<Camera>().orthographicSize);
        transform.position = new Vector3(x, y, transform.position.z);

    }
}


