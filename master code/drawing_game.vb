Imports System.Threading
Module drawing_game
    Sub drawing_menu()
        Const DRAWING_NUMBER_OF_OPTIONS = 2
        Dim DRAWING_MENU_OPTIONS() As String = {"1.drawing", "2.drawing game"}
        Dim user_input As String = ""

        menu(DRAWING_NUMBER_OF_OPTIONS, DRAWING_MENU_OPTIONS, user_input)

        If user_input = 0 Then
            Exit Sub
        ElseIf user_input = 1 Then
            drawing()
        ElseIf user_input = 2 Then
            snake()
        End If


    End Sub
    Sub drawing()
        Console.Clear()
        Console.CursorVisible = False


        Const WIDTH = 119
        Const HEIGHT = 29

        Dim down As Boolean = False
        Dim up As Boolean = False
        Dim left As Boolean = False
        Dim right As Boolean = False

        Dim direction As String = ""


        Dim x As Integer = 0
        Dim y As Integer = 0

        Console.SetCursorPosition(x, y)


        Console.Clear()
        Console.Write("press a key to start{0}use WASD to change direction", vbCrLf)
        direction = Console.ReadKey(True).Key.ToString()
        Console.Clear()


        Do
            Console.SetCursorPosition(x, y)
            Console.Write("█")

            direction = Console.ReadKey(True).Key.ToString()

            Select Case direction
                Case "W"
                    If y <> 0 Then
                        y -= 1
                    End If
                Case "A"
                    If x <> 0 Then
                        x -= 1
                    End If
                Case "S"
                    If y <> HEIGHT - 1 Then
                        y += 1
                    End If
                Case "D"
                    If x <> WIDTH - 1 Then
                        x += 1
                    End If
            End Select


            If direction = "Escape" Then
                Console.CursorVisible = True
                Exit Sub
            End If

        Loop

        Console.ReadLine()
    End Sub
    Sub snake()
        Console.Clear()
        Console.CursorVisible = False


        Const WIDTH = 119
        Const HEIGHT = 29
        Const original_speed = 125
        Dim SNAKE_WIN As Integer = 20
        Const num_of_obs = 50
        Dim obs((num_of_obs - 1), 1) As String

        Console.SetWindowSize(WIDTH + 1, HEIGHT + 1)

        Dim user_snake As user_character_snake

        user_snake.length = 3

        Dim speed As Integer = original_speed
        Dim extend As Boolean = False

        Dim num As Integer = 0
        Dim count As Integer = 0


        Dim px As Integer = 0
        Dim py As Integer = 0

        Dim dx As Integer = 1
        Dim dy As Integer = 0

        Dim c As String = "X"

        Dim direction As String = ""

        Dim x As Integer = 0
        Dim y As Integer = 0

        Dim length As Integer = 3
        Dim body(40, 1) As String

        Dim create_snake_count As Integer = length

        body(0, 0) = 1
        body(0, 1) = 1



        Console.SetCursorPosition(x, y)


        Console.Clear()
        Console.Write("press a key to start{0}use WASD to change direction", vbCrLf)
        direction = Console.ReadKey(True).Key.ToString()
        Console.Clear()
        For m = 0 To 1

            For n = 0 To WIDTH
                y = m * HEIGHT
                x = n
                draw(x, y, "#")
                x = 0
            Next
            For n = 0 To HEIGHT
                x = m * WIDTH
                y = n
                draw(x, y, "#")
                y = 0
            Next
        Next
        draw(0, 0, "#")


        obsticals(num_of_obs, obs)

        Console.SetCursorPosition(x, y)

        pelet(WIDTH, HEIGHT, px, py, x, y)

        x = 1
        y = 1

        Do
           
            draw(x, y, c)

            Thread.Sleep(speed)
            speed = original_speed


            If Console.KeyAvailable = True Then
                direction = Console.ReadKey(True).Key.ToString
            End If


            Select Case direction
                Case "W"
                    If y <> 0 Then
                        dx = 0
                        dy = -1
                    End If
                Case "A"
                    If x <> 0 Then
                        dx = -1
                        dy = 0
                    End If
                Case "S"
                    If y <> HEIGHT - 1 Then
                        dx = 0
                        dy = 1
                    End If
                Case "D"
                    If x <> WIDTH - 1 Then
                        dx = 1
                        dy = 0
                    End If
                Case "E"
                    speed = 25
            End Select

            x += dx
            y += dy

            count += 1

            If count > length Then
                For n = 1 To length
                    If (body(0, 0) = body(n, 0)) And (body(0, 1) = body(n, 1)) Then
                        Console.Clear()
                        snake()
                    End If
                Next
            End If




            For m = 0 To 1
                For n = 1 To length - 1
                    draw(body(length - 1, 0), body(length - 1, 1), " ")
                    body(length - n, m) = body(length - 1 - n, m)
                Next
            Next



            body(0, 0) = x
            body(0, 1) = y

            If body(0, 0) = px And body(0, 1) = py Then
                length += 1

                extend = True
                pelet(WIDTH, HEIGHT, px, py, x, y)
                If length - 1 = SNAKE_WIN Then
                    Console.Clear()
                    Console.Write("you win!!!")
                    Console.ReadKey(True).Key.ToString()
                    snake()
                End If
            End If

            If x = 0 Or x = WIDTH Or y = 0 Or y = HEIGHT Then
                Console.Clear()
                snake()
            End If

            For n = 0 To (num_of_obs - 1)
                If (px = obs(n, 0)) And (py = obs(n, 1)) Then
                    pelet(WIDTH, HEIGHT, px, py, x, y)
                End If
                If (x = obs(n, 0)) And (y = obs(n, 1)) Then
                    Console.Clear()
                    snake()
                End If
            Next






            draw(body(0, 0), body(0, 1), c)



            If direction = "Escape" Then
                Console.CursorVisible = True
                Exit Sub
            End If

        Loop Until direction = "x"


    End Sub
    Sub draw(x As Integer, y As Integer, c As Char)
        Console.SetCursorPosition(x, y)
        Console.Write(c)
    End Sub
    Sub pelet(ByVal WIDTH As Integer, ByVal HEIGHT As Integer, ByRef px As Integer, ByRef py As Integer, ByVal x As Integer, ByVal y As Integer)


        random_number(1, WIDTH, px)

        random_number(1, WIDTH, px)

        random_number(2, HEIGHT, py)

        random_number(2, HEIGHT, py)

        draw(px, py, "~")

        Console.SetCursorPosition(x, y)
    End Sub
    Function obsticals(ByRef num_of_obs As Integer, ByRef obs(,) As String)

        Dim obx As Integer
        Dim oby As Integer

        For n = 0 To (num_of_obs - 1)
            random_number(1, 118, obx)
            random_number(2, 27, oby)

            draw(obx, oby, "#")
            obs(n, 0) = obx
            obs(n, 1) = oby

        Next




        Return obs
    End Function
    Sub BackgroundSound()
        My.Computer.Audio.Play("point.mp3",AudioPlayMode.BackgroundLoop)
    End Sub
End Module
