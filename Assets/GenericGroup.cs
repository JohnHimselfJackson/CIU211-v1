using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericGroup : MonoBehaviour
{
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

    /*
        three types of interactions
            - mingle
            - Repel
            - attract
    */

    void Start()
    {
        selected = false;
        subcultures.Add(nameof(mySubculture));
    }

    private void OnTriggerEnter(Collider collision)
    {
        GameObject go = collision.gameObject;
        #region populars reactions
        if(mySubculture == Subculture.populars 
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.academics || go.GetComponent<GenericGroup>().mySubculture == Subculture.normies))
        {
            print("positive Reaction");
        }
        if (mySubculture == Subculture.populars
           && (false))
        {
            //no reaction
        }
        if (mySubculture == Subculture.populars
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.nerds || go.GetComponent<GenericGroup>().mySubculture == Subculture.loners))
        {
            print("Negative Reaction");
        }
        #endregion
        #region academics reactions
        if (mySubculture == Subculture.academics
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.nerds))
        {
            print("positive Reaction");
        }
        if (mySubculture == Subculture.academics
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.populars || go.GetComponent<GenericGroup>().mySubculture == Subculture.normies))
        {
            //no reaction
        }
        if (mySubculture == Subculture.academics
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.loners))
        {
            print("Negative Reaction");
        }
        #endregion
        #region loners reactions
        if (mySubculture == Subculture.loners
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.nerds))
        {
            print("positive Reaction");
        }
        if (mySubculture == Subculture.loners
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.academics || go.GetComponent<GenericGroup>().mySubculture == Subculture.normies))
        {
            //no reaction
        }
        if (mySubculture == Subculture.loners
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.populars))
        {
            print("Negative Reaction");
        }
        #endregion
        #region nerds reactions
        if (mySubculture == Subculture.nerds
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.loners || go.GetComponent<GenericGroup>().mySubculture == Subculture.normies))
        {
            print("positive Reaction");
        }
        if (mySubculture == Subculture.nerds
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.academics))
        {
            //no reaction
        }
        if (mySubculture == Subculture.nerds
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.populars))
        {
            print("Negative Reaction");
        }
        #endregion
        #region normies reactions
        if (mySubculture == Subculture.nerds
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.populars || go.GetComponent<GenericGroup>().mySubculture == Subculture.academics || go.GetComponent<GenericGroup>().mySubculture == Subculture.nerds))
        {
            print("positive Reaction");
        }
        if (mySubculture == Subculture.nerds
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.loners))
        {
            //no reaction
        }
        if (mySubculture == Subculture.nerds
           && (false))
        {
            print("Negative Reaction");
        }
        #endregion
        for (int ss = 0; ss < subcultures.Count; ss++)
        {
            
        }
    }








}
