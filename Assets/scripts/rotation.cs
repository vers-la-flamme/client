
using UnityEngine;


public class rotation : MonoBehaviour {
	Vector3 angle;
	
	public enum osi {x,y,z};
	public osi Curr_axis;
	// Use this for initialization
	void Start () {

		angle = transform.eulerAngles;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Curr_axis == osi.x)
		{
			angle.x += Time.deltaTime*100;
			transform.eulerAngles = angle;
		}
		else if (Curr_axis == osi.y)
		{
			angle.y += Time.deltaTime*100;
			transform.eulerAngles = angle;
		}
		else
		{
			angle.z += Time.deltaTime*100;
			transform.eulerAngles = angle;
		}
			
	}
}
