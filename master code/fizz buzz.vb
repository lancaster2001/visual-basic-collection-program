Module fizzbuzz_program

    Sub fizzbuzz()
        Dim max_num As Integer = 999
        Dim num As Integer
        Dim rnd As New Random
        Dim again As Integer

        Console.Clear()

        Do

            If again = max_num Then
                again = 0
            End If
            again = again + 1

            num = rnd.Next(1, 30)
            If num Mod 3 = 0 And num Mod 5 = 0 Then
                Console.WriteLine("fizzbuzz")

            ElseIf num Mod 3 = 0 Then
                Console.WriteLine("fizz")

            ElseIf num Mod 5 = 0 Then
                Console.WriteLine("buzz")
            End If


        Loop Until again = max_num
        Console.ReadLine()
    End Sub

End Module
