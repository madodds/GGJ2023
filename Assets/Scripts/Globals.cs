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
        tree
    }

    public enum PlayerCharacter
    {
        Dryad,
        Necromancer,
        PumpkinKing
    }

    public enum MiscResources
    {
        background,
        portrait,
        portraitFull
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
        {PlantResources.tumbleweeds, 2 },
        {PlantResources.venus, 2 },
        {PlantResources.flowers, 3 },
        {PlantResources.carrots, 4 }
    };

    public static HexStore hexes;
    public static TurnManager turnManager;
    
    // r
    // dr
    // dl
    // l
    // ul
    // ur
    // public static int[][] axial_direction_vectors = [
    //     [1, 0], [1, -1], [0, -1], 
    //     [-1, 0], [-1, 1], [0, 1]
    // ];

    public static List<(int, int)> hexDirections = new List<(int, int)>
        {
            (1, 0), (1, -1), (0, -1), (-1, 0), (-1, 1), (0, 1)
        };

    // public static Dictionary<string, int[]> hexDirections = new Dictionary<string, int[]>{
    //     {"r", [1,0]},
    //     {"dr", [1,-1]}, 
    //     {"dl", [0,-1]},
    //     {"l", [-1,0]},
    //     {"ul", [-1,1]},
    //     {"ur", [0,1]}
    // };

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
