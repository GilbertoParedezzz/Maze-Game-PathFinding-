using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovingKey : MonoBehaviour
{
    [SerializeField]float Speed;
    Vector3 Pos;
    [SerializeField] GameObject wndrPoint1;
    [SerializeField] GameObject wndrPoint2;
    [SerializeField] GameObject wndrPoint3;
    [SerializeField] GameObject wndrPoint4;
    [SerializeField] GameObject wndrPoint5;
    [SerializeField] GameObject wndrPoint6;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WanderCo());
    }


    IEnumerator WanderCo() {
        while (true){
        
            int trgtIndx = UnityEngine.Random.Range(1, 10);
            Pos = this.transform.position;
            GameObject Trgt = null;
            switch (trgtIndx)
            {
                case 1:
                    Trgt = wndrPoint1;
                    //Debug.Log("Moving to target1");
                    break;
                case 2:
                    Trgt = wndrPoint2;
                    //Debug.Log("Moving to target2");
                    break;
                case 3:
                    Trgt = wndrPoint3;
                    //Debug.Log("Moving to target3");
                    break;
                case 4:
                    Trgt = wndrPoint4;
                   // Debug.Log("Moving to target4");
                    break;
                case 5:
                    Trgt = wndrPoint5;
                    //Debug.Log("Moving to target5");
                    break;
                case 6:
                    Trgt = wndrPoint6;
                    break;
                case 7:
                    Trgt = wndrPoint6;
                    break;
                case 8:
                    Trgt = wndrPoint6;
                    break;
                case 9:
                    Trgt = wndrPoint6;
                    break;

            }

            float moveDuration = 2.5f;
            float elapsedTime = 0.0f;

            while (Trgt != null && elapsedTime < moveDuration)
            {
                transform.position = Vector3.MoveTowards(transform.position, Trgt.transform.position, Speed * Time.deltaTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            yield return new WaitForSeconds(0.25f);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.AddKey();
                Destroy(gameObject);
            }
        }
    }
}
