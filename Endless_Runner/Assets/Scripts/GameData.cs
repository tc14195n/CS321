public static class GameData
{
    static bool gameover;
    static int player_z;
    public static bool setGameOver(bool new_state)
    {
        gameover = new_state;
        return gameover;
    }
    public static bool gameOver()
    {
        return gameover;
    }
    public static void setPlayerZ(int z)
    {
        player_z = z;
    }
    public static int getPlayerZ()
    {
        return player_z;
    }
}
