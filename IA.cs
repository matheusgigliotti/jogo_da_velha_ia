            //0x01 = X
            //0x02 = O

            char[] g_ = { 'O', 'X', '-' };
            string _backup = String.Empty;
            int gameData = 0; // 0 = O , 1 = X
            int gamePointer = 00; // PonteiroXPosição
            byte[,] TableGame = { 
                //Exemplo:  {0x01,0,0x01} (X,null,X)  
                { 2,2,2 },{ 2,2,2 },{ 2,2,2 } //Tabuleiro
            };
            //Update table
            string up_table = String.Empty;

            void update_graphics()
            {
                //u_table update values
                up_table =
                    $";1;[ {TableGame[0, 0]} {TableGame[0, 1]} {TableGame[0, 2]} ] " +
                    $";2;[ {TableGame[1, 0]} {TableGame[1, 1]} {TableGame[1, 2]} ] " +
                    $";3;[ {TableGame[2, 0]} {TableGame[2, 1]} {TableGame[2, 2]} ]";

                Console.WriteLine(up_table + "\n");


                Console.WriteLine(
                    $"Turn: {g_[gameData]}"
                    ); ;
                //Headers
                Console.WriteLine
                    ($"|{g_[TableGame[0, 0]]}|{g_[TableGame[1, 0]]}|{g_[TableGame[2, 0]]}| "
                    );
                //Body
                Console.WriteLine(
                    $"|{g_[TableGame[0, 1]]}|{g_[TableGame[1, 1]]}|{g_[TableGame[2, 1]]}| "
                    );
                //Footer
                Console.WriteLine(
                    $"|{g_[TableGame[0, 2]]}|{g_[TableGame[1, 2]]}|{g_[TableGame[2, 2]]}| "
                    );
            }

            void IA_Play()
            {

                if (gameData == 0)
                {
                    //Updates and Others.
                    {
                        update_graphics();
                    }
                    //
                    {
                        string robot_read_table = up_table;
                        string[] tables_sp = up_table.Split(' ');

                        int[] robot_view = new int[9];
                        int pointer = 0;

                        for (int i = 0; i < tables_sp.Length; i++)
                        {
                            //Ideia do brainfuck []
                            if (i < 4 && i > 0)
                            {
                                robot_view[pointer] = int.Parse(tables_sp[i]);
                                pointer += 1;
                            }
                            if (i > 5 && i < 9)
                            {
                                robot_view[pointer] = int.Parse(tables_sp[i]);
                                pointer += 1;
                            }
                            if (i > 10 && i < 14)
                            {
                                robot_view[pointer] = int.Parse(tables_sp[i]);
                                pointer += 1;
                            }
                        }

                        int xT = 0;

                        for (int i = 0; i < robot_view.Length; i++)
                        {
                            if (xT == 0)
                            {
                                if (robot_view[i] == 2)
                                {
                                    string x = String.Empty;
                                    for (int c = 0; c < 3; c++){
                                        if(TableGame[0, c] == 2)
                                        {
                                            x = $"0 {c}";
                                        }
                                        if (TableGame[1, c] == 2)
                                        {
                                            x = $"1 {c}";
                                        }
                                        if (TableGame[2, c] == 2)
                                        {
                                            x = $"2 {c}";
                                        }
                                    }
                                    string[] a = x.Split(' ');

                                        TableGame[int.Parse(a[0]), int.Parse(a[1])] = (byte)gameData;
                                    xT = 1;
                                }
                            }
                        }
                    }
                    //
                }
            }

            IA_Play();
