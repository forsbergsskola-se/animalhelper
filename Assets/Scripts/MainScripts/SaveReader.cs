using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveReader : MonoBehaviour
{
    public void ReadSave()
    {
        Debug.Log(HackySave.Body.item.name);
        Debug.Log(HackySave.Front.item.name);
        Debug.Log(HackySave.FirstWheel.item.name);
        Debug.Log(HackySave.SecondWheel.item.name);
        Debug.Log(HackySave.Spoiler.item.name);
        /// It works Yeah it don't save the data between off and on well of now if you play with the race before you build a car (in theory) 
        /// it will just return Null in everything Stats, sprites ect.
        /// Ideas:
        /// 1- We can use the CarPart Save system just replace the data with the hacky save
        /// 2- We Force with say you don't have a car if HackySave returns Null.
        /// 3- Idk you come up with something
    }
}
