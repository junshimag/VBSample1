Public Class Form1
    'MouseMove用
    Private XX As Integer
    Private YY As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '既に起動している場合は強制終了
        If PrevInstance() = True Then
            Me.Close()
        End If

        Me.WindowState = FormWindowState.Maximized
        Me.ControlBox = False
        Me.FormBorderStyle = FormBorderStyle.None

        Me.BackColor = Color.Blue

    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        'マウスのボタンが押された
        Me.Close()
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Me.Close()
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove

        If XX = 0 And YY = 0 Then
            '   起動時の位置を記憶
            XX = e.X
            YY = e.Y
        ElseIf Math.Abs(e.X - XX) >= 5 Or Math.Abs(e.Y - YY) >= 5 Then
            '   正確には「最初の位置より5ピクセル動いたら」になる
            Me.Close()
        End If
    End Sub

    '二重起動チェックメソッド
    Public Shared Function PrevInstance() As Boolean
        If Diagnostics.Process.GetProcessesByName(
            Diagnostics.Process.GetCurrentProcess.ProcessName).Length > 1 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
