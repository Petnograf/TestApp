Module Module1
    'Public Class Mine
    '    Public isMine As Boolean
    '    Public id As Long
    'End Class

    'Field Class decleration
    Public Class Field
        Public width As Long
        Public height As Long
        Public id As Long
    End Class

    Sub Main()
        'Boolean to check if user is done adding numbers
        Dim isDone As Boolean
        isDone = False
        'List of the fields the user wants to display
        Dim Fields As New List(Of Field)
        Dim TempField As New Field
        Dim MineCount As Long
        'Strings to get the inputs from the console
        'I set them as strings so we can try and parse them to check if number or not
        Dim a As String
        Dim b As String
        Dim isNumber As Boolean
        Dim i As Long
        i = 0
        'App Starts from here
        Console.WriteLine("Welcome to the Minesweeper Test App")
        Do While isDone = False
            Console.WriteLine("Enter number for field height(! higher than 100)")
            a = Console.ReadLine()
            'Checks if user is done otherwise keeps looping
            If a = "done" Then
                isDone = True
            Else
                'Try parsing inputted string into an int
                isNumber = Decimal.TryParse(a, TempField.height)
                If isNumber = True Then
                    'Try parsing the second input
                    Console.WriteLine("Enter number for field width(! higher than 100)")
                    b = Console.ReadLine()
                    isNumber = Decimal.TryParse(b, TempField.width)
                    If isNumber = True Then
                        'Checks if inputs are less then 100
                        If TempField.height > 100 Or TempField.width > 100 Then
                            Console.WriteLine("The numbers you entered was too big")
                            'Checks if inputs are not equal to zero
                        ElseIf TempField.height = 0 Or TempField.width = 0 Then
                            Console.WriteLine("Zero is not a correct number")
                        Else
                            'If all correct adds it to the list of fields
                            i = i + 1
                            TempField.id = i
                            Fields.Add(TempField)
                            TempField = New Field
                            Console.WriteLine("Added field to list of fields")
                            Console.WriteLine("If you are done adding numbers type 'done'")
                        End If
                    End If
                Else
                    'Displays error message if input was a string
                    Console.WriteLine("You can only enter numbers for this test")
                End If
            End If
        Loop
        'Loop to create minefield from the fields list
        For Each item In Fields
            'Setting the mine count for the field
            If item.width > item.height Then
                MineCount = item.height
            Else
                MineCount = item.width
            End If
            Console.WriteLine("Field number #" + item.id.ToString())
            'Temporary ints for height/width calculation and mine count
            Dim temp_width As Long
            temp_width = 0
            Dim temp_height As Long
            temp_height = 0
            Dim temp_count As Long
            temp_count = 0
            'While loop till the grid height matches the height of the input
            Do While temp_height < item.height
                If temp_height <> item.height Then
                    'While loop till the grid width matches the width of the input
                    Do While temp_width < item.width
                        'Random number generator to put mines randomly into the field
                        Dim rnd = New Random()
                        'While loop inserts mines randomly into the field unless the width would make it bigger then the input
                        Do While temp_count < MineCount And temp_width <> item.width
                            Dim num = rnd.Next(1, 10)
                            'If random is bigger then five a mine is inserted
                            'After that it increments 1 to the temporary numbers
                            If num > 5 Then
                                Console.Write("*")
                                temp_count = temp_count + 1
                                temp_width = temp_width + 1
                            Else
                                Console.Write("0")
                                temp_width = temp_width + 1
                            End If
                        Loop
                        Do While temp_width < item.width
                            Console.Write("0")
                            temp_width = temp_width + 1
                        Loop
                    Loop
                    'If width is reached it sets the count back to zero
                    'Then adds a new row
                    temp_width = 0
                    Console.WriteLine("")
                    temp_height = temp_height + 1
                End If
            Loop
        Next
        Console.ReadLine()
    End Sub

End Module
