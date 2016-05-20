Module Module1

    Sub Main()
        'おためし変更

        'Processオブジェクトを作成
        Dim p As New System.Diagnostics.Process()

        'ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
        p.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec")
        '出力を読み取れるようにする
        p.StartInfo.UseShellExecute = False
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.RedirectStandardInput = False
        'ウィンドウを表示しないようにする
        p.StartInfo.CreateNoWindow = True
        'コマンドラインを指定（"/c"は実行後閉じるために必要）
        p.StartInfo.Arguments = "/c dir c:\ /w"

        '起動
        p.Start()

        '出力を読み取る
        Dim results As String = p.StandardOutput.ReadToEnd()

        'プロセス終了まで待機する
        'WaitForExitはReadToEndの後である必要がある
        '(親プロセス、子プロセスでブロック防止のため)
        p.WaitForExit()
        p.Close()

        '出力された結果を表示
        Console.WriteLine(results)
    End Sub

End Module
