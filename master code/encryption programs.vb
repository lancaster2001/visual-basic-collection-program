Imports System.IO
Module caeser_cipher
    Function encryption_programs(ByRef plain_text As String, ByRef key As Integer)
        Const NUMBER_OF_PROGRAMS_ENCRYPTION = 5
        Dim PROGRAMS_ENCRYPTION() As String = {"1)caeser cipher", "2)decryption", "3)encrypt file", "4)decrypt file", "5)text analysis"}

        Dim file_Name As String = ""
        Dim cipher_text As String = ""
        Dim valid As Boolean = False
        Dim valid2 As Boolean = False
        Dim valid3 As Boolean = False
        Dim choice As String = -6
        Dim know_key As Integer = 0
        Dim is_ok As Integer = 0

        Console.Clear()
        Do
            Do
                Try
                    valid2 = True
                    know_key = 0

                    choice = Convert.ToString(choice)
                    choice = ""
                    menu(NUMBER_OF_PROGRAMS_ENCRYPTION, PROGRAMS_ENCRYPTION, choice)
                    

                    If choice = 0 Then
                        Return key
                        Exit Function
                    End If

                    choice = Convert.ToInt16(choice)

                    If choice < 0 Or choice > 6 Then
                        valid2 = False
                        Console.Clear()
                        Console.WriteLine("please enter a number in range")
                    End If

                Catch ex As Exception

                    Console.Clear()
                    valid2 = False
                    Console.WriteLine("please enter a number")
                End Try
                If valid2 = False Then
                    choice = -111
                End If

            Loop Until valid2 = True And choice > 0 And choice < 6

            Console.Clear()



            If choice = 1 Then
                Console.WriteLine("enter the message you would like to encrypt")
                plain_text = Console.ReadLine

                Do
                    Try
                        valid = True
                        Console.WriteLine("what will be your key?")
                        key = Console.ReadLine()
                    Catch ex As Exception
                        Console.WriteLine("please input a number")
                        valid = False

                    End Try
                Loop Until valid = True

                caeser_encrypt(plain_text, key, cipher_text)

                Console.WriteLine("encrypted text: " & cipher_text & vbCrLf & "key: " & key)

            ElseIf choice = 2 Then
                Console.WriteLine("enter the message you would like to decrypt")
                cipher_text = Console.ReadLine
                Do
                    Try
                        valid = True
                        Console.WriteLine("what will be your key?")
                        key = Console.ReadLine()
                    Catch ex As Exception
                        Console.Clear()
                        Console.WriteLine("please input a number")
                        valid = False

                    End Try
                Loop Until valid = True

                caeser_decrypt(plain_text, key, cipher_text)

                Console.WriteLine("text: " & plain_text)
            ElseIf choice = 3 Then
                Console.WriteLine("what is the address of the file you would like to encrypt e.g. hello.txt would be called hello")
                file_Name = Console.ReadLine

                Do
                    Try
                        valid = True
                        Console.WriteLine("what will be your key?")
                        key = Console.ReadLine()
                    Catch ex As Exception
                        Console.WriteLine("please input a number")
                        valid = False

                    End Try
                Loop Until valid = True

                caeser_file_encrypt(plain_text, key, cipher_text, file_Name)

                Console.WriteLine("the encrypted text is{0} and was saved as the (file name)_encrypted at should be located underneath the original file", cipher_text)

                Console.ReadLine()
            ElseIf choice = 4 Then
                Console.WriteLine("what is the address of the file you would like to decrypt e.g. hello.txt would be called hello")
                file_Name = Console.ReadLine

                Do
                    Try
                        valid3 = True
                        Console.WriteLine("do you know the key?" & vbCrLf & "1)yes" & vbCrLf & "2)no")
                        know_key = Console.ReadLine()
                    Catch ex As Exception
                        Console.Clear()
                        Console.WriteLine("please input a number")
                        valid3 = False

                    End Try
                Loop Until valid3 = True And know_key > 0 And know_key < 3

                If know_key = 1 Then
                    Do
                        Try
                            valid3 = True
                            Console.WriteLine("what is the key")
                        Catch ex As Exception
                            valid3 = False
                            Console.Clear()
                            Console.WriteLine("please enter a number")
                        End Try
                    Loop Until valid3 = True

                ElseIf know_key = 2 Then
                    key = 98798

                End If



                is_ok = 2

                Do
                    Console.Clear()
                    caeser_decrypt_file(plain_text, key, cipher_text, file_Name)
                    Console.WriteLine(plain_text)
                    Try
                        valid3 = True
                        Console.WriteLine("does this look right?" & vbCrLf & "1)yes" & vbCrLf & "2)no")
                        is_ok = Console.ReadLine
                    Catch ex As Exception
                        valid3 = False
                        Console.Clear()
                        Console.WriteLine("please enter a number")

                    End Try



                    key += 1
                Loop Until valid3 = True And is_ok = 1
            ElseIf choice = 5 Then
                Console.WriteLine("what is the text you would like to analyse")
                cipher_text = Console.ReadLine

                letter_decrypt(cipher_text)
            End If

            Console.ReadLine()
            Console.Clear()
        Loop
        Return key
    End Function
    Function caeser_encrypt(ByRef plain_text As String, ByRef key As Integer, ByRef cipher_text As String)
        Dim letter As String = ""
        Dim ascii_letter As Integer = 0
        Dim valid As Boolean = False
        Dim count As UInteger = 0
        Dim space As Boolean = False
        Dim spaces As Integer = 0
        Dim rnd As New Random
        Dim random_holder As Integer


        plain_text = plain_text.ToUpper



        cipher_text = ""



        For n = 0 To (plain_text.Length - 1)
            space = False

            letter = plain_text(n)
            ascii_letter = Asc(letter)



            If ascii_letter < 65 Or ascii_letter > 90 Then
                space = True
            End If

            If space = True Then
                random_holder = rnd.Next(33, 176)
                cipher_text += Chr(random_holder)
            End If

            If space = False Then
                ascii_letter += key
                valid = False
                Do
                    If ascii_letter > 90 Then
                        ascii_letter -= 26
                    End If
                    If ascii_letter < 65 Then
                        ascii_letter += 26
                    End If
                    If ((ascii_letter < 91) And (ascii_letter > 64)) Then
                        valid = True
                    End If
                Loop Until valid = True

                cipher_text += Chr(ascii_letter)
            End If


        Next



        Return cipher_text
    End Function
    Function caeser_decrypt(ByRef plain_text As String, ByRef key As Integer, ByRef cipher_text As String)
        Dim letter As String = ""
        Dim ascii_letter As Integer = 0
        Dim valid As Boolean = False
        Dim count As Integer = 0




        cipher_text = cipher_text.ToUpper




        plain_text = ""

        For n = 0 To (cipher_text.Length - 1)


            letter = cipher_text(n)
            ascii_letter = Asc(letter)
            ascii_letter -= key
            valid = False



            Do
                If ascii_letter > 90 Then
                    ascii_letter -= 26
                End If
                If ascii_letter < 65 Then
                    ascii_letter += 26
                End If
                If ((ascii_letter < 91) And (ascii_letter > 64)) Then
                    valid = True
                End If

            Loop Until valid = True



            plain_text += Chr(ascii_letter)


        Next
        Return plain_text
    End Function
    Function caeser_file_encrypt(ByRef plain_text As String, ByRef key As Integer, ByRef cipher_text As String, ByRef file_name As String)
        Dim writing_file As StreamWriter
        Dim reading_file As StreamReader

        reading_file = New StreamReader(file_name & ".txt")

        plain_text = reading_file.ReadToEnd()

        caeser_encrypt(plain_text, key, cipher_text)

        writing_file = New StreamWriter(file_name & "_encrypted" & ".txt", True)


        writing_file.Write(cipher_text)

        reading_file.Close()
        writing_file.Close()

        Return cipher_text
    End Function
    Function caeser_decrypt_file(ByRef plain_text As String, ByRef key As Integer, ByRef cipher_text As String, ByRef file_name As String)
        Dim reading_file As StreamReader


        reading_file = New StreamReader(file_name & ".txt")

        cipher_text = reading_file.ReadToEnd()

        caeser_decrypt(plain_text, key, cipher_text)

        reading_file.Close()

        Console.Clear()


        Return plain_text
    End Function
    Sub letter_decrypt(ByRef cipher_text As String)
        Dim letter_count(254, 3) As String
        Dim editable_cipher_text As String = cipher_text
        Dim asc_count As Integer = 0
        Dim count As Integer = 0



        For n = 0 To 254
            letter_count(n, 0) = Chr(asc_count)
            letter_count(n, 1) = 0
            letter_count(n, 2) = 0
            asc_count += 1
        Next



        For n = 0 To (editable_cipher_text.Length - 1)
            For m = 0 To 254
                If editable_cipher_text(n) = letter_count(m, 0) Then
                    letter_count(m, 1) += 1
                End If
            Next
        Next

        For n = 0 To 254
            count += letter_count(n, 1)
        Next

        For n = 0 To 254
            letter_count(n, 2) = ((letter_count(n, 1) / count) * 100)
        Next

        For n = 0 To 254
            For m = 0 To Int(letter_count(n, 1))
                If m <> 0 Then
                    letter_count(n, 3) = letter_count(n, 3) & "#"
                End If
            Next
        Next

        Console.WriteLine("# = 10%")

        For n = 0 To 254
            If letter_count(n, 1) <> 0 Then
                Console.WriteLine("{0}: {2}     {1}%", letter_count(n, 0), (letter_count(n, 2)), letter_count(n, 3))
            End If
        Next
    End Sub
End Module