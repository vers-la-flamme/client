
using UnityEngine;

public class mouse_highlight : MonoBehaviour {

	private Color highlightColor;
	private Color temp_highlightColor;
	private Renderer rend;
	Material m_Material;
	public GameObject[] Unit;
	private Color distanceColor = new Vector4(0.25F,0.25F,0,1);
	private Color overColor = new Vector4(0.5F,0,0,1);

	
	void Start()
	{
		rend = gameObject.GetComponent<Renderer>();
		highlightColor = rend.material.GetColor("_Color");
		temp_highlightColor = highlightColor;
		
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			Unit = GameObject.FindGameObjectsWithTag("unit");
			foreach (GameObject cur_unit in Unit)
			{
				if (Vector3.Distance(cur_unit.transform.position, transform.position) < cur_unit.GetComponent<unit_params>().attackDistance)
				{
					rend.material.SetColor("_Color", highlightColor + distanceColor);
				}					
			}
		}
		else if(Input.GetMouseButtonUp(0))
		{
			rend.material.SetColor("_Color", highlightColor);
		}
	}

	void OnMouseEnter()
	{
		temp_highlightColor = rend.material.GetColor("_Color");
        rend.material.SetColor("_Color", temp_highlightColor + overColor);
	}

	 void OnMouseExit()
    {		
		rend.material.SetColor("_Color", temp_highlightColor);
	}
}