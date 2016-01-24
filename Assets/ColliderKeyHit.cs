using UnityEngine;
using System.Collections;
using Leap;
public class ColliderKeyHit : MonoBehaviour {
    bool inside = false;
    public Transform start;
    public GameObject key;
    public float time;
    public Transform end;
    public float intervalToCorrect;
    public AudioSource clickAudio;
    //NOTE: For the love of Chuck Norris, do not have any other objects with bone in their name
    const string BONE = "bone3", SPHERE = "Sphere";
    // Use this for initialization
 
    // Update is called once per frame
    void Update()
    {
        StartCoroutine("Correct");
    }
    
    IEnumerator Correct()
    {
        while (true)
        {
            if (iTween.Count(key) == 0 && start.position != key.transform.position)
            {
                iTween.MoveTo(key, start.position, time);
            }
            yield return new WaitForSeconds(intervalToCorrect);
        }
    }

    void AddToScore()
    {
        GameObject score = GameObject.FindGameObjectWithTag("Score");
        UnityEngine.UI.Text scoreText = score.GetComponent<UnityEngine.UI.Text>();
        int scoreNumber = int.Parse(scoreText.text.Substring(6));
        scoreNumber += 10;
        Debug.Log(scoreNumber);
        scoreText.text = "Score:" + scoreNumber.ToString();
        inside = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains(BONE))
        {
            clickAudio.Play();
            iTween.Stop(key);
            iTween.MoveTo(key, end.position, time);
            if (inside)
            {
                AddToScore();
            }
        }
        else if (other.gameObject.name == SPHERE)
        {
            print("Hello world");
            print(other.gameObject.name);
            inside = true;
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Contains(BONE) && inside)
        {
            AddToScore();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains(BONE))
        {
            iTween.Stop(key);
            iTween.MoveTo(key, start.position, time);
        }
        else if(other.gameObject.name.Contains(SPHERE))
        {
            inside = false;
        }
    }
}
