using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Naration
{
    public string name;
    public string description;

    public Naration(string name,string description)
    {
        this.name = name;
        this.description = description;
    }
}


public class NarationManager : MonoBehaviour {
    private static NarationManager mInstance;
    public static NarationManager Instance
    {
        get
        {
            return mInstance;
        }
    }

    public Queue<Naration> mDialogue = new Queue<Naration>();
    public Canvas mCanvas;

    public Text mDescription;
    public Text mName;

    public bool startNaration = false;
    public bool showNext = true;

    private void Awake()
    {
        mInstance = this;
   
    }

    public void Intro()
    {
        mDialogue.Enqueue(new Naration("Survivor", "Args.... my Head, I Survived the crush..."));
        mDialogue.Enqueue(new Naration("Survivor", "Where the hell, Am I ?"));
        mDialogue.Enqueue(new Naration("Survivor", "Damm.... my radio is busted, How the hell I am supposed to call for extraction."));
        mDialogue.Enqueue(new Naration("Survivor", "There must be something around this area, *Sigh* That's what you get when you try to be a good guy and follow a distress signal."));
        mDialogue.Enqueue(new Naration("Survivor", "Let's look around"));
    }

    public void FoundItem()
    {
        mDialogue.Clear();
        mDialogue.Enqueue(new Naration("Survivor", "Please let this Radio work"));
        mDialogue.Enqueue(new Naration("Radio", "..........*Radio Noices*"));
        mDialogue.Enqueue(new Naration("Survivor", "Sweet! It Workd! Let's go find a place to call for help"));
    }

    public void Signal()
    {
        mDialogue.Clear();
        mDialogue.Enqueue(new Naration("Survivor", "Does anyone hear me?"));
        mDialogue.Enqueue(new Naration("Radio", "..........*Radio Noices*"));
        mDialogue.Enqueue(new Naration("Survivor", "I need imidiate evacuation from this area! please!"));
        mDialogue.Enqueue(new Naration("Radio", "This is BT102 we see your signal and we are on our way. ETA 2 minites..."));
        mDialogue.Enqueue(new Naration("Survivor", "Oh thank god , thank you! "));
    }

    // Use this forinitialization
    void Start () {
        mCanvas.gameObject.SetActive(false);   
    }
	
	// Update is called once per frame
	void Update () {

        mCanvas.gameObject.SetActive(false);
        if (startNaration)
        {
            mCanvas.gameObject.SetActive(true);

            if (showNext)
            {
                showNext = false;
                Naration nar = mDialogue.Dequeue();
                if (nar != null)
                {
                    mName.text = nar.name;
                    mDescription.text = nar.description;
                }
            }
            if (Input.GetMouseButtonDown(0) && mDialogue.Count != 0)
            {
                showNext = true;
            }
            if(Input.GetMouseButtonDown(0) && mDialogue.Count == 0)
            {
                Finish();
            }
        }     
	}

    public void StartNaration()
    {
        startNaration = true;
    }

    public void Finish()
    {
        startNaration = false;
    }
}
