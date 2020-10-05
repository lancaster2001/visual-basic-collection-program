Imports System.IO
Module login_module
    Function main_register(ByRef user_login As String, ByRef user_password As String, ByRef logged_in As Boolean)
        Dim main_new_account As StreamWriter
        Dim main_register_username As String = ""
        Dim main_register_password As String = ""
        Dim main_account_details As String = ""
        Dim verification As Integer = 7346587
        Dim blank As Boolean = True

        Console.Clear()

        logged_in = False


        Do
            blank = False
            Console.WriteLine("please input a username")
            main_register_username = Console.ReadLine
            If main_register_username.ToUpper = "X" Then
                Return logged_in
                Exit Function
            End If

            Console.WriteLine("please input a password")
            main_register_password = Console.ReadLine
            If main_register_password.ToUpper = "X" Then
                Return logged_in
                Exit Function
            End If


            If main_register_username.Trim = "" Or main_register_password.Trim = "" Then
                blank = True
            End If

            If blank = False Then
                Try
                    Console.Clear()

                    Console.WriteLine("is this what you want your password to be?" & vbCrLf & "username: {0}" & vbCrLf & "password: {1}" & vbCrLf & vbCrLf & "1.yes" & vbCrLf & "2.no" & vbCrLf, main_register_username, main_register_password)
                    verification = Console.ReadLine
                Catch ex As Exception
                    Console.WriteLine("please enter 1 or 2")
                End Try
            End If
        Loop Until verification = 1

        user_login = main_register_username
        user_password = main_register_password


        main_account_details = ("un:" & main_register_username.Trim & ",p:" & main_register_password.Trim & ",")

        main_new_account = New StreamWriter("main_Accounts.txt", True)

        main_new_account.Write(main_account_details)

        main_new_account.Close()

        Console.Clear()

        Return user_login & user_password
    End Function
    Function main_login(ByRef user_login As String, ByRef user_password As String, ByRef logged_in As Boolean)
        Dim login_details As StreamReader
        Dim login_details_array() As String
        Dim line As String = ""
        Dim username_verification As Boolean = False
        Dim password_verification As Boolean = False

        Console.Clear()

        login_details = New StreamReader("main_Accounts.txt")

        line = login_details.ReadToEnd()

        login_details_array = line.Split(",")


        For n = 0 To (login_details_array.Length - 2)
            If (login_details_array(n) = ("un:" & user_login)) And (login_details_array(n + 1) = ("p:" & user_password)) Then
                username_verification = True
                password_verification = True
                logged_in = True
                Console.Clear()
                Console.WriteLine("you have logged in {0}", user_login)
            End If
        Next






        Do Until username_verification = True And password_verification = True
            Console.WriteLine("please input your username")
            user_login = Console.ReadLine
            If user_login.ToUpper = "X" Then
                Return logged_in
                Exit Function
            End If



            Console.WriteLine("please input your password")
            user_password = Console.ReadLine
            If user_password.ToUpper = "X" Then
                Return logged_in
                Exit Function
            End If


            For n = 0 To (login_details_array.Length - 2)
                If (login_details_array(n) = ("un:" & user_login)) And (login_details_array(n + 1) = ("p:" & user_password)) Then
                    username_verification = True
                    password_verification = True
                    Console.Clear()
                    Console.WriteLine("you have logged in {0}", user_login)
                    logged_in = True
                End If
            Next
            If username_verification = False And password_verification = False Then
                Console.WriteLine("the login details you entered are not valid please try again")
                Console.Clear()

            End If
        Loop

        login_details.Close()

        Return (user_login & logged_in)
    End Function
End Module