using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaiGeneratorSc : MonoBehaviour
{

    GameDirectorSc game_dir_sc;
    public GameObject kai_big_obj;
    public GameObject kai_obj;


    // Update is called once per frame
    void Start()
    {
        game_dir_sc=GameObject.FindWithTag("GameDirector").GetComponent<GameDirectorSc>();
        StartCoroutine(BigKaiGenerateCoroutine());
        StartCoroutine(SmallKaiGenerateCoroutine());
    }

    void BigKaiGenerate(){
        GameObject insta_obj=Instantiate(kai_big_obj,new Vector3(7f,1f,6f),Quaternion.identity);
        float scale=Random.Range(2.5f,3f);
        insta_obj.transform.localScale=new Vector3(scale,scale,scale);
        //insta_obj.GetComponent<KaiSc>().ok=true;
    }

    void SmallKaiGenerate(){
        Vector3 pos=new Vector3(Random.Range(-0.5f,0.5f) -7f ,5f,Random.Range(-0.5f,0.5f));
        Quaternion qua=Quaternion.Euler(0f,Random.Range(0f,360f),0f);      
        float scale=Random.Range(1f,1.5f);
        GameObject insta_obj=Instantiate(kai_obj,pos,qua); 
        insta_obj.transform.localScale=new Vector3(scale,scale,scale);
    }

    IEnumerator BigKaiGenerateCoroutine(){
        while(true){
            BigKaiGenerate();
            yield return new WaitForSeconds(4f-game_dir_sc.speed*50f);
        }
    }
    IEnumerator SmallKaiGenerateCoroutine(){
        while(true){
            SmallKaiGenerate();
            yield return new WaitForSeconds(2f-game_dir_sc.speed*25f);
        }
    }

}
