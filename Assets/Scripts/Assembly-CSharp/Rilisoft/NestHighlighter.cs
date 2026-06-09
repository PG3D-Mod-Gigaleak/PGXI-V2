using UnityEngine;

namespace Rilisoft
{
    [DisallowMultipleComponent]
    public sealed class NestHighlighter : MonoBehaviour
    {
        private const string COLOR_PORP_NAME = "_OutlineColor";

        private Material _mat;

        private Color _baseColor;

        private Color _colorStart;

        private Color _colorEnd;

        private float _elapsed;

        private bool _forvard = true;

        private void Awake()
        {
            Renderer renderer = GetComponent<Renderer>();
            if (renderer == null || renderer.sharedMaterial == null || !renderer.sharedMaterial.HasProperty("_OutlineColor"))
            {
                base.enabled = false;
                return;
            }
            _mat = renderer.sharedMaterial;
            _baseColor = _mat.GetColor("_OutlineColor");
            _colorStart = new Color(_baseColor.r, _baseColor.g, _baseColor.b, 0f);
            _colorEnd = new Color(_baseColor.r, _baseColor.g, _baseColor.b, 1f);
        }

        private void Update()
        {
            if (Nest.Instance == null || !Nest.Instance.EggIsReady)
            {
                _mat.SetColor("_OutlineColor", _colorEnd);
                return;
            }
            _elapsed += Time.deltaTime;
            if (_elapsed % 2f < 1f)
            {
                _mat.SetColor("_OutlineColor", Color.Lerp(_colorStart, _colorEnd, _elapsed % 2f));
            }
            else
            {
                _mat.SetColor("_OutlineColor", Color.Lerp(_colorEnd, _colorStart, _elapsed % 2f - 1f));
            }
        }
    }
}
