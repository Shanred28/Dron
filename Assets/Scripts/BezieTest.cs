using UnityEngine;

public class BezieTest : MonoBehaviour
{
    [SerializeField] private Transform p0;
    [SerializeField] private Transform p1;
    [SerializeField] private Transform p2;
    [SerializeField] private Transform p3;
    
    [SerializeField] private float time;
    void Update()
    {
        transform.position = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, time);
        transform.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivative(p0.position, p1.position, p2.position, p3.position, time));
    }

    private void OnDrawGizmos()
    {
        int sigmentsNumber = 20;
        Vector3 preeviousePoint = p0.position;
        for (int i = 0; i < sigmentsNumber + 1; i++)
        { 
            float parameter = (float)i/ sigmentsNumber;
            Vector3 point = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, parameter);
            Gizmos.DrawLine(preeviousePoint, point);
            preeviousePoint = point;
        }
    }

}
