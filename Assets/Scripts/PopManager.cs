using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public class PopManager : MonoBehaviour
{
    public GameObject botPrefab;
    public int popSize = 60;
    List<GameObject>population = new List<GameObject>();
    public static float elapsed = 0;
    public float trialTime = 6;

    int generation = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GeneratePopulation();
    }


    void Update()
    {
           elapsed += Time.deltaTime;
        if(elapsed>= trialTime)
        {
            GenerateNewPopulation();
            elapsed =0;
        }
    }





    public void GeneratePopulation()
    {
        for (int i =0; i < popSize; i++)
        {
            int mutationRate = Random.Range(0,100);

            Vector3 startPosition = new Vector3(this.transform.position.x + Random.Range(-2,2),this.transform.position.y,this.transform.position.z + Random.Range(-2,2));
            GameObject bot = Instantiate(botPrefab,startPosition,this.transform.rotation);
            bot.GetComponent<BrainVision>().Init();
            population.Add(bot);
         


        }

            

    }


    GameObject Breed(GameObject parent1,GameObject parent2)
    {
        int mutationRate = Random.Range(0,100);

            Vector3 startPosition = new Vector3(this.transform.position.x + Random.Range(-2,2),this.transform.position.y,this.transform.position.z + Random.Range(-2,2));
            GameObject child = Instantiate(botPrefab,startPosition,this.transform.rotation);
            BrainVision b = child.GetComponent<BrainVision>();
            if (mutationRate == 1)
            {
                b.Init();
                b.dna.Mutation();

            }
            else
            {
                b.Init();
                DNA parent1DNA =parent1.GetComponent<BrainVision>().dna;
                DNA parent2DNA = parent1.GetComponent<BrainVision>().dna;
                b.dna.Crossover(parent1DNA,parent2DNA);
            }
            return child;

    }
    void GenerateNewPopulation()
    {
        
        List<GameObject> SortedList = population.OrderBy(gameObject =>gameObject.GetComponent<BrainVision>().timeWalking + gameObject.GetComponent<BrainVision>().timeAlive).ToList();
        
        population.Clear();
         for (int i = (int)(SortedList.Count/2.0f)-1; i<SortedList.Count - 1; i++)
        {
            population.Add(Breed(SortedList[i],SortedList[i+1]));
            population.Add(Breed(SortedList[i+1],SortedList[i]));
        }

        for(int i = 0; i < SortedList.Count; i++)
        {
            Destroy(SortedList[i]);
            generation ++;
        }


    }


}
