
using UnityEngine;

public class scroll : MonoBehaviour
{

public Material material;
public float xVel = 0.7f;
Vector2 offset;
    void Start()
    {
       
    }

  
    void Update()
    {
     offset = new Vector2(xVel,0);
     material.mainTextureOffset += offset * Time.deltaTime;  
    }
}
