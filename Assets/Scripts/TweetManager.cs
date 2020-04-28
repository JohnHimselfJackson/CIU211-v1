using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TweetManager : MonoBehaviour
{
    int testVal = 0;
    public TMP_Text tweetTB;

    private List<string> _tweets = new List<string>();
    public List<string> tweets
    {
        get
        {
            return _tweets;
        }
    }
    public string newTweet
    {
        get
        {
            // returns last string in list
            return _tweets[_tweets.Count];
        }
        set
        {
            // when new tweet string is set adds that to the list _tweets
            if(_tweets.Count < 5)
            {
                _tweets.Add(value);
            }
            else if (_tweets.Count >= 5)
            {
                _tweets.RemoveAt(0);
                _tweets.Add(value);
            }
            tweetDecayTime = 5;
            RefreshTweets();
        }
    }
    private float tweetDecayTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TweetDecay();
    }

    void TweetDecay()
    {
        if(tweetDecayTime > 0)
        {
            tweetDecayTime -= Time.deltaTime;
        }
        else if(tweetDecayTime <= 0 && tweets.Count > 0)
        {
            _tweets.RemoveAt(0);
            tweetDecayTime = 5;
            RefreshTweets();
        }
    }

    void RefreshTweets()
    {
        string newString = null;
        for(int ss = tweets.Count - 1; ss >-1; ss--)
        {
            newString += tweets[ss] + "\n\n";
        }

        tweetTB.text = newString;
    }

    void Test()
    {
        newTweet = testVal.ToString();
        testVal++;
    }
}
