using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.IMGUI.Controls;

public class AdvanceDropDownWindow : EditorWindow
{
    [MenuItem("EditorWindow/AdvancedDropdownWindow")]
    static void Open()
    {
        CreateInstance<AdvanceDropDownWindow>().Show();
    }

    private void OnGUI()
    {
        var rect = GUILayoutUtility.GetRect(new GUIContent("Show"), EditorStyles.toolbarButton);
        if (GUI.Button(rect, new GUIContent("Show"), EditorStyles.toolbarButton))
        {
            var dropdown = new WeekdaysDropdown(new AdvancedDropdownState());
            dropdown.Show(rect);
        }
    }
}

public class WeekdaysDropdown : AdvancedDropdown
{
    public WeekdaysDropdown(AdvancedDropdownState state) : base(state)
    {
    }

    protected override AdvancedDropdownItem BuildRoot()
    {
        var root = new AdvancedDropdownItem("Weekdays");

        var firstHalf = new AdvancedDropdownItem("First half");
        var secondHalf = new AdvancedDropdownItem("Second Half");
        var weekend = new AdvancedDropdownItem("Weekend");
                
        firstHalf.AddChild(new AdvancedDropdownItem("Monday"));
        firstHalf.AddChild(new AdvancedDropdownItem("Tuesday"));
        secondHalf.AddChild(new AdvancedDropdownItem("Wednesday"));
        secondHalf.AddChild(new AdvancedDropdownItem("Thursday"));
        weekend.AddChild(new AdvancedDropdownItem("Friday"));
        weekend.AddChild(new AdvancedDropdownItem("Saturday"));
        weekend.AddChild(new AdvancedDropdownItem("Sunday"));
                
        root.AddChild(firstHalf);
        root.AddChild(secondHalf);
        root.AddChild(weekend);
        return root;
    }
}
