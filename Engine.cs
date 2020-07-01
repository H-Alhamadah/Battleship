using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridGame
//23X24 Size Grid
{
    class Engine
    {
        public static int ships = 0;
        public static int width = 25;
        public static int height = 25;
        public static int P1Tries = 0;
        public static int P1LiveShips = 30;
        public static int P2Tries = 0;
        public static int P2LiveShips = 30;
        public static int ComputerGuessX = 0;
        public static int ComputerGuessY = 0;
        public static bool ComputerTurn = false;
        public static int[,] board1 = new int[width, height];
        public static int[,] board2 = new int[width, height];
        Random rand = new Random();
        public static Stack<int> goodGuessX = new Stack<int>();
        public static Stack<int> goodGuessY = new Stack<int>();
        public static bool? win = null;
        public static string playerName = "Player 1";
        public static bool customShips = false;
        public static bool resumeGame = false;
        public static bool forceClosed = false;
        public static bool save = false;
        public static int[] custLocationsX = new int[30];
        public static int[] custLocationsY = new int[30];
        public static string board1String;
        public static string board2String;
        public static string P1ShipLeft;
        public static string P1ShipTop;
        public static string P1ShipWidth;
        public static string P1ShipHeight;
        public static string P1ShipOr;
        public static string P2ShipLeft;
        public static string P2ShipTop;
        public static string P2ShipWidth;
        public static string P2ShipHeight;
        public static string P2ShipOr;
        public static string GuessX;
        public static string GuessY;
        public static Ship[] shipsList1 = new Ship[10];
        public int shipCountP2 = 0;
        public int shipCountP1 = 0;

        public static Ship[] shipsList2 = new Ship[10];


        public enum Status
        {
            Water,
            Ship,
            Hit,
            Miss
        }


        public static GameData gameData = new GameData();
        public int[,] generateMap()
        {
            int[,] mapData = new int[width, height];
            for (int x = 0; x < mapData.GetLength(0); x++)
                for (int y = 0; y < mapData.GetLength(1); y++)
                    mapData[x, y] = 0;
            return mapData;
        }

        public int[,] generateCustomShips(int[,] map)
        {
            for (int i = 0; i < custLocationsX.Length; i++)
            {
                map[custLocationsX[i], custLocationsY[i]] = 1;
                //Console.WriteLine("X:" + custLocationsX[i] + " Y:" + custLocationsY[i]);
            }
            return map;
        }

        public int[,] generateShips1(int shipSize, int[,] map)
        {
            int direction = rand.Next(2);
            int x = rand.Next(1, width - 1);
            int y = rand.Next(1, height);
            Boolean valid = true;


            switch (direction)
            {
                case 0:
                    for (int i = 0; i < shipSize; i++)
                    {
                        if ((x + i) < 23)
                        {
                            if (map[x + i, y] == 1)
                            {
                                valid = false;
                                break;
                            }
                        }
                        else
                        {
                            valid = false;
                        }
                    }
                    break;

                case 1:
                    for (int i = 0; i < shipSize; i++)
                    {
                        if ((y + i) < 24)
                        {
                            if (map[x, y + i] == 1)
                            {
                                valid = false;
                                break;
                            }
                        }
                        else
                        {
                            valid = false;
                        }
                    }
                    break;
                default:
                    break;
            }


            if (valid)
            {
                if (direction == 0)
                {
                    ships++;
                    for (int i = 0; i < shipSize; i++)
                        map[x + i, y] = 1;
                    shipsList1[shipCountP1++] = new Ship(x, y, 20 * shipSize, 20, true);
                }
                else
                {
                    ships++;
                    for (int i = 0; i < shipSize; i++)
                        map[x, y + i] = 1;
                    shipsList1[shipCountP1++] = new Ship(x, y, 20, 20 * shipSize, false);
                }
            }
            else
            {
                map = generateShips1(shipSize, map);

            }

            return map;

        }
        public int[,] generateShips2(int shipSize, int[,] map)
        {
            int direction = rand.Next(2);
            int x = rand.Next(1, width - 1);
            int y = rand.Next(1, height);
            Boolean valid = true;


            switch (direction)
            {
                case 0:
                    for (int i = 0; i < shipSize; i++)
                    {
                        if ((x + i) < 23)
                        {
                            if (map[x + i, y] == 1)
                            {
                                valid = false;
                                break;
                            }
                        }
                        else
                        {
                            valid = false;
                        }
                    }
                    break;

                case 1:
                    for (int i = 0; i < shipSize; i++)
                    {
                        if ((y + i) < 24)
                        {
                            if (map[x, y + i] == 1)
                            {
                                valid = false;
                                break;
                            }
                        }
                        else
                        {
                            valid = false;
                        }
                    }
                    break;
                default:
                    break;
            }


            if (valid)
            {
                if (direction == 0)
                {
                    ships++;
                    for (int i = 0; i < shipSize; i++)
                        map[x + i, y] = 1;
                    shipsList2[shipCountP2++] = new Ship(x, y, 20 * shipSize, 20, true);
                }
                else
                {
                    ships++;
                    for (int i = 0; i < shipSize; i++)
                        map[x, y + i] = 1;
                    shipsList2[shipCountP2++] = new Ship(x, y, 20, 20 * shipSize, false);
                }
            }
            else
            {
                map = generateShips2(shipSize, map);

            }

            return map;

        }

        void drawMap(int[,] mapData)
        {
            for (int x = 0; x < mapData.GetLength(0); x++)
            {
                for (int y = 0; y < mapData.GetLength(1); y++)
                    Console.Write($"{mapData[x, y]}");
                Console.WriteLine();
            }
        }

        public void generateGame()
        {
            if (!resumeGame)
            {
                if (customShips)
                {
                    board1 = generateCustomShips(board1);

                    board2 = generateShips2(5, board2);
                    for (int i = 0; i < 2; i++)
                    {
                        board2 = generateShips2(4, board2);
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        board2 = generateShips2(3, board2);
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        board2 = generateShips2(2, board2);
                    }


                }
                else
                {
                    board1 = generateShips1(5, board1);
                    board2 = generateShips2(5, board2);
                    for (int i = 0; i < 2; i++)
                    {
                        board1 = generateShips1(4, board1);
                        board2 = generateShips2(4, board2);
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        board1 = generateShips1(3, board1);
                        board2 = generateShips2(3, board2);
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        board1 = generateShips1(2, board1);
                        board2 = generateShips2(2, board2);
                    }




                }
            }


            drawMap(board1);
            drawMap(board2);
        }



        public Engine()
        {


            if (!resumeGame)
            {
                board1 = generateMap();
                board2 = generateMap();

            }
        }

        public Boolean checkForWin(int[,] mapData)
        {
            for (int x = 0; x < mapData.GetLength(0); x++)
            {
                for (int y = 0; y < mapData.GetLength(1); y++)
                {
                    if (mapData[x, y] == 1) { return false; }

                }
            }
            return true;
        }



        public void Update()
        {
            if ((!checkForWin(board1)) && (!checkForWin(board2)))
            {
                drawMap(board1);
                drawMap(board2);
            }

        }

        public void ComputerPlays()
        {
            if (goodGuessX.Count > 0 && goodGuessY.Count > 0)
            {
                ComputerGuessX = goodGuessX.Pop();
                ComputerGuessY = goodGuessY.Pop();
            }
            else
            {
                ComputerGuessX = rand.Next(width);
                ComputerGuessY = rand.Next(height);
            }

        }

        public void GenerateGuess(int x, int y)
        {
            if (x + 1 < 24)
            {
                goodGuessX.Push(x + 1);
                goodGuessY.Push(y);
            }
            if (x - 1 > 0)
            {
                goodGuessX.Push(x - 1);
                goodGuessY.Push(y);
            }
            if (y + 1 < 25)
            {
                goodGuessX.Push(x);
                goodGuessY.Push(y + 1);
            }
            if (y - 1 > 0)
            {
                goodGuessX.Push(x);
                goodGuessY.Push(y - 1);
            }

        }


        public int[,] winMessage(int[,] board)
        {
            board = generateMap();
            for (int i = 9; i < 14; i++)
            {
                board[1, i] = (int)Status.Hit;
                board[5, i] = (int)Status.Hit;
                board[7, i] = (int)Status.Hit;
            }
            for (int i = 10; i < 14; i++)
            {
                board[9, i] = (int)Status.Hit;
                board[11, i] = (int)Status.Hit;
                board[13, i] = (int)Status.Hit;
                board[15, i] = (int)Status.Hit;
                board[17, i] = (int)Status.Hit;
                board[21, i] = (int)Status.Hit;

            }
            board[2, 13] = (int)Status.Hit;
            board[3, 12] = (int)Status.Hit;
            board[4, 13] = (int)Status.Hit;
            board[10, 9] = (int)Status.Hit;
            board[14, 9] = (int)Status.Hit;
            board[18, 9] = (int)Status.Hit;
            board[19, 10] = (int)Status.Hit;
            board[19, 11] = (int)Status.Hit;
            board[18, 11] = (int)Status.Hit;
            board[18, 13] = (int)Status.Hit;
            board[19, 13] = (int)Status.Hit;
            board[22, 9] = (int)Status.Hit;
            board[23, 9] = (int)Status.Hit;

            return board;
        }

        public int[,] loseMessage(int[,] board)
        {
            board = generateMap();
            for (int i = 9; i < 14; i++)
            {
                board[1, i] = (int)Status.Hit;
            }
            for (int i = 10; i < 14; i++)
            {
                board[16, i] = (int)Status.Hit;
                board[21, i] = (int)Status.Hit;
            }

            for (int i = 10; i < 13; i++)
            {
                board[6, i] = (int)Status.Hit;
                board[8, i] = (int)Status.Hit;
            }
            board[2, 13] = (int)Status.Hit;
            board[3, 13] = (int)Status.Hit;
            board[7, 9] = (int)Status.Hit;
            board[7, 13] = (int)Status.Hit;
            board[11, 9] = (int)Status.Hit;
            board[11, 10] = (int)Status.Hit;
            board[11, 11] = (int)Status.Hit;
            board[11, 13] = (int)Status.Hit;
            board[12, 9] = (int)Status.Hit;
            board[12, 11] = (int)Status.Hit;
            board[12, 13] = (int)Status.Hit;
            board[13, 9] = (int)Status.Hit;
            board[13, 11] = (int)Status.Hit;
            board[13, 12] = (int)Status.Hit;
            board[13, 13] = (int)Status.Hit;
            board[17, 9] = (int)Status.Hit;
            board[17, 11] = (int)Status.Hit;
            board[17, 13] = (int)Status.Hit;
            board[18, 10] = (int)Status.Hit;
            board[18, 11] = (int)Status.Hit;
            board[18, 13] = (int)Status.Hit;
            board[22, 9] = (int)Status.Hit;
            board[23, 9] = (int)Status.Hit;

            return board;
        }

        public string getboardString(int[,] board)
        {
            String finalString = "";
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    finalString += board[i, j];
                }
            }
            return finalString;
        }

        public void getGuessString()
        {
            int guessCount = goodGuessX.Count;
            for (int i=0; i<guessCount; i++)
            {
                GuessX += goodGuessX.Pop() + " ";
                GuessY += goodGuessY.Pop() + " ";
            }
        
        }
        public void getListString()
        {
            for (int i = 0; i < shipsList1.Length; i++)
            {
                P1ShipTop += shipsList1[i].shipLocationTop + " ";
                P1ShipLeft += shipsList1[i].shipLocationLeft + " ";
                P1ShipWidth += shipsList1[i].shipWidth + " ";
                P1ShipHeight += shipsList1[i].shipHeight + " ";
                if (shipsList1[i].orientation)
                {
                    P1ShipOr += 1 + " ";
                }
                else
                {
                    P1ShipOr += 0 + " ";
                }
            }

            for (int i = 0; i < shipsList2.Length; i++)
            {
                P2ShipTop += shipsList2[i].shipLocationTop + " ";
                P2ShipLeft += shipsList2[i].shipLocationLeft + " ";
                P2ShipWidth += shipsList2[i].shipWidth + " ";
                P2ShipHeight += shipsList2[i].shipHeight + " ";
                if (shipsList2[i].orientation)
                {
                    P2ShipOr += 1 + " ";
                }
                else
                {
                    P2ShipOr += 0 + " ";
                }
            }


        }
        public void sendData(string name, int score)
        {

        }


    }

}
