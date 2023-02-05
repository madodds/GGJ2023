using System;
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

    public enum PlantResources
    {
        grass,
        weeds,
        tumbleweeds,
        venus,
        flowers,
        carrots,
    }

    public enum PlayerCharacter
    {
        Dryad,
        Necromancer,
        PumpkinKing
    }

    public enum MiscResources
    {
        portrait,
        background
    }

    public enum TurnPhases
    {
        BetweenPhases,
        StartTurn,
        GainResources,
        ResolvePlants,
        ResolveRabbits,
        CheckEndGame,
        SpendResources,
        PlacePlants,
    }

    public static IReadOnlyDictionary<PlantResources, int> ResourceCosts = new Dictionary<PlantResources, int>
    {
        {PlantResources.grass, 1 },
        {PlantResources.weeds, 2 },
        {PlantResources.tumbleweeds, 3 },
        {PlantResources.venus, 4 },
        {PlantResources.flowers, 5 },
        {PlantResources.carrots, 6 }
    };

    public static HexStore hexes;
    public static TurnManager turnManager;
    
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

    public static Texture LookupTextureAsset(PlayerCharacter playerCharacter, PlantResources plantResource) =>
        Resources.Load<Texture>(
            $"Art/PlayerTypes/{Enum.GetName(typeof(PlayerCharacter), playerCharacter)}/{Enum.GetName(typeof(PlantResources), plantResource)}"
        );

    public static Texture LookupTextureAsset(PlayerCharacter playerCharacter, MiscResources miscResource) =>
        Resources.Load<Texture>(
            $"Art/PlayerTypes/{Enum.GetName(typeof(PlayerCharacter), playerCharacter)}/{Enum.GetName(typeof(MiscResources), miscResource)}"
        );
}
