
using UnityEngine;
using UnityEngine.EventSystems;

public class Target : MonoBehaviour
{
	public Camera playerCam;
	
	private RaycastHit hit;
	
	Ray MyRay;
	
	
	public void Update()
	{
		MyRay = playerCam.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast(MyRay, out hit, Mathf.Infinity);
		
		Debug.DrawRay(MyRay.origin, MyRay.direction*10,Color.yellow);

	
		transform.position = new Vector3(hit.point.x,0.5f,hit.point.z);
		Debug.Log(hit.point);
		
	




	}
}


