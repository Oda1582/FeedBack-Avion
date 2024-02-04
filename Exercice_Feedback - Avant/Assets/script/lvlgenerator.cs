using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlgenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D TxtLimit;
    public Texture2D TxtWalls;
    public Texture2D TxtObstacles;
    public Texture2D TxtEnnemys;
    public Texture2D TxtScraps;

    public List<Texture2D> TxtLvlgenerator;

    public GameObject gWall;
    public GameObject gEnnemy;
    public GameObject gObstacle;
    public GameObject gScrap;

    void Start()
    {
        StartCoroutine(LateStart(1f));
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //Your Function You Want to Call
        generate();
    }
  
    private void generate() //noir limite et wall, rouge ennemy, bleu obstacle, vert scrap, blanc vide
    {
        GameObject obj;
        Texture2D togenerate;
        int HightPos = -TxtLvlgenerator.Count/2*20;
        for (int t=0;t<TxtLvlgenerator.Count;t++)
        {
            togenerate = TxtLvlgenerator[t];
            HightPos = -TxtLvlgenerator.Count / 2 * 20 + (t * 20);

            for (int i = 0; i < togenerate.width; i++)
            {
                for (int j = 0; j < togenerate.height; j++)
                {
                    
                    Vector3 Position = new Vector3((togenerate.width / 2 * -20) + i * 20, HightPos, (togenerate.height / 2 * -20) + j * 20);
                    Color c = togenerate.GetPixel(i, j);
                    
                    if (c == Color.black) // wall
                    {
                        obj = Instantiate(gWall);
                        obj.transform.position = Position;
                    }else if(c == Color.red)//ennemy
                    {
                        obj = Instantiate(gEnnemy);
                        obj.transform.position = Position;
                    }
                    else if (c == Color.blue)//obstacle
                    {
                        obj = Instantiate(gObstacle);
                        obj.transform.position = Position;
                    }
                    else if (c == Color.green)//scrap
                    {
                        obj = Instantiate(gScrap);
                        obj.transform.position = Position;
                    }
                }
            }

            
        }
        
    }

}
