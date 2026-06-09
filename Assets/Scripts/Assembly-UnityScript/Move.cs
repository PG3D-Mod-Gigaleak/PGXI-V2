using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class Move : MonoBehaviour
{
    public Transform target;

    public float speed;

    public float smokeDestroyTime;

    public Renderer smokeStem;

    public float destroySpeed;

    public float destroySpeedStem;

    private bool destroyEnabled;

    public virtual IEnumerator Start()
    {
        yield return new WaitForSeconds(smokeDestroyTime);
        destroyEnabled = true;
    }

    public virtual void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
        Color color = default(Color);
        if (destroyEnabled)
        {
            Renderer particleRenderer = GetComponent<Renderer>();
            color = particleRenderer.material.GetColor("_TintColor");
            Color color2 = smokeStem.material.GetColor("_TintColor");
            if (!(color.a <= 0f))
            {
                color.a -= destroySpeed * Time.deltaTime;
            }
            if (!(color2.a <= 0f))
            {
                color2.a -= destroySpeedStem * Time.deltaTime;
            }
            smokeStem.material.SetColor("_TintColor", color2);
            particleRenderer.material.SetColor("_TintColor", color);
        }
        if (!(color.a >= 0f))
        {
            UnityEngine.Object.Destroy(transform.root.gameObject);
        }
    }

    public virtual void Main()
    {
    }
}
