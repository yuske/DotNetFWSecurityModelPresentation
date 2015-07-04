Imports System.Security

<Assembly: SecurityTransparent> 

Public Class ExceptionHandler
    Private ReadOnly _tryAction As Action
    Private ReadOnly _filterFunc As Func(Of Boolean)
    Private ReadOnly _catchAction As Action

    Public Sub New(tryAction As Action, filterFunc As Func(Of Boolean), catchAction As Action)
        _tryAction = tryAction
        _filterFunc = filterFunc
        _catchAction = catchAction
    End Sub

    Public Sub Execute()
        Try
            _tryAction()
        Catch ex As Exception When Filter()
            _catchAction()
        End Try
    End Sub

    Public Function Filter() As Boolean
        Filter = _filterFunc()
    End Function

End Class
