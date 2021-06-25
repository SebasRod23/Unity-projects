using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public DistanceJoint2D joint;
    public Vector3 targetPos;
    RaycastHit2D hit;
    public float maxRopeDistance = 5f;
    public LayerMask mask;
    public LineRenderer rope;
    public Transform shootPoint;
    public bool hooked;
    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
        hooked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !hooked) Connect();
        else if (Input.GetKeyDown(KeyCode.Mouse1) && joint.enabled) Release();

        if (rope.gameObject.active) rope.SetPosition(0, shootPoint.position);

    }
    void Connect()
    {
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = 0;
        hit = Physics2D.Raycast(transform.position, targetPos - transform.position, Vector2.Distance(transform.position, targetPos), mask);
        float distance= Vector2.Distance(transform.position, hit.point);
        if (hit.collider != null && distance<=maxRopeDistance)
        {
            SoundManager.PlaySound("Shot");
            GetComponent<Animator>().SetBool("isFalling", true);
            GetComponent<Animator>().ResetTrigger("isHitted");
            GetComponent<Animator>().ResetTrigger("disappear");
            GetComponent<Animator>().ResetTrigger("jump");
            GetComponent<Animator>().ResetTrigger("doubleJump");
            joint.enabled = true;
            joint.distance = Vector2.Distance(transform.position, hit.point);
            joint.connectedAnchor = new Vector2(targetPos.x, targetPos.y);
            //joint.connectedAnchor = new Vector2(targetPos.x-hit.collider.gameObject.transform.position.x, targetPos.y-hit.collider.gameObject.transform.position.x);
            GetComponent<Player>().enabled = false;
            rope.gameObject.active = true;
            rope.SetPosition(0, shootPoint.position);
            rope.SetPosition(1, targetPos);
            hooked = true;
        }
    }
    void Release()
    {
        joint.enabled = false;
        GetComponent<Player>().enabled = true;
        GetComponent<Player>().jumps = 2;
        rope.gameObject.active = false;
        hooked = false;
    }
}
