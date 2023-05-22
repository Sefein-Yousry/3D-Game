using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vision : MonoBehaviour
{
    public string targetTag = "Player";
    public Agent agentData;

    private void Awake()
    {
        agentData = GetComponentInParent<Agent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject target = other.gameObject;
        string Tag = target.tag;
        if (Tag.Equals(targetTag) == false )
        {
            return;
        }
        Vector3 agentPosition = gameObject.transform.position;
        Vector3 targetPosition = target.transform.position;
        Vector3 direction = targetPosition - agentPosition;

        Ray ray = new Ray(agentPosition, direction.normalized);
        RaycastHit hit;
        Debug.DrawRay(agentPosition, direction);
        if(Physics.Raycast(ray, out hit, direction.magnitude)) 
        { 
            if(hit.collider.gameObject.tag.Equals(targetTag))
            { 
                agentData.target = target;
                return;
            }
        }
        agentData.target = null;
    }

    private void onTriggerExit(Collider other) 
    {
        if(agentData.target != null && other.gameObject == agentData.target)
        {
            agentData.target = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
