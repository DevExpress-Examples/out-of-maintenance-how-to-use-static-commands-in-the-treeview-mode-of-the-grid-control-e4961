Imports System.Windows
Imports DevExpress.Xpf.Core

Namespace DxTreeViewTest

    ''' <summary>
    ''' Interaction logic for App.xaml
    ''' </summary>
    Public Partial Class App
        Inherits Application

        Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
            MyBase.OnStartup(e)
            ApplicationThemeHelper.ApplicationThemeName = "Office2007Blue"
        End Sub
    End Class
End Namespace
