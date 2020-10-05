Module number_input_program 'program starts with number_input

    Sub number_input()
        Const ARRAY_SIZE = 5


        Dim Numbers(ARRAY_SIZE - 1) As Integer
        Dim Total As Integer
        Dim Largest As Integer
        Dim Smallest As Integer
        Dim InCorrect As Boolean
        Dim Average As Decimal

        Total = 0

        For N = 0 To ARRAY_SIZE - 1
            Do
                Try
                    InCorrect = True
                    Console.Write("please enter a number")
                    Numbers(N) = Console.ReadLine()
                Catch ex As Exception
                    Console.WriteLine("invalid input")
                    InCorrect = False
                End Try
            Loop Until InCorrect = True


        Next
        Largest = Numbers(0)
        Smallest = Numbers(0)
        For M = 1 To ARRAY_SIZE - 1
            If Numbers(M) > Largest Then
                Largest = Numbers(M)
            End If
        Next
        For M = 1 To ARRAY_SIZE - 1
            If Numbers(M) < Smallest Then
                Smallest = Numbers(M)
            End If
        Next
        For M = 0 To ARRAY_SIZE - 1
            Total = Total + Numbers(M)
        Next

        Average = Total / ARRAY_SIZE

        Console.Write("Total = {0}" & vbCrLf & "Largest number = {1}" & vbCrLf & "Smallest number = {2}" & vbCrLf & "Average number = {3}", Total, Largest, Smallest, Average)

        Console.ReadLine()
    End Sub


End Module
