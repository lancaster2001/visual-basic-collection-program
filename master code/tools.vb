Imports System.IO
Imports System.Threading
Module tools
    Function menu(ByVal number_of_options As Integer, ByVal menu_options() As String, ByRef menu_answer As String)
        Console.Clear()
        Console.CursorVisible = False


        Dim current_option As Integer
        Dim correct As Boolean = False

        current_option = 1

        menu_answer = Convert.ToString(menu_answer)

        menu_answer = ""

        Do
            Try
                correct = False



                For n = 0 To number_of_options - 1
                    If n = current_option - 1 Then
                        Console.Write("█")
                    End If
                    Console.WriteLine(menu_options(n))
                Next

                menu_answer = Console.ReadKey(True).Key.ToString()




                Select Case menu_answer
                    Case "S"
                        current_option = current_option + 1
                    Case "DownArrow"
                        current_option += 1
                    Case "W"
                        current_option -= 1
                    Case "UpArrow"
                        current_option -= 1
                    Case "Enter"
                        correct = True
                    Case "RightArrow"
                        correct = True
                    Case "D"
                        correct = True
                    Case "p"
                        testing()
                    Case menu_answer = "X"
                        menu_answer = "-1"
                        menu_answer = Convert.ToInt16(menu_answer)
                        Return menu_answer
                        Exit Function
                    Case menu_answer = "A"
                        menu_answer = "-1"
                        menu_answer = Convert.ToInt16(menu_answer)
                        Return menu_answer
                        Exit Function
                        menu_answer = "LeftArrow"
                        menu_answer = "-1"
                        menu_answer = Convert.ToInt16(menu_answer)
                        Return menu_answer
                        Exit Function
                End Select



                Console.Clear()

            Catch ex As Exception
                Console.Clear()
                Console.WriteLine("something somewhere went wrong")
                correct = False
            End Try


            If current_option = 0 Then
                current_option = number_of_options
            ElseIf current_option = number_of_options + 1 Then
                current_option = 1
            End If


        Loop Until correct = True

        Console.CursorVisible = True

        menu_answer = Convert.ToInt16(current_option)

        Return menu_answer
    End Function
    Sub testing()
        Console.Clear()

        Dim key As String
        Do
            key = Console.ReadKey(True).Key.ToString()
            Console.WriteLine(key)

            Select Case key
                Case "="
                    Exit Sub
            End Select
        Loop
    End Sub
    Sub list()

    End Sub
    '
    Sub file_writer(ByRef file_name As String, ByRef text As String, ByRef newline As Boolean)
        Dim file As StreamWriter


        file = New StreamWriter(file_name & ".txt", True)

        file.Write(text)

        If newline = True Then
            file.Write(vbCrLf)
        End If

        file.Close()

    End Sub
    Function file_reader(ByRef file_name As String, ByRef read As Boolean)
        Dim file As StreamReader
        Dim text As String

        file = New StreamReader(file_name & ".txt")

        text = file.ReadToEnd

        If read = True Then
            Console.WriteLine(text)
        End If

        file.Close()

        Return text
    End Function
    '
    Function random_number(ByVal num1 As Integer, ByVal num2 As Integer, ByRef random_num As Integer)
        Dim rnd_num As New Random
        Dim random_num1 As Integer = 10

        Thread.Sleep(21)

        Randomize()

        Dim random_num2 = CInt(Int((random_num * Rnd()) + 1)) - 1

        For n = 0 To random_num2

            random_num = rnd_num.Next(num1 - 1, num2)
        Next

        Return random_num
    End Function
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        ' by making Generator static, we preserve the same instance '
        ' (i.e., do not create new instances with the same seed over and over) '
        ' between calls '
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function
    '
End Module

