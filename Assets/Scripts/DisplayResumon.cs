using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DisplayResumon", menuName = "DisplayResumon")]
public class DisplayResumon : ScriptableObject
{
    [SerializeField] public static GameObject prefab;

    public static void RenderResumon(Resumon toRender, Vector3 pos)
    {
        GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
        obj.GetComponent<SpriteRenderer>().sprite = toRender.sprite;
    }
}
