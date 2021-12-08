using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private ScrollElement _elementPrefab;
    [SerializeField] private DescriptionUI _description;
    [SerializeField] private Image _petImage;
    [SerializeField] private RectTransform _contentTransform;
    [SerializeField] private RectTransform _viewPort;

    private List<ScrollElement> _elements;
    private PetCollection _collection;
    private int _indexPetInfo;

    private void Start()
    {
        _collection = new PetCollection();
        _elements = new List<ScrollElement>();

        for (var i = 0; i < _collection.Count; i++)
        {
            var element = Instantiate(_elementPrefab, _contentTransform);
            element.Initialize(i, _collection.GetPetInfo(i).Sprite);
            element.Click += OnClick;
            if (_collection.GetPetInfo(i).IsOpen == false)
            {
                element.SetHide(true);
            }
            _elements.Add(element);
        }

        LayoutRebuilder.MarkLayoutForRebuild(_contentTransform);
        StartCoroutine(RebuildScroller());
        ChangePetInfo();
    }

    private IEnumerator RebuildScroller()
    {
        yield return null;
        Debug.Log(_contentTransform.GetComponent<GridLayoutGroup>().minHeight);
        _contentTransform.GetComponent<RectTransform>().sizeDelta = new Vector2(_contentTransform.GetComponent<GridLayoutGroup>().minWidth, _contentTransform.GetComponent<GridLayoutGroup>().minHeight);
    }

    private void ChangePetInfo()
    {
        if(_collection.TryGetPetInfo(_indexPetInfo, out var info))
        {
            _petImage.sprite = info.Sprite;
            _description.ShowInfo(info);
        }

        _petImage.color = info.IsOpen ? Color.white : Color.black;

        foreach (var element in _elements)
        {
            element.SetSelect(false);
        }

        _elements[_indexPetInfo].SetSelect(true);
    }

    public void Scroll(int value)
    {
        _indexPetInfo = Mathf.Clamp(_indexPetInfo + value, 0, _collection.Count - 1);
        ChangePetInfo();
    }

    private void OnClick(int index)
    {
        _indexPetInfo = index;
        ChangePetInfo();
    }
}
