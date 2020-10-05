Imports System.IO
Module Module1

    Sub Main()
        Dim objStreamWriter As StreamWriter

        'Pass the file path and the file name to the StreamWriter constructor.
        objStreamWriter = New StreamWriter("M:\Visual Studio 2013\Projects\testing.txt")

        'Write a line of text.
        objStreamWriter.WriteLine("Hello World")

        'Write a second line of text.
        objStreamWriter.WriteLine("From the StreamWriter class")

        'Close the file.
        objStreamWriter.Close()

        Dim objStreamReader As StreamReader
        Dim strLine As String

        'Pass the file path and the file name to the StreamReader constructor.
        objStreamReader = New StreamReader("M:\Visual Studio 2013\Projects\testing.txt")

        'Read the first line of text.
        strLine = objStreamReader.ReadLine

        'Continue to read until you reach the end of the file.
        Do While Not strLine Is Nothing

            'Write the line to the Console window.
            Console.WriteLine(strLine)

            'Read the next line.
            strLine = objStreamReader.ReadLine
        Loop

        'Close the file.
        objStreamReader.Close()

        Console.ReadLine()

    End Sub

End Module
