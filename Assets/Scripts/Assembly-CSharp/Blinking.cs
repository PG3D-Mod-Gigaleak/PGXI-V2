using UnityEngine;

public class Blinking : MonoBehaviour
{
	public float halfCycle = 1f;

	private MeshRenderer meshRenderer;

	private float _time;

	private void Start()
	{
		meshRenderer = GetComponent<MeshRenderer>();
	}

	private void Update()
	{
		_time += Time.deltaTime;
		if (meshRenderer != null)
		{
			Color color = meshRenderer.sharedMaterial.GetColor("_Color");
			float num = 2f * (_time - Mathf.Floor(_time / halfCycle) * halfCycle) / halfCycle;
			if (num > 1f)
			{
				num = 2f - num;
			}
			meshRenderer.sharedMaterial.SetColor("_Color", new Color(color.r, color.g, color.b, num));
		}
	}
}
