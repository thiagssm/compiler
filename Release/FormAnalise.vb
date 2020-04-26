Imports WindowsApp1.Token
Imports System.Text.RegularExpressions
Imports System.IO

Public Class FormAnalise
    Private listaTokens As New List(Of Token)
    Private listaTabela As New List(Of Token)
    Private linha As Integer
    Private Function AnaliseNumero(palavra As String) As Boolean
        Dim retorno As Boolean = False
        Dim testeNumero As Double = 0
        Double.TryParse(palavra, testeNumero)
        If testeNumero <> 0 Then
            retorno = True
        End If
        Return retorno
    End Function

    Private Function AnaliseParenteses(palavra As String) As Boolean
        Dim retorno As Boolean = False
        If palavra = "(" Then
            retorno = True
        ElseIf palavra = ")" Then
            retorno = True
        End If
        Return retorno
    End Function

    Private Sub btnAnalisar_Click(sender As Object, e As EventArgs) Handles btnAnalisar.Click
        Dim txtToAnalize = txtAnalisar.Text
        Dim textoTokenResolvido As String = ""
        Dim textoTabelaResolvido As String = ""
        AnaliseComWhile(txtToAnalize)
        If listaTokens IsNot Nothing AndAlso listaTokens.Count > 0 Then
            For Each t In listaTokens
                textoTokenResolvido += $"<{t.Tipo},{t.Numero}>, "
            Next
        Else
            textoTokenResolvido = "erro"
        End If
        If listaTabela IsNot Nothing AndAlso listaTabela.Count > 0 Then
            For Each t In listaTabela
                textoTabelaResolvido += $"{t.Numero} Token: {t.Tipo}, Lexema: {t.Valor}, Padrão:, Ocorrências: {t.Ocorrencia}"
            Next
        Else
            textoTabelaResolvido = "erro"
        End If
        txtRetornoToken.Text = IIf(textoTokenResolvido <> "erro", textoTokenResolvido.TrimEnd().TrimEnd(","), textoTokenResolvido)
        txtRetornoTabela.Text = IIf(textoTabelaResolvido <> "erro", textoTabelaResolvido.TrimEnd().TrimEnd(","), textoTabelaResolvido)
    End Sub

    Private Sub AnaliseComWhile(texto As String)
        listaTokens = New List(Of Token)
        listaTabela = New List(Of Token)
        Dim arrayTexto = texto.ToArray()
        Dim contador = 0
        Dim contadorToken = 1
        Dim letraRegex = New Regex("([A-Z]|[a-z])")
        Dim numRegex = New Regex("([1-9])|\.")
        Dim compRegex = New Regex("(<|>|=|!)")
        Dim previewCompRegex = New Regex("(<=|>=|(==)|!=)")

        While contador < arrayTexto.Length()
            Dim caracter = arrayTexto(contador)

            If caracter = "(" OrElse caracter = ")" Then
                Dim caracterToken = New Token
                caracterToken.Tipo = "Parenteses"
                caracterToken.Valor = caracter
                caracterToken.Numero = contadorToken
                caracterToken.Coluna = contador
                caracterToken.Ocorrencia += $"Linha: {linha}, Coluna: {caracterToken.Coluna}, {vbCrLf}"
                If listaTabela.Count > 0 Then
                    Dim listaAux As New List(Of Token)
                    For Each item In listaTabela
                        If item.Valor = caracterToken.Valor Then
                            item.Ocorrencia = item.Ocorrencia.TrimEnd().TrimEnd("vbCrLf")
                            item.Ocorrencia += caracterToken.Ocorrencia
                            caracterToken.Numero = item.Numero
                        Else
                            listaAux.Add(caracterToken)
                        End If
                    Next
                    listaTokens.Add(caracterToken)
                    listaTabela.AddRange(listaAux.Distinct())
                Else
                    listaTokens.Add(caracterToken)
                    listaTabela.Add(caracterToken)
                End If
                contador += 1
                contadorToken += 1
            ElseIf caracter = "+" OrElse caracter = "-" OrElse caracter = "*" OrElse caracter = "/" OrElse caracter = "%" OrElse caracter = "^" Then
                Dim caracterToken = New Token
                caracterToken.Tipo = "Operator"
                caracterToken.Valor = caracter
                caracterToken.Numero = contadorToken
                caracterToken.Coluna = contador
                caracterToken.Ocorrencia += $"Linha: {linha}, Coluna: {caracterToken.Coluna}, {vbCrLf}"
                If listaTabela.Count > 0 Then
                    Dim listaAux As New List(Of Token)
                    For Each item In listaTabela
                        If item.Valor = caracterToken.Valor Then
                            item.Ocorrencia = item.Ocorrencia.TrimEnd().TrimEnd("vbCrLf")
                            item.Ocorrencia += caracterToken.Ocorrencia
                            caracterToken.Numero = item.Numero
                        End If
                    Next
                    listaTokens.Add(caracterToken)
                Else
                    listaTokens.Add(caracterToken)
                    listaTabela.Add(caracterToken)
                End If
                contador += 1
                contadorToken += 1
            ElseIf caracter = " " Then
                contador += 1
            ElseIf caracter = vbCr Then
                linha += 1
                contador += 1
            ElseIf caracter = vbLf Then
                contador += 1
            ElseIf letraRegex.IsMatch(caracter) Then
                Dim valor = ""

                While letraRegex.IsMatch(caracter) OrElse numRegex.IsMatch(caracter)
                    valor += caracter
                    contador += 1
                    If contador = arrayTexto.Length Then
                        caracter = ""
                    Else
                        caracter = arrayTexto(contador)
                    End If
                End While

                Dim caracterToken = New Token
                caracterToken.Tipo = "Id"
                caracterToken.Valor = valor
                caracterToken.Coluna = contador
                caracterToken.Numero = contadorToken
                caracterToken.Ocorrencia += $"Linha: {linha}, Coluna: {caracterToken.Coluna}, {vbCrLf}"
                If listaTabela.Count > 0 Then
                    Dim listaAux As New List(Of Token)
                    For Each item In listaTabela
                        If item.Valor = caracterToken.Valor Then
                            item.Ocorrencia = item.Ocorrencia.TrimEnd().TrimEnd("vbCrLf")
                            item.Ocorrencia += caracterToken.Ocorrencia
                            caracterToken.Numero = item.Numero
                        End If
                    Next
                    listaTokens.Add(caracterToken)
                Else
                    listaTokens.Add(caracterToken)
                    listaTabela.Add(caracterToken)
                End If
                contadorToken += 1
            ElseIf numRegex.IsMatch(caracter) Then
                Dim valor = ""
                Dim caracterToken = New Token
                caracterToken.Coluna = contador

                While numRegex.IsMatch(caracter)
                    valor += caracter
                    contador += 1
                    If contador = arrayTexto.Length Then
                        caracter = ""
                    Else
                        caracter = arrayTexto(contador)
                    End If
                End While

                caracterToken.Tipo = "Numero"
                caracterToken.Valor = valor
                caracterToken.Numero = contadorToken
                caracterToken.Ocorrencia += $"Linha: {linha}, Coluna: {caracterToken.Coluna}, {vbCrLf}{vbCrLf}"
                If listaTabela.Count > 0 Then
                    Dim listaAux As New List(Of Token)
                    For Each item In listaTabela
                        If item.Valor = caracterToken.Valor Then
                            item.Ocorrencia = item.Ocorrencia.TrimEnd().TrimEnd("vbCrLf")
                            item.Ocorrencia += caracterToken.Ocorrencia
                            caracterToken.Numero = item.Numero
                        End If
                    Next
                    listaTokens.Add(caracterToken)
                Else
                    listaTokens.Add(caracterToken)
                    listaTabela.Add(caracterToken)
                End If
                contadorToken += 1
            ElseIf caracter = "=" Then
                Dim caracterToken = New Token
                caracterToken.Tipo = "Atribuição"
                caracterToken.Valor = caracter
                caracterToken.Numero = contadorToken
                caracterToken.Ocorrencia += $"Linha: {linha}, Coluna: {caracterToken.Coluna}, {vbCrLf}"
                If listaTabela.Count > 0 Then
                    Dim listaAux As New List(Of Token)
                    For Each item In listaTabela
                        If item.Valor = caracterToken.Valor Then
                            item.Ocorrencia = item.Ocorrencia.TrimEnd().TrimEnd("vbCrLf")
                            item.Ocorrencia += caracterToken.Ocorrencia
                            caracterToken.Numero = item.Numero
                        Else
                            listaAux.Add(caracterToken)
                        End If
                    Next
                    listaTokens.Add(caracterToken)
                    listaTabela.AddRange(listaAux.Distinct())
                Else
                    listaTokens.Add(caracterToken)
                    listaTabela.Add(caracterToken)
                End If
                contador += 1
                contadorToken += 1
            ElseIf caracter = ";" Then
                Dim caracterToken = New Token
                caracterToken.Tipo = "End Of Statement"
                caracterToken.Valor = caracter
                caracterToken.Coluna = contador
                caracterToken.Numero = contadorToken
                caracterToken.Ocorrencia += $"Linha: {linha}, Coluna: {caracterToken.Coluna}, {vbCrLf}"
                If listaTabela.Count > 0 Then
                    Dim listaAux As New List(Of Token)
                    For Each item In listaTabela
                        If item.Valor = caracterToken.Valor Then
                            item.Ocorrencia = item.Ocorrencia.TrimEnd().TrimEnd("vbCrLf")
                            item.Ocorrencia += caracterToken.Ocorrencia
                            caracterToken.Numero = item.Numero
                        Else
                            listaAux.Add(caracterToken)
                        End If
                    Next
                    listaTokens.Add(caracterToken)
                    listaTabela.AddRange(listaAux.Distinct())
                Else
                    listaTokens.Add(caracterToken)
                    listaTabela.Add(caracterToken)
                End If
                contador += 1
                contadorToken += 1
            ElseIf caracter = "?" Then
                Dim caracterToken = New Token
                caracterToken.Tipo = "Mark"
                caracterToken.Valor = caracter
                caracterToken.Coluna = contador
                caracterToken.Numero = contadorToken
                caracterToken.Ocorrencia += $"Linha: {linha}, Coluna: {caracterToken.Coluna}, {vbCrLf}"
                If listaTabela.Count > 0 Then
                    Dim listaAux As New List(Of Token)
                    For Each item In listaTabela
                        If item.Valor = caracterToken.Valor Then
                            item.Ocorrencia = item.Ocorrencia.TrimEnd().TrimEnd("vbCrLf")
                            item.Ocorrencia += caracterToken.Ocorrencia
                            caracterToken.Numero = item.Numero
                        Else
                            listaAux.Add(caracterToken)
                        End If
                    Next
                    listaTokens.Add(caracterToken)
                    listaTabela.AddRange(listaAux.Distinct())
                Else
                    listaTokens.Add(caracterToken)
                    listaTabela.Add(caracterToken)
                End If
                contador += 1
                contadorToken += 1
            ElseIf caracter = "{" OrElse caracter = "}" Then
                Dim caracterToken = New Token
                caracterToken.Tipo = "Key"
                caracterToken.Valor = caracter
                caracterToken.Coluna = contador
                caracterToken.Numero = contadorToken
                caracterToken.Ocorrencia += $"Linha: {linha}, Coluna: {caracterToken.Coluna}, {vbCrLf}"
                If listaTabela.Count > 0 Then
                    Dim listaAux As New List(Of Token)
                    For Each item In listaTabela
                        If item.Valor = caracterToken.Valor Then
                            item.Ocorrencia = item.Ocorrencia.TrimEnd().TrimEnd("vbCrLf")
                            item.Ocorrencia += caracterToken.Ocorrencia
                            caracterToken.Numero = item.Numero
                        Else
                            listaAux.Add(caracterToken)
                        End If
                    Next
                    listaTokens.Add(caracterToken)
                    listaTabela.AddRange(listaAux.Distinct())
                Else
                    listaTokens.Add(caracterToken)
                    listaTabela.Add(caracterToken)
                End If
                contador += 1
                contadorToken += 1
            ElseIf caracter = ":" Then
                Dim caracterToken = New Token
                caracterToken.Tipo = "Collon"
                caracterToken.Valor = caracter
                caracterToken.Coluna = contador
                caracterToken.Numero = contadorToken
                caracterToken.Ocorrencia += $"Linha: {linha}, Coluna: {caracterToken.Coluna}, {vbCrLf}"
                If listaTabela.Count > 0 Then
                    Dim listaAux As New List(Of Token)
                    For Each item In listaTabela
                        If item.Valor = caracterToken.Valor Then
                            item.Ocorrencia = item.Ocorrencia.TrimEnd().TrimEnd("vbCrLf")
                            item.Ocorrencia += caracterToken.Ocorrencia
                            caracterToken.Numero = item.Numero
                        Else
                            listaAux.Add(caracterToken)
                        End If
                    Next
                    listaTokens.Add(caracterToken)
                    listaTabela.AddRange(listaAux.Distinct())
                Else
                    listaTokens.Add(caracterToken)
                    listaTabela.Add(caracterToken)
                End If
                contador += 1
                contadorToken += 1
            End If
        End While
    End Sub

    Private Sub BtnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        If Arquivos.ShowDialog = DialogResult.OK Then
            txtAnalisar.Text = My.Computer.FileSystem.ReadAllText(Arquivos.FileName)
        End If
    End Sub

    Private Sub BtnGerarToken_Click(sender As Object, e As EventArgs) Handles btnGerarToken.Click
        Dim fileWriter As New System.IO.StreamWriter(My.Application.Info.DirectoryPath & "\Token.txt")
        fileWriter.WriteLine(txtRetornoToken.Text)
        fileWriter.Close()
        MsgBox("O arquivo foi gerado!")
    End Sub

    Private Sub btnGerarTabela_Click(sender As Object, e As EventArgs) Handles btnGerarTabela.Click
        Dim fileWriter As New System.IO.StreamWriter(My.Application.Info.DirectoryPath & "\Tabela.txt")
        fileWriter.WriteLine(txtRetornoTabela.Text)
        fileWriter.Close()
        MsgBox("O arquivo foi gerado!")
    End Sub
End Class
