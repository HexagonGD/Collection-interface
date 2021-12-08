using UnityEngine;
using UnityEngine.UI;

public class DescriptionUI : MonoBehaviour
{
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _findText;
    [SerializeField] private Text _energyText;
    [SerializeField] private Text _speedText;

    public void ShowInfo(PetInfo info)
    {
        if (info.IsOpen)
        {
            _nameText.text = info.Name;
            _findText.text = info.Find;
            _energyText.text = $"Энергия {info.MaxEnergy} / {info.MaxEnergy}";
            _speedText.text = $"Скорость\n" +
                $"разведки {info.Speed}";
        }
        else
        {
            ShowNoOpenPetInfp();
        }
    }

    private void ShowNoOpenPetInfp()
    {
        _nameText.text = "?";
        _findText.text = "?";
        _energyText.text = "?";
        _speedText.text = "?";
    }
}
