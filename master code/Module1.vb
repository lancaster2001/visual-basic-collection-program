Public Module Module1
    Public Sub Main()
        Dim PROGRAMS() As String = {"1.RPG", "2.calculator", "3.caeser cipher", "4.dice", "5.fizzbuzz", "6.drawing"}
        Dim PROGRAMS_LINkS() As String = {}
        Dim LOGIN_MENU_OPTIONS() As String = {"1.login", "2.register"}
        Dim NUMBER_OF_LOGIN_MENU_OPTIONS As Integer = 2


        Dim X As Boolean = False
        Dim user_program As String = ""
        Dim user_login As String = ""
        Dim user_password As String = ""
        Dim finished As Integer = False
        Dim main_user_login As String = ""
        Dim main_user_password As String = ""
        Dim main_user_option As Integer = -1
        Dim main_logged_in As Boolean = False
        Dim main_error_string As Boolean = False
        Dim finish As Boolean = False

        Console.Clear()

        welcome()

        main_user_option = 0

        finish = False
        main_logged_in = False


        Do

            menu(NUMBER_OF_LOGIN_MENU_OPTIONS, LOGIN_MENU_OPTIONS, main_user_option)





            If main_user_option = 0 Then
                Exit Sub
            ElseIf main_user_option = 1 Then
                main_login(main_user_login, main_user_password, main_logged_in)
            ElseIf main_user_option = 2 Then
                main_register(main_user_login, main_user_password, main_logged_in)
                main_login(main_user_login, main_user_password, main_logged_in)
            ElseIf main_user_option = 26 Then
                main_logged_in = True
                main_user_login = "guest"
                Console.Clear()
            End If

        Loop Until main_logged_in = True

        If finish = False Then
            catagories1()
        End If
        Main()
    End Sub
    Sub catagories1()
        Const NUMBER_OF_PROGRAMS_MAIN = 6
        Dim PROGRAMS() As String = {"1.RPG", "2.calculator", "3.caeser cipher", "4.dice", "5.fizzbuzz", "6.drawing"}
        Dim user_program As Integer = 0

        Do

            menu(NUMBER_OF_PROGRAMS_MAIN, PROGRAMS, user_program)

            If user_program <> 0 Then
                program_caller(user_program)
            End If

            Console.Clear()
        Loop Until user_program = 0
    End Sub
    Function program_caller(ByRef main_user_option As Integer)
        Dim plain_text As String = ""
        Dim key As Integer = 0



        If main_user_option = 1 Then
            rpg_start()
        ElseIf main_user_option = 2 Then
            advanced_calculator()
        ElseIf main_user_option = 3 Then
            encryption_programs(plain_text, key)
        ElseIf main_user_option = 4 Then
            dice()
        ElseIf main_user_option = 5 Then
            fizzbuzz()
        ElseIf main_user_option = 6 Then
            drawing_menu()
        End If

        Return main_user_option
    End Function
    Sub welcome()
        Dim random_crap_the_user_typed_because_they_were_probably_bored As String = ""
        Console.WriteLine("█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█" & vbCrLf & "█░░╦─╦╔╗╦─╔╗╔╗╔╦╗╔╗░░█" & vbCrLf & "█░░║║║╠─║─║─║║║║║╠─░░█" & vbCrLf & "█░░╚╩╝╚╝╚╝╚╝╚╝╩─╩╚╝░░█" & vbCrLf & "█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█")

        Console.ReadKey(True).Key.ToString()

        Console.Clear()
    End Sub
End Module
