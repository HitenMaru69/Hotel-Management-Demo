using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPCController : MonoBehaviour
{
    [SerializeField] RoomManager roomManager;
    [SerializeField] GameObject moneyPrefeb;
    [SerializeField] Transform moneySpwanPos;

    public static NPCController Instance;

    public Transform[] queuePositions;    
    public GameObject customerPrefab;     
    public Transform spawnPoint;          
    public float spawnInterval = 3f;      
    public int poolSize = 10;            

    public Queue<GameObject> customerQueue = new Queue<GameObject>(); 
    private Queue<GameObject> customerPool = new Queue<GameObject>();
    private Queue<GameObject> NPCinRoom = new Queue<GameObject>();



    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InitializeObjectPool();
        StartCoroutine(SpawnCustomers());
    }

  
    void InitializeObjectPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject customer = Instantiate(customerPrefab);
            customer.SetActive(false);
            customerPool.Enqueue(customer);
        }
    }
    
    IEnumerator SpawnCustomers()
    {
        while (true)
        {
            if (customerQueue.Count < queuePositions.Length && customerPool.Count > 0)
            {
                GameObject newCustomer = customerPool.Dequeue();
                newCustomer.transform.position = spawnPoint.position;
                newCustomer.SetActive(true);

                NavMeshAgent agent = newCustomer.GetComponent<NavMeshAgent>();
                if (agent == null)
                {
                    Debug.LogError("Customer prefab must have a NavMeshAgent component!");
                }

                customerQueue.Enqueue(newCustomer);
                UpdateQueuePositions();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    
    void UpdateQueuePositions()
    {
        int index = 0;
        foreach (GameObject customer in customerQueue)
        {
            if (customer != null)
            {
                NavMeshAgent agent = customer.GetComponent<NavMeshAgent>();
                if (agent != null)
                {
                    agent.SetDestination(queuePositions[index].position);
                }
                index++;
            }
        }
    }

   
    public void AttendCustomer_Bu()
    {
        if (customerQueue.Count > 0 && customerQueue.Count <= queuePositions.Length)
        {
            for (int i = 0; i < roomManager.rooms.Count; i++)
            {
                if (roomManager.rooms != null && roomManager.rooms[i].type == RoomType.Available)
                {
                    GameObject servedCustomer = customerQueue.Dequeue();
                    MoveToRoom(servedCustomer);
                    UpdateQueuePositions();
                    break;

                }
            }

        }
    }


    void MoveToRoom(GameObject agent)
    {

        NavMeshAgent navMeshAgent = agent.GetComponent<NavMeshAgent>();

        for(int i = 0;i< roomManager.rooms.Count; i++)
        {
            if (roomManager.rooms[i].type == RoomType.Available)
            {
                navMeshAgent.SetDestination(roomManager.rooms[i].transform.Find(NameTag.RoomPos).position);
                roomManager.rooms[i].GetComponent<Room>().type = RoomType.Taken;

                NPCinRoom.Enqueue(agent);

                SpwanMoney();

                break;
            }
        }


    }

    public void NPCLeaveRoom()
    {
        foreach (GameObject agent in NPCinRoom)
        {
            if (agent != null)
            {
   
                StartCoroutine(StartLeaveRoom(agent));
                
            }

        }
    }

    IEnumerator StartLeaveRoom(GameObject agent)
    {
        yield return new WaitForSeconds(5f);

        GameObject NpcLeve = NPCinRoom.Dequeue();

        NavMeshAgent navMeshAgent = NpcLeve.GetComponent<NavMeshAgent>();

        navMeshAgent.SetDestination(spawnPoint.position);

        customerPool.Enqueue(NpcLeve);

        StartCoroutine(DeactiveNPC(NpcLeve));

    }

    IEnumerator DeactiveNPC(GameObject agent)
    {
        yield return new WaitForSeconds(7f);

        agent.SetActive(false);
    }

    void SpwanMoney()
    {
        Instantiate(moneyPrefeb, moneySpwanPos.position,Quaternion.identity);
    }

}
