Module binary_to_hex_module ' start of program is binary_to_hex

    Sub binary_to_hex()

        Dim Number As Integer
        Dim Number2 As Integer
        Dim Number3 As Integer
        Dim Number4 As Integer
        Dim Rnd As New Random
        Dim BinaryNumber As String
        Dim HexNumber As String
        Dim UserInput As String

        Console.Clear()

        Do

            Number = Rnd.Next(2, 256)
            Number2 = Rnd.Next(2, 256)
            Number3 = Rnd.Next(2, 256)
            Number4 = Rnd.Next(2, 256)
            BinaryNumber = Convert.ToString(Number, 2).PadLeft(8, "0") & Convert.ToString(Number2, 2).PadLeft(8, "0") & Convert.ToString(Number3, 2).PadLeft(8, "0") & Convert.ToString(Number4, 2).PadLeft(8, "0")
            HexNumber = Convert.ToString(Number, 16).ToUpper.PadLeft(2, "0") & Convert.ToString(Number2, 16).ToUpper.PadLeft(2, "0") & Convert.ToString(Number3, 16).ToUpper.PadLeft(2, "0") & Convert.ToString(Number4, 16).ToUpper.PadLeft(2, "0")

            Console.Write("Convert the binary number {0} to hexadecimal: ", BinaryNumber)
            UserInput = Console.ReadLine
            UserInput = UserInput.ToUpper.PadLeft(2, "0")

            If UserInput = HexNumber Then
                Console.WriteLine("That's correct")
            Else
                Console.WriteLine("WRONG, the binary number {0} written in hexadecimal is {1}", BinaryNumber, HexNumber)
            End If

            Console.ReadLine()
        Loop
    End Sub

End Module
