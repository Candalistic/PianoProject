using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;



public class Spawn : MonoBehaviour {
    public GameObject blackNote;
    public GameObject whiteNote;
    public float timeDelay = 1f;
    public string [] song;

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
        for (int i=0; i < song.Length; i++)
        {
            if (int.Parse(song[i]) > 11)
            {
                yield return new WaitForSeconds(timeDelay);
            }

            else if (int.Parse(song[i]) < 12)
            {
                Transform randomChild = transform.GetChild(int.Parse(song[i]));
                GameObject note = whiteNote;
                if (Contains(blackKeys, int.Parse(song[i])))
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
        // Getting string array from the input song file

        string[] lines = System.IO.File.ReadAllLines(@"Songs\\twinkle.txt");
        char space = ' ';
        song = lines[0].Split(space);
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