using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceController : MonoBehaviour
{
    MeshRenderer mr;
    Material material;
    [SerializeField] float parralax;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        material = mr.material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = material.mainTextureOffset;
        offset.y += Time.deltaTime * speed / parralax;

        material.mainTextureOffset = offset;
        
    }
}
