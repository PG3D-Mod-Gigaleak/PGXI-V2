using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class FireFade : MonoBehaviour
{
    public float smokeDestroyTime = 6f;

    public float destroySpeed = 0.05f;

    private bool destroyEnabled;

    public virtual IEnumerator Start()
    {
        yield return new WaitForSeconds(smokeDestroyTime);
        destroyEnabled = true;
    }

    public virtual void Update()
    {
        if (destroyEnabled)
        {
            Renderer particleRenderer = GetComponent<Renderer>();
			Color color = particleRenderer.materials[1].GetColor("_TintColor");
			color.a -= destroySpeed * Time.deltaTime;
			particleRenderer.materials[1].SetColor("_TintColor", color);
        }
    }

    public virtual void Main()
    {
    }
}
