using UnityEngine;
using System.Collections;
using System.IO;




public class Spawn : MonoBehaviour {
    public GameObject blackNote;
    public GameObject whiteNote;
    public float timeDelay = 1f;
    public ArrayList song = new ArrayList { 0, 1, 12, 2, 12, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};

    bool Contains(int[] array,int value)
    {
        foreach (int number in array)
        {
            if (number == value)
            {
                return true;
            }
        }
        return false;
    }
    IEnumerator Birth()
    {
        int[] blackKeys = { 1, 3, 6, 8, 10 };
        int[] whiteKeys = { 0, 2, 4, 5, 7, 9, 11 };
        foreach (int keyindex in song)
        {
            if (keyindex > 11)
            {
                yield return new WaitForSeconds(timeDelay);
            }

            else if (keyindex < 12)
            {
                Transform randomChild = transform.GetChild(keyindex);

                GameObject note = whiteNote;
                if (Contains(blackKeys, keyindex))
                {
                    note = blackNote;
                }
                Instantiate(note, randomChild.position, Quaternion.identity);
                yield return new WaitForSeconds(timeDelay);
            }
        }

        /*while (true)
        {
            int[] blackKeys = { 1,3,6,8,10 };
            int[] whiteKeys = { 0,2,4,5,7,9,11};
            int randomChildIndex = UnityEngine.Random.Range(0, transform.childCount);
            Transform randomChild = transform.GetChild(randomChildIndex);
            GameObject note = whiteNote;
            if (Contains(blackKeys, randomChildIndex))
            {
                note = blackNote;
            }
            Instantiate(note, randomChild.position, Quaternion.identity);
            yield return new WaitForSeconds(timeDelay);
        }*/
    }
    void Start()
    {
        StartCoroutine("Birth");
    }
    void Update()
    {
        
    }
}
/*public class Spawn : MonoBehaviour
{
    public GameObject note;
    public float timeDelay = 1f;

    IEnumerator Birth()
    {
        while (true)
        {
            Instantiate(note, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(timeDelay);
        }
    }

    void Start()
    {
        StartCoroutine("Birth");
    }
}*/