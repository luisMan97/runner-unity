using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;

    private float lastTargetX;

    private void Start()
    {
        if (target != null)
            lastTargetX = target.position.x;
    }

    private void Update()
    {
        if (target != null)
        {
            if (target.position.x != lastTargetX)
            {
                transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
                lastTargetX = target.position.x;
            }
        }
    }
}
