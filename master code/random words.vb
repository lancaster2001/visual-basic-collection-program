Module random_word_program ' program starts with random_words

    Sub random_words()
        Dim StartLetter As String
        Dim EndLetter As String
        Dim range As Integer
        Dim word As String
        Dim rnd As New Random


        Do
            StartLetter = rnd.Next(65, 91)
            StartLetter = Chr(StartLetter)
            EndLetter = rnd.Next(65, 91)
            EndLetter = Chr(EndLetter)
            range = rnd.Next(2, 11)

            Console.Write("Enter a word that starts with {0}, ends with {1} and is {2} characters long ", StartLetter, EndLetter, range)
            word = Console.ReadLine

            If word.ToUpper.StartsWith(StartLetter) And word.ToUpper.EndsWith(EndLetter) And word.Length = range Then
                Console.WriteLine("{0} starts with {1}, ends with {2} and is {3} characters long ", word, StartLetter, EndLetter, range)
            Else
                Console.WriteLine("{0} either doesn't start with {1}, end in {2} or is {3} characters long  ", word, StartLetter, EndLetter, range)
            End If
        Loop

        Console.ReadLine()
    End Sub

End Module
