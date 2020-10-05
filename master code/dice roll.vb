Module dice_roll 'program starts with dice

    Sub dice()
        Const ROLLS = 100


        Dim rnd As New Random
        Dim List(5) As Integer
        Dim num As Integer


        Console.Clear()


        For N = 0 To (ROLLS - 1)
            random_number(1, 6, num)
            For m = 0 To 5
                If num = m Then
                    List(m) += 1
                End If
            Next

        Next
        Console.Write("1 was rolled {0}" & vbCrLf & "2 was rolled {1}" & vbCrLf & "3 was rolled {2}" & vbCrLf & "4 was rolled {3}" & vbCrLf & "5 was rolled {4}" & vbCrLf & "6 was rolled {5}", List(0), List(1), List(2), List(3), List(4), List(5))

        Console.ReadKey(True).Key.ToString()
    End Sub

End Module
