using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainStation : ArkhamEncounter
{
    public TrainStation()
    {
        encounterText[0] = "On the loading dock you investigate a loarge crate with strange marking. Make a <b>Sneak (-1) check.</b> If you pass, you find a very unusual item in the crate. Gain 1 Unique Item. If you fail, Deputy Dingby catches you breaking it open. Youa re arrested and taken to the Police Station.";
        encounterText[1] = "Pay $3 at the Railroad Office to claim an item left in Lost and Found.  If you do so, make a <b>Luck (-2) check.</b> If you pass, draw a Unique Item. If you fail, draw a Common Item.";
    }
}
