using System;

class Program
{
    static char[] columns = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
    static void print_battlefield(char[][] battlefield)
    {
        Console.WriteLine("Your field:");
        Console.WriteLine("     A   B   C   D   E   F   G   H   I   J");
        Console.WriteLine("   -----------------------------------------");
        for (int i = 0; i < 9; i++)
        {
            Console.WriteLine($"{i + 1}  | {battlefield[i][0]} | {battlefield[i][1]} | {battlefield[i][2]} | {battlefield[i][3]} | {battlefield[i][4]} | {battlefield[i][5]} | {battlefield[i][6]} | {battlefield[i][7]} | {battlefield[i][8]} | {battlefield[i][9]} |");
            Console.WriteLine("   -----------------------------------------");
        }
        Console.WriteLine($"10 | {battlefield[9][0]} | {battlefield[9][1]} | {battlefield[9][2]} | {battlefield[9][3]} | {battlefield[9][4]} | {battlefield[9][5]} | {battlefield[9][6]} | {battlefield[9][7]} | {battlefield[9][8]} | {battlefield[9][9]} |");
        Console.WriteLine("   -----------------------------------------\n");
    }
    static void print_fightfield(char[][] fightfield)
    {
        Console.WriteLine("Enemy's field:");
        Console.WriteLine("     A   B   C   D   E   F   G   H   I   J");
        Console.WriteLine("   -----------------------------------------");
        for (int i = 0; i < 9; i++)
        {
            Console.WriteLine($"{i + 1}  | {fightfield[i][0]} | {fightfield[i][1]} | {fightfield[i][2]} | {fightfield[i][3]} | {fightfield[i][4]} | {fightfield[i][5]} | {fightfield[i][6]} | {fightfield[i][7]} | {fightfield[i][8]} | {fightfield[i][9]} |");
            Console.WriteLine("   -----------------------------------------");
        }
        Console.WriteLine($"10 | {fightfield[9][0]} | {fightfield[9][1]} | {fightfield[9][2]} | {fightfield[9][3]} | {fightfield[9][4]} | {fightfield[9][5]} | {fightfield[9][6]} | {fightfield[9][7]} | {fightfield[9][8]} | {fightfield[9][9]} |");
        Console.WriteLine("   -----------------------------------------\n");
    }
    static char[][] establish(char[][] battlefield, int size)
    {
        int row1 = 0, column1 = 0, row2 = 0, column2 = 0;
        string input;
        for (int count = 0; count < 5 - size; count++)
        {
            bool left = false, right = false, up = false, down = false;
            while (true)
            {
                try
                {
                    print_battlefield(battlefield);
                    Console.Write($"Enter the cell where the beginning of the ship with size {size} will be located: ");
                    input = Console.ReadLine().
                        Trim().
                        ToUpper();
                    row1 = Convert.ToInt32(input[0]) - 49;
                    column1 = Array.IndexOf(columns, input[1]);
                    if (row1 < 0 || row1 > 9)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input! Try again");
                        continue;
                    }
                    if (row1 == 0)
                    {
                        if (input[1] == '0')
                        {
                            row1 = 9;
                            column1 = Array.IndexOf(columns, input[2]);
                        }
                    }
                    if (column1 == -1 || row1 == -1 || input.Length > 3 || input.Length > 2 && input[1] != '0')
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input! Try again");
                        continue;
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input! Try again");
                    continue;
                }

                if (10 - column1 >= size) right = true;
                if (10 - row1 >= size) down = true;
                if (column1 + 1 >= size) left = true;
                if (row1 + 1 >= size) up = true;

                if (battlefield[row1][column1] == ' ')
                {
                    if (row1 == 0)
                    {
                        up = false;
                        if (column1 == 0)
                        {
                            left = false;
                            if (battlefield[0][1] != ' ' ||
                                battlefield[1][0] != ' ' ||
                                battlefield[1][1] != ' ')
                            {
                                Console.Clear();
                                Console.WriteLine("It is impossible to place the ship close to others! Try again");
                                continue;
                            }
                            for (int i = 1; i < size; i++)
                            {
                                if (right)
                                {
                                    if (battlefield[0][i + 1] != ' ' ||
                                    battlefield[1][i + 1] != ' ')
                                    {
                                        right = false;
                                    }
                                }
                                if (down)
                                {
                                    if (battlefield[i + 1][0] != ' ' ||
                                    battlefield[i + 1][1] != ' ')
                                    {
                                        down = false;
                                    }
                                }
                            }
                        }
                        else if (column1 == 9)
                        {
                            right = false;
                            if (battlefield[0][8] != ' ' ||
                                battlefield[1][8] != ' ' ||
                                battlefield[1][9] != ' ')
                            {
                                Console.Clear();
                                Console.WriteLine("It is impossible to place the ship close to others! Try again");
                                continue;
                            }
                            for (int i = 1; i < size; i++)
                            {
                                if (left)
                                {
                                    if (battlefield[0][8 - i] != ' ' ||
                                        battlefield[1][8 - i] != ' ')
                                    {
                                        left = false;
                                    }
                                }
                                if (down)
                                {
                                    if (battlefield[i + 1][9] != ' ' ||
                                        battlefield[i + 1][8] != ' ')
                                    {
                                        down = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (battlefield[row1][column1 + 1] != ' ' ||
                                battlefield[row1][column1 - 1] != ' ' ||
                                battlefield[row1 + 1][column1] != ' ' ||
                                battlefield[row1 + 1][column1 + 1] != ' ' ||
                                battlefield[row1 + 1][column1 - 1] != ' ')
                            {
                                Console.Clear();
                                Console.WriteLine("It is impossible to place the ship close to others! Try again");
                                continue;
                            }
                            for (int i = 1; i < size; i++)
                            {
                                if (left && column1 - i - 1 >= 0)
                                {
                                    if (battlefield[0][column1 - i - 1] != ' ' ||
                                        battlefield[1][column1 - i - 1] != ' ')
                                    {
                                        left = false;
                                    }
                                }
                                if (right && column1 + i + 1 < 10)
                                {
                                    if (battlefield[0][column1 + i + 1] != ' ' ||
                                        battlefield[1][column1 + i + 1] != ' ')
                                    {
                                        right = false;
                                    }
                                }
                                if (down)
                                {
                                    if (battlefield[i + 1][column1] != ' ' ||
                                        battlefield[i + 1][column1 + 1] != ' ' ||
                                        battlefield[i + 1][column1 - 1] != ' ')
                                    {
                                        down = false;
                                    }
                                }
                            }
                        }
                    }
                    else if (row1 == 9)
                    {
                        down = false;
                        if (column1 == 0)
                        {
                            left = false;
                            if (battlefield[9][1] != ' ' ||
                                battlefield[8][1] != ' ' ||
                                battlefield[8][0] != ' ')
                            {
                                Console.Clear();
                                Console.WriteLine("It is impossible to place the ship close to others! Try again");
                                continue;
                            }
                            for (int i = 1; i < size; i++)
                            {
                                if (right)
                                {
                                    if (battlefield[9][i + 1] != ' ' ||
                                        battlefield[8][i + 1] != ' ')
                                    {
                                        right = false;
                                    }
                                }
                                if (up)
                                {
                                    if (battlefield[8 - i][0] != ' ' ||
                                        battlefield[8 - i][1] != ' ')
                                    {
                                        up = false;
                                    }
                                }
                            }
                        }
                        else if (column1 == 9)
                        {
                            right = false;
                            if (battlefield[row1][column1 - 1] != ' ' ||
                                battlefield[row1 - 1][column1 - 1] != ' ' ||
                                battlefield[row1 - 1][column1] != ' ')
                            {
                                Console.Clear();
                                Console.WriteLine("It is impossible to place the ship close to others! Try again");
                                continue;
                            }
                            for (int i = 1; i < size; i++)
                            {
                                if (left)
                                {
                                    if (battlefield[9][8 - i] != ' ' ||
                                        battlefield[8][8 - i] != ' ')
                                    {
                                        left = false;
                                    }
                                }
                                if (up)
                                {
                                    if (battlefield[8 - i][9] != ' ' ||
                                        battlefield[8 - i][8] != ' ')
                                    {
                                        up = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (battlefield[row1][column1 + 1] != ' ' ||
                                battlefield[row1][column1 - 1] != ' ' ||
                                battlefield[row1 - 1][column1 + 1] != ' ' ||
                                battlefield[row1 - 1][column1 - 1] != ' ' ||
                                battlefield[row1 - 1][column1] != ' ')
                            {
                                Console.Clear();
                                Console.WriteLine("It is impossible to place the ship close to others! Try again");
                                continue;
                            }
                            for (int i = 1; i < size; i++)
                            {
                                if (left && column1 - i - 1 >= 0)
                                {
                                    if (battlefield[9][column1 - i - 1] != ' ' ||
                                        battlefield[8][column1 - i - 1] != ' ')
                                    {
                                        left = false;
                                    }
                                }
                                if (right && column1 + i + 1 < 10)
                                {
                                    if (battlefield[9][column1 + i + 1] != ' ' ||
                                        battlefield[8][column1 + i + 1] != ' ')
                                    {
                                        right = false;
                                    }
                                }
                                if (up)
                                {
                                    if (battlefield[8 - i][column1] != ' ' ||
                                        battlefield[8 - i][column1 + 1] != ' ' ||
                                        battlefield[8 - i][column1 - 1] != ' ')
                                    {
                                        up = false;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (column1 == 0)
                        {
                            left = false;
                            if (battlefield[row1][1] != ' ' ||
                                battlefield[row1 + 1][1] != ' ' ||
                                battlefield[row1 - 1][1] != ' ' ||
                                battlefield[row1 + 1][0] != ' ' ||
                                battlefield[row1 - 1][0] != ' ')
                            {
                                Console.Clear();
                                Console.WriteLine("It is impossible to place the ship close to others! Try again");
                                continue;
                            }
                            for (int i = 1; i < size; i++)
                            {
                                if (right)
                                {
                                    if (battlefield[row1][i + 1] != ' ' ||
                                        battlefield[row1 + 1][i + 1] != ' ' ||
                                        battlefield[row1 - 1][i + 1] != ' ')
                                    {
                                        right = false;
                                    }
                                }
                                if (up && row1 - i - 1 >= 0)
                                {
                                    if (battlefield[row1 - i - 1][0] != ' ' ||
                                        battlefield[row1 - i - 1][1] != ' ')
                                    {
                                        up = false;
                                    }
                                }
                                if (down && row1 + i + 1 < 10)
                                {
                                    if (battlefield[row1 + i + 1][0] != ' ' ||
                                        battlefield[row1 + i + 1][1] != ' ')
                                    {
                                        down = false;
                                    }
                                }
                            }
                        }
                        else if (column1 == 9)
                        {
                            right = false;
                            if (battlefield[row1][column1 - 1] != ' ' ||
                                battlefield[row1 + 1][column1 - 1] != ' ' ||
                                battlefield[row1 - 1][column1 - 1] != ' ' ||
                                battlefield[row1 + 1][column1] != ' ' ||
                                battlefield[row1 - 1][column1] != ' ')
                            {
                                Console.Clear();
                                Console.WriteLine("It is impossible to place the ship close to others! Try again");
                                continue;
                            }
                            for (int i = 1; i < size; i++)
                            {
                                if (left)
                                {
                                    if (battlefield[row1][8 - i] != ' ' ||
                                        battlefield[row1 + 1][8 - i] != ' ' ||
                                        battlefield[row1 - 1][8 - i] != ' ')
                                    {
                                        left = false;
                                    }
                                }
                                if (up && row1 - i - 1 >= 0)
                                {
                                    if (battlefield[row1 - i - 1][9] != ' ' ||
                                        battlefield[row1 - i - 1][8] != ' ')
                                    {
                                        up = false;
                                    }
                                }
                                if (down && row1 + i + 1 < 10)
                                {
                                    if (battlefield[row1 + i + 1][9] != ' ' ||
                                        battlefield[row1 + i + 1][8] != ' ')
                                    {
                                        down = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (battlefield[row1][column1 + 1] != ' ' ||
                                battlefield[row1][column1 - 1] != ' ' ||
                                battlefield[row1 + 1][column1] != ' ' ||
                                battlefield[row1 + 1][column1 + 1] != ' ' ||
                                battlefield[row1 + 1][column1 - 1] != ' ' ||
                                battlefield[row1 - 1][column1 + 1] != ' ' ||
                                battlefield[row1 - 1][column1 - 1] != ' ' ||
                                battlefield[row1 - 1][column1] != ' ')
                            {
                                Console.Clear();
                                Console.WriteLine("It is impossible to place the ship close to others! Try again");
                                continue;
                            }
                            for (int i = 1; i < size; i++)
                            {
                                if (left && column1 - i - 1 >= 0)
                                {
                                    if (battlefield[row1][column1 - i - 1] != ' ' ||
                                        battlefield[row1 + 1][column1 - i - 1] != ' ' ||
                                        battlefield[row1 - 1][column1 - i - 1] != ' ')
                                    {
                                        left = false;
                                    }
                                }
                                if (right && column1 + i + 1 < 10)
                                {
                                    if (battlefield[row1][column1 + i + 1] != ' ' ||
                                        battlefield[row1 + 1][column1 + i + 1] != ' ' ||
                                        battlefield[row1 - 1][column1 + i + 1] != ' ')
                                    {
                                        right = false;
                                    }
                                }
                                if (up && row1 - i - 1 >= 0)
                                {
                                    if (battlefield[row1 - i - 1][column1] != ' ' ||
                                        battlefield[row1 - i - 1][column1 + 1] != ' ' ||
                                        battlefield[row1 - i - 1][column1 - 1] != ' ')
                                    {
                                        up = false;
                                    }
                                }
                                if (down && row1 + i + 1 < 10)
                                {
                                    if (battlefield[row1 + i + 1][column1] != ' ' ||
                                        battlefield[row1 + i + 1][column1 + 1] != ' ' ||
                                        battlefield[row1 + i + 1][column1 - 1] != ' ')
                                    {
                                        down = false;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("There is already a ship in this cell! Try again");
                    continue;
                }
                if (!up && !down && !left && !right)
                {
                    Console.Clear();
                    Console.WriteLine("The ship won't fit here! Try again");
                    continue;
                }
                else
                {
                    battlefield[row1][column1] = '▓';
                    Console.Clear();
                    break;
                }
            }
            while (true)
            {
                if (size == 1)
                {
                    battlefield[row1][column1] = '█';
                    break;
                }
                else
                {
                    try
                    {
                        print_battlefield(battlefield);
                        Console.Write($"Enter the cell where the end of the ship with size {size} will be located: ");
                        input = Console.ReadLine().
                            Trim().
                            ToUpper();
                        row2 = Convert.ToInt32(input[0]) - 49;
                        column2 = Array.IndexOf(columns, input[1]);
                        if (row2 < 0 || row2 > 9)
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid input! Try again");
                            continue;
                        }
                        if (row2 == 0)
                        {
                            if (input[1] == '0')
                            {
                                row2 = 9;
                                column2 = Array.IndexOf(columns, input[2]);
                            }
                        }
                        if (column2 == -1 || row2 == -1 || input.Length > 3 || input.Length > 2 && input[1] != '0')
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid input! Try again");
                            continue;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input! Try again");
                        continue;
                    }
                    if (row1 != row2 && column1 != column2)
                    {
                        Console.Clear();
                        Console.WriteLine("The ship can only be positioned vertically or horizontally! Try again");
                        continue;
                    }
                    if (row1 == row2)
                    {
                        if (column2 - column1 == size - 1)
                        {
                            if (right)
                            {
                                for (int i = column1; i <= column2; i++) battlefield[row1][i] = '█';
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("It is impossible to place the ship close to others! Try again");
                                continue;
                            }
                        }
                        else if (column1 - column2 == size - 1)
                        {
                            if (left)
                            {
                                for (int i = column2; i <= column1; i++) battlefield[row1][i] = '█';
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("It is impossible to place the ship close to others! Try again");
                                continue;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("The ship is the wrong length! Try again");
                            continue;
                        }
                    }
                    else
                    {
                        if (row2 - row1 == size - 1)
                        {
                            if (down)
                            {
                                for (int i = row1; i <= row2; i++) battlefield[i][column1] = '█';
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("It is impossible to place the ship close to others! Try again");
                                continue;
                            }
                        }
                        else if (row1 - row2 == size - 1)
                        {
                            if (up)
                            {
                                for (int i = row2; i <= row1; i++) battlefield[i][column1] = '█';
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("It is impossible to place the ship close to others! Try again");
                                continue;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("The ship is the wrong length! Try again");
                            continue;
                        }
                    }
                    Console.Clear();
                    break;
                }
            }
        }
        return battlefield;
    }
    static bool shot(string name, char[][] battlefield, ref char[][] fightfield, ref char[][] enemy_battlefield)
    {
        string input;
        int row, column, fired, intact;
        while (true)
        {
            try
            {
                Console.WriteLine($"{name}'s turn");
                print_battlefield(battlefield);
                print_fightfield(fightfield);
                Console.Write("Enter the cell you will shoot at: ");
                input = Console.ReadLine().
                    Trim().
                    ToUpper();
                row = Convert.ToInt32(input[0]) - 49;
                column = Array.IndexOf(columns, input[1]);
                if (row < 0 || row > 9)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input! Try again");
                    continue;
                }
                if (row == 0)
                {
                    if (input[1] == '0')
                    {
                        row = 9;
                        column = Array.IndexOf(columns, input[2]);
                    }
                }
                if (column == -1 || row == -1 || input.Length > 3 || input.Length > 2 && input[1] != '0')
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input! Try again");
                    continue;
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("Invalid input! Try again");
                continue;
            }
            if (fightfield[row][column] == 'Ø')
            {
                Console.Clear();
                Console.WriteLine("You have already shot at this cell! Select another cell");
                continue;
            }
            else if (fightfield[row][column] == 'X')
            {
                Console.Clear();
                Console.WriteLine("There can't be a ship here! Select another cell");
                continue;
            }
            else break;
        }
        if (enemy_battlefield[row][column] == ' ')
        {
            fightfield[row][column] = 'X';
            enemy_battlefield[row][column] = 'X';
            Console.Clear();
            Console.WriteLine($"{name}'s turn");
            print_battlefield(battlefield);
            print_fightfield(fightfield);
            Console.WriteLine($"Enter the cell you will shoot at: {input}");
            Console.WriteLine("Miss!");
            DateTime t = DateTime.Now;
            while ((DateTime.Now - t).TotalSeconds < 5) ;
            Console.Clear();
            return false;
        }
        else
        {
            fired = 1;
            intact = 0;
            
            fightfield[row][column] = '▓';
            enemy_battlefield[row][column] = '▓';

            for (int i = row - 1; i >= 0 && enemy_battlefield[i][column] != ' ' && enemy_battlefield[i][column] != 'X'; i--)
            {
                if (enemy_battlefield[i][column] == '▓') fired++;
                else intact++;
            }
            for (int i = row + 1; i < 10 && enemy_battlefield[i][column] != ' ' && enemy_battlefield[i][column] != 'X'; i++)
            {
                if (enemy_battlefield[i][column] == '▓') fired++;
                else intact++;
            }
            for (int i = column - 1; i >= 0 && enemy_battlefield[row][i] != ' ' && enemy_battlefield[row][i] != 'X'; i--)
            {
                if (enemy_battlefield[row][i] == '▓') fired++;
                else intact++;
            }
            for (int i = column + 1; i < 10 && enemy_battlefield[row][i] != ' ' && enemy_battlefield[row][i] != 'X'; i++)
            {
                if (enemy_battlefield[row][i] == '▓') fired++;
                else intact++;
            }

            if (intact == 0)
            {
                enemy_battlefield[row][column] = '█';
                fightfield[row][column] = '█';
                for (int i = row + 1; i < 10; i++)
                {
                    if (enemy_battlefield[i][column] == ' ' || enemy_battlefield[i][column] == 'X')
                    {
                        enemy_battlefield[i][column] = 'X';
                        fightfield[i][column] = 'X';
                        if (column == 0)
                        {
                            enemy_battlefield[i][column + 1] = 'X';
                            fightfield[i][column + 1] = 'X';
                        }
                        else if (column == 9)
                        {
                            enemy_battlefield[i][column - 1] = 'X';
                            fightfield[i][column - 1] = 'X';
                        }
                        else
                        {
                            enemy_battlefield[i][column + 1] = 'X';
                            fightfield[i][column + 1] = 'X';
                            enemy_battlefield[i][column - 1] = 'X';
                            fightfield[i][column - 1] = 'X';
                        }
                        break;
                    }
                    else
                    {
                        enemy_battlefield[i][column] = '█';
                        fightfield[i][column] = '█';
                        if (column == 0)
                        {
                            enemy_battlefield[i][column + 1] = 'X';
                            fightfield[i][column + 1] = 'X';
                        }
                        else if (column == 9)
                        {
                            enemy_battlefield[i][column - 1] = 'X';
                            fightfield[i][column - 1] = 'X';
                        }
                        else
                        {
                            enemy_battlefield[i][column + 1] = 'X';
                            fightfield[i][column + 1] = 'X';
                            enemy_battlefield[i][column - 1] = 'X';
                            fightfield[i][column - 1] = 'X';
                        }
                    }
                }
                for (int i = row - 1; i >= 0; i--)
                {
                    if (enemy_battlefield[i][column] == ' ' || enemy_battlefield[i][column] == 'X')
                    {
                        enemy_battlefield[i][column] = 'X';
                        fightfield[i][column] = 'X';
                        if (column == 0)
                        {
                            enemy_battlefield[i][column + 1] = 'X';
                            fightfield[i][column + 1] = 'X';
                        }
                        else if (column == 9)
                        {
                            enemy_battlefield[i][column - 1] = 'X';
                            fightfield[i][column - 1] = 'X';
                        }
                        else
                        {
                            enemy_battlefield[i][column + 1] = 'X';
                            fightfield[i][column + 1] = 'X';
                            enemy_battlefield[i][column - 1] = 'X';
                            fightfield[i][column - 1] = 'X';
                        }
                        break;
                    }
                    else
                    {
                        enemy_battlefield[i][column] = '█';
                        fightfield[i][column] = '█';
                        if (column == 0)
                        {
                            enemy_battlefield[i][column + 1] = 'X';
                            fightfield[i][column + 1] = 'X';
                        }
                        else if (column == 9)
                        {
                            enemy_battlefield[i][column - 1] = 'X';
                            fightfield[i][column - 1] = 'X';
                        }
                        else
                        {
                            enemy_battlefield[i][column + 1] = 'X';
                            fightfield[i][column + 1] = 'X';
                            enemy_battlefield[i][column - 1] = 'X';
                            fightfield[i][column - 1] = 'X';
                        }
                    }
                }
                for (int i = column + 1; i < 10; i++)
                {
                    if (enemy_battlefield[row][i] == ' ' || enemy_battlefield[row][i] == 'X')
                    {
                        enemy_battlefield[row][i] = 'X';
                        fightfield[row][i] = 'X';
                        if (row == 0)
                        {
                            enemy_battlefield[row + 1][i] = 'X';
                            fightfield[row + 1][i] = 'X';
                        }
                        else if (row == 9)
                        {
                            enemy_battlefield[row - 1][i] = 'X';
                            fightfield[row - 1][i] = 'X';
                        }
                        else
                        {
                            enemy_battlefield[row + 1][i] = 'X';
                            fightfield[row + 1][i] = 'X';
                            enemy_battlefield[row - 1][i] = 'X';
                            fightfield[row - 1][i] = 'X';
                        }
                        break;
                    }
                    else
                    {
                        enemy_battlefield[row][i] = '█';
                        fightfield[row][i] = '█';
                        if (row == 0)
                        {
                            enemy_battlefield[row + 1][i] = 'X';
                            fightfield[row + 1][i] = 'X';
                        }
                        else if (row == 9)
                        {
                            enemy_battlefield[row - 1][i] = 'X';
                            fightfield[row - 1][i] = 'X';
                        }
                        else
                        {
                            enemy_battlefield[row + 1][i] = 'X';
                            fightfield[row + 1][i] = 'X';
                            enemy_battlefield[row - 1][i] = 'X';
                            fightfield[row - 1][i] = 'X';
                        }
                    }
                }
                for (int i = column - 1; i >= 0; i--)
                {
                    if (enemy_battlefield[row][i] == ' ' || enemy_battlefield[row][i] == 'X')
                    {
                        enemy_battlefield[row][i] = 'X';
                        fightfield[row][i] = 'X';
                        if (row == 0)
                        {
                            enemy_battlefield[row + 1][i] = 'X';
                            fightfield[row + 1][i] = 'X';
                        }
                        else if (row == 9)
                        {
                            enemy_battlefield[row - 1][i] = 'X';
                            fightfield[row - 1][i] = 'X';
                        }
                        else
                        {
                            enemy_battlefield[row + 1][i] = 'X';
                            fightfield[row + 1][i] = 'X';
                            enemy_battlefield[row - 1][i] = 'X';
                            fightfield[row - 1][i] = 'X';
                        }
                        break;
                    }
                    else
                    {
                        enemy_battlefield[row][i] = '█';
                        fightfield[row][i] = '█';
                        if (row == 0)
                        {
                            enemy_battlefield[row + 1][i] = 'X';
                            fightfield[row + 1][i] = 'X';
                        }
                        else if (row == 9)
                        {
                            enemy_battlefield[row - 1][i] = 'X';
                            fightfield[row - 1][i] = 'X';
                        }
                        else
                        {
                            enemy_battlefield[row + 1][i] = 'X';
                            fightfield[row + 1][i] = 'X';
                            enemy_battlefield[row - 1][i] = 'X';
                            fightfield[row - 1][i] = 'X';
                        }
                    }
                }
                Console.Clear();
                Console.WriteLine($"A ship of size {fired} was sunk");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Hit!");
            }
            return true;
        }
    }
    static void Main()
    {
        int ships1 = 20, ships2 = 20;
        string name1, name2;
        char[][] battlefield1 = new char[10][], battlefield2 = new char[10][], firedfield1 = new char[10][], firedfield2 = new char[10][];
        bool first_step; //Player1's turn, if true
        Console.Title = "Battleship";

        Console.Write("Player1, enter your name: ");
        name1 = Console.ReadLine().Trim();
        Console.Write("Player2, enter your name: ");
        name2 = Console.ReadLine().Trim();

        if (name1 == "") name1 = "Player2";
        if (name2 == "") name2 = "Player2";
        if (name1 == name2)
        {
            if (name1 != "")
            {
                name1 = name1 + '1';
                name2 = name2 + '2';
            }
        }
        while (true)
        {
            Console.Clear();

            for (int i = 0; i < 10; i++)
            {
                battlefield1[i] = new char[10] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
                battlefield2[i] = new char[10] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
                firedfield1[i] = new char[10] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
                firedfield2[i] = new char[10] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
            }

            Console.WriteLine("You need to arrange 1 ship with size 4, 2 ships with size 3, 3 ships with size 2 and 4 ships with size 1.");
            Console.WriteLine("Ships can only be positioned vertically or horizontally and cannot touch each other.");
            Console.WriteLine("You need to specify cells in the range from 1A to 10J\n");
            Console.WriteLine($"{name1}, position your ships.");
            battlefield1 = establish(battlefield1, 4);
            battlefield1 = establish(battlefield1, 3);
            battlefield1 = establish(battlefield1, 2);
            battlefield1 = establish(battlefield1, 1);

            Console.WriteLine("You need to arrange 1 ship with size 4, 2 ships with size 3, 3 ships with size 2 and 4 ships with size 1.");
            Console.WriteLine("Ships can only be positioned vertically or horizontally and cannot touch each other.");
            Console.WriteLine("You need to specify cells in the range from 1A to 10J\n");
            Console.WriteLine($"{name2}, position your ships.");
            battlefield2 = establish(battlefield2, 4);
            battlefield2 = establish(battlefield2, 3);
            battlefield2 = establish(battlefield2, 2);
            battlefield2 = establish(battlefield2, 1);

            Random rnd = new Random();
            if (rnd.Next(2) == 0) first_step = true;
            else first_step = false;

            Console.WriteLine("The great random chooses the one who will move first. Wait");
            Console.Write(".");
            DateTime t = DateTime.Now;
            while ((DateTime.Now - t).TotalSeconds < 1) ;
            Console.Write(".");
            while ((DateTime.Now - t).TotalSeconds < 2) ;
            Console.Write(".");
            while ((DateTime.Now - t).TotalSeconds < 3) ;
            Console.Write("\b\b\b   \b\b\b");
            if (first_step) Console.WriteLine($"{name1} will be the first to move");
            else Console.WriteLine($"{name2} will be the first to move");
            while ((DateTime.Now - t).TotalSeconds < 5.5) ;
            Console.Clear();

            while (ships1 > 0 && ships2 > 0)
            {
                if (first_step)
                {
                    if (shot(name1, battlefield1, ref firedfield1, ref battlefield2))
                    {
                        ships2--;
                    }
                    else
                    {
                        first_step = false;
                    }
                }
                else
                {
                    if (shot(name2, battlefield2, ref firedfield2, ref battlefield1))
                    {
                        ships1--;
                    }
                    else
                    {
                        first_step = true;
                    }
                }
            }
            Console.Clear();
            Console.WriteLine($"{name1}'s field");
            print_battlefield(battlefield1);
            Console.WriteLine($"{name2}'s field");
            print_battlefield(battlefield2);
            if (ships1 == 0)
            {
                Console.WriteLine($"{name2} won!");
            }
            else
            {
                Console.WriteLine($"{name1} won!");
            }
            Console.WriteLine("\nDo you want to play again?");
            string choice;
            while (true)
            {
                Console.WriteLine("1. Play again");
                Console.WriteLine("2. Exit");
                choice = Console.ReadLine().Trim();
                if (choice == "1") break;
                else if (choice == "2") Environment.Exit(0);
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input! Try again");
                }
            }
        }
    }
}