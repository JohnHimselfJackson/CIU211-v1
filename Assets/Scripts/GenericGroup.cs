using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GenericGroup : MonoBehaviour
{
    PlayerController pc;
    public int groupSize;
    public GameObject[] npcs;
    public GameObject selectionCircle;
    private bool _selected;
    public bool selected
    {
        get
        {
            return _selected;
        }
        
        set
        {
            _selected = value;
            if(value == true)
            {
                selectionCircle.SetActive(true);
            }
            else
            {
                selectionCircle.SetActive(false);
            }
        }
    }

    public enum Subculture { populars, academics, loners, nerds, normies}
    public Subculture mySubculture = Subculture.normies;
    public List<string> subcultures;
    public GameObject otherGroupWorkerAround;
    public TweetManager tm;
    
    /*
        three types of interactions
            - mingle
            - Repel
            - attract
    */

    int reactionType; //0 = positive 1 = neutral 2 = negative

    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        selected = false;
        subcultures.Add(mySubculture.ToString());
        groupSize = 1;
    }

    private void OnTriggerEnter(Collider collision)
    {
        GameObject colGo = collision.gameObject;
        SetConversing(true);
        tm.newTweet = subcultures[0] + ": Hmmm, i wonder what the " + (string)colGo.GetComponent<GenericGroup>().subcultures[0] + " are like";
        if (pc.selectedGroup == gameObject)
        {
            int reaction = 2;
            for (int ms = 0; ms < subcultures.Count; ms++)
            {
                for (int ts = 0; ts < subcultures.Count; ts++)
                {
                    int newReaction = ReactionChecker((Subculture)Enum.Parse(typeof(Subculture), subcultures[ms]), (Subculture)Enum.Parse(typeof(Subculture), colGo.GetComponent<GenericGroup>().subcultures[ts]), colGo);
                    if (newReaction == 0)
                    {
                        reaction = 0;
                    }
                    else if (reaction > 0 && newReaction == 1)
                    {
                        reaction = 1;
                    }
                    else if (reaction > 1 && newReaction == 2)
                    {
                        reaction = 2;
                    }
                }
            }
            print(reaction);
            if (reaction == 0)
            {
                otherGroupWorkerAround = colGo;
                Invoke("PositiveReaction", 3.5f);

            }
            if(reaction == 2)
            {
                otherGroupWorkerAround = colGo;
                colGo.GetComponent<GenericGroup>().otherGroupWorkerAround = gameObject;
                Invoke("NegativeReaction",2);
            }
            if (groupSize == 5)
            {
                //game won
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SetConversing(false);
        CancelInvoke("PositiveReaction");
        otherGroupWorkerAround = null;
    }

    void IncreaseGroupSize(Subculture newGroupType)
    {
        groupSize += 1;
        subcultures.Add(nameof(newGroupType));
        switch (groupSize)
        {
            case 2:
                npcs[8].SetActive(true);
                npcs[9].SetActive(true);
                break;
            case 3:
                npcs[10].SetActive(true);
                npcs[11].SetActive(true);
                break;
            case 4:
                npcs[12].SetActive(true);
                npcs[13].SetActive(true);
                break; 
            case 5:
                npcs[14].SetActive(true);
                npcs[15].SetActive(true);
                break;
        }
    }

    void PositiveReaction()
    {
        if(pc.selectedGroup == gameObject)
        {
            SetConversing(false);
            IncreaseGroupSize(otherGroupWorkerAround.GetComponent<GenericGroup>().mySubculture);
            tm.newTweet = otherGroupWorkerAround.GetComponent<GenericGroup>().mySubculture.ToString() + ": huh, " + mySubculture.ToString() + " are actually pretty cool";
            Destroy(otherGroupWorkerAround);
        }
    }
    void NegativeReaction()
    {
        if (pc.selectedGroup != gameObject)
        {
            SetConversing(false);
            otherGroupWorkerAround.GetComponent<GenericGroup>().SetConversing(false);
            tm.newTweet = otherGroupWorkerAround.GetComponent<GenericGroup>().mySubculture.ToString() + ": yeah nah mate, i dont like these " + mySubculture.ToString();
            otherGroupWorkerAround.transform.position = new Vector3(UnityEngine.Random.Range(-13f, 13f), UnityEngine.Random.Range(-8f, 8f), otherGroupWorkerAround.transform.position.z);
        }
    }
    void NeutralReaction()
    {
        if (pc.selectedGroup == gameObject)
        {
            SetConversing(false);
            otherGroupWorkerAround.GetComponent<GenericGroup>().SetConversing(false);
            tm.newTweet = otherGroupWorkerAround.GetComponent<GenericGroup>().mySubculture.ToString() + ": eh, these " + mySubculture.ToString() + "are a bit average";
        }
    }

    int ReactionChecker(Subculture mySc, Subculture theirSc, GameObject go)
    {
        #region populars reactions
        if (mySc == Subculture.populars
           && (theirSc == Subculture.academics || theirSc == Subculture.normies))
        {
            return 0;
        }
        if (mySubculture == Subculture.populars
           && (false))
        {
            //no reaction
            return 1;
        }
        if (mySubculture == Subculture.populars
           && (theirSc == Subculture.nerds || theirSc == Subculture.loners))
        {
            print("Negative Reaction");
            return 2;
        }
        #endregion
        #region academics reactions
        if (mySubculture == Subculture.academics
           && (theirSc == Subculture.nerds))
        {
            return 0;
        }
        if (mySubculture == Subculture.academics
           && (theirSc == Subculture.populars || theirSc == Subculture.normies))
        {
            //no reaction
            return 1;
        }
        if (mySubculture == Subculture.academics
           && (theirSc == Subculture.loners))
        {
            print("Negative Reaction");
            return 2;
        }
        #endregion
        #region loners reactions
        if (mySubculture == Subculture.loners
           && (theirSc == Subculture.nerds))
        {
            return 0;
        }
        if (mySubculture == Subculture.loners
           && (theirSc == Subculture.academics || theirSc == Subculture.normies))
        {
            //no reaction
            return 1;
        }
        if (mySubculture == Subculture.loners
           && (theirSc == Subculture.populars))
        {
            print("Negative Reaction");
            return 2;
        }
        #endregion
        #region nerds reactions
        if (mySubculture == Subculture.nerds
           && (theirSc == Subculture.loners || theirSc == Subculture.normies))
        {
            return 0;
        }
        if (mySubculture == Subculture.nerds
           && (theirSc == Subculture.academics))
        {
            //no reaction
            return 1;
        }
        if (mySubculture == Subculture.nerds
           && (theirSc == Subculture.populars))
        {
            print("Negative Reaction");
            return 2;
        }
        #endregion
        #region normies reactions
        if (mySubculture == Subculture.nerds
           && (theirSc == Subculture.populars || theirSc == Subculture.academics || theirSc == Subculture.nerds))
        {
            return 0;
        }
        if (mySubculture == Subculture.nerds
           && (theirSc == Subculture.loners))
        {
            //no reaction
            return 1;
        }
        if (mySubculture == Subculture.nerds
           && (false))
        {
            print("Negative Reaction");
            return 2;
        }
        #endregion
        return 0;
    }

    void SetConversing(bool state)
    {
        for(int nn = 0; nn < npcs.Length; nn++)
        {
            if(npcs[nn].activeInHierarchy == true)
            {
                npcs[nn].GetComponent<Animator>().SetBool("conversing", state);
            }
        }
    }



}
