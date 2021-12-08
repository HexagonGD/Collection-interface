using UnityEngine;

[CreateAssetMenu(fileName = "PetInfo", menuName = "CollectionInterface/PetInfo")]
public class PetInfo : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _name;
    [SerializeField] private string _find;
    [SerializeField] private int _maxEnergy;
    [SerializeField] private int _speed;
    [SerializeField] private bool _isOpen = true;

    public Sprite Sprite => _sprite;
    public string Name => _name;
    public string Find => _find;
    public int MaxEnergy => _maxEnergy;
    public int Speed => _speed;
    public bool IsOpen => _isOpen;
}
