using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorGUIMode
{
    private Rect mDisableRect = new Rect(10, 40, 100, 20);
    private Rect mLabelRect = new Rect(10, 60, 200, 20);
    private Rect mTextFieldRect = new Rect(10, 90, 200, 20);
    private Rect mTextAreaRect = new Rect(10, 120, 200, 40);
    private Rect mPasswordFieldRect = new Rect(10, 170, 200, 20);
    private Rect mDropdownButtonRect = new Rect(10, 200, 200, 20);
    private Rect mLinkedButtonRect = new Rect(10, 230, 200, 20);
    private Rect mToggleRect = new Rect(10, 260, 200, 20);
    private Rect mToggleLeftRect = new Rect(10, 290, 200, 20);
    private Rect mHelpBoxRect = new Rect(10, 320, 200, 20);
    private Rect mColorFieldRect = new Rect(10, 350, 200, 20);
    private Rect mBoundsFieldRect = new Rect(10, 380, 200, 20);
    private Rect mBoundsIntFieldRect = new Rect(10, 410, 200, 20);
    private Rect mCurveFieldRect = new Rect(10, 440, 200, 20);
    private Rect mDelayedDoubleFieldRect = new Rect(10, 470, 200, 20);
    private Rect mDoubleFieldRect = new Rect(10, 500, 200, 20);
    private Rect mEnumFlagsFieldRect = new Rect(10, 530, 200, 20);
    private Rect mEnumPopRect = new Rect(10, 560, 200, 20);
    private Rect mGradientFieldRect = new Rect(210, 90, 200, 20);

    private bool mDisabledGroupValue = false;
    private string mTextFieldValue;
    private string mTextAreaValue;
    private string mPasswordFieldValue = string.Empty;
    private bool mToggleValue = false;
    private Color mColorFieldValue;
    private Bounds mBoundsFieldValue;
    private BoundsInt mBoundsIntFieldValue;
    private AnimationCurve mCurveFieldValue = new AnimationCurve();
    private double mDoubleFieldvalue;
    private bool mFoldOutValue = true;
    private Gradient mGradient = new Gradient();
    
    private enum EnumFlagsFieldValue
    {
        A = 0,
        B,
        C
    }
    enum ExampleFlagsEnum
    {
        None = 0,
        A = 1 << 0,
        B = 1 << 1,
        C = 1 << 2,
        All = ~0,
    }
    
    private EnumFlagsFieldValue mEnumFlagsFieldValue;
    private ExampleFlagsEnum mExampleFlagsEnumValue;
    
    public void Draw()
    {
        mDisabledGroupValue = EditorGUI.Toggle(mDisableRect, "Disable Group", mDisabledGroupValue);
        mFoldOutValue = EditorGUI.Foldout(new Rect(210, 60, 300, 20),mFoldOutValue,"??????");
        if (mFoldOutValue)
        {
            EditorGUI.BeginDisabledGroup(mDisabledGroupValue);
            {
                EditorGUI.LabelField(mLabelRect, "Label Field");
                mTextFieldValue = EditorGUI.TextField(mTextFieldRect, mTextFieldValue);
                mTextAreaValue = EditorGUI.TextArea(mTextAreaRect, mTextAreaValue);
                mPasswordFieldValue = EditorGUI.PasswordField(mPasswordFieldRect, mPasswordFieldValue);
      
                //??????????????????true?????????????????????API??????
                //??? GenericMenu ???????????????????????? GenericMenu.Dropdown ?????????????????????????????????????????????????????????????????????
                //???????????? EditorWindow ???????????????????????? EditorWindow.ShowAsDropdown ?????????????????????????????????????????????????????????????????????
                if(EditorGUI.DropdownButton(mDropdownButtonRect, new GUIContent("123", "tips"), FocusType.Keyboard))
                {
                    Debug.Log("DropdownButton Clicked");
                }

                if (EditorGUI.LinkButton(mLinkedButtonRect, "link button"))
                {
                    Debug.Log("Link Button Clicked");
                }

                mToggleValue = EditorGUI.Toggle(mToggleRect, "??????/??????", mToggleValue);

                mToggleValue = EditorGUI.ToggleLeft(mToggleLeftRect, "??????/??????", mToggleValue);
                
                EditorGUI.HelpBox(mHelpBoxRect, "1234567", MessageType.Error);
                
                //???????????????????????????
                mColorFieldValue = EditorGUI.ColorField(mColorFieldRect, mColorFieldValue);
                mBoundsFieldValue = EditorGUI.BoundsField(mBoundsFieldRect, mBoundsFieldValue);
                mBoundsIntFieldValue = EditorGUI.BoundsIntField(mBoundsIntFieldRect, mBoundsIntFieldValue);
                mCurveFieldValue = EditorGUI.CurveField(mCurveFieldRect, mCurveFieldValue);
                mDoubleFieldvalue = EditorGUI.DoubleField(mDoubleFieldRect, mDoubleFieldvalue);
                
                //????????????????????? Enter ???????????????????????????????????????????????????????????????
                mDoubleFieldvalue = EditorGUI.DelayedDoubleField(mDelayedDoubleFieldRect, new GUIContent("Delayed Double"), mDoubleFieldvalue);

                //Enum?????????????????????????????????????????????????????????????????????????????????
                mExampleFlagsEnumValue = (ExampleFlagsEnum)EditorGUI.EnumFlagsField(mEnumFlagsFieldRect, mExampleFlagsEnumValue);
                //Enum??????
                mEnumFlagsFieldValue = (EnumFlagsFieldValue)EditorGUI.EnumPopup(mEnumPopRect, mEnumFlagsFieldValue);
                
                //?????????
                mGradient = EditorGUI.GradientField(mGradientFieldRect, mGradient);
            }
            EditorGUI.EndDisabledGroup();
        }
    }
}
