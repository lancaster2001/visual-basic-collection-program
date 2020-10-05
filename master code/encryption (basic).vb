Module encryption_module ' start of program is encryption

    Sub encryption()

        Dim AMOUNT_OF_INPUTS As Integer

        Console.Clear()

        Try
            Console.Write("how many messages would you like to encrypt? ")
            AMOUNT_OF_INPUTS = Console.ReadLine()
        Catch ex As Exception
            Console.WriteLine("please enter a valid number")
        End Try

        Dim UserIn(AMOUNT_OF_INPUTS - 1) As String
        Dim UserInEcrypt(AMOUNT_OF_INPUTS - 1) As String



        Console.WriteLine("input {0} messages", AMOUNT_OF_INPUTS)
        For n = 0 To (AMOUNT_OF_INPUTS - 1)
            UserIn(n) = Console.ReadLine()
        Next

        Console.WriteLine("your encrypted messages are:")

        For n = 0 To (AMOUNT_OF_INPUTS - 1)
            UserInEcrypt(n) = Asc(UserIn(n))
            UserInEcrypt(n) = UserInEcrypt(n) * 2 - 7 ^ 3
            Console.WriteLine("{0}", UserInEcrypt(n))
        Next
        Console.ReadLine()
    End Sub

End Module
