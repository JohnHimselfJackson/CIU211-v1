using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericGroup : MonoBehaviour
{
    public GameObject[] npcs;

    public enum Subculture { populars, academics, loners, nerds, normies}
    public Subculture mySubculture = Subculture.normies;


    /*
        three types of interactions
            - mingle
            - Repel
            - attract
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        #region populars reactions
        if(mySubculture == Subculture.populars 
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.academics || go.GetComponent<GenericGroup>().mySubculture == Subculture.normies))
        {
            //positive reaction
        }
        if (mySubculture == Subculture.populars
           && (false))
        {
            //no reaction
        }
        if (mySubculture == Subculture.populars
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.nerds || go.GetComponent<GenericGroup>().mySubculture == Subculture.loners))
        {
            //negative reaction
        }
        #endregion
        #region academics reactions
        if (mySubculture == Subculture.academics
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.nerds))
        {
            //positive reaction
        }
        if (mySubculture == Subculture.academics
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.populars || go.GetComponent<GenericGroup>().mySubculture == Subculture.normies))
        {
            //no reaction
        }
        if (mySubculture == Subculture.academics
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.loners))
        {
            //negative reaction
        }
        #endregion
        #region loners reactions
        if (mySubculture == Subculture.loners
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.nerds))
        {
            //positive reaction
        }
        if (mySubculture == Subculture.loners
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.academics || go.GetComponent<GenericGroup>().mySubculture == Subculture.normies))
        {
            //no reaction
        }
        if (mySubculture == Subculture.loners
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.populars))
        {
            //negative reaction
        }
        #endregion
        #region nerds reactions
        if (mySubculture == Subculture.nerds
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.loners || go.GetComponent<GenericGroup>().mySubculture == Subculture.normies))
        {
            //positive reaction
        }
        if (mySubculture == Subculture.nerds
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.academics))
        {
            //no reaction
        }
        if (mySubculture == Subculture.nerds
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.populars))
        {
            //negative reaction
        }
        #endregion
        #region normies reactions
        if (mySubculture == Subculture.nerds
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.populars || go.GetComponent<GenericGroup>().mySubculture == Subculture.academics || go.GetComponent<GenericGroup>().mySubculture == Subculture.nerds))
        {
            //positive reaction
        }
        if (mySubculture == Subculture.nerds
           && (go.GetComponent<GenericGroup>().mySubculture == Subculture.loners))
        {
            //no reaction
        }
        if (mySubculture == Subculture.nerds
           && (false))
        {
            //negative reaction
        }
        #endregion
    }





}
