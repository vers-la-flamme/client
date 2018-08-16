
using UnityEngine;


public class PlayerController : MonoBehaviour
{
	public GameObject Target;
	public GameObject Shell;
	void Update()
	{
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
 
		transform.Translate(-x, 0, 0);
		transform.Translate(0, 0, -z);
		
		
		Shell.transform.LookAt(Target.transform);
		
		
	}
}