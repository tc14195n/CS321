public static class GameData
{
    static bool gameover;
    public static bool setGameOver(bool new_state)
    {
        gameover = new_state;
        return gameover;
    }
}
