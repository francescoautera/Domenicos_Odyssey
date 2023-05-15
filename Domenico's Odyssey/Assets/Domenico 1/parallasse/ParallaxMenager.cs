using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMenager : MonoBehaviour
{
    [Tooltip("Qua vanno inseriti tutti i materiali del parallasse")]
    public List<Material> materials = new List<Material>();
    [Range(0.01f,1),Tooltip("questa è la velocità generale di tutto" )]
    public float velocity;
    [Tooltip("in base alla loro posizione nella lista l'elemento va più veloce, più è in alto e meno va veloce")]
    public float orderWeight;
    public bool vertical;
      // Update is called once per frame
    void Update()
    {
        for (int i=0; i<materials.Count; i++)
        {
           Vector2 tmp= materials[i].GetTextureOffset("_MainTex");
            if (vertical)
            {
                tmp += new Vector2(0, (orderWeight * i+1)*(Time.deltaTime/2*velocity) );
                materials[i].SetTextureOffset("_MainTex", tmp );
            }
            else
            {
                tmp +=new Vector2((orderWeight * i+1)*(Time.deltaTime/2*velocity) , 0);
                materials[i].SetTextureOffset("_MainTex", tmp);

            }
        }
    }
}
