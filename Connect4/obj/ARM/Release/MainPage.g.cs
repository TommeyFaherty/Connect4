﻿#pragma checksum "C:\Users\Tommey\Documents\GitHub\Connect4\Connect4\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F0468752FB7973E671B2E3FE28D9E2A0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Connect4
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.MainPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 2:
                {
                    this.Title = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 3:
                {
                    this.playerNames = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4:
                {
                    this.choiceText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5:
                {
                    this.chooseChip = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 6:
                {
                    this.Radiobtn = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 7:
                {
                    this.selectedColour = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 8:
                {
                    this.RadioButton1 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 37 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.RadioButton1).Checked += this.RadioButton_Checked;
                    #line default
                }
                break;
            case 9:
                {
                    this.RadioButton2 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 38 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.RadioButton2).Checked += this.RadioButton_Checked;
                    #line default
                }
                break;
            case 10:
                {
                    this.RedChp = (global::Windows.UI.Xaml.Shapes.Ellipse)(target);
                }
                break;
            case 11:
                {
                    this.YelChp = (global::Windows.UI.Xaml.Shapes.Ellipse)(target);
                }
                break;
            case 12:
                {
                    this.P1Color = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 13:
                {
                    this.P2Color = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 14:
                {
                    this.P2 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 15:
                {
                    this.P1 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 16:
                {
                    this.title = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

