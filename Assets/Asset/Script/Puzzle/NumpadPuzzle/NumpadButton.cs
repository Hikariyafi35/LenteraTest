using UnityEngine;

public class NumpadButton : MonoBehaviour
{
    
    [SerializeField]
    private int _number;

    
    [SerializeField]
    private NumpadPuzzle _puzzle;

    public void OnClick()
    {
        
        _puzzle.EnterNumber(_number);
    }
}
