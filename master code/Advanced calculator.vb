Module calculator ' start of program is advanced_calculator

    Sub advanced_calculator()
        Dim UserIn As String = ""
        'Dim Calculation As String
        'Dim CalAdd() As String
        'Dim CalSub() As String
        'Dim CalMult() As String
        Dim CalDiv() As String
        Dim Results() As Integer = {}

        Console.Clear()

        Exit Sub

        Console.WriteLine("input your calculation")
        UserIn = Console.ReadLine()

        CalDiv = UserIn.Split({"/"c})
        Console.WriteLine("{0}", CalDiv(0))
        For n = 0 To 2

            Results(0) = (CalDiv(n) / CalDiv(n + 1))
            Console.WriteLine("{0}", Results(n))
        Next
        Console.Write(Results(0))
        Console.Write(CalDiv(0))
        Console.Write(UserIn(0))
        Console.ReadLine()
    End Sub

End Module
