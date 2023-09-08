using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ABI_HoundOfTindalos", menuName = "Arkham/Ability/Monster/Hound Of Tindalos")]
public class HoundOfTindalos : A_Ability
{    
    public override void Execute(GameObject self)
    {
        self.transform.position = ClosestInvestigatorLocation(self).transform.position + new Vector3(0, 1, 0);
    }

    private NeighborhoodTile ClosestInvestigatorLocation(GameObject self)
    {
        Monster m = self.GetComponent<Monster>();
        Dictionary<NeighborhoodTile, int> returnDict = new();
        GameBoard.instance.GetReachableTiles(m.CurrentLocation, 10, 0, ref returnDict);

        Investigator closest = null;
        int dist = int.MaxValue;

        foreach (Investigator i in GameManager.instance.CurrentInvestigators)
        {
            if (!i.CurrentTile.data.InArkham) continue;
            int iDist = returnDict.GetValueOrDefault((NeighborhoodTile)i.CurrentTile);
            if (dist > iDist)
            {
                dist = iDist;
                closest = i;
            }
        }

        return (NeighborhoodTile)closest.CurrentTile;
    }
}
