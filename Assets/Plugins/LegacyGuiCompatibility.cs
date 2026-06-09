using UnityEngine;

/// <summary>
/// Compatibility stubs for Unity's removed legacy GUIText and GUITexture components.
///
/// These are compile-time/runtime placeholders for old Unity 2017 scripts. They
/// do not render UI. Replace affected objects with Canvas/UI.Text/UI.Image when
/// restoring the actual UI behavior.
/// </summary>
public sealed class GUIText : MonoBehaviour
{
    [SerializeField]
    private string _text = string.Empty;

    [SerializeField]
    private Color _color = Color.white;

    [SerializeField]
    private int _fontSize = 13;

    [SerializeField]
    private Font _font;

    [SerializeField]
    private Vector2 _pixelOffset;

    public string text
    {
        get { return _text; }
        set { _text = value; }
    }

    public Color color
    {
        get { return _color; }
        set { _color = value; }
    }

    public int fontSize
    {
        get { return _fontSize; }
        set { _fontSize = value; }
    }

    public Font font
    {
        get { return _font; }
        set { _font = value; }
    }

    public Vector2 pixelOffset
    {
        get { return _pixelOffset; }
        set { _pixelOffset = value; }
    }
}

public sealed class GUITexture : MonoBehaviour
{
    [SerializeField]
    private Texture _texture;

    [SerializeField]
    private Color _color = Color.white;

    [SerializeField]
    private Rect _pixelInset;

    public Texture texture
    {
        get { return _texture; }
        set { _texture = value; }
    }

    public Color color
    {
        get { return _color; }
        set { _color = value; }
    }

    public Rect pixelInset
    {
        get { return _pixelInset; }
        set { _pixelInset = value; }
    }
}
