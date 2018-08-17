using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit_params : MonoBehaviour {

	public int hitPoints;
	public int damage;
	public int attackDistance;
	public LineRenderer hitpointsLine;


	private void FixedUpdate()
	{

		if (hitPoints >= 0)
		{
			hitpointsLine.SetPosition(1,new Vector3(0,0,0.1f + hitPoints/10f));
			
			float hue = 0.3f - (10 - hitPoints) / 30f;
			Color lineColor = Color.HSVToRGB(hue, 1, 1);
			Gradient gradient = new Gradient();
			gradient.SetKeys(
				new GradientColorKey[] {new GradientColorKey(lineColor, 0.0f), new GradientColorKey(lineColor, 1.0f)},
				new GradientAlphaKey[] {new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f)});
			hitpointsLine.colorGradient = gradient;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, attackDistance);
	}
}
