Imports System.IO
Module rpg ' start of program is rpg_main
    'functions to do stuff-------------------------------------------------------------------------
    Public Structure loaded_character
        Dim username As String
        Dim name As String
        Dim gender As String
        Dim level As Integer
        Dim class_ As String
        Dim hp As Integer
        Dim attack As Integer
        Dim defense As Integer
        Dim speed As Integer
    End Structure
    Sub print_loaded_character(ByRef loaded_character As loaded_character)
        Console.WriteLine("|name:" & loaded_character.name & "||gender:" & loaded_character.gender & "||level:" & loaded_character.level & "||class:" & loaded_character.class_ & "||hp:" & loaded_character.hp & "||attack:" & loaded_character.attack & "||defense:" & loaded_character.defense & "||speed:" & loaded_character.speed)
    End Sub
    Sub login(ByRef user_login As String, ByRef user_password As String) 'done
        Dim login_details As StreamReader
        Dim login_details_array() As String
        Dim line As String
        Dim username_verification As Boolean = False
        Dim password_verification As Boolean = False

        Console.Clear()

        login_details = New StreamReader("RpgAccounts.txt")

        line = login_details.ReadToEnd()

        login_details_array = line.Split(",")



        For n = 0 To (login_details_array.Length - 2)
            If (login_details_array(n) = ("un:" & user_login)) And (login_details_array(n + 1) = ("p:" & user_password)) Then
                username_verification = True
                password_verification = True
                Console.Clear()
                Console.WriteLine("you have logged in {0}", user_login)
            End If
        Next






        Do Until username_verification = True And password_verification = True
            Console.WriteLine("please input your username")
            user_login = Console.ReadLine
            Console.WriteLine("please input your password")
            user_password = Console.ReadLine

            If user_login.ToUpper = "X" Or user_password.ToUpper = "X" Then
                Exit Sub
            End If

            For n = 0 To (login_details_array.Length - 2)
                If (login_details_array(n) = ("un:" & user_login)) And (login_details_array(n + 1) = ("p:" & user_password)) Then
                    username_verification = True
                    password_verification = True
                    Console.Clear()
                    Console.WriteLine("you have logged in {0}", user_login)
                End If
            Next
            If username_verification = False And password_verification = False Then
                Console.WriteLine("the login details you entered are not valid please try again")
                Console.Clear()
            End If
        Loop

        If username_verification = True And password_verification = True Then
            logged_in(user_login)
        End If

    End Sub
    Function register(ByRef user_login As String, ByRef user_password As String) 'done
        Dim new_account As StreamWriter
        Dim register_username As String
        Dim register_password As String
        Dim account_details As String
        Dim verification As Integer = 7346587

        Console.Clear()

        Do

            Console.WriteLine("please input your username")
            register_username = Console.ReadLine
            Console.WriteLine("please input your password")
            register_password = Console.ReadLine


            Try
                Console.Clear()

                Console.WriteLine("is this what you want your password to be?" & vbCrLf & "username: {0}" & vbCrLf & "password: {1}" & vbCrLf & vbCrLf & "1.yes" & vbCrLf & "2.no" & vbCrLf, register_username, register_password)
                verification = Console.ReadLine
            Catch ex As Exception
                Console.WriteLine("please enter 1 or 2")
            End Try
        Loop Until verification = 1

        user_login = register_username
        user_password = register_password


        account_details = ("un:" & register_username.Trim & ",p:" & register_password.Trim & ",")

        new_account = New StreamWriter("RpgAccounts.txt", True)

        new_account.Write(account_details)

        new_account.Close()

        Console.Clear()

        Return user_login & user_password

    End Function
    Function create_character(ByRef user_login As String) 'done
        Dim character_sheet As StreamReader
        Dim new_character As String
        Dim new_gender As String = ""
        Dim new_class As Integer
        Dim new_name As String
        Dim line As String
        Dim class_stats() As String
        Dim counter As Integer = 0
        Dim num_of_classes As Integer
        Dim new_characters_stats As String = ""
        Dim new_class_name As String
        Dim lvl As Integer = 1
        Dim gender As Integer = 0

        character_sheet = New StreamReader("class_sheet.txt")

        line = character_sheet.ReadToEnd()

        class_stats = line.Split(",")

        Console.Clear()

        Console.WriteLine("what will be your character's name?")
        new_name = Console.ReadLine

        Console.Write(vbCrLf)

        num_of_classes = class_stats.Length / 5


        Do
            Const number_of_genders = 2
            Dim genders() As String = {"Male", "Female"}
            menu(number_of_genders, genders, gender)

            If gender = 1 Then
                new_gender = "male"
            ElseIf gender = 2 Then
                new_gender = "female"
            End If
        Loop Until gender = 1 Or gender = 2

        Console.Write(vbCrLf)



        Do
            Try
                Console.WriteLine("please.. pick your character's class:" & vbCrLf & "1.warrior" & vbCrLf & "2.paladin" & vbCrLf)
                For n = 0 To class_stats.Length - 1
                    counter = counter + 1
                    If counter = 1 Then

                    ElseIf counter = 2 Then
                        Console.Write("hp: ")
                    ElseIf counter = 3 Then
                        Console.Write("attack: ")
                    ElseIf counter = 4 Then
                        Console.Write("defense:")
                    ElseIf counter = 5 Then
                        Console.Write("speed:")


                    End If
                    Console.WriteLine(class_stats(n))
                    If counter = 5 Then
                        Console.WriteLine(vbCrLf)
                    ElseIf counter = 6 Then
                        counter = 1
                    End If
                Next
                new_class = Console.ReadLine()
            Catch ex As Exception
                Console.WriteLine("please input 1 or 2")
            End Try
            new_class_name = class_stats((new_class - 1) * 5)
        Loop Until new_class < num_of_classes + 1 And new_class > 0


        For n = 0 To num_of_classes - 1

            If (new_class_name) = (class_stats(n * 5)) Then
                new_characters_stats = (class_stats(n * 5).Trim & "," & class_stats((n * 5) + 1) & "," & class_stats((n * 5) + 2) & "," & class_stats((n * 5) + 3) & "," & (class_stats((n * 5) + 4)))

            End If

        Next

        new_character = (user_login & "," & new_name & "," & new_gender & "," & lvl & "," & new_characters_stats & ",")

        file_writer("character_sheet", new_character, False)


        Dim new_inventory As String = ("inventories\" & new_name & "'s_invetory")

        file_writer(new_inventory, ",", True)



        Return user_login
    End Function
    Sub pick_character(ByRef user_login As String) 'not done
        Dim character_s As StreamReader
        Dim character_s_array() As String
        Dim line As String
        Dim load_character As Integer
        Dim choose_character As loaded_character
        Dim owns_character As Boolean = False

        character_s = New StreamReader("character_sheet.txt")

        line = character_s.ReadToEnd

        character_s_array = line.Split(",")



        Do
            For n = 0 To (character_s_array.Length / 10)
                Try
                    If user_login = character_s_array(n * 9) Then
                        owns_character = True
                        Console.WriteLine("|" & (n) & "|name:" & character_s_array((n * 9) + 1).Trim & "||gender:" & character_s_array((n * 9) + 2) & "||level:" & character_s_array((n * 9) + 3) & "||class:" & character_s_array((n * 9) + 4).Trim & "||hp:" & character_s_array((n * 9) + 5) & "||attack:" & character_s_array((n * 9) + 6) & "||defense:" & character_s_array((n * 9) + 7) & "||speed:" & character_s_array((n * 9) + 8))
                        load_character = Console.ReadLine
                    End If
                Catch ex As Exception
                    Console.WriteLine("please enter a number")
                End Try
            Next
        Loop Until load_character < ((character_s_array.Length / 10)) And load_character > -1 Or owns_character = False


        If owns_character = True Then
            choose_character.username = character_s_array((load_character * 9)).Trim
            choose_character.name = character_s_array((load_character * 9) + 1).Trim
            choose_character.gender = character_s_array((load_character * 9) + 2).Trim
            choose_character.level = character_s_array((load_character * 9) + 3).Trim
            choose_character.class_ = character_s_array((load_character * 9) + 4).Trim
            choose_character.hp = character_s_array((load_character * 9) + 5).Trim
            choose_character.attack = character_s_array((load_character * 9) + 6).Trim
            choose_character.defense = character_s_array((load_character * 9) + 7).Trim
            choose_character.speed = character_s_array((load_character * 9) + 8).Trim

            print_loaded_character(choose_character)
        End If

        If owns_character = False Then
            Console.WriteLine("you dont have any characters")
        End If

        Console.ReadLine()

        Console.Clear()

        logged_in(user_login)
    End Sub
    Sub logged_in(ByRef user_login As String) 'not done
        Dim logged_in_menu As Integer
        Dim finished As Integer
        Const LOGGED_IN_NUMBER_OF_OPTIONS = 2
        Dim LOGGED_IN_OPTIONS() As String = {"1.pick character", "2.create new character"}

        Do
            Do
                menu(LOGGED_IN_NUMBER_OF_OPTIONS, LOGGED_IN_OPTIONS, logged_in_menu)
            Loop Until logged_in_menu < 3 And logged_in_menu > 0

            finished = 1

            If logged_in_menu = 1 Then
                pick_character(user_login)
            ElseIf logged_in_menu = 2 Then
                create_character(user_login)
                finished = 0

            End If
        Loop Until finished = 1

    End Sub
    'admin stuff-----------------------------------------------------------------------------------
    Sub admin() 'not done
        Dim choice As Integer


        Do
            Try
                Console.WriteLine("1.class create" & vbCrLf & "2.inventory create/add to" & vbCrLf & "3.create new equipment")
                choice = Console.ReadLine()
            Catch ex As Exception
                Console.WriteLine("please input valid option")
            End Try
        Loop Until choice < 4 And choice > 0

        If choice = 1 Then
            admin_class_create()
        ElseIf choice = 2 Then
            admin_inventory_create()
        ElseIf choice = 3 Then
            admin_create_new_equipment()
        End If

    End Sub
    Sub admin_create_new_equipment()
        Dim equipment_file As StreamWriter
        Dim id As Integer
        Dim name As String
        Dim equipment_type As String
        Dim lvl As Integer
        Dim hp As Integer
        Dim attack As Integer
        Dim defense As Integer
        Dim speed As Integer
        Dim value As Integer
        Dim id_finder As StreamReader
        Dim line As String
        Dim equipment_currently_made() As String
        Dim new_equipment_stats As String
        Dim equipment_reader As String
        Dim all_equipment() As String
        Dim one_equipment() As String = {}


        equipment_file = New StreamWriter("equipment.txt", True)

        equipment_file.Close()

        id_finder = New StreamReader("equipment.txt")

        line = id_finder.ReadToEnd

        equipment_currently_made = line.Split(",")

        If equipment_currently_made.Length = 0 Then
            id = 0
            equipment_file.WriteLine("id,name,equipment_type,lvl,HP,Attack,Defense,Speed,Value,", True)
            equipment_file.WriteLine("0,empty,all,0,0,0,0,0,0,", True)
        End If

        If ((equipment_currently_made.Length - 18) / 9) > -1 Then
            id = ((equipment_currently_made.Length - 18) / 9) + 1
        End If

        id_finder.Close()

        Do
            Console.WriteLine("what will the equipment be? e.g helmet or sword")
            equipment_type = Console.ReadLine
        Loop Until equipment_type = "chestplate" Or equipment_type = "boots" Or equipment_type = "sword" Or equipment_type = "sheild"

        Console.WriteLine("what would you like to call the new equipment")
        name = Console.ReadLine

        Console.WriteLine("what lvl does a character need to be to use the equipment?")
        lvl = Console.ReadLine

        Console.WriteLine("what bonus hp will the equipment give?")
        hp = Console.ReadLine

        Console.WriteLine("what bonus attack will the equipment give?")
        attack = Console.ReadLine

        Console.WriteLine("what bonus defense will the equipment give?")
        defense = Console.ReadLine

        Console.WriteLine("what bonus speed will the equipment give?")
        speed = Console.ReadLine

        Console.WriteLine("what value will the equipment have?")
        value = Console.ReadLine


        new_equipment_stats = (",id:" & id & "," & name & "," & "type:" & equipment_type & "," & "lvl:" & lvl & "," & "hp:" & hp & "," & "attack:" & attack & "," & "defense:" & defense & "," & "speed:" & speed & "," & "value:" & value & "," & vbCrLf)

        equipment_file = New StreamWriter("equipment.txt", True)

        equipment_file.Write(new_equipment_stats)

        equipment_file.Close()

        id_finder = New StreamReader("equipment.txt")

        Console.WriteLine("equipment:" & vbCrLf)

        equipment_reader = id_finder.ReadToEnd

        all_equipment = equipment_reader.Split(",")

        For n = 0 To ((all_equipment.Length - 1) / 11)

            For m = 0 To 9
                one_equipment(m + 1) = all_equipment(((n - 1) * 11) + m)
            Next
        Next

        Console.ReadLine()

    End Sub
    Sub admin_inventory_create()
        Dim inventory_text_file As StreamWriter
        Dim new_inventory_name As String

        Console.WriteLine("what would you like to call the new of the inventory")
        new_inventory_name = Console.ReadLine


        inventory_text_file = New StreamWriter("inventories\" & new_inventory_name & ".txt", True)

    End Sub
    Sub admin_class_create()
        Dim class_sheet_edit As StreamWriter
        Dim create_new_class_name As String
        Dim create_new_class_sort As String
        Dim new_class_hp As Integer
        Dim new_class_attack As Integer
        Dim new_class_defense As Integer
        Dim new_class_speed As Integer


        Console.WriteLine("what new class would you like to create?")
        create_new_class_name = Console.ReadLine


        Do
            Try
                Console.WriteLine("what bonus hp would you like the class to have?")
                new_class_hp = Console.ReadLine()
            Catch ex As Exception
                Console.WriteLine("please input a number")
            End Try
        Loop Until new_class_hp < 100 And new_class_hp > 0

        Do
            Try
                Console.WriteLine("what bonus attack would you like the class to have?")
                new_class_attack = Console.ReadLine()
            Catch ex As Exception
                Console.WriteLine("please input a number")
            End Try
        Loop Until new_class_attack < 100 And new_class_attack > 0

        Do
            Try
                Console.WriteLine("what bonus defense would you like the class to have?")
                new_class_defense = Console.ReadLine()
            Catch ex As Exception
                Console.WriteLine("please input a number")
            End Try
        Loop Until new_class_defense < 100 And new_class_defense > 0

        Do
            Try
                Console.WriteLine("what bonus speed would you like the class to have?")
                new_class_speed = Console.ReadLine()
            Catch ex As Exception
                Console.WriteLine("please input a number")
            End Try
        Loop Until new_class_speed < 100 And new_class_speed > 0

        create_new_class_sort = (create_new_class_name & "," & new_class_hp & "," & new_class_attack & "," & new_class_defense & "," & new_class_speed & ",")

        class_sheet_edit = New StreamWriter("M:\Visual Studio 2013\Projects\rpg\rpg\bin\Debug\class_sheet.txt", True)


        class_sheet_edit.WriteLine(create_new_class_sort)

        class_sheet_edit.Close()
    End Sub

    ' main code -----------------------------------------------------------------------------------
    Sub rpg_start() 'not done
        Const NUMBER_OF_OPTIONS_RPG_MENU = 2
        Dim RPG_MENU_OPTIONS() As String = {"1.login", "2.register"}

        Dim user_input_for_start As String = ""
        Dim user_login As String = ""
        Dim user_password As String = ""
        Dim finished As Integer


        Console.Clear()

        Do
            Do

                menu(NUMBER_OF_OPTIONS_RPG_MENU, RPG_MENU_OPTIONS, user_input_for_start)

            Loop Until user_input_for_start < NUMBER_OF_OPTIONS_RPG_MENU + 1 And user_input_for_start > 0 Or user_input_for_start = 26

            finished = 1

            If user_input_for_start = 1 Then
                login(user_login, user_password)
            ElseIf user_input_for_start = 2 Then
                register(user_login, user_password)
                login(user_login, user_password)
            ElseIf user_input_for_start = -1 Then
                finished = 1
            ElseIf user_input_for_start = 26 Then
                admin()
                finished = 0
            End If
            Console.Clear()
        Loop Until finished = 1


    End Sub

End Module
