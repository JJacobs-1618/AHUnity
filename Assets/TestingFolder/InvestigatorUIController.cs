using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigatorUIController : MonoBehaviour
{

    public GameObject statusBar;

    private Investigator investigator;

    private StatusBar sb;

    // Start is called before the first frame update
    void Start()
    {
        investigator = this.GetComponent<Investigator>();

        statusBar = this.transform.GetChild(0).gameObject;
        sb = statusBar.GetComponent<StatusBar>();

        InitializeInvestigator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeInvestigator()
    {
        sb.AddSanity(investigator.data.maxSanity);
        sb.AddStamina(investigator.data.maxStamina);
    }
}
