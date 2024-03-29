using EasingCore;
using FancyScrollView;
using FancyScrollView.Example03;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class SongScroll : FancyScrollView<Song, Context>
{
    [SerializeField] Scroller scroller = default;
    [SerializeField] GameObject cellPrefab = default;

    protected override GameObject CellPrefab => cellPrefab;

    protected override void Initialize()
    {
        base.Initialize();

        Context.OnCellClicked = SelectCell;

        scroller.OnValueChanged(UpdatePosition);
        scroller.OnSelectionChanged(UpdateSelection);
    }

    void UpdateSelection(int index)
    {
        if (Context.SelectedIndex == index)
        {
            return;
        }
        Context.SelectedIndex = index;
        ItemsSource[index].SelectSong();
        Refresh();
    }

    public void UpdateData(IList<Song> items)
    {
        UpdateContents(items);
        scroller.SetTotalCount(items.Count);
    }

    public void SelectCell(int index)
    {
        if (index < 0 || index >= ItemsSource.Count || index == Context.SelectedIndex)
        {
            return;
        }
        UpdateSelection(index);
        scroller.ScrollTo(index, 0.35f, Ease.OutCubic);
    }
}
