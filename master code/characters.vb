Module characters
    Structure user_character_snake
        Dim current_locations(,) As String
        Dim length As Integer
        Dim c As String

    End Structure
    Sub snake_create()
        Dim user_snake As user_character_snake
        Dim count As Integer = 0



        user_snake.c = "X"

        For m = 0 To 1
            For n = 1 To user_snake.length - 1
                draw(user_snake.current_locations(user_snake.length - 1, 0), user_snake.current_locations(user_snake.length - 1, 1), " ")
                user_snake.current_locations(user_snake.length - n, m) = user_snake.current_locations(user_snake.length - 1 - n, m)
            Next
        Next

        For n = 0 To user_snake.length - 1

            user_snake.current_locations(n, 0) = 1
            user_snake.current_locations(n, 1) = 1
            count += 1
        Next


    End Sub
    Sub snake_move(ByVal dx As Integer, ByVal dy As Integer)



    End Sub
End Module
