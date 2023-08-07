using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;

public class GameController : MonoBehaviour
{

    //So you can write the the debugger screen
    public TextMeshPro debuggerText;

    //So you can get user inputs
    public InputReader inputs;

    public GameObject Ball;
    public Transform rh;
    public GameObject PreBlock;
    public Transform lh;
    public GameObject Block;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Clear the debugger screen when user presses B button
        if (inputs.ButtonBDown)
        {
            debuggerText.SetText("Debugger Log (Press B to clear):");
        }

        if (inputs.RightMainTriggerDown)
        {
            SpawnBall();
        }

        if (inputs.LeftMainTrigger)
        {
            PreBlock.SetActive(true);
        }
        else
        {
            PreBlock.SetActive(false);
        }

        if (inputs.LeftMainTriggerUp)
        {
            SpawnBlock();
        }
        

    }

    void SpawnBall()
    {
        GameObject newBall = Instantiate(Ball, rh.position, Quaternion.identity);
        var component = newBall.GetComponent<Grabbable>();
        component.Setup(inputs, lh, rh);
    }

    void SpawnBlock()
    {
        GameObject newBlock=Instantiate(Block, lh.position + 0.5f*lh.forward, lh.rotation);
        var component = newBlock.GetComponent<BlockController>();
        component.Setup(inputs, lh, rh);
    }

    
}
