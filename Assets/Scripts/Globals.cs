using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{

    public const string k_AxisNameVertical = "Vertical";
    public const string k_AxisNameHorizontal = "Horizontal";
    public const string k_ButtonNamePauseMenu = "Pause Menu";
    public const string k_ButtonNameSubmit = "Submit";
    public const string k_ButtonNameCancel = "Cancel";
    public const string k_ButtonReload = "Reload";

    public enum player {
        none,
        player1,
        player2
    }

    public enum states {
        empty,
        tree,
        grass,
        weeds,
        flowers,
        tumbleweeds,
        veggies,

    }
    

    
//     var axial_direction_vectors = [
//     Hex(+1, 0), Hex(+1, -1), Hex(0, -1), 
//     Hex(-1, 0), Hex(-1, +1), Hex(0, +1), 
// ]
    static public int[][] hex(){
        int[][] coords = {
            new int[] { 1, 0 },
            new int[] { 1, 1 },
            new int[] { 0, -1 },
            new int[] { -1, 0 },
            new int[] { -1, 1 },
            new int[] { 0, 1 }
        };
        return coords;
    }
}
