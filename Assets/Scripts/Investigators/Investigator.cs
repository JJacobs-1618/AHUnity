using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Investigator : MonoBehaviour
{
    [SerializeField] string investigatorName;
    [SerializeField] string profession;
    [SerializeField] string home;
    [SerializeField] List<Item> fixedPossessions;
    [SerializeField] Dictionary<int, string> randomPossessions;
    [SerializeField] string abilityName;
    [SerializeField] string abilityText;
    [SerializeField] string theStorySoFar;
    [SerializeField] InvestigatorStats stats;
    [SerializeField] Inventory inventory;

    private void Awake()
    {
        theStorySoFar = "Sister Mary has server the Church faithfully for many years, so when she was sent to Arkham to work with Father Michael, " +
                        "a man whose writings she had admited formany years, she felt that she was truly blessed. Now, after witnessing " + 
                        "Father Michael's strange mood swings and seeing some of the bvizarre practices that go on in this town, she's beginning " + 
                        "to feel that she may have been a bit too hasty...\n\n" + 
                        "For instances, last night, there was a knock on the door of the church, " + 
                        "and when she answered it, there was nothing but a handwritten joyurnal laying on the steps outisde. Reading it, she learned " + 
                        "of strange cults and tterrible creatures that lurk in the darkness. Worse, when she laughingly showied it to Father Michael, " + 
                        "he turned pale and threw it into the fire, yelling at her to forget what she'd seen.\n\n" +
                        "Now, gathering her things and quietly ;eaving South Chruch, sister Mary has decided to " + 
                        "investigate this town, and in so dowing, reaffirm her faith.";
    }
}
