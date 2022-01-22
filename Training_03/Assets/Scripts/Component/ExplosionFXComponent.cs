using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ExplosionFXComponent : MonoBehaviour
{
    VisualEffect vfx;
    Vector2 delay;

    private void Awake()
    {
        vfx = GetComponent<VisualEffect>();
    }

    

    public void Init(Color _color, Vector2 _lifetime)
    {
        vfx.SetVector4("Color", new Vector3(_color.r, _color.g, _color.b));
        vfx.SetVector2("Lifetime", _lifetime);
        Invoke("Kill", _lifetime.y);
    }

    void Kill()
    {
        Destroy(this.gameObject);
    }
}
