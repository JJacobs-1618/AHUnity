using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrorTrackController : MonoBehaviour
{
    [SerializeField] GameObject _terrorTrackToken;
    [SerializeField] int _currentTerrorTrack;
    [SerializeField] List<Transform> _terrorTrackTransforms;

    private void Awake()
    {
        _currentTerrorTrack = 0;
    }

    public void IncreaseTerror()
    {
        _currentTerrorTrack = Mathf.Clamp(++_currentTerrorTrack, 0, 10);
        if (_currentTerrorTrack >= 10)
        {
            Debug.Log("Increase Doom Track by 1");
            return;
        }

        _terrorTrackToken.transform.position = _terrorTrackTransforms[_currentTerrorTrack].position;
        switch (_currentTerrorTrack)
        {
            case 3:
                Debug.Log("Terror Increases");
                Debug.Log("General Store Closure");
                GameBoard.instance.CloseLocation(GameConsts.GeneralStore);
                break;
            case 6:
                Debug.Log("Terror Increases");
                Debug.Log("Curiositie Shoppe Closure");
                GameBoard.instance.CloseLocation(GameConsts.CuriositieShoppe);
                break;
            case 9:
                Debug.Log("Terror Increases");
                Debug.Log("Ye Olde Magick Shoppe Closure");
                GameBoard.instance.CloseLocation(GameConsts.YeOldeMagickShoppe);
                break;
            case 10:
                Debug.Log("Terror Increases");
                Debug.Log("Arkham is Overrun. Monster limit removed.");
                Debug.Log("Increase Doom Track by 1");
                break;
            default:
                Debug.Log("Terror Increases");
                break;
        }
    }
}
