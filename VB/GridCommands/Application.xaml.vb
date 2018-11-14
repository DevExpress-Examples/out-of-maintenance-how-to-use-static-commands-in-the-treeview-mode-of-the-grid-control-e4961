Imports System
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data
Imports System.Linq
Imports System.Windows
Imports DevExpress.Xpf.Core

Namespace DxTreeViewTest
    ''' <summary>
    ''' Interaction logic for App.xaml
    ''' </summary>
    Partial Public Class App
        Inherits Application

        Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
            MyBase.OnStartup(e)
            ApplicationThemeHelper.ApplicationThemeName = "Office2007Blue"

        End Sub
    End Class
End Namespace
