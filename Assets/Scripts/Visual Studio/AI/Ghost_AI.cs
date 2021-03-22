using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost_AI : MonoBehaviour
{
    NavMeshAgent nav;
    public int frameInterval = 10;
    public int facePlayerFactor = 50;

    public GameObject player;

    // take cover/hide
    Vector3 randomPosition;
    Vector3 coverPoint;
    public float rangeRandPoint = 6f; // 4f
    public bool isHiding = false;

    // GoToCover
    public LayerMask coverLayer; // to set the layer that should be used as cover
    Vector3 coverObj; // to storee the cover object positions
    public LayerMask visibleLayer; // to declare objects on layer that might obstruct the view between AI and target/player

    private float maxCoverDistance = 30; // if distance to cover is greater than this, do something else
    public bool coverIsClose; // is cover in reach?
    public bool coverNotReached = true; // if true, AI is not close enough to the cover object

    public float distToCoverPos = 1f; //1f
    public float distToCoverObj = 20f; // 60f

    public float rangeDist = 15f;
    public bool playerInRange = false;


    private int testCoverPos = 10;

    //bool to find positions behind cover
    bool RandomPoint(Vector3 center, float rangeRandPoint, out Vector3 resultCover)
    {
        for (int i = 0; i < testCoverPos; i++)
        {
            randomPosition = center + Random.insideUnitSphere * rangeRandPoint;
            Vector3 direction = player.transform.position - randomPosition;
            RaycastHit hitTestCov;
            if (Physics.Raycast(randomPosition, direction.normalized, out hitTestCov, 10f, visibleLayer))
            {
                if(hitTestCov.collider.gameObject.layer == 18)
                {
                    resultCover = randomPosition;
                    return true;
                }
            }    
        }
        resultCover = Vector3.zero;
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(nav.isActiveAndEnabled) // to this only every few frames, no need to do it every frame
        {
            float distance = ((player.transform.position - transform.position).sqrMagnitude); //check distancee to player

            if (distance < rangeDist * rangeDist)
            {
                playerInRange = true;
            }
            else playerInRange = false;
        }

        if(playerInRange == true) // if true, do something
        {
            CheckCoverDist(); // check if cover is close enough

            if (coverIsClose == true)
            {
                if(coverNotReached == true)
                {
                    nav.SetDestination(coverObj); // got to thee cover obj
                }

                if (coverNotReached == false) // when close enough to cover, take cover
                {
                    TakeCover();
                }
            }
        }
    }

    void CheckCoverDist()
    {
        // Check if cover is in vicinity
        Collider[] colliders = Physics.OverlapSphere(transform.position, maxCoverDistance, coverLayer);
        Collider nearestCollider = null;
        float minSqrDistance = Mathf.Infinity;

        Vector3 AI_position = transform.position;

        for (int i = 0; i < colliders.Length; i++)
        {
            float sqrDistanceToCenter = (AI_position - colliders[i].transform.position).sqrMagnitude;
            if(sqrDistanceToCenter < minSqrDistance)
            {
                minSqrDistance = sqrDistanceToCenter;
                nearestCollider = colliders[i];

                //to check if AI is already close enough to take cover
                float coverDistance = (nearestCollider.transform.position - AI_position).sqrMagnitude;

                if (coverDistance <= maxCoverDistance*maxCoverDistance)
                {
                    coverIsClose = true;
                    coverObj = nearestCollider.transform.position;
                    if (coverDistance <= distToCoverObj * distToCoverObj)
                    {
                        coverNotReached = false;
                    }
                    else if (coverDistance > distToCoverObj*distToCoverObj)
                    {
                        coverNotReached = true;
                    }
                }

                if(coverDistance >= maxCoverDistance*maxCoverDistance)
                {
                    coverIsClose = false;
                }
            }
        }

        if (colliders.Length < 1)
        {
            coverIsClose = false;
        }
    }

    void TakeCover()
    {
        if (RandomPoint(transform.position, rangeRandPoint, out coverPoint))
        {
            if(nav.isActiveAndEnabled)
            {
                nav.SetDestination(coverPoint);
                if ((coverPoint - transform.position).sqrMagnitude <= distToCoverPos*distToCoverPos) //0.75f
                {
                    isHiding = true;
                }
            }
        }
    }
}
