using UnityEngine;

public class BrainVision : MonoBehaviour
{

int DNALength =2;
public float timeAlive;
public DNA dna;
public float timeWalking;
public GameObject eyes;
bool  isAlive = true;
bool seeingGround = true;


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "dead")
        {
            Debug.Log("Died at " + timeAlive);
            isAlive = false;
            timeAlive =0;
            timeWalking =0;

            
        }
    }




    public void Init()
    {
        //
        dna = new DNA(DNALength,3);
        timeAlive = 0;
        isAlive = true;


    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vision();
    }

    public void Vision()
    {
        if(!isAlive) return;
        Debug.DrawRay(eyes.transform.position,eyes.transform.forward *10,Color.blue,15);
        seeingGround = false;
        RaycastHit hit;
        if(Physics.Raycast(eyes.transform.position,eyes.transform.forward * 10, out hit))
        {
            if(hit.collider.gameObject.tag == "ground")
            {
                seeingGround = true;
            }
        }
        timeAlive = PopManager.elapsed;

        float turn =0;
        float move= 0;
        if (seeingGround)
        {
            if(dna.GetGene(0) == 0) {move= 1; timeWalking +=1;}
            else if(dna.GetGene(0)==1)turn = -90;
            else if(dna.GetGene(0)==2)turn = -90;


        }
        else
        {
            if(dna.GetGene(1)==0){move  =1; timeWalking +=1;}
            else if(dna.GetGene(1)==1) turn = -90;
            else if(dna.GetGene(1)==2) turn = 90;
        }

        this.transform.Translate(0,0,move* 0.1f);
        this.transform.Rotate(0,turn,0);
    }




}
