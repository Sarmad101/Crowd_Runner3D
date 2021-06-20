using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skinColor : MonoBehaviour
{

    /// <summary>
    /// This script is just for test purpose however the mechanics for assigning colors to player can be improved
    /// its just for a prototype game
    /// </summary>
    public Material skinBlack , skinBlue , skinRed , skinPink , skinGreen , skinYellow;
    public Renderer skin, head , knife;
    [SerializeField]
    private Color col;
    public string color;
    void Start()
    {
       
        SkinColor(this.color);
        
    }
    public void SkinColor(string color)
    {
        if (color == "black")
        {
            skin.material = skinBlack;
            head.material = skinBlack;
            knife.material = skinBlack;
        }
        if (color == "yellow")
        {
            skin.material = skinYellow;
            head.material = skinYellow;
            knife.material = skinYellow;
        }
        if (color == "green")
        {
            skin.material = skinGreen;
            head.material = skinGreen;
            knife.material = skinGreen;
        }
        if (color == "pink")
        {
            skin.material = skinPink;
            head.material = skinPink;
            knife.material = skinPink;
        }
        if (color == "blue")
        {
            skin.material = skinBlue;
            head.material = skinBlue;
            knife.material = skinBlue;
        }
        if (color == "red")
        {
            skin.material = skinRed;
            head.material = skinRed;
            knife.material = skinRed;
        }


        //some colors to remember
        /*
         * #28FF00 = green
         * #FFF900 = yellow
         * #FF1000 = red
         * #2800FF = pink
         * #00E0FF = blue
         * #000000 = black
         */

    }
    
   
}
