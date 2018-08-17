using UnityEngine;


public class unit_movement : MonoBehaviour {
	
	private Vector3 newPosition;
	private Vector3 temPosition;
	private GameObject active;
	public GameObject attackEffect;

	public void Update()
	{
		
		if (active != null)
		{
			var activeCollider =  active.GetComponent<Collider>();
			
			if (Input.GetMouseButtonDown(1))
			{
				
				PlayerMove(active);
				
			}
			active.transform.Rotate(Vector3.up);
		}
		if (Input.GetMouseButtonDown(0))
		{
			PlayerSelect();
		}
	}

	private void PlayerSelect()
	{
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 3000))
		{
			var unit = FindHere(hit.collider.gameObject.transform.position);
			active = unit;
		}
	}

	private void PlayerMove(GameObject active)
	{
		temPosition = active.transform.position;
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 3000))
		{
			GameObject cellObject = FindHere(hit.transform.position);
			if (cellObject != null && cellObject != active)
			{
				Attack(cellObject,active);
				cellObject.GetComponent<unit_params>().hitPoints -= active.GetComponent<unit_params>().damage;
			}
			else
			{
				newPosition = hit.collider.gameObject.transform.position;
				active.transform.position = new Vector3(newPosition.x, temPosition.y, newPosition.z);
			}
		}
	}

	public void Attack(GameObject target, GameObject self)
	{
		
		var force = target.transform.position - self.transform.position;
		var spawn = self.transform.position + force.normalized * 1.2f; 
		
		GameObject fireball = Instantiate(attackEffect, spawn, Quaternion.AngleAxis(0f,Vector3.zero));
		fireball.GetComponent<Rigidbody>().AddForce(force.normalized*500f);
		
	}

	private GameObject FindHere(Vector3 pose)
	{
		GameObject[] units = GameObject.FindGameObjectsWithTag("unit");
		foreach (var unit in units)
		{
			if (unit.transform.position.x == pose.x && unit.transform.position.z == pose.z)
			{
				return unit;
			}
		}
		return null;
	}
}
